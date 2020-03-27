using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Psb.Tests.Infrastructure.Stream.Writer.SectionWriters
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LayerListSectionWriterTests
    {
        [TestCase(Psb.Domain.Enums.FileMode.BigFile)]
        [TestCase(Psb.Domain.Enums.FileMode.RegularFile)]
        public void Write_ShouldWriteEverythingWhenCalled(Psb.Domain.Enums.FileMode fileMode)
        {
            // arrange
            var binaryWriter = new Moq.Mock<Psb.Infrastructure.Stream.Writer.IBinaryWriter>();
            var psdFile = new Moq.Mock<Psb.Domain.IPsdFile>();
            var (layerList, layers) = BuildLayers(psdFile.Object);

            psdFile
                .SetupGet(p => p.FileMode)
                .Returns(fileMode);

            var sut = new Psb.Infrastructure.Stream.Writer.SectionWriters.Implementations.LayerListSectionWriter(binaryWriter.Object, layerList);

            // act
            sut.Write();

            // assert
            binaryWriter.Verify(b => b.WriteInt16((short)layerList.Count), Moq.Times.Once());
        }

        private (Psb.Domain.ILayerList layerList, IList<Moq.Mock<Psb.Domain.ILayer>> layers) BuildLayers(Psb.Domain.IPsdFile psdFile)
        {
            const int layerCount = 10;

            var layerList = new Psb.Domain.Implementations.LayerList { Owner = psdFile };
            var layers = new List<Moq.Mock<Psb.Domain.ILayer>>();

            for (int i = 0; i < layerCount; i++)
            {
                var layer = new Moq.Mock<Psb.Domain.ILayer>();

                layer
                    .SetupGet(l => l.Owner)
                    .Returns(psdFile);

                layers.Add(layer);
                layerList.Add(layer.Object);
            }

            return (layerList, layers);
        }
    }
}
