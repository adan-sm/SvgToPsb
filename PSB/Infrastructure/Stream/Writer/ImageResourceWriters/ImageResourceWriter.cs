namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters

{
    internal abstract class ImageResourceWriter : IImageResourceWriter
    {
        public void Write(IBinaryWriter binaryWriter)
        {
            
        }

        protected abstract void WriteInternal(IBinaryWriter binaryWriter);
    }
}
