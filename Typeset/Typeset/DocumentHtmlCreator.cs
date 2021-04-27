using System.Collections.Generic;
using System.Text;

namespace Typeset
{
    internal class DocumentHtmlCreator
    {
        private readonly IStringResourceProvider _stringResourceProvider;

        public DocumentHtmlCreator(IStringResourceProvider stringResourceProvider)
        {
            _stringResourceProvider = stringResourceProvider;
        }

        public string Create(DocumentFormatting documentFormatting, IEnumerable<string> markdownPages)
        {
            var pagesHtml = GetHtmlForMarkdownPages(markdownPages);
            var documentHtml = _stringResourceProvider.Get(StringResources.DocumentHtml);

            var css = _stringResourceProvider.Get(StringResources.DocumentCss)
                .Replace("{fontFamily}", documentFormatting.FontFamily)
                .Replace("{fontSize}", documentFormatting.FontSize)
                .Replace("{lineHeight}", documentFormatting.LineHeight)
                .Replace("{pageMargin}", documentFormatting.PageMargin)
                .Replace("{pageSize}", documentFormatting.PageSize);


            var html = documentHtml
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