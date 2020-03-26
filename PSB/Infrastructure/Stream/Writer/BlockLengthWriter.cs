using System;

namespace Psb.Infrastructure.Stream.Writer
{
    internal class BlockLengthWriter : IDisposable
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly long _lengthPosition;
        private readonly long _startPosition;

        public BlockLengthWriter(IBinaryWriter binaryWriter, long lengthPosition, long startPosition)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _lengthPosition = lengthPosition;
            _startPosition = startPosition;
        }

        public static BlockLengthWriter CreateBlockLengthWriter(IBinaryWriter binaryWriter)
        {
            var lengthPosition = binaryWriter.Position;

            binaryWriter.WriteUInt32(0xBADDFEED);

            return new BlockLengthWriter(binaryWriter, lengthPosition, binaryWriter.Position);
        }

        public void Dispose()
        {
            var position = _binaryWriter.Position;
            var length = position - _startPosition;

            _binaryWriter.Seek(_lengthPosition);
            _binaryWriter.WriteUInt32((uint)length);
            _binaryWriter.Seek(position);
        }
    }
}
