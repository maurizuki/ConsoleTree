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

namespace ConsoleTree
{
	/// <summary>
	///     Provides a convenient way to store the settings of both foreground and background colors of the console.
	/// </summary>
	public sealed class ConsoleColors
	{
		/// <summary>
		///     Gets or sets the setting value for the foreground color of the console.
		/// </summary>
		public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.Gray;

		/// <summary>
		///     Gets or sets the setting value for the background color of the console.
		/// </summary>
		public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

		/// <summary>
		///     Creates a new instance of the <c>ConsoleColors</c> class with the current color settings of the console.
		/// </summary>
		/// <returns>A new instance of the <c>ConsoleColors</c> class</returns>
		public static ConsoleColors FromConsole()
		{
			return new ConsoleColors
			{
				ForegroundColor = Console.ForegroundColor,
				BackgroundColor = Console.BackgroundColor,
			};
		}

		/// <summary>
		///     Applies the color settings to the console.
		/// </summary>
		public void Apply()
		{
			Console.ForegroundColor = ForegroundColor;
			Console.BackgroundColor = BackgroundColor;
		}
	}
}
