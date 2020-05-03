using Psb.Infrastructure.Builders;
using System;
using System.Drawing;

namespace Svg2Psb
{
    class Program
    {
        static void Main(string[] args)
        {
            using var background = new Bitmap(200, 200);
            using (var graphics = Graphics.FromImage(background))
            {
                graphics.Clear(Color.CornflowerBlue);
            }

            using var character = new Bitmap(180, 180);
            using (var graphics = Graphics.FromImage(character))
            {
                graphics.Clear(Color.Transparent);
                graphics.FillEllipse(Brushes.MediumVioletRed, new Rectangle(0, 0, 180, 180));
            }

            var psdFile = new Psb.Infrastructure.Builders.Implementations.PsdFileBuilder()
                            .WithChannelDepth(Psb.Domain.Enums.NumberOfBitsPerChannel._8)
                            .WithColorMode(Psb.Domain.Enums.ColorMode.RGB)
                            .WithImagesResources(resources =>
                            {
                                resources
                                 .AddDefaultVersionInfo();
                            })
                            .WithLayers(builder =>
                            {
                                builder
                                    .CreateLayer()
                                    .WithImage(background)
                                    .WithName("Background")
                                    .WithRectangle(new Psb.Domain.Rectangle());

                                builder
                                    .CreateLayer()
                                    .WithImage(character)
                                    .WithName("Characteré")
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
