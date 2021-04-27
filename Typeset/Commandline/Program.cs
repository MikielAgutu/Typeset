using Typeset;

namespace Commandline
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var typesetter = new Typesetter();
            typesetter.GeneratePdf();
        }
    }
}
