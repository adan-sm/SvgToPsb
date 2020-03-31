using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters

{
    internal abstract class ImageResourceWriter<T> : IImageResourceWriter
        where T : IImageResource
    {
        protected readonly T _imageResource;

        protected ImageResourceWriter(T imageResource)
        {
            if (imageResource == null)
            {
                throw new ArgumentNullException(nameof(imageResource));
            }

            _imageResource = imageResource;
        }

        public void Write(IBinaryWriter binaryWriter)
        {
            binaryWriter.WriteAsciiCharacters("8BIM");
            binaryWriter.WriteUInt16(_imageResource.Id);
            binaryWriter.WritePascalString(_imageResource.Name, 2, true);

            using (var blockLength = BlockLengthWriter.CreateBlockLengthWriter(binaryWriter, Domain.Enums.FileMode.RegularFile))
            {
                var position = binaryWriter.Position;

                WriteInternal(binaryWriter);
                binaryWriter.WritePadding(position, 2);
            }
        }

        protected internal abstract void WriteInternal(IBinaryWriter binaryWriter);
    }
}
