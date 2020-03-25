using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer
{
    public class PsdFileWriter
    {
        private readonly ISectionWriterFactory _sectionWriterFactory;

        public PsdFileWriter(ISectionWriterFactory sectionWriterFactory)
        {
            _sectionWriterFactory = sectionWriterFactory ?? throw new ArgumentNullException(nameof(sectionWriterFactory));
        }

        public void WriteToFile(string filePath, IPsdFile psdFile)
        {
            using (var file = System.IO.File.Create(filePath))
            {
                using (var binaryWriter = new BinaryWriter(file))
                {
                    WriteHeader(binaryWriter, psdFile);
                    WriteColorMode(binaryWriter, psdFile);
                    WriteImageResources(binaryWriter, psdFile);
                    WriteLayers(binaryWriter, psdFile);
                    WriteImageData(binaryWriter, psdFile);
                }
            }
        }

        private void WriteHeader(IBinaryWriter binaryWriter, IPsdFile psdFile)
        {
            var headerSectionWriter = _sectionWriterFactory.Get(binaryWriter, psdFile);
            headerSectionWriter.Write();
        }

        private void WriteColorMode(IBinaryWriter binaryWriter, IPsdFile psdFile)
        {
            var colorModeDataSectionWriter = _sectionWriterFactory.Get(binaryWriter, psdFile.ColorModeData);
            colorModeDataSectionWriter.Write();
        }

        private void WriteImageResources(IBinaryWriter binaryWriter, IPsdFile psdFile)
        {
            var imageResourcesSectionWriter = _sectionWriterFactory.Get(binaryWriter, psdFile.ImageResources);
            imageResourcesSectionWriter.Write();
        }

        private void WriteLayers(IBinaryWriter binaryWriter, IPsdFile psdFile)
        {
            throw new NotImplementedException();
        }

        private void WriteImageData(IBinaryWriter binaryWriter, IPsdFile psdFile)
        {
            throw new NotImplementedException();
        }
    }
}
