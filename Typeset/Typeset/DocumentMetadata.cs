namespace Typeset
{
    public class DocumentMetadata
    {
        public DocumentMetadata(string title, DocumentFormatting documentFormatting)
        {
            Title = title;
            DocumentFormatting = documentFormatting;
        }
        public string Title { get; set; }
        public DocumentFormatting DocumentFormatting { get; }
    }
}