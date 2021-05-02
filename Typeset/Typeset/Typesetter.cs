using System.IO;
using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
        private readonly DocumentHtmlCreator _documentHtmlCreator = new(new StringResourceProvider());

        private readonly DocumentMetadata _defaultDocumentMetadata =
            new(string.Empty,
                new DocumentFormatting(
                    "Arial",
                    "A4",
                    "70pt 60pt 70pt",
                    "200%",
                    "14pt",
                    false,
                    false));

        public Stream CreatePdfDocument(params string[] markdownPages)
        {
            var html = _documentHtmlCreator.Create(_defaultDocumentMetadata, markdownPages);
            return CreatePdfStreamFromHtmlAsync(html).GetAwaiter().GetResult();
        }

        public Stream CreatePdfDocument(DocumentMetadata documentMetadata, params string[] markdownPages)
        {
            var html = _documentHtmlCreator.Create(documentMetadata, markdownPages);
            return CreatePdfStreamFromHtmlAsync(html).GetAwaiter().GetResult();
        }

        public Task<Stream> CreatePdfDocumentAsync(params string[] markdownPages)
        {
            var html = _documentHtmlCreator.Create(_defaultDocumentMetadata, markdownPages);
            return CreatePdfStreamFromHtmlAsync(html);
        }

        public Task<Stream> CreatePdfDocumentAsync(DocumentMetadata documentMetadata, params string[] markdownPages)
        {
            var html = _documentHtmlCreator.Create(documentMetadata, markdownPages);
            return CreatePdfStreamFromHtmlAsync(html);
        }

        private static async Task<Stream> CreatePdfStreamFromHtmlAsync(string html)
        {
            return await PdfGenerator.GeneratePdfStreamFromHtml(html);
        }
    }
}
