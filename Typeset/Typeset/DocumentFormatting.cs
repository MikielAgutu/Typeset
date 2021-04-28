namespace Typeset
{
    public class DocumentFormatting
    {
        public string FontFamily { get; }
        public string PageSize { get; }
        public string PageMargin { get; }
        public string LineHeight { get; }
        public string FontSize { get; }
        public bool PrintPageNumbers { get; }
        public bool PrintMarginals { get; }

        public DocumentFormatting(string fontFamily, string pageSize, string pageMargin, string lineHeight, string fontSize, bool printPageNumbers, bool printMarginals)
        {
            FontFamily = fontFamily;
            PageSize = pageSize;
            PageMargin = pageMargin;
            LineHeight = lineHeight;
            FontSize = fontSize;
            PrintPageNumbers = printPageNumbers;
            PrintMarginals = printMarginals;
        }
    }
}