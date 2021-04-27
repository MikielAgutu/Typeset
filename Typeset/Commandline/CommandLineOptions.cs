using System.Collections.Generic;
using CommandLine;

namespace Commandline
{
    public class CommandLineOptions
    {
        [Option("fontFamily", Required = false, HelpText = "Font family to use for all text in the document")]
        public string FontFamily { get; set; }

        [Option("pageSize", Required = false, HelpText = "Page size of the document")]
        public string PageSize { get; set; }

        [Option("pageMargin", Required = false, HelpText = "Margin around the text")]
        public string PageMargin { get; set; }

        [Option("lineHeight", Required = false, HelpText = "Height of each line of text")]
        public string LineHeight { get; set; }

        [Option("fontSize", Required = false, HelpText = "Font size for main text of document")]
        public string FontSize { get; set; }

        [Option("InputFilePaths", Required = false, HelpText = "Markdown files to create into a document")]
        public List<string> InputFilePaths { get; set; }

        [Option("outputFilepath", Required = false, HelpText = "Where to output the document PDF")]
        public string OutputFilepath { get; set; }

        [Option("title", Required = false, HelpText = "Title of the document")]
        public string Title { get; set; }
    }
}