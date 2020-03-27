using Psb.Domain;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    internal interface IImageResourceWriterFactory
    {
        IImageResourceWriter Get(IImageResource imageResource);
    }
}