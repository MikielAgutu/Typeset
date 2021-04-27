using System.IO;
using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
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
