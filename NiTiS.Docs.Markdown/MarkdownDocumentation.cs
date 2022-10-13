namespace NiTiS.Docs.Markdown;

public class MarkdownDocumentation : IDocumentationType
{
	public readonly string Content;
	public string Path { get; }
	public MarkdownDocumentation(string path, string content)
	{
		Path = path;
		Content = content;
	}
}
