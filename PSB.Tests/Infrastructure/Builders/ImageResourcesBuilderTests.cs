using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Builders
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImageResourcesBuilderTests
    {
        private Moq.Mock<Psb.Domain.IImageResource> BuildImageResource(ushort id)
        {
            var result = new Moq.Mock<Psb.Domain.IImageResource>();

            result
                .SetupGet(r => r.Id)
                .Returns(id);

            return result;
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhenCalledTwiceWithTheSameImageResource()
        {
            // arrange
            var id = (ushort)0xFA4E;
            var sut = new Psb.Infrastructure.Builders.Implementations.ImageResourcesBuilder();
            var resource1 = BuildImageResource(id);
            var resource2 = BuildImageResource(id);

            // act
            sut.Add(resource1.Object);
            var result = Assert.Throws<InvalidOperationException>(() => sut.Add(resource2.Object));

            // assert
            Assert.AreEqual($"There is already a {id} resource", result.Message);
        }

        [Test]
        public void Add_ShouldArgumentNullOperationException_WhenCalledWithNullImageResource()
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.ImageResourcesBuilder();

            // act
            var result = Assert.Throws<ArgumentNullException>(() => sut.Add(null));

            // assert
            Assert.AreEqual("imageResource", result.ParamName);
        }

        [Test]
        public void Add_ShouldAddAnImageResource_WhenCalled()
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.ImageResourcesBuilder();
            var resource1 = BuildImageResource(1);

            // act
            sut.Add(resource1.Object);

            // assert
            Assert.IsTrue(sut.ImageResources.Count == 1);
            Assert.AreSame(resource1.Object, sut.ImageResources[0]);
        }

        [Test]
        public void Get_ShouldReturnAnEmptyList_WhenCalledWithNoImageResourceAdded()
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.ImageResourcesBuilder();

            // act
            var result = sut.Get();

            // assert
            Assert.IsInstanceOf<Psb.Domain.Implementations.ImageResourceList>(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public void Get_ShouldReturnAList_WhenCalledWith1ImageResourceAdded()
        {
            // arrange
            var sut = new Psb.Infrastructure.Builders.Implementations.ImageResourcesBuilder();
            var resource1 = BuildImageResource(1);

            sut.Add(resource1.Object);

            // act
            var result = sut.Get();

            // assert
            Assert.IsInstanceOf<Psb.Domain.Implementations.ImageResourceList>(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreSame(resource1.Object, result[0]);
        }
    }
}
