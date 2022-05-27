// Copyright (c) 2022 Maurizio Basaglia
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
using System.Linq;
using ConsoleTree.Patterns;

namespace ConsoleTree
{
	/// <summary>
	///     Provides methods to write a tree structure to the console output stream.
	/// </summary>
	public static class Tree
	{
		private static readonly IConnectorPatterns DefaultConnectorPatterns = new SingleConnectorPatterns();

		/// <summary>
		///     Writes a tree structure to the console output stream.
		/// </summary>
		/// <param name="rootNode">The root node of the tree structure.</param>
		/// <param name="settings">
		///     The <see cref="DisplaySettings" /> used to write the tree structure to the console output stream.
		/// </param>
		/// <exception cref="ArgumentNullException"><c>rootNode</c> is <c>null</c>.</exception>
		[DebuggerStepThrough]
		public static void Write(ITreeNode rootNode, DisplaySettings settings = null)
		{
			Write(rootNode, (node, _) => Console.Write(node), (node, _) => node.GetNodes(), settings);
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
		/// <exception cref="ArgumentNullException">
		///     <c>rootNode</c> is <c>null</c> or <c>nodeEnumerator</c> is <c>null</c>.
		/// </exception>
		[DebuggerStepThrough]
		public static void Write<T>(
			T rootNode,
			Func<T, int, IEnumerable<T>> nodeEnumerator,
			DisplaySettings settings = null
		)
		{
			Write(rootNode, (node, _) => Console.Write(node), nodeEnumerator, settings);
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
		/// <exception cref="ArgumentNullException">
		///     <c>rootNode</c> is <c>null</c> or <c>nodeTextWriter</c> is <c>null</c> or <c>nodeEnumerator</c> is <c>null</c>.
		/// </exception>
		public static void Write<T>(
			T rootNode,
			Action<T, int> nodeWriter,
			Func<T, int, IEnumerable<T>> nodeEnumerator,
			DisplaySettings settings = null
		)
		{
			if (rootNode == null) throw new ArgumentNullException(nameof(rootNode));
			if (nodeWriter == null) throw new ArgumentNullException(nameof(nodeWriter));
			if (nodeEnumerator == null) throw new ArgumentNullException(nameof(nodeEnumerator));

			Write(
				rootNode,
				nodeWriter,
				nodeEnumerator,
				settings ?? new DisplaySettings(),
				settings?.ConnectorPatterns ?? DefaultConnectorPatterns,
				string.Empty,
				0
			);
		}

		private static void Write<T>(
			T node,
			Action<T, int> nodeWriter,
			Func<T, int, IEnumerable<T>> nodeEnumerator,
			DisplaySettings settings,
			IConnectorPatterns connectorPatterns,
			string indentation,
			int level
		)
		{
			var initialColors = ConsoleColors.FromConsole();

			settings.NodeColors?.Apply();
			nodeWriter(node, level);
			Console.WriteLine();
			initialColors.Apply();

			if (settings.MaxLevels > 0 && level >= settings.MaxLevels - 1) return;

			var nodes = nodeEnumerator(node, level).ToList();

			for (var i = 0; i < nodes.Count - 1; i++)
			{
				settings.ConnectorColors?.Apply();
				Console.Write(indentation);
				Console.Write(connectorPatterns.GetVerticalAndRight(settings.IndentSize, level));
				initialColors.Apply();

				Write(
					nodes[i],
					nodeWriter,
					nodeEnumerator,
					settings,
					connectorPatterns,
					indentation + connectorPatterns.GetVertical(settings.IndentSize, level),
					level + 1
				);
			}

			if (nodes.Any())
			{
				settings.ConnectorColors?.Apply();
				Console.Write(indentation);
				Console.Write(connectorPatterns.GetUpAndRight(settings.IndentSize, level));
				initialColors.Apply();

				Write(
					nodes.Last(),
					nodeWriter,
					nodeEnumerator,
					settings,
					connectorPatterns,
					indentation + connectorPatterns.GetBlank(settings.IndentSize, level),
					level + 1
				);
			}
		}
	}
}
