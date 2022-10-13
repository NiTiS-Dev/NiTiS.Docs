using System;

namespace NiTiS.Docs.Markdown.Tests;
public class ItemDocumentator : ITypeDocumentator<MarkdownDocumentation>
{
	public MarkdownDocumentation Documentate(object obj)
	{
		Item item = (obj as Item)!;

		MarkdownBuilder mb = new();

		mb
			.PlaceHeader()
			.PlainText(item.Name)
			.NewLine()
			;

		Item? parent = item.Parent;
		if (parent is null)
			goto RET;
		else
		{
			mb.Link(item.Name, "/" + item.Name);
			goto DEP;
		}

	DEP:
		mb.PlainText(" → ");
		mb.Link(parent.Name, "/" + parent.Name);
		parent = parent.Parent;
		if (parent is not null)
			goto DEP;

	RET:
		return mb.Build(item.Name + ".md");
	}
	public bool IsValidType(Type type)
		=> type == typeof(Item);
}
