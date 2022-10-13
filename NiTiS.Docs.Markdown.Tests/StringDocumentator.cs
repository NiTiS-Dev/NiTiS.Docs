using System;

namespace NiTiS.Docs.Markdown.Tests;

public class StringDocumentator : ITypeDocumentator<MarkdownDocumentation>
{
	public MarkdownDocumentation Documentate(object obj)
	{
		string str = (obj as string)!;

		MarkdownBuilder mb = new();

		mb
			.PlaceHeader()
			.PlainText(str)
			.NewLine()


			;

		return mb.Build(str + ".md");
	}
	public bool IsValidType(Type type)
		=> type == typeof(string);
}
