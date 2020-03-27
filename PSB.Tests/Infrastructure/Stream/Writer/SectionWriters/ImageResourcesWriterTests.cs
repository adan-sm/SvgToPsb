using FizzWare.NBuilder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            var (imageResources, imagesResourcesWriters, imageResourceFactory) = BuildImageResources();
            
            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.ImageResourcesWriter(binaryWriter.Object, imageResources, imageResourceFactory.Object);

            // act
            sut.Write();

            // assert
            foreach (var currentImageResource in imageResources)
            {
                imageResourceFactory.Verify(i => i.Get(currentImageResource), Moq.Times.Once());
            }

            foreach (var currentWriter in imagesResourcesWriters)
            {
                currentWriter.Verify(c => c.Write(binaryWriter.Object), Moq.Times.Once());
            }
        }

        private (Psb.Domain.Implementations.ImageResourceList imageResources,
                    IList<Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.IImageResourceWriter>> resourceWriters,
                    Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.IImageResourceWriterFactory> resourceWriterFactory)
            BuildImageResources()
        {
            var imageResources = new Psb.Domain.Implementations.ImageResourceList();
            var resourceWriters = new List<Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.IImageResourceWriter>>();
            var resourceWriterFactory = new Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.IImageResourceWriterFactory>();

            for (int i = 0; i < 10; i++)
            {
                var imageResource = new Moq.Mock<Psb.Domain.IImageResource>();

                imageResource
                    .SetupGet(ir => ir.Id)
                    .Returns((ushort)i);

                imageResource
                    .SetupGet(ir => ir.Name)
                    .Returns($"FakeName{i}");

                var writer = new Moq.Mock<Psb.Infrastructure.Stream.Writer.ImageResourceWriters.IImageResourceWriter>();

                resourceWriterFactory
                    .Setup(f => f.Get(imageResource.Object))
                    .Returns(writer.Object);

                imageResources.Add(imageResource.Object);
                resourceWriters.Add(writer);
            }

            return (imageResources, resourceWriters, resourceWriterFactory);
        }
    }
}
