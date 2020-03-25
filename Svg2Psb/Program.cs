using System;

namespace Svg2Psb
{
    class Program
    {
        static void Main(string[] args)
        {
            var psdFile = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder()
                                    .WithChannelDepth(Psb.Domain.NumberOfBitsPerChannel._8)
                                    .WithColorMode(Psb.Domain.ColorMode.RGB)
                                    .WithImagesResources(resources =>
                                       {
                                           resources
                                            .Add()
                                            .Add();
                                       })
                                    .WithLayers( builder =>
                                    {
                                        builder
                                            .CreateLayer()
                                            .WithImage(null)
                                            .WithName("Background")
                                            .WithRectangle(new Psb.Domain.Rectangle());

                                        builder
                                            .CreateLayer()
                                            .WithImage(null)
                                            .WithName("Character")
                                            .WithRectangle(new Psb.Domain.Rectangle());
                                    })
                                    .WithAutomaticDimensionsFromLayers()
                                    .Build();

            new Psb
                    .Infrastructure
                    .Stream
                    .Writer
                    .PsdFileWriter(new Psb.Infrastructure.Stream.Writer.Implementations.SectionWriterFactory())
                        .WriteToFile("file.psd", psdFile);
        }
    }
}
