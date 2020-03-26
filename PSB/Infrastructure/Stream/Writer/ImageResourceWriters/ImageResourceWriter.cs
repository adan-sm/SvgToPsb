using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters

{
    internal abstract class ImageResourceWriter : IImageResourceWriter
    {
        private readonly Domain.IImageResource _imageResource;

        protected ImageResourceWriter(IImageResource imageResource)
        {
            _imageResource = imageResource ?? throw new ArgumentNullException(nameof(imageResource));
        }

        public void Write(IBinaryWriter binaryWriter)
        {
            binaryWriter.WriteAsciiCharacters("8BIM");
            binaryWriter.WriteUInt16(_imageResource.Id);
            binaryWriter.WritePascalString(_imageResource.Name);

            using (var blockLength = BlockLengthWriter.CreateBlockLengthWriter(binaryWriter))
            {
                WriteInternal(binaryWriter);
            }
        }

        protected internal abstract void WriteInternal(IBinaryWriter binaryWriter);
    }
}
