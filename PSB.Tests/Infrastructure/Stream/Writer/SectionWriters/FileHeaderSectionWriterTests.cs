using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.SectionWriters
{
    public class FileHeaderSectionWriterTestCase
    {
        public ushort ChannelCount { get; set; }

        public uint Width { get; set; }

        public uint Height { get; set; }

        public Psb.Domain.Enums.NumberOfBitsPerChannel Depth { get; set; }

        public Psb.Domain.Enums.ColorMode ColorMode { get; set; }

        public Psb.Domain.Enums.FileMode ExpectedMode { get; set; }
    }

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FileHeaderSectionWriterTests
    {
        // build a representative collection of psd file header
        static IEnumerable<FileHeaderSectionWriterTestCase> AllCases()
        {
            var result = new List<FileHeaderSectionWriterTestCase>();

            var widths = new uint[] { 1, 1000, 100000 };
            var heights = new uint[] { 2, 1001, 100001 };
            var channels = new ushort[] { 1, 3, 4, 10 };
            var colorModes = Enum.GetValues(typeof(Psb.Domain.Enums.ColorMode));
            var depths = Enum.GetValues(typeof(Psb.Domain.Enums.NumberOfBitsPerChannel));

            foreach (var width in widths)
            {
                foreach (var height in heights)
                {
                    foreach (var channel in channels)
                    {
                        foreach (var colorMode in colorModes)
                        {
                            foreach (var depth in depths)
                            {
                                var fileHeaderSectionWriterTestCase = new FileHeaderSectionWriterTestCase
                                {
                                    ChannelCount = channel,
                                    ColorMode = (Psb.Domain.Enums.ColorMode)colorMode,
                                    Depth = (Psb.Domain.Enums.NumberOfBitsPerChannel)depth,
                                    Height = height,
                                    Width = width,
                                    ExpectedMode = width > Psb.Domain.Consts.PsdFile.MaxRegularFileWidth || height > Psb.Domain.Consts.PsdFile.MaxRegularFileHeight ?
                                                    Psb.Domain.Enums.FileMode.BigFile : Psb.Domain.Enums.FileMode.RegularFile
                                };

                                result.Add(fileHeaderSectionWriterTestCase);
                            }
                        }
                    }
                }
            }

            return result;
        }

        [TestCaseSource(nameof(AllCases))]
        public void Write_ShouldWriteEverything_WhenCalled(FileHeaderSectionWriterTestCase fileHeaderSectionWriterTestCase)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>(Moq.MockBehavior.Strict);
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                                .With(psdFile => psdFile.ColorMode = fileHeaderSectionWriterTestCase.ColorMode)
                                .And(psdFile => psdFile.Depth = fileHeaderSectionWriterTestCase.Depth)
                                .And(psdFile => psdFile.ChannelCount = fileHeaderSectionWriterTestCase.ChannelCount)
                                .And(psdFile => psdFile.Width = fileHeaderSectionWriterTestCase.Width)
                                .And(psdFile => psdFile.Height = fileHeaderSectionWriterTestCase.Height)
                            .Build();

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.FileHeaderSectionWriter(binaryWriter.Object, psdFile);

            byte[] byteArrayWritten = null;
            List<uint> writtenUInt32 = new List<uint>();

            binaryWriter
                .Setup(b => b.WriteAsciiCharacters("8BPS"))
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteEnum16(fileHeaderSectionWriterTestCase.ExpectedMode))
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteBytes(Moq.It.IsAny<byte[]>()))
                .Callback<byte[]>(byteArray => byteArrayWritten = byteArray)
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteUInt16(fileHeaderSectionWriterTestCase.ChannelCount))
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteUInt32(Moq.It.IsAny<uint>()))
                .Callback<uint>(value => writtenUInt32.Add(value))
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteEnum16(fileHeaderSectionWriterTestCase.ColorMode))
                .Verifiable();

            binaryWriter
                .Setup(b => b.WriteEnum16(fileHeaderSectionWriterTestCase.Depth))
                .Verifiable();

            // act
            sut.Write();

            // assert
            binaryWriter.Verify();

            Assert.IsTrue(byteArrayWritten.All(b => b == 0) && byteArrayWritten.Length == 6);

            Assert.AreEqual(fileHeaderSectionWriterTestCase.Height, writtenUInt32[0]);
            Assert.AreEqual(fileHeaderSectionWriterTestCase.Width, writtenUInt32[1]);
        }
    }
}
