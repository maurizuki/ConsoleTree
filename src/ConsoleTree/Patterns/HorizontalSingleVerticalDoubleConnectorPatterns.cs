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

namespace ConsoleTree.Patterns;

/// <summary>
///     <see cref="IConnectorPatterns" /> implementation to write horizontal single-line connectors and vertical
///     double-line connectors.
/// </summary>
public sealed class HorizontalSingleVerticalDoubleConnectorPatterns : IConnectorPatterns
{
	/// <summary>
	///     Returns the characters pattern to represent a blank space.
	/// </summary>
	/// <param name="indent">The amount of characters by which the level of the tree structure must be indented.</param>
	/// <param name="level">The level of the tree structure being written.</param>
	/// <returns>The characters pattern.</returns>
	public string GetBlank(byte indent, int level)
	{
		return new string(' ', indent + 1);
	}

	/// <summary>
	///     Returns the characters pattern to represent a vertical line.
	/// </summary>
	/// <param name="indent">The amount of characters by which the level of the tree structure must be indented.</param>
	/// <param name="level">The level of the tree structure being written.</param>
	/// <returns>The characters pattern.</returns>
	public string GetVertical(byte indent, int level)
	{
		return "║" + new string(' ', indent);
	}

	/// <summary>
	///     Returns the characters pattern to represent a vertical line with a right connection.
	/// </summary>
	/// <param name="indent">The amount of characters by which the level of the tree structure must be indented.</param>
	/// <param name="level">The level of the tree structure being written.</param>
	/// <returns>The characters pattern.</returns>
	public string GetVerticalAndRight(byte indent, int level)
	{
		return "╟" + new string('─', indent);
	}

	/// <summary>
	///     Returns the characters pattern to represent a connection from upside to right.
	/// </summary>
	/// <param name="indent">The amount of characters by which the level of the tree structure must be indented.</param>
	/// <param name="level">The level of the tree structure being written.</param>
	/// <returns>The characters pattern.</returns>
	public string GetUpAndRight(byte indent, int level)
	{
		return "╙" + new string('─', indent);
	}
}
