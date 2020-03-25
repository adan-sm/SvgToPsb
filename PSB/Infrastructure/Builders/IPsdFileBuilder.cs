using Psb.Domain;
using System;

namespace Psb.Infrastructure.Builders
{
    public interface IPsdFileBuilder
    {
        IPsdFile Build();
        IPsdFileBuilder WithChannelDepth(Domain.Enums.NumberOfBitsPerChannel depth);
        IPsdFileBuilder WithHeight(uint height);
        IPsdFileBuilder WithColorMode(Domain.Enums.ColorMode colorMode);
        IPsdFileBuilder WithWidth(uint width);
        IPsdFileBuilder WithAutomaticDimensionsFromLayers();
        IPsdFileBuilder WithImagesResources(Action<IImageResourcesBuilder> setup);
        IPsdFileBuilder WithLayers(Action<ILayersBuilder> builder);
    }
}