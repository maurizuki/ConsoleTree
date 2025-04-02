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
	Members = new List<TaxonomicRank>
	{
		new()
		{
			Category = TaxonomicRankCategory.Subfamily,
			Name = "Felinae",
			Members = new List<TaxonomicRank>
			{
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Acinonyx",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Acinonyx jubatus"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Caracal",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Caracal aurata"},
						new() {Name = "Caracal caracal"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Catopuma",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Catopuma badia"},
						new() {Name = "Catopuma temminckii"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Felis",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Felis bieti"},
						new() {Name = "Felis chaus"},
						new() {Name = "Felis margarita"},
						new() {Name = "Felis manul"},
						new() {Name = "Felis nigripes"},
						new()
						{
							Name = "Felis silvestris",
							Members = new List<TaxonomicRank>
							{
								new()
								{
									Category = TaxonomicRankCategory.Subspecies,
									Name = "Felis silvestris catus",
								},
							},
						},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Herpailurus",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Herpailurus yagouaroundi"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Leopardus",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Leopardus colocolo"},
						new() {Name = "Leopardus geoffroyi"},
						new() {Name = "Leopardus guigna"},
						new() {Name = "Leopardus jacobitus"},
						new() {Name = "Leopardus pajeros"},
						new() {Name = "Leopardus pardalis"},
						new() {Name = "Leopardus tigrinus"},
						new() {Name = "Leopardus wiedii"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Leptailurus",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Leptailurus serval"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Lynx",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Lynx lynx"},
						new() {Name = "Lynx pardinus"},
						new() {Name = "Lynx rufus"},
						new() {Name = "Lynx canadensis"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Pardofelis",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Pardofelis marmorata"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Prionailurus",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Prionailurus bengalensis"},
						new() {Name = "Prionailurus iriomotensis"},
						new() {Name = "Prionailurus planiceps"},
						new() {Name = "Prionailurus rubiginosus"},
						new() {Name = "Prionailurus viverrinus"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Puma",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Puma concolor"},
					},
				},
			},
		},
		new()
		{
			Category = TaxonomicRankCategory.Subfamily,
			Name = "Pantherinae",
			Members = new List<TaxonomicRank>
			{
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Neofelis",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Neofelis diardi"},
						new() {Name = "Neofelis nebulosa"},
					},
				},
				new()
				{
					Category = TaxonomicRankCategory.Genus,
					Name = "Panthera",
					Members = new List<TaxonomicRank>
					{
						new() {Name = "Panthera leo"},
						new() {Name = "Panthera onca"},
						new() {Name = "Panthera pardus"},
						new() {Name = "Panthera tigris"},
						new() {Name = "Panthera uncia"},
					},
				},
			},
		},
	},
};

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
}

Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <option>");
Console.WriteLine();
Console.WriteLine("Where <option> is one of:");
Console.WriteLine();
Console.WriteLine("basics         Displays the tree with the default settings.");
Console.WriteLine("levels         Displays the tree with a maximum of three levels.");
Console.WriteLine("indent         Displays the tree with an indent of five characters.");
Console.WriteLine("double         Displays the tree with double-line style connectors.");
Console.WriteLine("colors         Displays the tree in Technicolor.");
Console.WriteLine("custom         Displays some of the customization potential.");
