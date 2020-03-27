using Psb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Psb.Infrastructure.Builders.Implementations
{
    // TODO : change to internal
    public class ImageResourcesBuilder : IImageResourcesBuilder
    {
        private readonly List<IImageResource> _imagesResources = new List<IImageResource>();

        public IImageResourcesBuilder Add(IImageResource imageResource)
        {
            if (imageResource == null)
            {
                throw new ArgumentNullException(nameof(imageResource));
            }

            if (_imagesResources.Any(i => i.Id == imageResource.Id))
            {
                throw new InvalidOperationException($"There is already a {imageResource.Id} resource");
            }

            _imagesResources.Add(imageResource);

            return this;
        }

        public IImageResourceList Get()
        {
            var result = new Domain.Implementations.ImageResourceList();

            result.AddRange(_imagesResources);

            return result;
        }

        internal IReadOnlyList<IImageResource> ImageResources => _imagesResources.AsReadOnly();
    }
}
