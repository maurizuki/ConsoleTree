// Copyright (c) 2022-2025 Maurizio Basaglia
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleTree.Patterns;

namespace ConsoleTree;

/// <summary>
///     Provides methods to write a tree structure to the console output stream.
/// </summary>
public sealed class Tree
{
	private static readonly IConnectorPatterns DefaultConnectorPatterns = new SingleConnectorPatterns();

	private static readonly INodeWriter DefaultNodeWriter = new NodeWriter<object>((node, _) => Console.Write(node.ToString()));

	private static readonly INodeEnumerator DefaultNodeEnumerator = new NodeEnumerator<ITreeNode, ITreeNode>((node, _) => node.GetNodes());

	private readonly Dictionary<string, INodeWriter> _nodeWriters = new();

	private readonly Dictionary<string, INodeEnumerator> _nodeEnumerators = new();

	private readonly DisplaySettings _displaySettings;

	private readonly IConnectorPatterns _connectorPatterns;

	/// <summary>
	///     Initializes a new instance of the <c>Tree</c> class.
	/// </summary>
	/// <param name="settings">
	///     The <see cref="DisplaySettings" /> used to write the tree structure to the console output stream.
	/// </param>
	public Tree(DisplaySettings? settings = null)
	{
		_displaySettings = settings ?? new DisplaySettings();
		_connectorPatterns = settings?.ConnectorPatterns ?? DefaultConnectorPatterns;
	}

	/// <summary>
	///     Adds a method to write the text of each node of type <c>T</c> of the tree structure to the console output
	///     stream.
	/// </summary>
	/// <typeparam name="T">The type of the nodes of the tree structure.</typeparam>
	/// <param name="nodeWriter">
	///     A method to write the text of each node of type <c>T</c> of the tree structure to the console output
	///     stream.
	/// </param>
	public Tree WriteNode<T>(Action<T, int> nodeWriter)
	{
		_nodeWriters[typeof(T).FullName] = new NodeWriter<T>(nodeWriter);
		return this;
	}

	/// <summary>
	///     Adds a function to return the subnodes of each node of type <c>T</c> of the tree structure.
	/// </summary>
	/// <typeparam name="T">The type of the nodes of the tree structure.</typeparam>
	/// <typeparam name="TSub">The type of the subnodes of a node of type <c>T</c>.</typeparam>
	/// <param name="nodeEnumerator">
	///     A function to return the subnodes of each node of type <c>T</c> of the tree structure.
	/// </param>
	public Tree EnumNodes<T, TSub>(Func<T, int, IEnumerable<TSub>> nodeEnumerator)
	{
		_nodeEnumerators[typeof(T).FullName] = new NodeEnumerator<T, TSub>(nodeEnumerator);
		return this;
	}

	/// <summary>
	///     Writes a tree structure to the console output stream.
	/// </summary>
	/// <param name="rootNode">The root node of the tree structure.</param>
	public void Write(object rootNode)
	{
		Write(rootNode, string.Empty, 0);
	}

	internal void Write(object node, string indentation, int level, bool isLast)
	{
		var initialColors = ConsoleColors.FromConsole();
		try
		{
			_displaySettings.ConnectorColors?.Apply();
			Console.Write(indentation);
			Console.Write(
				isLast
					? _connectorPatterns.GetUpAndRight(_displaySettings.IndentSize, level)
					: _connectorPatterns.GetVerticalAndRight(_displaySettings.IndentSize, level)
			);
		}
		finally
		{
			initialColors.Apply();
		}

		Write(
			node,
			indentation + (isLast
				? _connectorPatterns.GetBlank(_displaySettings.IndentSize, level)
				: _connectorPatterns.GetVertical(_displaySettings.IndentSize, level)),
			level + 1
		);
	}

	private void Write(object node, string indentation, int level)
	{
		var nodeClassName = node.GetType().FullName;

		if (!_nodeWriters.TryGetValue(nodeClassName, out var nodeWriter))
		{
			nodeWriter = DefaultNodeWriter;
		}

		var initialColors = ConsoleColors.FromConsole();
		try
		{
			_displaySettings.NodeColors?.Apply();
			nodeWriter.Invoke(node, level);
		}
		finally
		{
			initialColors.Apply();
		}

		Console.WriteLine();

		if (_displaySettings.MaxLevels > 0 && level >= _displaySettings.MaxLevels - 1) return;

		if (!_nodeEnumerators.TryGetValue(nodeClassName, out var nodeEnumerator))
		{
			nodeEnumerator = DefaultNodeEnumerator;
		}

		nodeEnumerator.Invoke(this, node, indentation, level);
	}

	/// <summary>
	///     Writes a tree structure to the console output stream.
	/// </summary>
	/// <param name="rootNode">The root node of the tree structure.</param>
	/// <param name="settings">
	///     The <see cref="DisplaySettings" /> used to write the tree structure to the console output stream.
	/// </param>
	[DebuggerStepThrough]
	public static void Write(ITreeNode rootNode, DisplaySettings? settings = null)
	{
		new Tree(settings).Write(rootNode);
	}

	/// <summary>
	///     Writes a tree structure to the console output stream using a custom function to enumerate the subnodes of each
	///     node.
	/// </summary>
	/// <typeparam name="T">The type of the nodes of the tree structure.</typeparam>
	/// <param name="rootNode">The root node of the tree structure.</param>
	/// <param name="nodeEnumerator">
	///     A function to return the subnodes of each node of the tree structure.
	/// </param>
	/// <param name="settings">
	///     The <see cref="DisplaySettings" /> used to write the tree structure to the console output stream.
	/// </param>
	/// <exception cref="ArgumentNullException"><c>rootNode</c> is <c>null</c>.</exception>
	[DebuggerStepThrough]
	public static void Write<T>(
		T rootNode,
		Func<T, int, IEnumerable<T>> nodeEnumerator,
		DisplaySettings? settings = null
	)
	{
		if (rootNode == null) throw new ArgumentNullException(nameof(rootNode));
		new Tree(settings).EnumNodes(nodeEnumerator).Write(rootNode);
	}

	/// <summary>
	///     Writes a tree structure to the console output stream using a custom method to write the text of each node and a
	///     custom function to enumerate the subnodes of each node.
	/// </summary>
	/// <typeparam name="T">The type of the nodes of the tree structure.</typeparam>
	/// <param name="rootNode">The root node of the tree structure.</param>
	/// <param name="nodeWriter">
	///     A method to write the text of each node of the tree structure to the console output stream.
	/// </param>
	/// <param name="nodeEnumerator">
	///     A function to return the subnodes of each node of the tree structure.
	/// </param>
	/// <param name="settings">
	///     The <see cref="DisplaySettings" /> used to write the tree structure to the console output stream.
	/// </param>
	/// <exception cref="ArgumentNullException"><c>rootNode</c> is <c>null</c>.</exception>
	[DebuggerStepThrough]
	public static void Write<T>(
		T rootNode,
		Action<T, int> nodeWriter,
		Func<T, int, IEnumerable<T>> nodeEnumerator,
		DisplaySettings? settings = null
	)
	{
		if (rootNode == null) throw new ArgumentNullException(nameof(rootNode));
		new Tree(settings).WriteNode(nodeWriter).EnumNodes(nodeEnumerator).Write(rootNode);
	}
}
