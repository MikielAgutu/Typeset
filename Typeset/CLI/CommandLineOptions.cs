using System.Collections.Generic;
using CommandLine;

namespace CLI
{
    public class CommandLineOptions
    {
        [Option("fontFamily",
            Required = false,
            HelpText = "Font family to use for all text in the document",
            Default = "Arial")]
        public string FontFamily { get; set; }

        [Option("pageSize",
            Required = false,
            HelpText = "Page size of the document",
            Default = "A4")]
        public string PageSize { get; set; }

        [Option("pageMargin",
            Required = false,
            HelpText = "Margin around the text",
            Default = "70pt 60pt 70pt")]
        public string PageMargin { get; set; }

        [Option("lineHeight",
            Required = false,
            HelpText = "Height of each line of text",
            Default = "200%")]
        public string LineHeight { get; set; }

        [Option("fontSize",
            Required = false,
            HelpText = "Font size for main text of document",
            Default = "14pt")]
        public string FontSize { get; set; }

        [Option('i',
            "inputFilePaths",
            Required = true,
            HelpText = "Markdown files to create into a document")]
        public IEnumerable<string> InputFilePaths { get; set; }

        [Option('o',
            "outputFilepath",
            Required = true,
            HelpText = "Where to output the document PDF")]
        public string OutputFilepath { get; set; }

        [Option("title",
            Required = false,
            HelpText = "Title of the document",
            Default = "")]
        public string Title { get; set; }

        [Option("printPageNumbers",
            Required = false,
            HelpText = "Whether to print page numbers",
            Default = false)]
        public bool PrintPageNumbers { get; set; }

        [Option("printPageMarginals",
            Required = false,
            HelpText = "Whether to print page marginals",
            Default = false)]
        public bool PrintMarginals { get; set; }
    }
}