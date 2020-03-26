using Psb.Domain;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    internal interface IImageResourceWriterFactory
    {
        ImageResourceWriter Get(IImageResource imageResource);
    }
}