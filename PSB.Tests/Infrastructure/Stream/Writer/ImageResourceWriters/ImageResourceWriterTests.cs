using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.ImageResourceWriters
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImageResourceWriterTests
    {
        [Test]
        public void Write_ShouldWriteBasicInformation_WhenCalled()
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var imageResource = new Moq.Mock<Psb.Domain.IImageResource>();

            var imageResourceId = (ushort)0xFAC7;
            var imageResourceName = "FakeName";

            imageResource
                .SetupGet(i => i.Id)
                .Returns(imageResourceId);

            imageResource
                .SetupGet(i => i.Name)
                .Returns(imageResourceName);

            var sut = new Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.ImageResourceWriter>(imageResource.Object);

            // act
            sut.Object.Write(binaryWriter.Object);

            // assert
            binaryWriter.Verify(b => b.WriteAsciiCharacters("8BIM"), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteUInt16(imageResourceId), Moq.Times.Once());
            binaryWriter.Verify(b => b.WritePascalString(imageResourceName), Moq.Times.Once());

            sut.Verify(s => s.WriteInternal(binaryWriter.Object), Moq.Times.Once());
        }
    }
}
