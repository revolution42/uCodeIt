using System;
using System.Collections.Generic;
using uCodeIt.DocumentTypes;
using uCodeIt.Metadata;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace uCodeIt.Strategies
{
    public class AppStartupDocumentTypeInitStrategy : IDocumentTypeInitStrategy
    {
        protected internal AppStartupDocumentTypeInitStrategy()
            : this(ApplicationContext.Current.Services.ContentTypeService)
        {
        }

        protected AppStartupDocumentTypeInitStrategy(IContentTypeService contentTypeService)
        {
            ContentTypeService = contentTypeService;
        }

        public IContentTypeService ContentTypeService { get; private set; }

        public void Process(IEnumerable<DocumentTypeMetadata> types)
        {
            foreach (var type in types)
            {
                
            }
        }

        public bool CanRun()
        {
            //todo - make sure this is run at the right time only
            return true;
        }
    }
}
