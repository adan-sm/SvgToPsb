using Psb.Domain;
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
            _sectionWriterFactory = sectionWriterFactory ?? new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();
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

                    _binaryWriter.WritePadding(startPosition, 4);
                }
            }
        }
    }
}
