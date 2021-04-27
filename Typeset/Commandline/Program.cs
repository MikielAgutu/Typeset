using System.IO;
using Typeset;

namespace Commandline
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var typesetter = new Typesetter();
            var stream = typesetter.CreatePdfStreamFromHtml("<h1>Hello</h1>\n<p>world</p>");

            using var fileStream = new FileStream("C:\\output\\output.pdf", FileMode.Create);
            stream.CopyTo(fileStream);
        }
    }
}
