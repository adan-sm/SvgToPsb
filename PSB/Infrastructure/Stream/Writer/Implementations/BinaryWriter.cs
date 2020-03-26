using System;
using System.Buffers.Binary;
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
            var data = System.Text.Encoding.ASCII.GetBytes(value);

            file.Write(data, 0, data.Length);
        }

        public void WriteBytes(byte[] value)
        {
            file.Write(value, 0, value.Length);
        }

        public void WriteEnum16<T>(T enumValue) where T : Enum
        {
            WriteUInt16(Convert.ToUInt16(enumValue));
        }

        public void WriteEnum32<T>(T enumValue) where T : Enum
        {
            WriteUInt32(Convert.ToUInt32(enumValue));
        }

        public void WriteInt16(short value)
        {
            var bytes = new byte[sizeof(short)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteInt16BigEndian(span, value);

            file.Write(bytes, 0, sizeof(short));
        }

        public void WriteInt32(int value)
        {
            var bytes = new byte[sizeof(int)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteInt32BigEndian(span, value);

            file.Write(bytes, 0, sizeof(int));
        }

        public void WriteUInt16(ushort value)
        {
            var bytes = new byte[sizeof(ushort)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteUInt16BigEndian(span, value);

            file.Write(bytes, 0, sizeof(ushort));
        }

        public void WriteUInt32(uint value)
        {
            var bytes = new byte[sizeof(uint)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteUInt32BigEndian(span, value);

            file.Write(bytes, 0, sizeof(uint));
        }

        public void WriteUnicodeString(string value)
        {
            WriteInt32(value.Length);

            var data = System.Text.Encoding.BigEndianUnicode.GetBytes(value);

            WriteBytes(data);
        }
    }
}