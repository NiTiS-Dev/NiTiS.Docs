using NiTiS.IO;
using System.Collections.Generic;
using System.Linq;

namespace NiTiS.Docs.Markdown;

public class MarkdownDocs : Docs<MarkdownDocumentation>
{
	public MarkdownDocs(Directory directory) : base(directory)
	{

	}
	public override void Document(params object[] objs)
	{
		foreach (object obj in objs)
		{
			if (obj is null)
				continue;

			ITypeDocumentator<MarkdownDocumentation>? doc = TypeDocumentators.Values.Where(t => t.IsValidType(obj.GetType())).FirstOrDefault();

			if (doc is null)
				continue;

			doc.Documentate(this, obj);
		}
	}
	public override void Deploy()
	{
		foreach (MarkdownDocumentation doc in documentations)
		{
			File file = new File(doc.Path);
			file.Parent?.Create();
			file.Create();
			using System.IO.FileStream fs = file.CreateOpen();
			using System.IO.StreamWriter sw = new(fs);


			sw.Write(doc.Content);
		}
	}
}
