using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.ImageResourceWriters
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VersionInfoWriterTests
    {
        [Test]
        public void Write_ShouldWriteEverything_WhenCalled()
        {
            // arrange
            var imageResource = Psb.Domain.ImageResources.Implementations.VersionInfo.CreateDefaultVersionInfo();

            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var sut = new Psb.Infrastructure.Stream.Writer.ImageResourceWriters.VersionInfoWriter(imageResource);

            // act
            sut.WriteInternal(binaryWriter.Object);

            // assert
            
        }
    }
}
