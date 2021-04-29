using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;
using Typeset;

namespace CLI
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Typeset - Print-ready PDFs from Markdown");

            return Parser.Default.ParseArguments<CommandLineOptions>(args)
                .MapResult(Enter, HandleCommandLineParseError);
        }
        private static int HandleCommandLineParseError(IEnumerable<Error> errors)
        {
            Console.Error.WriteLine(string.Join(Environment.NewLine, errors));
            return -1;
        }

        private static int Enter(CommandLineOptions commandLineOptions)
        {
            var exitCode = 0;

            try
            {
                RunTypeset(commandLineOptions);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                exitCode = 1;
            }

            return exitCode;
        }

        private static void RunTypeset(CommandLineOptions commandLineOptions)
        {
            var typesetter = new Typesetter();
            var documentFormatting = new DocumentFormatting(
                commandLineOptions.FontFamily,
                commandLineOptions.PageSize,
                commandLineOptions.PageMargin,
                commandLineOptions.LineHeight,
                commandLineOptions.FontSize,
                commandLineOptions.PrintPageNumbers,
                commandLineOptions.PrintMarginals);

            var documentMetadata = new DocumentMetadata(
                commandLineOptions.Title,
                documentFormatting);

            var markdownPages = commandLineOptions.InputFilePaths.Select(File.ReadAllText);
            var stream = typesetter.CreatePdfDocument(documentMetadata, markdownPages);

            using var fileStream = new FileStream(commandLineOptions.OutputFilepath, FileMode.Create);
            stream.CopyTo(fileStream);
        }
    }
}
