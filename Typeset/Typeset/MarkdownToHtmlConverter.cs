using Markdig;

namespace Typeset
{
    internal static class MarkdownToHtmlConverter
    {
        public static string Convert(string markdown)
        {
            return Markdown.ToHtml(markdown);
        }
    }
}