using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Builders
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LayersBuilderTests
    {
        [Test]
        public void GetLayers_ShouldReturnEmptyLayerList_WhenCalledWithNoLayerCreated()
        {
            // arrange
            var psdFile = new Psb.Domain.PsdFile();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayersBuilder(psdFile);

            // act
            var result = sut.GetLayers();

            // assert
            Assert.IsInstanceOf<Psb.Domain.Implementations.LayerList>(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void CreateLayer_ShouldAddOneLayerBuilderAndReturnsIt_WhenCalled()
        {
            // arrange
            var psdFile = new Psb.Domain.PsdFile();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayersBuilder(psdFile);

            // act
            var result = sut.CreateLayer();

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(sut.LayerBuilders.Count == 1);
            Assert.IsInstanceOf<Psb.Infrastructure.Builders.Implementations.LayerBuilder>(result);
            Assert.AreEqual(result, sut.LayerBuilders[0]);
        }

        [Test]
        public void GetLayers_ShouldReturnLayerListWithCorectPsdFileOwner_WhenCalledWithLayersAdded()
        {
            // arrange
            var psdFile = new Psb.Domain.PsdFile();
            var sut = new Psb.Infrastructure.Builders.Implementations.LayersBuilder(psdFile);
            sut.CreateLayer();

            // act
            var result = sut.GetLayers();

            // assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Psb.Domain.Implementations.LayerList>(result);
            Assert.IsTrue(result.Count == 1);
            Assert.IsNotNull(result[0]);
            Assert.AreSame(psdFile, result[0].Owner);
        }
    }
}
