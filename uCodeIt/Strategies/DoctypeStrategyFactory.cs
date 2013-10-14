using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace uCodeIt.Strategies
{
    public class DoctypeStrategyFactory {
        
        private static IDoctypeInitStrategy _strategy = null;
        
        public static DoctypeStrategyFactory Current {
            get {
                if (_strategy == null) _strategy = new DefaultStrategy();
                return new DoctypeStrategyFactory(_strategy);
            }
        }

        public DoctypeStrategyFactory(IDoctypeInitStrategy strategyType)
        {
            _strategy = strategyType;
        }

        public void SetStrategy(IDoctypeInitStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Execute()
        {
            _strategy.Process(null);
        }
    }
}
