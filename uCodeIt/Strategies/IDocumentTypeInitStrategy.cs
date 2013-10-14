using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uCodeIt.Strategies
{
    public interface IDocumentTypeInitStrategy
    {
        void Process(IEnumerable<Type> types);
    }
}
