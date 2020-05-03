using Psb.Domain;
using Psb.Domain.Implementations;
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

        public LayerSectionWriter(IBinaryWriter binaryWriter,
                                  ILayer layer,
                                  LayerAdditionalInfoWriters.ILayerAdditionalInfoWriterFactory layerAdditionalInfoWriterFactory = null)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _layer = layer ?? throw new ArgumentNullException(nameof(layer));

            _layerAdditionalInfoWriterFactory = layerAdditionalInfoWriterFactory ?? new LayerAdditionalInfoWriters.Implementations.LayerAdditionalInfoWriterFactory();
        }

        public void Write()
        {
            _binaryWriter.WriteRectangle(_layer.Rectangle);

            // TODO : move to an other class
            _binaryWriter.WriteUInt16((ushort)_layer.Channels.Count);
            foreach (var ichannel in _layer.Channels)
            {
                var channel = ichannel as Channel;
                _binaryWriter.WriteInt16(channel.Id);
                using (BlockLengthWriter.CreateBlockLengthWriter(_binaryWriter, _layer.Owner.FileMode))
                {
                    _binaryWriter.WriteEnum16(channel.ChannelData.CompressionMode);
                    _binaryWriter.WriteBytes(channel.ChannelData.Data);
                }
            }
            // ...

            _binaryWriter.WriteAsciiCharacters("8BIM");
            _binaryWriter.WriteAsciiCharacters(_layer.BlendMode.Description());
            _binaryWriter.WriteByte(_layer.Opacity);
            _binaryWriter.WriteBool(_layer.Clipping);
            _binaryWriter.WriteEnumByte(_layer.Flags);
            _binaryWriter.WriteFillers(1);

            using (var blockLengthWriter = BlockLengthWriter.CreateBlockLengthWriter(_binaryWriter, Domain.Enums.FileMode.RegularFile))
            {
                _binaryWriter.WriteUInt32(0); // TODO : MASKS (currently, by writing 0, there a no mask)
                _binaryWriter.WriteUInt32(0); // TODO : BLENDING RANGES (currently, by writing 0, there a no mask)

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
