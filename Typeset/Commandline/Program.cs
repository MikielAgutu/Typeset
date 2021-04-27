using System.IO;
using Typeset;

namespace Commandline
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var typesetter = new Typesetter();
            var documentFormatting = new DocumentFormatting
            {
                FontFamily = "Arial",
                FontSize = "14pt",
                LineHeight = "200%",
                PageMargin = "70pt 60pt 70pt",
                PageSize = "A5"
            };

            var stream = typesetter.CreateDocumentPdfStream(
                documentFormatting,
                "# Hello\nworld", "# Goodbye \nuniverse");

            using var fileStream = new FileStream("C:\\output\\output.pdf", FileMode.Create);
            stream.CopyTo(fileStream);
        }
    }
}
