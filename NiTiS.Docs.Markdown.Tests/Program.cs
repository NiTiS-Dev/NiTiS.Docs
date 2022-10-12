using NiTiS.IO;

namespace NiTiS.Docs.Markdown.Tests;

public class Program
{
	private static void Main(string[] args)
	{
		MarkdownDocs docs = new(new Directory("./docs/"));



		docs.Documentate();

		docs.Build();
	}
}