using System;
using System.IO;

namespace Psb.Infrastructure.Stream.Writer
{
    class BinaryWriter : IDisposable, IBinaryWriter
    {
        private FileStream file;

        public BinaryWriter(FileStream file)
        {
            this.file = file;
        }

        public void Dispose()
        {
            file.Dispose();
        }
    }
}