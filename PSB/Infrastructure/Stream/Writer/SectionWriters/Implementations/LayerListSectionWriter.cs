using Psb.Domain;
using Psb.Domain.Implementations;
using System;

namespace Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class LayerListSectionWriter : ILayerListSectionWriter
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly Psb.Domain.ILayerList _layers;
        private readonly ISectionWriterFactory _sectionWriterFactory;

        public LayerListSectionWriter(IBinaryWriter binaryWriter, ILayerList layers, ISectionWriterFactory sectionWriterFactory = null)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _layers = layers ?? throw new ArgumentNullException(nameof(layers));
            _sectionWriterFactory = sectionWriterFactory ?? new Writer.Implementations.SectionWriterFactory();
        }

        public void Write()
        {
            using (var blockLength = BlockLengthWriter.CreateBlockLengthWriter(_binaryWriter, _layers.Owner.FileMode))
            {
                using (var blockLength2 = BlockLengthWriter.CreateBlockLengthWriter(_binaryWriter, _layers.Owner.FileMode))
                {
                    var startPosition = _binaryWriter.Position;

                    _binaryWriter.WriteInt16((short)_layers.Count);

                    foreach (var currentLayer in _layers)
                    {
                        _sectionWriterFactory
                            .Get(_binaryWriter, currentLayer)
                            .Write();
                    }

                    foreach(var currentLayer in _layers)
                    {
                        foreach (var ichannel in currentLayer.Channels)
                        {
                            var channel = ichannel as Channel;

                            _binaryWriter.WriteEnum16(channel.ChannelData.CompressionMode);
                            _binaryWriter.WriteBytes(channel.ChannelData.Data);
                        }
                    }

                    _binaryWriter.WritePadding(startPosition, 4);
                }
            }
        }
    }
}
