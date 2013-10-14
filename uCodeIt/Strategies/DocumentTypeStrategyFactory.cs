using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace uCodeIt.Strategies
{
    public static class DocumentTypeStrategyFactory {

        private static IDocumentTypeInitStrategy _strategy = null;

        public static IDocumentTypeInitStrategy Current
        {
            get
            {
                return _strategy == null ? _strategy = new AppStartupDocumentTypeInitStrategy() : _strategy;
            }
            set
            {
                _strategy = value;
            }
        }
    }
}
