using System;

namespace Psb.Infrastructure.Stream.Writer
{
    public interface IBinaryWriter
    {
        long Position { get; }

        /// <summary>
        /// Writes a unicode string, with leading size on 4 bytes
        /// </summary>
        /// <param name="value"></param>
        void WriteUnicodeString(string value);

        void WritePascalString(string value, int padMultiple);

        /// <summary>
        /// Writes an array of characters as bytes, with no leading size.
        /// Basically, it's equivalent to a WriteBytes()
        /// </summary>
        /// <param name="value"></param>
        void WriteAsciiCharacters(string value);

        void WriteByte(byte value);

        void WriteInt16(short value);

        void WriteInt32(int value);

        void WriteUInt16(ushort value);

        void WriteUInt32(uint value);

        void WriteBytes(byte[] value);

        void WriteBool(bool value);

        void WriteEnum16<T>(T enumValue) where T : Enum;

        void WriteEnum32<T>(T enumValue) where T : Enum;

        void Seek(long offset);

        void WritePadding(long startPosition, int padMultiple);
    }
}