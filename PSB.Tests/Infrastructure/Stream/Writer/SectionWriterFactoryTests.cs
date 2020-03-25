using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SectionWriterFactoryTests
    {
        [Test]
        public void Get_ShouldReturnFileHeaderSectionWriter_WhenCalledWithPsdFile()
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();
            var psdFile = Moq.Mock.Of<Psb.Domain.IPsdFile>();
            var binaryWriter = Moq.Mock.Of<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();

            // act
            var result = sut.Get(binaryWriter, psdFile);

            // assert
            Assert.IsInstanceOf<Psb.Infrastructure.Stream.Writer.SectionWriters.IFileHeaderSectionWriter>(result);
        }

        [Test]
        public void Get_ShouldThrownArgumentException_WhenCalledWithObject()
        {
            // arrange
            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();
            var obj = new object();
            var binaryWriter = Moq.Mock.Of<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var method = new TestDelegate(() => sut.Get(binaryWriter, obj));

            // act
            var result = Assert.Throws<ArgumentException>(method);

            // assert
            Assert.IsTrue(result.Message.StartsWith("Unable to get a section writer for given type"));
        }
    }
}
