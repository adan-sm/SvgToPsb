using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Psb.Tests.Infrastructure.Builders
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LayerBuilderTests
    {
        [Test]
        public void Build_ShouldReturnCorrectInstance_WhenCalled()
        {
            // arrange
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                            .Build();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayerBuilder(psdFile);

            // act
            var result = sut.GetLayer();

            // assert
            Assert.IsInstanceOf<Psb.Domain.Implementations.Layer>(result);
        }

        [TestCase(Psb.Domain.Enums.BlendModeKey.Color)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.ColorBurn)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.ColorDodge)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Darken)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.DarkerColor)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Difference)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Dissolve)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Divide)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Exclusion)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.HardLight)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.HardMix)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Hue)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Lighten)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.LighterColor)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.LinearBurn)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.LinearDodge)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.LinearLight)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Luminosity)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Multiply)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Normal)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Overlay)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.PassThrough)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.PinLight)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Saturation)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Screen)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.SoftLight)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.Subtract)]
        [TestCase(Psb.Domain.Enums.BlendModeKey.VividLight)]
        public void WithBlendMode_ShouldSetBlendModeKey_WhenCalled(Psb.Domain.Enums.BlendModeKey value)
        {
            // arrange
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                            .Build();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayerBuilder(psdFile);

            // act
            sut.WithBlendMode(value);
            var result = sut.GetLayer();

            // assert
            Assert.AreEqual(value, result.BlendMode);
        }

        [Test]
        public void WithImage_ShouldSetImage_WhenCalled()
        {
            // arrange
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                            .Build();
            var bitmap = new Bitmap(10, 10);
            var sut = new Psb.Infrastructure.Builders.Implementations.LayerBuilder(psdFile);

            // act
            sut.WithImage(bitmap);
            var result = sut.GetLayer();

            // assert
            Assert.AreSame(bitmap, result.GetImage());

            bitmap.Dispose();
        }

        [Test]
        public void WithName_ShouldSetName_WhenCalled()
        {
            // arrange
            var layerName = "FakeName";
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                            .Build();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayerBuilder(psdFile);

            // act
            sut.WithName(layerName);
            var result = sut.GetLayer();

            // assert
            Assert.AreEqual(layerName, result.Name);
        }

        [Test]
        public void WithWithRectangle_ShouldSetRectangle_WhenCalled()
        {
            // arrange
            var rectangle = new Psb.Domain.Rectangle { Bottom = 1, Left = 2, Right = 3, Top = 4 };
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                            .Build();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayerBuilder(psdFile);

            // act
            sut.WithRectangle(rectangle);
            var result = sut.GetLayer();

            // assert
            Assert.AreEqual(rectangle, result.Rectangle);
        }

        [Test]
        public void Build_ShouldSetBlendModeKeyToDefaultOne_WhenCalledAndNoBlendModeHadBeenSpecified()
        {
            // arrange
            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                            .Build();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayerBuilder(psdFile);

            // act
            var result = sut.GetLayer();

            // assert
            Assert.AreEqual(Psb.Domain.Consts.Layer.DefaultBlendModeKey, result.BlendMode);
        }
    }
}
