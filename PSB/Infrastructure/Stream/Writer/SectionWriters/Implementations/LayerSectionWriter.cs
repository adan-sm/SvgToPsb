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

        public LayerSectionWriter(IBinaryWriter binaryWriter, ILayer layer)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _layer = layer ?? throw new ArgumentNullException(nameof(layer));
        }

        public void Write()
        {
            _binaryWriter.WriteRectangle(_layer.Rectangle);
            // TODO : channel
            _binaryWriter.WriteAsciiCharacters("8BIM");
            _binaryWriter.WriteAsciiCharacters(_layer.BlendMode.Description());
            _binaryWriter.WriteByte(_layer.Opacity);
            _binaryWriter.WriteBool(_layer.Clipping);
            // TODO : flags
            _binaryWriter.WriteFillers(1);
        }
    }
}
