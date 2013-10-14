using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCodeIt.Strategies;
using Umbraco.Core;

namespace uCodeIt
{
    public class StartupHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            DoctypeStrategyFactory.Current.SetStrategy(null);
            DoctypeStrategyFactory.Current.Execute();
            // something.Execute();
            // uCodeIt.Strategies.DoctypeStrategyFactory.Current.Execute();
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }
    }
}
