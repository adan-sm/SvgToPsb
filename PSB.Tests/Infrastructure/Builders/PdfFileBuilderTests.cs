using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Psb.Tests.Infrastructure.Builders
{
    public class LayerTestCase
    {
        public List<Domain.Rectangle> LayersRectangles { get; set; }

        public int ExpectedWidth { get; set; }

        public int ExpectedHeight { get; set; }
    }

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PdfFileBuilderTests
    {
        [Test]
        public void WithWidth_ShouldSetPsdFileWidth_WhenCalled()
        {
            // arrange
            const uint width = 0xBAD0;

            var sut = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder();

            // act
            sut.WithWidth(width);
            var result = sut.Build();

            // assert
            Assert.AreEqual(width, result.Width);
        }

        [Test]
        public void WithHeight_ShouldSetPsdFileHeight_WhenCalled()
        {
            // arrange
            const uint height = 0xBAD0;

            var sut = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder();

            // act
            sut.WithHeight(height);
            var result = sut.Build();

            // assert
            Assert.AreEqual(height, result.Height);
        }


        [TestCase(Domain.ColorMode.Bitmap)]
        [TestCase(Domain.ColorMode.CMYK)]
        [TestCase(Domain.ColorMode.DuoTone)]
        [TestCase(Domain.ColorMode.Grayscale)]
        [TestCase(Domain.ColorMode.Indexed)]
        [TestCase(Domain.ColorMode.Lab)]
        [TestCase(Domain.ColorMode.Multichannel)]
        [TestCase(Domain.ColorMode.RGB)]
        public void WithColorMode_ShouldSetPsdColorMode_WhenCalled(Psb.Domain.ColorMode colorMode)
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder();

            // act
            sut.WithColorMode(colorMode);
            var result = sut.Build();

            // assert
            Assert.AreEqual(colorMode, result.ColorMode);
        }

        [TestCase(Domain.NumberOfBitsPerChannel._1)]
        [TestCase(Domain.NumberOfBitsPerChannel._8)]
        [TestCase(Domain.NumberOfBitsPerChannel._16)]
        [TestCase(Domain.NumberOfBitsPerChannel._32)]
        public void WithDepth_ShouldSetPsdDepth_WhenCalled(Psb.Domain.NumberOfBitsPerChannel numberOfBitsPerChannel)
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder();

            // act
            sut.WithChannelDepth(numberOfBitsPerChannel);
            var result = sut.Build();

            // assert
            Assert.AreEqual(numberOfBitsPerChannel, result.Depth);
        }

        static List<LayerTestCase> LayersTestsCases = new List<LayerTestCase>
        {
            new LayerTestCase
            {
                ExpectedWidth = 0,
                ExpectedHeight = 0,
                LayersRectangles = new List<Domain.Rectangle>()
            },
            new LayerTestCase
            {
                ExpectedWidth = 10,
                ExpectedHeight = 10,
                LayersRectangles = new List<Domain.Rectangle>
                {
                    new Domain.Rectangle { Left = 0, Bottom = 0, Right = 9, Top = 9 }
                }
            },
            new LayerTestCase
            {
                ExpectedWidth = 100,
                ExpectedHeight = 100,
                LayersRectangles = new List<Domain.Rectangle>
                {
                    new Domain.Rectangle { Left = 0, Bottom = 0, Right = 9, Top = 9 },
                    new Domain.Rectangle { Left = 90, Bottom = 90, Right = 99, Top = 99 },
                }
            },
        };

        [TestCaseSource(nameof(LayersTestsCases))]
        public void WithAutomaticDimensionsFromLayers_ReturnsCorrectValue_WhenCalled(LayerTestCase layerTestsCase)
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder();
            var layers = layerTestsCase
                            .LayersRectangles
                            .Select(lt =>
                            {
                                var layer = new Moq.Mock<Domain.ILayer>();
                                layer
                                    .SetupGet(l => l.Rectangle)
                                    .Returns(lt);

                                return layer.Object;
                            });

            var layerList = new Moq.Mock<Domain.ILayerList>();
            layerList
                .Setup(ll => ll.GetEnumerator())
                .Returns(() => layers.GetEnumerator());

            sut.Layers = layerList.Object;

            // act
            sut.WithAutomaticDimensionsFromLayers();

            var result = sut.Build();

            // assert
            Assert.AreEqual(layerTestsCase.ExpectedWidth, result.Width);
            Assert.AreEqual(layerTestsCase.ExpectedHeight, result.Height);
        }
    }
}
