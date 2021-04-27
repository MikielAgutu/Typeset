using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Typeset
{
    public class Typesetter
    {
        public Stream CreateBookPdfStream(params string[] markdownPages)
        {
            var stringBuilder = new StringBuilder();

            foreach (var markdownPage in markdownPages)
            {
                var html = MarkdownToHtmlConverter.Convert(markdownPage);
                stringBuilder.AppendLine(html);
            }

            return CreatePdfStreamFromHtml(stringBuilder.ToString());
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
