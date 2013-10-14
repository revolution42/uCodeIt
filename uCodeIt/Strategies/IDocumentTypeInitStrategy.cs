using System.Collections.Generic;
using uCodeIt.Metadata;
using Umbraco.Core.Services;

namespace uCodeIt.Strategies
{
    public interface IDocumentTypeInitStrategy
    {
        IContentTypeService ContentTypeService { get; }
        bool CanRun();
        void Process(IEnumerable<DocumentTypeMetadata> types);
    }
}
