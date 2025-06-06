# Tree.EnumNodes&lt;T,TSub&gt; method

Adds a function to return the subnodes of each node of type `T` of the tree structure.

```csharp
public Tree EnumNodes<T, TSub>(Func<T, int, IEnumerable<TSub>> nodeEnumerator)
```

| parameter | description |
| --- | --- |
| T | The type of the nodes of the tree structure. |
| TSub | The type of the subnodes of a node of type `T`. |
| nodeEnumerator | A function to return the subnodes of each node of type `T` of the tree structure. |

## See Also

* class [Tree](../Tree.md)
* namespace [ConsoleTree](../../ConsoleTree.md)

<!-- DO NOT EDIT: generated by xmldocmd for ConsoleTree.dll -->
