using Psb.Domain;
using System;


namespace Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations
{
    /// <summary>
    /// TODO : remove public
    /// </summary>
    public class LayerSectionWriter : ILayerSectionWriter
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly ILayer _layer;
        private readonly LayerAdditionalInfoWriters.ILayerAdditionalInfoWriterFactory _layerAdditionalInfoWriterFactory;

        public LayerSectionWriter(IBinaryWriter binaryWriter, ILayer layer, LayerAdditionalInfoWriters.ILayerAdditionalInfoWriterFactory layerAdditionalInfoWriterFactory = null)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _layer = layer ?? throw new ArgumentNullException(nameof(layer));

            _layerAdditionalInfoWriterFactory = layerAdditionalInfoWriterFactory ?? new LayerAdditionalInfoWriters.Implementations.LayerAdditionalInfoWriterFactory();
        }

        public void Write()
        {
            _binaryWriter.WriteRectangle(_layer.Rectangle);
            // TODO : channel
            _binaryWriter.WriteAsciiCharacters("8BIM");
            _binaryWriter.WriteAsciiCharacters(_layer.BlendMode.Description());
            _binaryWriter.WriteByte(_layer.Opacity);
            _binaryWriter.WriteBool(_layer.Clipping);
            _binaryWriter.WriteEnumByte(_layer.Flags);
            _binaryWriter.WriteFillers(1);

            using (var blockLengthWriter = BlockLengthWriter.CreateBlockLengthWriter(_binaryWriter, Domain.Enums.FileMode.RegularFile))
            {
                // TODO : MASKS
                _binaryWriter.WriteUInt32(0);
                // TODO : BLENDING RANGES
                _binaryWriter.WriteUInt32(0);

                _binaryWriter.WritePascalString(_layer.Name, 4, true);

                foreach (var currentLayerInfo in _layer.LayerInformations)
                {
                    _layerAdditionalInfoWriterFactory
                        .Get(currentLayerInfo)
                        .Write(_binaryWriter);
                }
            }
        }
    }
}
