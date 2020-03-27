using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class ImageResourcesWriter : IImageResourcesWriter
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly IImageResourceList _imageResources;
        private readonly ImageResourceWriters.IImageResourceWriterFactory _factory;

        public ImageResourcesWriter(IBinaryWriter binaryWriter, IImageResourceList imageResources)
            : this(binaryWriter, imageResources, null)
        {

        }

        // test purposes
        internal ImageResourcesWriter(IBinaryWriter binaryWriter, IImageResourceList imageResources, ImageResourceWriters.IImageResourceWriterFactory factory)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _imageResources = imageResources ?? throw new ArgumentNullException(nameof(imageResources));

            _factory = factory ?? new ImageResourceWriters.ImageResourceWriterFactory();
        }

        public void Write()
        {
            using (var blockLength = BlockLengthWriter.CreateBlockLengthWriter(_binaryWriter, Domain.Enums.FileMode.RegularFile))
            {
                foreach(var currentImageResource in _imageResources)
                {
                    var writer = _factory.Get(currentImageResource);
                    writer.Write(_binaryWriter);
                }
            }
        }
    }
}
