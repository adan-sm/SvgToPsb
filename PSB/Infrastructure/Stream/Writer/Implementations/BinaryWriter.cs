using Psb.Domain;
using System;
using System.Buffers.Binary;
using System.IO;

namespace Psb.Infrastructure.Stream.Writer
{
    internal class BinaryWriter : IDisposable, IBinaryWriter
    {
        private readonly FileStream _file;
        private readonly IPaddingComputer _paddingComputer;

        public BinaryWriter(FileStream file)
            : this(file, null)
        {

        }

        public BinaryWriter(FileStream file, IPaddingComputer paddingComputer)
        {
            _file = file;
            _paddingComputer = paddingComputer ?? new Implementations.PaddingComputer();
        }

        public long Position => _file.Position;

        public void Dispose()
        {
            _file.Dispose();
        }

        public void WriteAsciiCharacters(string value)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(value);

            _file.Write(data, 0, data.Length);
        }

        public void WriteBytes(byte[] value)
        {
            _file.Write(value, 0, value.Length);
        }

        public void WriteEnum16<T>(T enumValue) where T : Enum
        {
            WriteUInt16(Convert.ToUInt16(enumValue));
        }

        public void WriteEnum32<T>(T enumValue) where T : Enum
        {
            WriteUInt32(Convert.ToUInt32(enumValue));
        }

        public void WriteByte(byte value)
        {
            _file.WriteByte(value);
        }

        public void WriteInt16(short value)
        {
            var bytes = new byte[sizeof(short)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteInt16BigEndian(span, value);

            _file.Write(bytes, 0, sizeof(short));
        }

        public void WriteInt32(int value)
        {
            var bytes = new byte[sizeof(int)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteInt32BigEndian(span, value);

            _file.Write(bytes, 0, sizeof(int));
        }

        public void WriteUInt16(ushort value)
        {
            var bytes = new byte[sizeof(ushort)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteUInt16BigEndian(span, value);

            _file.Write(bytes, 0, sizeof(ushort));
        }

        public void WriteUInt32(uint value)
        {
            var bytes = new byte[sizeof(uint)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteUInt32BigEndian(span, value);

            _file.Write(bytes, 0, sizeof(uint));
        }

        public void WriteUInt64(ulong value)
        {
            var bytes = new byte[sizeof(ulong)];
            var span = new Span<byte>(bytes);

            BinaryPrimitives.WriteUInt64BigEndian(span, value);

            _file.Write(bytes, 0, sizeof(ulong));
        }

        public void WriteBool(bool value)
        {
            _file.WriteByte(Convert.ToByte(value));
        }

        public void WriteUnicodeString(string value)
        {
            WriteInt32(value.Length);

            var data = System.Text.Encoding.BigEndianUnicode.GetBytes(value);

            WriteBytes(data);
        }

        public void WritePascalString(string value, int padMultiple = 2)
        {
            if (value.Length > byte.MaxValue)
            {
                throw new ArgumentException($"'{value}' length is too long, max {byte.MaxValue}");
            }

            var position = _file.Position;
            var length = (byte)value.Length;
            var bytes = System.Text.Encoding.ASCII.GetBytes(value);

            WriteByte(length);
            WriteBytes(bytes);
            WritePadding(position, padMultiple);
        }

        public void Seek(long offset)
        {
            _file.Seek(offset, SeekOrigin.Begin);
        }

        public void WritePadding(long startPosition, int padMultiple)
        {
            var length = _file.Position - startPosition;
            var padding = _paddingComputer.GetPadding(length, padMultiple);

            for (int i = 0; i < padding; i++)
            {
                WriteByte(0);
            }
        }

        public void WriteRectangle(Rectangle rectangle)
        {
            WriteInt32(rectangle.Top);
            WriteInt32(rectangle.Left);
            WriteInt32(rectangle.Bottom);
            WriteInt32(rectangle.Right);
        }

        public void WriteFillers(int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                WriteByte(0);
            }
        }
    }
}