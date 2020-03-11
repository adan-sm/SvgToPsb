using Psb.Domain;
using System;
using System.Linq;

namespace Psb.Infrastructure.Builders.Implementations
{
    // TODO : change to Internal
    public class PsdFileBuilder : IPsdFileBuilder
    {
        private SizePolicyConfig _sizePolicy;
        private Domain.IImageResourceList _imageRessources;
        private Domain.ILayerList _layers;

        private uint _width;
        private uint _height;
        private ColorMode _colorMode;
        private NumberOfBitsPerChannel _depth;

        enum SizePolicyConfig
        {
            NotSpecified,
            ManuelSet,
            AutomaticAccordingToLayer
        }

        SizePolicyConfig SizePolicy
        {
            get => _sizePolicy;
            set
            {
                if (_sizePolicy != SizePolicyConfig.NotSpecified && _sizePolicy != value)
                {
                    throw new InvalidOperationException("Size cannot be specified this way");
                }

                _sizePolicy = value;
            }
        }

        public PsdFileBuilder()
        {
            _sizePolicy = SizePolicyConfig.NotSpecified;
            _colorMode = ColorMode.RGB;
            _depth = NumberOfBitsPerChannel._8;
        }

        public IPsdFileBuilder WithWidth(uint width)
        {
            _width = width;

            SizePolicy = SizePolicyConfig.ManuelSet;

            return this;
        }

        public IPsdFileBuilder WithHeight(uint height)
        {
            _height = height;

            SizePolicy = SizePolicyConfig.ManuelSet;

            return this;
        }

        public IPsdFileBuilder WithChannelDepth(NumberOfBitsPerChannel depth)
        {
            _depth = depth;

            return this;
        }

        public IPsdFileBuilder WithColorMode(ColorMode colorMode)
        {
            _colorMode = colorMode;

            return this;
        }

        public IPsdFileBuilder WithImagesResources(Action<IImageResourcesBuilder> setup)
        {
            IImageResourcesBuilder imageResourcesBuilder = new ImageResourcesBuilder();

            setup(imageResourcesBuilder);

            _imageRessources = imageResourcesBuilder.Get();

            return this;
        }

        public IPsdFileBuilder WithLayers(Action<ILayersBuilder> builder)
        {
            

            return this;
        }

        public IPsdFileBuilder WithAutomaticDimensionsFromLayers()
        {
            SizePolicy = SizePolicyConfig.AutomaticAccordingToLayer;

            return this;
        }

        private (uint width, uint height) ComputeSize()
        {
            if (_layers == null || !_layers.Any()) { return (0, 0); }

            var mergedRectangle = new Rectangle();

            foreach (var currentLayer in _layers)
            {
                mergedRectangle = Rectangle.Merge(mergedRectangle, currentLayer.Rectangle);
            }

            return ((uint)mergedRectangle.Right + 1, (uint)mergedRectangle.Bottom + 1);
        }

        public IPsdFile Build()
        {
            var result = new PsdFile();

            if (SizePolicy == SizePolicyConfig.AutomaticAccordingToLayer || SizePolicy == SizePolicyConfig.NotSpecified)
            {
                var dimensions = ComputeSize();

                result.Width = dimensions.width;
                result.Height = dimensions.height;
            }
            else
            {
                result.Width = _width;
                result.Height = _height;
            }

            result.Depth = _depth;
            result.ColorMode = _colorMode;

            return result;
        }

        // test purposes only
        internal IImageResourceList ImageResourceList
        {
            set => _imageRessources = value;
        }

        // test purposes only
        internal ILayerList Layers
        {
            set => _layers = value;
        }
    }
}
