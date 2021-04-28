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

        public string Create(DocumentMetadata documentMetadata, IEnumerable<string> markdownPages)
        {
            var css = CreateDocumentCss(documentMetadata);
            var html = CreateDocumentHtml(markdownPages, css);

            return html;
        }

        private string CreateDocumentHtml(IEnumerable<string> markdownPages, string css)
        {
            var htmlTemplate = GetHtmlTemplate();
            var html = SubstituteVariablesInHtmlTemplate(markdownPages, htmlTemplate, css);
            return html;
        }

        private string CreateDocumentCss(DocumentMetadata documentMetadata)
        {
            var cssTemplate = GetCssTemplate(documentMetadata.DocumentFormatting);
            return SubstituteVariablesInCssTemplate(documentMetadata, cssTemplate);
        }

        private static string SubstituteVariablesInHtmlTemplate(IEnumerable<string> markdownPages, string htmlTemplate, string css)
        {
            var pagesHtml = GetHtmlForMarkdownPages(markdownPages);

            var html = htmlTemplate
                .Replace("{css}", css)
                .Replace("{pagesHtml}", pagesHtml);
            return html;
        }

        private string GetHtmlTemplate()
        {
            return _stringResourceProvider.Get(StringResources.DocumentHtml);
        }

        private static string SubstituteVariablesInCssTemplate(DocumentMetadata documentMetadata, string cssTemplate)
        {
            var documentFormatting = documentMetadata.DocumentFormatting;

            return cssTemplate
                .Replace("{fontFamily}", documentFormatting.FontFamily)
                .Replace("{fontSize}", documentFormatting.FontSize)
                .Replace("{lineHeight}", documentFormatting.LineHeight)
                .Replace("{pageMargin}", documentFormatting.PageMargin)
                .Replace("{pageSize}", documentFormatting.PageSize)
                .Replace("{documentTitle}", documentMetadata.Title);
        }

        private string GetCssTemplate(DocumentFormatting documentFormatting)
        {
            var firstPageCss = _stringResourceProvider.Get(StringResources.FirstPageCss);
            var pageMarginalsCss = _stringResourceProvider.Get(StringResources.PageMarginalsCss);
            var pageNumberCss = _stringResourceProvider.Get(StringResources.PageNumberCss);
            var documentCss = _stringResourceProvider.Get(StringResources.DocumentCss);

            var sb = new StringBuilder();

            if (documentFormatting.PrintMarginals)
            {
                sb.AppendLine(pageMarginalsCss);
            }

            if (documentFormatting.PrintPageNumbers)
            {
                sb.AppendLine(pageNumberCss);
            }

            sb.AppendLine(documentCss);

            return sb.ToString();
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