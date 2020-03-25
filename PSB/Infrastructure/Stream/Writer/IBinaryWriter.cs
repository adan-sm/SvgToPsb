namespace Psb.Infrastructure.Stream.Writer
{
    public interface IBinaryWriter
    {
        void WriteAsciiString(string value);

        void WriteUnicodeString(string value);

        void WriteAsciiCharacters(string value);

        void WriteUInt16(ushort value);

        void WriteUInt32(uint value);

        void WriteBytes(byte[] value);

        void WriteEnum16<T>(T enumValue);

        void WriteEnum32<T>(T enumValue);
    }
}