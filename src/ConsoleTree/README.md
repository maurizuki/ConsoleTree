# ConsoleTree

A tool to write a tree structure to the console standard output stream, with colors support and a lot of customization options.

## Getting started

To add ConsoleTree to your project, you can use the following NuGet Package Manager command:

```PowerShell
Install-Package ConsoleTree
```

More options are available on the [ConsoleTree page](https://www.nuget.org/packages/ConsoleTree) of the NuGet Gallery website.

## Usage

Implement the `ITreeNode` interface to obtain the node of a tree structure. Optionally override the `ToString` method to provide a custom text for the node. To write a tree structure to the console standard output stream, call the `Tree.Write` method specifying its root node as parameter.

```csharp
class TaxonomicRank : ITreeNode
{
	public string Name { get; set; }

	public List<TaxonomicRank> Members { get; set; }

	public IEnumerable<ITreeNode> GetNodes() => Members;

	public override string ToString() => Name;
}

var taxonomy = new TaxonomicRank
{
	Name = "Felidae",
	Members =
	[
		new TaxonomicRank { Name = "Felinae" },
		new TaxonomicRank { Name = "Pantherinae" }
	]
};

Tree.Write(taxonomy, new DisplaySettings { IndentSize = 2 });

// Output:
//
// Felidae
// ├──Felinae
// └──Pantherinae
```

If it is not possible or not desired to implement the `ITreeNode` interface, then use the `Tree.Write<T>` method overloads.

```csharp
class TaxonomicRank
{
	public string Name { get; set; }

	public List<TaxonomicRank> Members { get; set; }
}

var taxonomy = new TaxonomicRank
{
	Name = "Felidae",
	Members =
	[
		new TaxonomicRank { Name = "Felinae" },
		new TaxonomicRank { Name = "Pantherinae" }
	]
};

Tree.Write(taxonomy, (node, _) => Console.Write(node.Name), (node, _) => node.Members, new DisplaySettings { IndentSize = 2 });

// Output:
//
// Felidae
// ├──Felinae
// └──Pantherinae
```
If there are multiple types of nodes in the tree structure, then use the fluent interface methods.

```csharp
class Family
{
	public string Name { get; set; }

	public List<Subfamily> Members { get; set; }
}

class Subfamily
{
	public string Name { get; set; }
}

var taxonomy = new Family
{
	Name = "Felidae",
	Members =
	[
		new Subfamily { Name = "Felinae" },
		new Subfamily { Name = "Pantherinae" }
	]
};

new Tree(new DisplaySettings { IndentSize = 2 })
	.WriteNode<Family>((node, _) => Console.Write(node.Name))
	.EnumNodes<Family, Subfamily>((node, _) => node.Members)
	.WriteNode<Subfamily>((node, _) => Console.Write(node.Name))
	.Write(taxonomy);

// Output:
//
// Felidae
// ├──Felinae
// └──Pantherinae
```

## Resources

See the [API reference](https://github.com/maurizuki/ConsoleTree/blob/v2.0.0/docs/ConsoleTree.md) and the [ConsoleTree.Demo](https://github.com/maurizuki/ConsoleTree/tree/v2.0.0/src/ConsoleTree.Demo) application to learn how to customize indentation, maximum depth, type of connectors and colors.
