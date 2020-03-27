using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.SectionWriters
{
    public class LayerSectionWriterTestCase
    {
        public Psb.Domain.Rectangle Rectangle { get; set; }

        public Psb.Domain.Enums.BlendModeKey BlendMode { get; set; }

        public Psb.Domain.Enums.LayerFlag Flags { get; set; }
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
                var testCase = new LayerSectionWriterTestCase
                {
                    BlendMode = (Psb.Domain.Enums.BlendModeKey)blendMode
                };

                testCases.Add(testCase);
            }

            return testCases;
        }

        [TestCaseSource(nameof(GetTests))]
        public void Write_ShouldWriteEverythin_WhenCalled(LayerSectionWriterTestCase testCase)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var layer = new Moq.Mock<Psb.Domain.ILayer>();

            layer
                .SetupGet(l => l.BlendMode)
                .Returns(testCase.BlendMode);

            layer
                .SetupGet(l => l.Rectangle)
                .Returns(testCase.Rectangle);

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.LayerSectionWriter(binaryWriter.Object, layer.Object);

            // act
            sut.Write();

            // assert
            binaryWriter.Verify(b => b.WriteRectangle(testCase.Rectangle), Moq.Times.Once());
            // TODO : channel writer
            binaryWriter.Verify(b => b.WriteAsciiCharacters("8BIM"), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteAsciiCharacters(testCase.BlendMode.Description()), Moq.Times.Once());
        }
    }
}
