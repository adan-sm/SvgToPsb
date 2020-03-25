using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class SectionWriterFactory : ISectionWriterFactory
    {
        public ISectionWriter Get<T>(IBinaryWriter binaryWriter, T section)
        {
            switch(section)
            {
                case IPsdFile psdFile: return new SectionWriters.Implementations.FileHeaderSectionWriter(binaryWriter, psdFile);
            }

            throw new ArgumentException("Unable to get a section writer for given type");
        }
    }
}
