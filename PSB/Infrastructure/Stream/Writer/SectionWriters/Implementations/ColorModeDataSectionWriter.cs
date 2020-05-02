using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class ColorModeDataSectionWriter : IColorModeDataSectionWriter
    {
        private readonly IBinaryWriter _binaryWriter;
        private readonly Domain.IColorModeData _colorModeData;

        public ColorModeDataSectionWriter(IBinaryWriter binaryWriter, IColorModeData colorModeData)
        {
            _binaryWriter = binaryWriter ?? throw new ArgumentNullException(nameof(binaryWriter));
            _colorModeData = colorModeData ?? throw new ArgumentNullException(nameof(colorModeData));
        }

        public void Write()
        {
            switch (_colorModeData.Owner.ColorMode)
            {
                case Domain.Enums.ColorMode.DuoTone:
                case Domain.Enums.ColorMode.Indexed:
                    throw new NotImplementedException($"'{_colorModeData.Owner.ColorMode:g}' color mode is not yet implemented");
            }

            // only write length, which is 0
            _binaryWriter.WriteUInt32(0);
        }
    }
}
