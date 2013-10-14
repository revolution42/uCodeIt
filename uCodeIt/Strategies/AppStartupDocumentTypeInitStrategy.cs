using System;
using System.Collections.Generic;
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

        public void Process(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                foreach (var prop in type.GetProperties()) {
                    // prop.Name
                }
            }
        }

        public bool CanRun()
        {
            //todo - make sure this is run at the right time only
            return true;
        }
    }
}
