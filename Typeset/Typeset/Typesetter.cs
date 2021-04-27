using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
        private readonly DocumentHtmlCreator _documentHtmlCreator = new DocumentHtmlCreator(new StringResourceProvider());

        public Stream CreateDocumentPdfStream(DocumentMetadata documentMetadata, IEnumerable<string> markdownPages)
        {
            var html = _documentHtmlCreator.Create(documentMetadata, markdownPages);
            return CreatePdfStreamFromHtml(html);
        }

        public Stream CreatePdfStreamFromMarkdown(string markdown)
        {
            var html = MarkdownToHtmlConverter.Convert(markdown);
            return CreatePdfStreamFromHtml(html);
        }

        public Stream CreatePdfStreamFromHtml(string html)
        {
            return CreatePdfStreamFromHtmlAsync(html).GetAwaiter().GetResult();
        }

        private static async Task<Stream> CreatePdfStreamFromHtmlAsync(string html)
        {
            var pdfStream = await PdfGenerator.GeneratePdfStreamFromHtml(html);
            return pdfStream;
        }
    }
}
