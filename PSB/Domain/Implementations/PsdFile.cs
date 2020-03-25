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
                if (value < Consts.PsdFile.MinWidth)
                {
                    throw new ArgumentException($"Minimum width : {Consts.PsdFile.MinWidth}");
                }

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
                if (value < Consts.PsdFile.MinHeight)
                {
                    throw new ArgumentException($"Minimum height : {Consts.PsdFile.MinHeight}");
                }

                if (value > Consts.PsdFile.MaxHeight)
                {
                    throw new ArgumentException($"Maximum height : {Consts.PsdFile.MaxHeight}");
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

        public IColorModeData ColorModeData => throw new NotImplementedException();

        public IImageResourceList ImageResources => throw new NotImplementedException();
    }
}
