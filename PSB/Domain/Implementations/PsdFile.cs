using System;

namespace Psb.Domain
{
    internal class PsdFile : IPsdFile
    {
        private uint _width;
        private uint _height;

        public uint Width
        {
            get => _width;
            internal set
            {
                if (value > Consts.PsdFile.MaxWidth)
                {
                    throw new ArgumentException($"Maximum width : {Consts.PsdFile.MaxWidth}");
                }

                _width = value;
            }
        }

        public uint Height
        {
            get => _height;
            internal set
            {
                if (value > Consts.PsdFile.MaxHeight)
                {
                    throw new ArgumentException($"Maximum width : {Consts.PsdFile.MaxHeight}");
                }

                _height = value;
            }
        }

        public NumberOfBitsPerChannel Depth
        {
            get;
            internal set;
        }

        public ColorMode ColorMode
        {
            get;
            internal set;
        }
    }
}
