using System.IO;
using Typeset;

namespace Commandline
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var typesetter = new Typesetter();
            var stream = typesetter.CreateDocumentPdfStream("# Hello\nworld", "# Goodbye \nuniverse");

            using var fileStream = new FileStream("C:\\output\\output.pdf", FileMode.Create);
            stream.CopyTo(fileStream);
        }
    }
}
