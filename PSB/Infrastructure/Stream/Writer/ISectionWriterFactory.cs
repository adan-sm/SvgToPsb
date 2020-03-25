namespace Psb.Infrastructure.Stream.Writer
{
    public interface ISectionWriterFactory
    {
        ISectionWriter<T> Get<T>(IBinaryWriter binaryWriter, T section);
    }
}
