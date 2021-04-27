using System;
using System.Collections.Generic;
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
            var pagesHtml = GetHtmlForMarkdownPages(markdownPages);
            var bookHtml = _stringResourceProvider.Get(StringResources.BookHtml);
            var css = _stringResourceProvider.Get(StringResources.BookCss);

            var html = bookHtml
                .Replace("{css}", css)
                .Replace("{pagesHtml}", pagesHtml);

            return html;
        }

        private static string GetHtmlForMarkdownPages(IEnumerable<string> markdownPages)
        {
            var stringBuilder = new StringBuilder();

            foreach (var markdownPage in markdownPages)
            {
                var markdownPageHtml = MarkdownToHtmlConverter.Convert(markdownPage);
                stringBuilder.AppendLine(markdownPageHtml);
            }

            return stringBuilder.ToString();
        }
    }
}