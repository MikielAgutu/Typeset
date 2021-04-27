using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;
using Typeset;

namespace Commandline
{
    public static class Program
    {
        public static int Main(string[] args)
        {
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
            var exitCode = 1;

            try
            {
                RunTypeset(commandLineOptions);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                exitCode = -1;
            }

            return exitCode;
        }

        private static void RunTypeset(CommandLineOptions commandLineOptions)
        {
            var typesetter = new Typesetter();
            var documentFormatting = new DocumentFormatting
            {
                FontFamily = commandLineOptions.FontFamily,
                FontSize = commandLineOptions.FontSize,
                LineHeight = commandLineOptions.LineHeight,
                PageMargin = commandLineOptions.PageMargin,
                PageSize = commandLineOptions.PageSize
            };

            var documentMetadata = 
                new DocumentMetadata(
                commandLineOptions.Title,
                documentFormatting);

            var markdownPages = commandLineOptions.InputFilePaths.Select(File.ReadAllText);
            var stream = typesetter.CreateDocumentPdfStream(documentMetadata, markdownPages);

            using var fileStream = new FileStream(commandLineOptions.OutputFilepath, FileMode.Create);
            stream.CopyTo(fileStream);
        }

        private static void HandleParseError(IEnumerable<Error> errors)
        {
            throw new Exception($"Failed to parse command line arguments {string.Join(Environment.NewLine, errors)}");
        }
    }
}
