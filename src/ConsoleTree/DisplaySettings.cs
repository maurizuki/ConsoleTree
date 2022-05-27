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

namespace ConsoleTree
{
	/// <summary>
	///     Specifies the settings to use to write a tree structure to the console output stream.
	/// </summary>
	public sealed class DisplaySettings
	{
		/// <summary>
		///     Gets or sets the maximum number of levels of the tree structure to write. A value less than or equal to zero
		///     indicates no limitation.
		/// </summary>
		public int MaxLevels { get; set; }

		/// <summary>
		///     Gets or sets the amount of characters by which each level in the tree structure is indented.
		/// </summary>
		public byte IndentSize { get; set; }

		/// <summary>
		///     Gets or sets the <see cref="ConsoleColors" /> that specifies the color settings of the console used to write the
		///     text of each node of the tree structure. The current console colors are used if it is not assigned.
		/// </summary>
		public ConsoleColors NodeColors { get; set; }

		/// <summary>
		///     Gets or sets the <see cref="ConsoleColors" /> that specifies the color settings of the console used to write the
		///     lines that connect the nodes of the tree structure. The current console colors are used if it is not assigned.
		/// </summary>
		public ConsoleColors ConnectorColors { get; set; }

		/// <summary>
		///     Gets or sets an implementation of <see cref="IConnectorPatterns" /> used to write the lines that connect the
		///     nodes of the tree structure. <see cref="Patterns.SingleConnectorPatterns" /> is used if it is not assigned.
		/// </summary>
		public IConnectorPatterns ConnectorPatterns { get; set; }
	}
}
