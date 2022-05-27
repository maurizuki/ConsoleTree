# ConsoleTree

[![language](https://img.shields.io/github/languages/top/maurizuki/ConsoleTree)](https://github.com/maurizuki/ConsoleTree)
[![Nuget](https://img.shields.io/github/workflow/status/maurizuki/ConsoleTree/publish%20to%20nuget)](https://github.com/maurizuki/ConsoleTree/actions)
[![issues](https://img.shields.io/github/issues/maurizuki/ConsoleTree)](https://github.com/maurizuki/ConsoleTree/issues)
[![Nuget](https://img.shields.io/nuget/v/ConsoleTree)](https://www.nuget.org/packages/ConsoleTree)
[![Nuget](https://img.shields.io/nuget/dt/ConsoleTree)](https://www.nuget.org/packages/ConsoleTree)

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
class TreeNode : ITreeNode
{
	public string Text { get; set; }
	public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();

	public IEnumerable<ITreeNode> GetNodes()
	{
		return Nodes;
	}

	public override string ToString()
	{
		return Text;
	}
}

var tree = new TreeNode
{
	Text = "a",
	Nodes = new List<TreeNode>
	{
		new TreeNode { Text = "b"},
		new TreeNode { Text = "c"}
	}
};

Tree.Write(tree, new DisplaySettings { IndentSize = 2 });

// Output:
//
// a
// ├──b
// └──c
```

If it is not possible or not desired to implement the `ITreeNode` interface, then use the `Tree.Write<T>` method overloads.

```csharp
sealed class TreeNode
{
	public string Text { get; set; }
	public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
}

var tree = new TreeNode
{
	Text = "a",
	Nodes = new List<TreeNode>
	{
		new TreeNode { Text = "b"},
		new TreeNode { Text = "c"}
	}
};

Tree.Write(tree, (node, level) => Console.Write(node.Text), (node, level) => node.Nodes, new DisplaySettings { IndentSize = 2 });

// Output:
//
// a
// ├──b
// └──c
```

## Resources

See the [API reference](.\docs\ConsoleTree.md) and the [ConsoleTree.Demo](.\src\ConsoleTree.Demo) application to learn how to customize indentation, maximum depth, type of connectors and colors.
