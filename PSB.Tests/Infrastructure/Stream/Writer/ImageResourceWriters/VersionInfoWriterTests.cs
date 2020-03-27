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
            uint version = 0xBADE;
            uint fileVersion = 0xDABE;
            var hasRealMergeData = true;
            var writerName = "fakeWriter";
            var readerName = "fakeReader";

            var imageResource = new Moq.Mock<Psb.Domain.ImageResources.IVersionInfo>();

            imageResource
                .SetupGet(b => b.FileVersion)
                .Returns(fileVersion);

            imageResource
                .SetupGet(b => b.Version)
                .Returns(version);

            imageResource
                .SetupGet(b => b.HasRealMergedData)
                .Returns(hasRealMergeData);

            imageResource
                .SetupGet(b => b.WriterName)
                .Returns(writerName);

            imageResource
                .SetupGet(b => b.ReaderName)
                .Returns(readerName);

            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var sut = new Psb.Infrastructure.Stream.Writer.ImageResourceWriters.VersionInfoWriter(imageResource.Object);

            // act
            sut.WriteInternal(binaryWriter.Object);

            // assert
            binaryWriter.Verify(b => b.WriteBool(hasRealMergeData), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteUInt32(version), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteUnicodeString(writerName), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteUnicodeString(readerName), Moq.Times.Once());
            binaryWriter.Verify(b => b.WriteUInt32(fileVersion), Moq.Times.Once());
        }
    }
}
