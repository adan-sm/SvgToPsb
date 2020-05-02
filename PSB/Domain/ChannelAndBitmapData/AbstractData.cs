using System;

namespace Psb.Domain.ChannelAndBitmapData
{
    internal abstract class AbstractData
    {
        protected AbstractData(CompressionMode compressionMode, byte[] data)
        {
            CompressionMode = compressionMode;

            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public CompressionMode CompressionMode { get; }

        public byte[] Data { get; }
    }
}
