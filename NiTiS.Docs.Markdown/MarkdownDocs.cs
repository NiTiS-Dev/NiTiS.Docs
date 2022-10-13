using NiTiS.IO;
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

			ITypeDocumentator<MarkdownDocumentation>? doc = documentators.Where(t => t.IsValidType(obj.GetType())).FirstOrDefault();

			if (doc is null)
				continue;

			documentations.Add(doc.Documentate(obj));
		}
	}
	public override void Deploy()
	{
		foreach (MarkdownDocumentation doc in documentations)
		{
			using System.IO.FileStream fs = new File(doc.Path).CreateOpen();
			using System.IO.StreamWriter sw = new(fs);


			sw.Write(doc.Content);
		}
	}
}
