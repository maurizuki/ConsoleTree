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

using ConsoleTree;
using ConsoleTree.Demo;
using ConsoleTree.Patterns;

var taxonomy = new TaxonomicRank
{
	Category = TaxonomicRankCategory.Family,
	Name = "Felidae",
	Members =
	[
		new TaxonomicRank
		{
			Category = TaxonomicRankCategory.Subfamily,
			Name = "Felinae",
			Members =
			[
				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Acinonyx",
					Members =
					[
						new TaxonomicRank { Name = "Acinonyx jubatus" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Caracal",
					Members =
					[
						new TaxonomicRank { Name = "Caracal aurata" },
						new TaxonomicRank { Name = "Caracal caracal" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Catopuma",
					Members =
					[
						new TaxonomicRank { Name = "Catopuma badia" },
						new TaxonomicRank { Name = "Catopuma temminckii" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Felis",
					Members =
					[
						new TaxonomicRank { Name = "Felis bieti" },
						new TaxonomicRank { Name = "Felis chaus" },
						new TaxonomicRank { Name = "Felis margarita" },
						new TaxonomicRank { Name = "Felis manul" },
						new TaxonomicRank { Name = "Felis nigripes" },
						new TaxonomicRank
						{
							Name = "Felis silvestris",
							Members =
							[
								new TaxonomicRank
								{
									Category = TaxonomicRankCategory.Subspecies,
									Name = "Felis silvestris catus",
								},
							],
						},
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Herpailurus",
					Members =
					[
						new TaxonomicRank { Name = "Herpailurus yagouaroundi" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Leopardus",
					Members =
					[
						new TaxonomicRank { Name = "Leopardus colocolo" },
						new TaxonomicRank { Name = "Leopardus geoffroyi" },
						new TaxonomicRank { Name = "Leopardus guigna" },
						new TaxonomicRank { Name = "Leopardus jacobitus" },
						new TaxonomicRank { Name = "Leopardus pajeros" },
						new TaxonomicRank { Name = "Leopardus pardalis" },
						new TaxonomicRank { Name = "Leopardus tigrinus" },
						new TaxonomicRank { Name = "Leopardus wiedii" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Leptailurus",
					Members =
					[
						new TaxonomicRank { Name = "Leptailurus serval" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Lynx",
					Members =
					[
						new TaxonomicRank { Name = "Lynx lynx" },
						new TaxonomicRank { Name = "Lynx pardinus" },
						new TaxonomicRank { Name = "Lynx rufus" },
						new TaxonomicRank { Name = "Lynx canadensis" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Pardofelis",
					Members =
					[
						new TaxonomicRank { Name = "Pardofelis marmorata" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Prionailurus",
					Members =
					[
						new TaxonomicRank { Name = "Prionailurus bengalensis" },
						new TaxonomicRank { Name = "Prionailurus iriomotensis" },
						new TaxonomicRank { Name = "Prionailurus planiceps" },
						new TaxonomicRank { Name = "Prionailurus rubiginosus" },
						new TaxonomicRank { Name = "Prionailurus viverrinus" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Puma",
					Members =
					[
						new TaxonomicRank { Name = "Puma concolor" },
					],
				},
			],
		},

		new TaxonomicRank
		{
			Category = TaxonomicRankCategory.Subfamily,
			Name = "Pantherinae",
			Members =
			[
				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Neofelis",
					Members =
					[
						new TaxonomicRank { Name = "Neofelis diardi" },
						new TaxonomicRank { Name = "Neofelis nebulosa" },
					],
				},

				new TaxonomicRank
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Panthera",
					Members =
					[
						new TaxonomicRank { Name = "Panthera leo" },
						new TaxonomicRank { Name = "Panthera onca" },
						new TaxonomicRank { Name = "Panthera pardus" },
						new TaxonomicRank { Name = "Panthera tigris" },
						new TaxonomicRank { Name = "Panthera uncia" },
					],
				},
			],
		},
	],
};

var bookshelf = new Bookshelf
{
	new BookSeries
	{
		Name = "The Hitchhiker's Guide to the Galaxy",
		Author = "Douglas Adams",
		Books =
		[
			new Book
			{
				Title = "Life, the Universe and Everything",
				Published = 1982,
			},
			new Book
			{
				Title = "Mostly Harmless",
				Published = 1992,
			},
			new Book
			{
				Title = "So Long, and Thanks for All the Fish",
				Published = 1984,
			},
			new Book
			{
				Title = "The Hitchhiker's Guide to the Galaxy",
				Published = 1979,
			},
			new Book
			{
				Title = "The Restaurant at the End of the Universe",
				Published = 1980,
			},
		],
	},
	new BookSeries
	{
		Name = "Dune",
		Author = "Frank Herbert",
		Books =
		[
			new Book
			{
				Title = "Chapterhouse: Dune",
				Published = 1985,
			},
			new Book
			{
				Title = "Children of Dune",
				Published = 1976,
			},
			new Book
			{
				Title = "Dune",
				Published = 1965,
			},
			new Book
			{
				Title = "Dune Messiah",
				Published = 1969,
			},
			new Book
			{
				Title = "God Emperor of Dune",
				Published = 1981,
			},
			new Book
			{
				Title = "Heretics of Dune",
				Published = 1984,
			},
		],
	},
	new BookSeries
	{
		Name = "The Lord of the Rings",
		Author = "J. R. R. Tolkien",
		Books =
		[
			new Book
			{
				Title = "The Fellowship of the Ring",
				Published = 1954,
			},
			new Book
			{
				Title = "The Return of the King",
				Published = 1955,
			},
			new Book
			{
				Title = "The Two Towers",
				Published = 1954,
			},
		],
	},
};

var tree = new Tree(new DisplaySettings { IndentSize = 5 })
	.EnumNodes<Bookshelf, BookSeries>((node, _) => node.OrderBy(series => series.Name))
	.WriteNode<BookSeries>((node, _) => Console.Write($"{node.Name} by {node.Author}"))
	.EnumNodes<BookSeries, Book>((node, _) => node.Books.OrderBy(book => book.Published))
	.WriteNode<Book>((node, _) => Console.Write($"{node.Title} ({node.Published})"));

if (args.Length == 1)
{
	if ("basics".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		Tree.Write(taxonomy);
		return;
	}

	if ("levels".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		Tree.Write(taxonomy, new DisplaySettings {MaxLevels = 3, IndentSize = 2});
		return;
	}

	if ("indent".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		Tree.Write(taxonomy, new DisplaySettings {IndentSize = 5});
		return;
	}

	if ("double".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		Tree.Write(
			taxonomy,
			new DisplaySettings
			{
				IndentSize = 2,
				ConnectorPatterns = new DoubleConnectorPatterns(),
			}
		);
		return;
	}

	if ("colors".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		Tree.Write(
			taxonomy,
			new DisplaySettings
			{
				IndentSize = 2,
				NodeColors = new ConsoleColors
				{
					BackgroundColor = ConsoleColor.Yellow,
					ForegroundColor = ConsoleColor.Red,
				},
				ConnectorColors = new ConsoleColors {ForegroundColor = ConsoleColor.Cyan},
			}
		);
		return;
	}

	if ("custom".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		Tree.Write(
			taxonomy,
			(node, _) =>
			{
				Console.ForegroundColor = node.Category switch
				{
					TaxonomicRankCategory.Family => ConsoleColor.Magenta,
					TaxonomicRankCategory.Subfamily => ConsoleColor.Blue,
					TaxonomicRankCategory.Genus => ConsoleColor.Red,
					TaxonomicRankCategory.Species => ConsoleColor.Cyan,
					TaxonomicRankCategory.Subspecies => ConsoleColor.Yellow,
					_ => ConsoleColor.Gray,
				};
				Console.Write($"{node.Category}: ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(node.Name);
			},
			(node, _) => node.Members,
			new DisplaySettings
			{
				ConnectorPatterns = new CustomConnectorPatterns(),
			}
		);
		return;
	}

	if ("fluent".Equals(args[0], StringComparison.InvariantCultureIgnoreCase))
	{
		tree.Write(bookshelf);
		return;
	}
}

Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <option>");
Console.WriteLine();
Console.WriteLine("Where <option> is one of:");
Console.WriteLine();
Console.WriteLine("basics ....... Displays the tree with the default settings.");
Console.WriteLine("levels ....... Displays the tree with a maximum of three levels.");
Console.WriteLine("indent ....... Displays the tree with an indent of five characters.");
Console.WriteLine("double ....... Displays the tree with double-line style connectors.");
Console.WriteLine("colors ....... Displays the tree in Technicolor\u00ae.");
Console.WriteLine("custom ....... Displays some of the customization potential.");
Console.WriteLine("fluent ....... Displays a tree with different types of nodes.");
