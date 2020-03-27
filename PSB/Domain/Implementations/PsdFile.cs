using Psb.Domain.Enums;
using System;

namespace Psb.Domain
{
    internal class PsdFile : IPsdFile
    {
        private readonly IFileModeComputer _fileModeComputer;

        private uint _width;
        private uint _height;
        private ushort _channelCount;

        public PsdFile() 
            : this(null)
        {
        }

        public PsdFile(IFileModeComputer fileModeComputer)
        {
            _fileModeComputer = fileModeComputer ?? new Implementations.FileModeComputer();
        }

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

        public Enums.NumberOfBitsPerChannel Depth
        {
            get;
            internal set;
        }

        public Enums.ColorMode ColorMode
        {
            get;
            internal set;
        }

        public ushort ChannelCount
        {
            get => _channelCount;
            internal set
            {
                if (value < Consts.PsdFile.MinChannelCount)
                {
                    throw new ArgumentException($"Minimum channel count : {Consts.PsdFile.MinChannelCount}");
                }

                if (value > Consts.PsdFile.MaxChannelCount)
                {
                    throw new ArgumentException($"Maximum channel count : {Consts.PsdFile.MaxChannelCount}");
                }

                _channelCount = value;
            }
        }

        public IColorModeData ColorModeData
        {
            get;
            internal set;
        }

        public IImageResourceList ImageResources
        {
            get;
            internal set;
        }

        public FileMode FileMode => _fileModeComputer.GetFileMode(this);

        public ILayerList Layers
        {
            get;
            internal set;
        }

        public ILayer BaseLayer
        {
            get;
            internal set;
        }
    }
}
