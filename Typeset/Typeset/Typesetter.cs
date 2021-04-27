using System.IO;
using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
        private readonly BookHtmlCreator _bookHtmlCreator = new BookHtmlCreator(new StringResourceProvider());

        public Stream CreateBookPdfStream(params string[] markdownPages)
        {
            var html = _bookHtmlCreator.Create(markdownPages);
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
