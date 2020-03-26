namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    interface IImageResourceWriter
    {
        void Write(IBinaryWriter binaryWriter);
    }
}
