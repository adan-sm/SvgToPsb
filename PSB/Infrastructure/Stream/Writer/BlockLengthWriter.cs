using System;

namespace Psb.Infrastructure.Stream.Writer
{
    internal class BlockLengthWriter : IDisposable
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly long _lengthPosition;
        private readonly long _startPosition;
        private readonly Domain.Enums.FileMode _fileMode;

        public BlockLengthWriter(IBinaryWriter binaryWriter, long lengthPosition, long startPosition, Domain.Enums.FileMode fileMode)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _lengthPosition = lengthPosition;
            _startPosition = startPosition;
            _fileMode = fileMode;
        }

        public static BlockLengthWriter CreateBlockLengthWriter(IBinaryWriter binaryWriter, Domain.Enums.FileMode fileMode)
        {
            var lengthPosition = binaryWriter.Position;

            if(fileMode == Domain.Enums.FileMode.RegularFile)
            {
                binaryWriter.WriteUInt32(0xBADDFEED);
            }
            else
            {
                binaryWriter.WriteUInt64(0xBADDFEEDBADDFEED);
            }
            
            return new BlockLengthWriter(binaryWriter, lengthPosition, binaryWriter.Position, fileMode);
        }

        public void Dispose()
        {
            var position = _binaryWriter.Position;
            var length = position - _startPosition;

            _binaryWriter.Seek(_lengthPosition);

            if (_fileMode == Domain.Enums.FileMode.RegularFile)
            {
                _binaryWriter.WriteUInt32((uint)length);
            }
            else
            {
                _binaryWriter.WriteUInt64((ulong)length);
            }

            _binaryWriter.Seek(position);
        }
    }
}
