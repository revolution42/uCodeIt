using uCodeIt.DocumentTypes;
using uCodeIt.Strategies;
using Umbraco.Core;

namespace uCodeIt
{
    public class StartupHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (CacheValidator.Exists())
                //The cache already exists and by extension has been run
                return;

            var strategy = DocumentTypeStrategyFactory.Current;

            if (strategy.CanRun())
            {
                var documentTypes = TypeFinder.FindClassesOfType<DocumentTypeBase>();
                strategy.Process(documentTypes);
            }
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}
