using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using MvcTemplate.Resources;
using System;

namespace MvcTemplate.Components.Mvc
{
    public class DisplayMetadataProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Key.ContainerType is Type view && context.Key.MetadataKind == ModelMetadataKind.Property)
                if (Resource.ForProperty(view, context.Key.Name!) is String { Length: > 0 } title)
                    context.DisplayMetadata.DisplayName = () => title;
        }
    }
}
