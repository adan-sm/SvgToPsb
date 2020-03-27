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
        private readonly Domain.ILayer _layer;

        public LayerSectionWriter(IBinaryWriter binaryWriter, ILayer layer)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _layer = layer ?? throw new ArgumentNullException(nameof(layer));
        }

        public void Write()
        {
            
        }
    }
}
