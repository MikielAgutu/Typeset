using System;
using System.IO;
using System.Text;

namespace Typeset
{
    public static class BookHtmlCreator
    {
        public static string Create(params string[] markdownPages)
        {
            var stringBuilder = new StringBuilder();

            foreach (var markdownPage in markdownPages)
            {
                var markdownPageHtml = MarkdownToHtmlConverter.Convert(markdownPage);
                stringBuilder.AppendLine(markdownPageHtml);
            }

            var pagesHtml = stringBuilder.ToString();
            var css = File.ReadAllText("book.css");
            var html =
                $"<html>" +
                "<head>" +
                "<style>" +
                $"{css}" +
                "</style>" +
                "</head>" +
                $"{Environment.NewLine}" +
                $"{pagesHtml}" +
                "</html>";

            return html;
        }
    }
}