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
using System.Linq;

namespace ConsoleTree;

internal interface INodeEnumerator
{
	void Invoke(Tree tree, object node, string indentation, int level);
}

internal sealed class NodeEnumerator<T, TSub>(Func<T, int, IEnumerable<TSub>> nodeEnumerator) : INodeEnumerator
{
	public void Invoke(Tree tree, object node, string indentation, int level)
	{
		if (node is not T treeNode) return;

		var nodes = nodeEnumerator.Invoke(treeNode, level).ToList();

		if (nodes.Count == 0) return;

		for (var i = 0; i < nodes.Count - 1; i++)
		{
			tree.Write(nodes[i]!, indentation, level, false);
		}

		tree.Write(nodes.Last()!, indentation, level, true);
	}
}
