using uCodeIt.DocumentTypes;

namespace uCodeIt.Demo.Models.DocumentTypes
{
    [DocumentType(Alias = "Home")]
    public class HomePage : DocumentTypeBase
    {
        [Property(DataType = "Textstring")]
        public string Title { get; set; }

        [Property(DataType = "Textstring")]
        public string BodyContent { get; set; }
    }
}