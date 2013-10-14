using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace uCodeIt.Strategies
{
    public class DocumentTypeStrategyFactory {
        
        private static IDocumentTypeInitStrategy _strategy = null;
        
        public static DocumentTypeStrategyFactory Current {
            get {
                if (_strategy == null) _strategy = new DefaultStrategy();
                return new DocumentTypeStrategyFactory(_strategy);
            }
        }

        public DocumentTypeStrategyFactory(IDocumentTypeInitStrategy strategyType)
        {
            _strategy = strategyType;
        }

        public void SetStrategy(IDocumentTypeInitStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Execute()
        {
            _strategy.Process(null);
        }
    }
}
