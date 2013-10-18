using System.Collections.Generic;
using System.Linq;
using uCodeIt.Metadata;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace uCodeIt.Importer
{
    internal class DefaultImporter : IImporter
    {
        public IContentTypeService ContentTypeService { get; private set; }
        public IDataTypeService DataTypeService { get; private set; }

        protected internal DefaultImporter()
            : this(ApplicationContext.Current.Services.ContentTypeService, ApplicationContext.Current.Services.DataTypeService)
        {
        }

        protected DefaultImporter(IContentTypeService contentTypeService, IDataTypeService dataTypeService)
        {
            ContentTypeService = contentTypeService;
            DataTypeService = dataTypeService;
        }

        public void Process(IEnumerable<DocumentTypeMetadata> types)
        {
            var contentTypes = new List<IContentType>();
            var dataTypeDefinitions = DataTypeService.GetAllDataTypeDefinitions().ToArray();

            foreach (var type in types)
            {
                var ct = ContentTypeService.GetContentType(type.Alias) ?? new ContentType(-1);

                ct.Name = type.Name;
                ct.Alias = type.Alias;
                ct.AllowedAsRoot = type.AllowAsRoot;
                ct.Description = type.Description;
                ct.Icon = type.Icon;
                ct.Thumbnail = type.Thumbnail;

                var properties = ct.PropertyTypes.ToArray();

                var newProperties = type.Properties.Where(p => !properties.Any(x => x.Alias == p.Alias));

                foreach (var property in newProperties)
                {
                    ct.AddPropertyType(new PropertyType(dataTypeDefinitions.First(dtd => dtd.Name == property.DataType))
                    {
                        Name = property.Name,
                        Alias = property.Alias,
                        Description = property.Description
                    });
                }

                contentTypes.Add(ct);
            }

            ContentTypeService.Save(contentTypes);
        }

    }
}
