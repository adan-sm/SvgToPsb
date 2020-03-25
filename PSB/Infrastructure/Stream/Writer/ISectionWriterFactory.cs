namespace Psb.Infrastructure.Stream.Writer
{
    public interface ISectionWriterFactory
    {
        ISectionWriter Get<T>(IBinaryWriter binaryWriter, T section);
    }
}
