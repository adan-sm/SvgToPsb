using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.SectionWriters
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ColorModeDataSectionWriterTests
    {
        [TestCase(Psb.Domain.Enums.ColorMode.Bitmap)]
        [TestCase(Psb.Domain.Enums.ColorMode.CMYK)]
        [TestCase(Psb.Domain.Enums.ColorMode.Grayscale)]
        [TestCase(Psb.Domain.Enums.ColorMode.Lab)]
        [TestCase(Psb.Domain.Enums.ColorMode.Multichannel)]
        [TestCase(Psb.Domain.Enums.ColorMode.RGB)]
        public void Write_ShouldWriteEverything_WhenCalledWithNotIndexedNorDuoToneColorMode(Psb.Domain.Enums.ColorMode colorMode)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>(Moq.MockBehavior.Strict);
            var colorModeData = new Moq.Mock<Psb.Domain.IColorModeData>();

            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                                .With(psdFile => psdFile.ColorMode = colorMode)
                                .With(psdFile => psdFile.ColorModeData = colorModeData.Object)
                            .Build();

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.ColorModeDataSectionWriter(binaryWriter.Object, colorModeData.Object);

            
            
            colorModeData
                .SetupGet(colorMode => colorMode.Owner)
                .Returns(psdFile);

            binaryWriter
                .Setup(b => b.WriteUInt32(0))
                .Verifiable();

            // act
            sut.Write();

            // assert
            binaryWriter.Verify();
        }

        [TestCase(Psb.Domain.Enums.ColorMode.DuoTone)]
        [TestCase(Psb.Domain.Enums.ColorMode.Indexed)]
        public void Write_ShouldThrowNotImplementedException_WhenCalledWithIndexedOrDuotoneColorMode(Psb.Domain.Enums.ColorMode colorMode)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>(Moq.MockBehavior.Strict);
            var colorModeData = new Moq.Mock<Psb.Domain.IColorModeData>();

            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                                .With(psdFile => psdFile.ColorMode = colorMode)
                                .With(psdFile => psdFile.ColorModeData = colorModeData.Object)
                            .Build();

            colorModeData
                .SetupGet(colorMode => colorMode.Owner)
                .Returns(psdFile);

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.ColorModeDataSectionWriter(binaryWriter.Object, colorModeData.Object);
            var method = new TestDelegate(() => sut.Write());

            // act
            var result = Assert.Throws<NotImplementedException>(method);

            // assert
            Assert.IsTrue(result.Message.StartsWith($"'{colorMode:g}' color mode is not yet implemented"));
        }
    }
}
