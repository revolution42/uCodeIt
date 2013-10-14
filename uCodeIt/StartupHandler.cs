using uCodeIt.DocumentTypes;
using uCodeIt.Strategies;
using Umbraco.Core;
using System.Linq;

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
                var documentTypes = (from type in TypeFinder.FindClassesOfType<DocumentTypeBase>()
                                    let attr = type.GetCustomAttribute<DocumentTypeAttribute>(true)
                                    let name = string.IsNullOrEmpty(attr.Name) ? type.Name : attr.Name
                                    let alias = string.IsNullOrEmpty(attr.Alias) ? type.Name : attr.Alias
                                    select new DocumentTypeMetadata
                                    {
                                        Name = name,
                                        Alias = alias,
                                        Description = attr.Description,
                                        Icon = attr.Icon,
                                        Thumbnail = attr.Thumbnail,
                                        AllowAsRoot = attr.AllowAsRoot,
                                        Type = type,
                                        Attribute = attr
                                    }).ToArray();

                foreach (var documentType in documentTypes)
                    documentType.AllowedChildren = documentTypes.Where(t => documentType.Attribute.AllowedChildren.Any(x => x == t.Type));

                strategy.Process(documentTypes);
            }
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}
