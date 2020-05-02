using NUnit.Framework;
using Psb.Domain.LayerAdditionalInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.SectionWriters
{
    public class LayerSectionWriterTestCase
    {
        public Psb.Domain.Rectangle Rectangle { get; set; }

        public Psb.Domain.Enums.BlendModeKey BlendMode { get; set; }

        public Psb.Domain.Enums.LayerFlags Flags { get; set; }

        public bool Clipping { get; set; }

        public byte Opacity { get; set; }
    }

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LayerSectionWriterTests
    {
        static IEnumerable<LayerSectionWriterTestCase> GetTests()
        {
            var testCases = new List<LayerSectionWriterTestCase>();

            var blendModes = Enum.GetValues(typeof(Psb.Domain.Enums.BlendModeKey));

            foreach (var blendMode in blendModes)
            {
                for (int opacity = 0; opacity < byte.MaxValue; opacity += 100)
                {
                    var testCase = new LayerSectionWriterTestCase
                    {
                        BlendMode = (Psb.Domain.Enums.BlendModeKey)blendMode,
                        Rectangle = new Psb.Domain.Rectangle { Bottom = 0, Top = 1, Left = 2, Right = 3 },
                        Opacity = (byte)opacity,
                        Clipping = true,
                    };

                    testCases.Add(testCase);
                }
            }

            return testCases;
        }

        [TestCaseSource(nameof(GetTests))]
        public void Write_ShouldWriteEverything_WhenCalled(LayerSectionWriterTestCase testCase)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var layer = new Moq.Mock<Psb.Domain.ILayer>();

            layer
                .SetupGet(l => l.BlendMode)
                .Returns(testCase.BlendMode);

            layer
                .SetupGet(l => l.Opacity)
                .Returns(testCase.Opacity);

            layer
                .SetupGet(l => l.Clipping)
                .Returns(testCase.Clipping);

            layer
                .SetupGet(l => l.Rectangle)
                .Returns(testCase.Rectangle);

            layer
                .SetupGet(l => l.LayerInformations)
                .Returns(new LayerAdditionalInfoList());

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.LayerSectionWriter(binaryWriter.Object, layer.Object);

            // act
            sut.Write();

            // assert
            binaryWriter.Verify(b => b.WriteRectangle(testCase.Rectangle), Moq.Times.Once());
            // TODO : channel writer
            binaryWriter.Verify(b => b.WriteAsciiCharacters("8BIM"), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteAsciiCharacters(testCase.BlendMode.Description()), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteByte(testCase.Opacity), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteBool(testCase.Clipping), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteEnumByte(testCase.Flags), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteFillers(1), Moq.Times.Once());
        }
    }
}
