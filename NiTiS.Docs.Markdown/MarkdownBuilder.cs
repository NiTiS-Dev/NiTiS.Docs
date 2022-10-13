using System;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NiTiS.Docs.Markdown;

public sealed class MarkdownBuilder
{
	private const string MdNewLn = "  \n";
	private StringBuilder sb = new();
	public MarkdownBuilder WriteRaw(string rawContent)
	{
		sb.Append(rawContent + MdNewLn);
		return this;
	}
	public MarkdownBuilder PlaceHeader(ushort power = 1)
	{
		if (power == 0) throw new ArgumentOutOfRangeException(nameof(power));

		sb.Append(string.Concat(Enumerable.Repeat('#', power)) + " ");
		return this;
	}
	public MarkdownBuilder NewLine()
	{
		sb.Append(MdNewLn);
		return this;
	}
	public MarkdownBuilder PlainText(string text)
	{
		sb.Append(text.Replace("\n", "  \n"));
		return this;
	}
	public MarkdownBuilder Link(string text, MarkdownDocumentation href)
	{
		string path = href.Path;

		return PlainText($"[{text}](doc:{path};)");
	}
	public MarkdownBuilder Link(string text, string href)
	{
		return PlainText($"[{text}]({href})");
	}
	public MarkdownBuilder Link(string href)
	{
		return PlainText($"<{href}>");
	}
	public MarkdownDocumentation Build(string path)
		=> new(path, sb.ToString());
}
