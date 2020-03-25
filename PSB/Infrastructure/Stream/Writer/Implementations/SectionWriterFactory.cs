using System;

namespace Psb.Infrastructure.Stream.Writer.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class SectionWriterFactory : ISectionWriterFactory
    {
        public ISectionWriter<T> Get<T>(IBinaryWriter binaryWriter, T section)
        {
            throw new NotImplementedException();
        }
    }
}
