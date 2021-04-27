using System.IO;
using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
        public Stream CreatePdfStreamFromHtml(string html)
        {
            var pdfStream = CreatePdfStreamFromHtmlAsync(html).GetAwaiter().GetResult();
            return pdfStream;
        }

        private static async Task<Stream> CreatePdfStreamFromHtmlAsync(string html)
        {
            var pdfStream = await PdfGenerator.GeneratePdfStreamFromHtml(html);
            return pdfStream;
        }
    }
}
