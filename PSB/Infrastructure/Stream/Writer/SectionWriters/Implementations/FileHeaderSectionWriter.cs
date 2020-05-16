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
            _binaryWriter.WriteAsciiCharacters("8BPS");
            _binaryWriter.WriteEnum16(_psdFile.FileMode);
            _binaryWriter.WriteBytes(new byte[6]);
            _binaryWriter.WriteUInt16(_psdFile.ChannelCount);
            _binaryWriter.WriteInt32((int)_psdFile.Width);
            _binaryWriter.WriteInt32((int)_psdFile.Height);
            _binaryWriter.WriteEnum16(_psdFile.Depth);
            _binaryWriter.WriteEnum16(_psdFile.ColorMode);
        }
    }
}
