using FizzWare.NBuilder;
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
            var psdFile = Moq.Mock.Of<Psb.Domain.IPsdFile>();
            var binaryWriter = Moq.Mock.Of<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();

            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();

            // act
            var result = sut.Get(binaryWriter, psdFile);

            // assert
            Assert.IsInstanceOf<Psb.Infrastructure.Stream.Writer.SectionWriters.IFileHeaderSectionWriter>(result);
        }

        [Test]
        public void Get_ShouldReturnColorModeDataSectionWriter_WhenCalledWithColorModeData()
        {
            // arrange
            var binaryWriter = Moq.Mock.Of<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var colorModeData = new Moq.Mock<Psb.Domain.IColorModeData>();

            var psdFile = Builder<Psb.Domain.PsdFile>
                            .CreateNew()
                                .With(psdFile => psdFile.ColorModeData = colorModeData.Object)
                            .Build();

            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();

            // act
            var result = sut.Get(binaryWriter, psdFile.ColorModeData);

            // assert
            Assert.IsInstanceOf<Psb.Infrastructure.Stream.Writer.SectionWriters.IColorModeDataSectionWriter>(result);
        }

        [Test]
        public void Get_ShouldReturnImageResourcesSectionWriter_WhenCalledWithImageResources()
        {
            // arrange
            var binaryWriter = Moq.Mock.Of<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var imageResources = Moq.Mock.Of<Psb.Domain.IImageResourceList>();
                        
            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();

            // act
            var result = sut.Get(binaryWriter, imageResources);

            // assert
            Assert.IsInstanceOf<Psb.Infrastructure.Stream.Writer.SectionWriters.IImageResourcesWriter>(result);
        }

        [Test]
        public void Get_ShouldThrowArgumentException_WhenCalledWithObject()
        {
            // arrange
            var obj = new object();
            var binaryWriter = Moq.Mock.Of<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();

            var sut = new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory();

            var method = new TestDelegate(() => sut.Get(binaryWriter, obj));

            // act
            var result = Assert.Throws<ArgumentException>(method);

            // assert
            Assert.IsTrue(result.Message.StartsWith("Unable to get a section writer for given type"));
        }
    }
}
