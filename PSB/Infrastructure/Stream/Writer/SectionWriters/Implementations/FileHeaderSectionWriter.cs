using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class FileHeaderSectionWriter : IFileHeaderSectionWriter
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly IPsdFile _psdFile;

        public FileHeaderSectionWriter(IBinaryWriter binaryWriter, IPsdFile psdFile)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _psdFile = psdFile ?? throw new ArgumentNullException(nameof(psdFile));
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
