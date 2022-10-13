using NiTiS.IO;

namespace NiTiS.Docs.Markdown.Tests;

internal static class Program
{
	private static void Main(string[] args)
	{
		MarkdownDocs docs = new(new Directory("./docs/"));
		docs.TypeDocumentator<StringDocumentator>();
		docs.TypeDocumentator<ItemDocumentator>();

		docs.Document("abobus", "deoxy");
		docs.Document(Items.A, Items.B, Items.C);
		docs.Deploy();
	}
}