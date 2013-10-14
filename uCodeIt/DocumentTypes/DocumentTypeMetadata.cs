using System;
using System.Collections.Generic;
namespace uCodeIt.DocumentTypes
{
    public sealed class DocumentTypeMetadata
    {
        public string Name { get; internal set; }
        public string Alias { get; internal set; }
        public string Description { get; internal set; }
        public string Icon { get; internal set; }
        public string Thumbnail { get; internal set; }
        public bool AllowAsRoot { get; internal set; }
        public IEnumerable<string> Templates { get; internal set; }
        public IEnumerable<DocumentTypeMetadata> AllowedChildren { get; internal set; }

        public Type Type { get; internal set; }
        internal DocumentTypeAttribute Attribute { get; set; }

        //public IEnumerable<PropertyMetadata> Properties { get; internal set; }
    }
}
