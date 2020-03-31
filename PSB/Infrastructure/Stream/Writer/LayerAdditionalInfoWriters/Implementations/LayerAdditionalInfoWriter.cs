using System;

namespace Psb.Infrastructure.Stream.Writer.LayerAdditionalInfoWriters.Implementations
{
    public abstract class LayerAdditionalInfoWriter<T> : ILayerAdditionalInfoWriter
        where T : Domain.LayerAdditionalInfo.ILayerAdditionalInfo
    {
        protected readonly T _layerAdditionalInfo;

        protected LayerAdditionalInfoWriter(T layerAdditionalInfo)
        {
            if (layerAdditionalInfo == null)
            {
                throw new ArgumentNullException(nameof(layerAdditionalInfo));
            }

            _layerAdditionalInfo = layerAdditionalInfo;
        }

        public void Write(IBinaryWriter binaryWriter)
        {
            binaryWriter.WriteAsciiCharacters("8BIM");
            binaryWriter.WriteAsciiCharacters(_layerAdditionalInfo.Key.Description());

            var size = LongBinaryLength ? Domain.Enums.FileMode.BigFile : Domain.Enums.FileMode.RegularFile;

            using (var blockLength = BlockLengthWriter.CreateBlockLengthWriter(binaryWriter, size))
            {
                WriteInternal(binaryWriter);
            }
        }

        protected abstract bool LongBinaryLength { get; }

        protected abstract void WriteInternal(IBinaryWriter binaryWriter);
    }
}
