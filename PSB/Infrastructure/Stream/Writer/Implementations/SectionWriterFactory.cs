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
                case IPsdFile psdFile:                  return new SectionWriters.Implementations.FileHeaderSectionWriter(binaryWriter, psdFile);
                case IColorModeData colorModeData:      return new SectionWriters.Implementations.ColorModeDataSectionWriter(binaryWriter, colorModeData);
                case IImageResourceList imageResources: return new SectionWriters.Implementations.ImageResourcesWriter(binaryWriter, imageResources);
            }

            throw new ArgumentException("Unable to get a section writer for given type");
        }
    }
}
