using System;
using System.Collections.Generic;
using Umbraco.Core.Services;

namespace uCodeIt.Strategies
{
    public interface IDocumentTypeInitStrategy
    {
        IContentTypeService ContentTypeService { get; }
        bool CanRun();
        void Process(IEnumerable<Type> types);
    }
}
