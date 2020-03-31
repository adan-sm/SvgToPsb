using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.ImageResourceWriters
{
    public class FakeImageResource : Psb.Domain.IImageResource
    {
        public ushort Id { get; set; }

        public string Name { get; set; }
    }

    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImageResourceWriterTests
    {
        [Test]
        public void Write_ShouldWriteBasicInformation_WhenCalled()
        {
            // arrange
            var imageResourceId = (ushort)0xFAC7;
            var imageResourceName = "FakeName";

            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var imageResource = new FakeImageResource
            {
                Id = imageResourceId,
                Name = imageResourceName
            };

            var sut = new Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.ImageResourceWriter<FakeImageResource>>(imageResource);

            // act
            sut.Object.Write(binaryWriter.Object);

            // assert
            binaryWriter.Verify(b => b.WriteAsciiCharacters("8BIM"), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteUInt16(imageResourceId), Moq.Times.Once());
            binaryWriter.Verify(b => b.WritePascalString(imageResourceName, 2, true), Moq.Times.Once());

            // TODO : verify BlockLengthWriter is called
            sut.Verify(s => s.WriteInternal(binaryWriter.Object), Moq.Times.Once());
            binaryWriter.Verify(b => b.WritePadding(Moq.It.IsAny<long>(), 2), Moq.Times.Once());
        }
    }
}
