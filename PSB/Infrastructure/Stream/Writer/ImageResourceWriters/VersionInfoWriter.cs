using Psb.Domain;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    internal class VersionInfoWriter : ImageResourceWriter
    {
        public VersionInfoWriter(IImageResource imageResource) : base(imageResource)
        {
        }

        protected internal override void WriteInternal(IBinaryWriter binaryWriter)
        {
            
        }
    }
}
