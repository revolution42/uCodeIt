using uCodeIt.DocumentTypes;

namespace uCodeIt.Demo.Models.DocumentTypes
{
    [DocumentType(Alias = "Home")]
    public class HomePage : DocumentTypeBase
    {
        [Property(DataType = DataType.TextString)]
        public string Title { get; set; }

        [Property(DataType = DataType.TextString)]
        public string BodyContent { get; set; }
    }
}