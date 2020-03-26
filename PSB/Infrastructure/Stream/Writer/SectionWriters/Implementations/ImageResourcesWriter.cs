using Psb.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class ImageResourcesWriter : IImageResourcesWriter
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly Psb.Domain.IImageResourceList _imageResources;

        public ImageResourcesWriter(IBinaryWriter binaryWriter, IImageResourceList imageResources)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _imageResources = imageResources ?? throw new ArgumentNullException(nameof(imageResources));
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
