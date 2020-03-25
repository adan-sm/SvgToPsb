using Psb.Domain.Enums;
using System;

namespace Psb.Domain.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class FileModeComputer : IFileModeComputer
    {
        public FileMode GetFileMode(IPsdFile psdFile)
        {
            if(psdFile.Width > Consts.PsdFile.MaxRegularFileWidth) { return FileMode.BigFile; }
            if(psdFile.Height > Consts.PsdFile.MaxRegularFileHeight) { return FileMode.BigFile; }

            return FileMode.RegularFile;
        }
    }
}
