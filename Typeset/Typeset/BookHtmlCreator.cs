using System;
using System.Text;

namespace Typeset
{
    internal class BookHtmlCreator
    {
        private readonly IStringResourceProvider _stringResourceProvider;

        public BookHtmlCreator(IStringResourceProvider stringResourceProvider)
        {
            _stringResourceProvider = stringResourceProvider;
        }

        public string Create(params string[] markdownPages)
        {
            var stringBuilder = new StringBuilder();

            foreach (var markdownPage in markdownPages)
            {
                var markdownPageHtml = MarkdownToHtmlConverter.Convert(markdownPage);
                stringBuilder.AppendLine(markdownPageHtml);
            }

            var pagesHtml = stringBuilder.ToString();
            var css = _stringResourceProvider.Get(StringResources.Css);
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