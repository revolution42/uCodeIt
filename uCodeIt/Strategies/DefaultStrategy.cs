using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;

namespace uCodeIt.Strategies
{
    public class DefaultStrategy : IDocumentTypeInitStrategy
    {
        public IContentTypeService ContentTypeService { get; set; }

        public void Process(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                foreach (var prop in type.GetProperties()) {
                    // prop.Name
                }
            }
        }

    }
}
