using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.SectionWriters
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImageResourcesWriterTests
    {
        [Test]
        public void Write_ShouldWriteAllImageResources_WhenCalled()
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var imageResources = new Moq.Mock<Psb.Domain.IImageResourceList>();

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.ImageResourcesWriter(binaryWriter.Object, imageResources.Object);

            // act
            sut.Write();

            // assert

        }
    }
}
