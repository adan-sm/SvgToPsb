using System;
using System.IO;

namespace Psb.Infrastructure.Stream.Writer
{
    class BinaryWriter : IDisposable, IBinaryWriter
    {
        private FileStream file;

        public BinaryWriter(FileStream file)
        {
            this.file = file;
        }

        public void Dispose()
        {
            file.Dispose();
        }

        public void WriteAsciiCharacters(string value)
        {
            throw new NotImplementedException();
        }

        public void WriteAsciiString(string value)
        {
            throw new NotImplementedException();
        }

        public void WriteBytes(byte[] value)
        {
            throw new NotImplementedException();
        }

        public void WriteEnum16<T>(T enumValue)
        {
            throw new NotImplementedException();
        }

        public void WriteEnum32<T>(T enumValue)
        {
            throw new NotImplementedException();
        }

        public void WriteUInt16(ushort value)
        {
            throw new NotImplementedException();
        }

        public void WriteUInt32(uint value)
        {
            throw new NotImplementedException();
        }

        public void WriteUnicodeString(string value)
        {
            throw new NotImplementedException();
        }
    }
}