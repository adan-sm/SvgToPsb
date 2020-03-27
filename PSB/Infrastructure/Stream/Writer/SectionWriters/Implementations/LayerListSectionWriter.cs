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

        public LayerListSectionWriter(IBinaryWriter binaryWriter, ILayerList layers)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _layers = layers ?? throw new ArgumentNullException(nameof(layers));
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
