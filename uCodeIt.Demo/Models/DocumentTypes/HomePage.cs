using uCodeIt.DocumentTypes;

namespace uCodeIt.Demo.Models.DocumentTypes
{
    [DocumentType]
    public class HomePage : DocumentTypeBase
    {
        [Property]
        public string Title { get; set; }

        [Property]
        public string BodyContent { get; set; }
    }
}