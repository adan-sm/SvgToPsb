using Psb.Domain;
using Psb.Domain.Implementations;
using System;
using System.Drawing;
using System.Linq;

namespace Psb.Infrastructure.Builders.Implementations
{
    // TODO : change to Internal
    public class PsdFileBuilder : IPsdFileBuilder
    {
        private SizePolicyConfig _sizePolicy;

        private Action<ILayersBuilder> _layersBuilderAction;
        private Action<IImageResourcesBuilder> _imageResourcesBuilderAction;

        private uint _width = Consts.PsdFile.MinWidth;
        private uint _height = Consts.PsdFile.MinHeight;
        private Domain.Enums.ColorMode _colorMode;
        private Domain.Enums.NumberOfBitsPerChannel _depth;

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

            _colorMode = Consts.PsdFile.DefaultColorMode;
            _depth = Consts.PsdFile.DefaultDepth;
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

        public IPsdFileBuilder WithChannelDepth(Domain.Enums.NumberOfBitsPerChannel depth)
        {
            _depth = depth;

            return this;
        }

        public IPsdFileBuilder WithColorMode(Domain.Enums.ColorMode colorMode)
        {
            _colorMode = colorMode;

            return this;
        }

        public IPsdFileBuilder WithImagesResources(Action<IImageResourcesBuilder> setup)
        {
            _imageResourcesBuilderAction = setup;

            return this;
        }

        public IPsdFileBuilder WithLayers(Action<ILayersBuilder> builder)
        {
            _layersBuilderAction = builder;

            return this;
        }

        public IPsdFileBuilder WithAutomaticDimensionsFromLayers()
        {
            SizePolicy = SizePolicyConfig.AutomaticAccordingToLayer;

            return this;
        }

        private (uint width, uint height) ComputeSize(Domain.ILayerList layers)
        {
            if (layers == null || !layers.Any())
            {
                throw new InvalidOperationException("No layer in the file");
            }

            var mergedRectangle = new Domain.Rectangle();

            foreach (var currentLayer in layers)
            {
                mergedRectangle = Domain.Rectangle.Merge(mergedRectangle, currentLayer.Rectangle);
            }

            return ((uint)mergedRectangle.Right, (uint)mergedRectangle.Bottom);
        }

        public IPsdFile Build()
        {
            var result = new PsdFile();

            var layers = GetLayers(result);

            if (SizePolicy == SizePolicyConfig.AutomaticAccordingToLayer)
            {
                var dimensions = ComputeSize(layers);

                result.Width = dimensions.width;
                result.Height = dimensions.height;
            }
            else
            {
                result.Width = _width;
                result.Height = _height;
            
            }

            result.ChannelCount = _colorMode == Domain.Enums.ColorMode.Bitmap ? (ushort)4 :
                                    _colorMode == Domain.Enums.ColorMode.RGB ? (ushort)3 :
                                        throw new NotImplementedException();
            result.Depth = _depth;
            result.ColorMode = _colorMode;
            result.ColorModeData = new Domain.Implementations.ColorModeData { Owner = result };

            result.ImageResources = GetImageResources();
            result.Layers = layers;

            result.BaseLayer = ConstructBaseLayer(result);

            return result;
        }

        private ILayer ConstructBaseLayer(PsdFile result)
        {
            using (var globalImage = new Bitmap((int)result.Width, (int)result.Height))
            {
                using (var g = Graphics.FromImage(globalImage))
                {

                }

                var builder = new LayerBuilder(result)
                                .WithImage(globalImage)
                                .WithName("global")
                                as LayerBuilder;
                
                return builder.GetLayer();
            }
        }

        private IImageResourceList GetImageResources()
        {
            if (_imageResourcesBuilderAction != null)
            {
                var imageResourceBuilder = new Implementations.ImageResourcesBuilder();
                _imageResourcesBuilderAction(imageResourceBuilder);

                return imageResourceBuilder.Get();
            }

            return new ImageResourceList();
        }

        private ILayerList GetLayers(PsdFile result)
        {
            if (Layers != null)
            {
                return Layers;
            }
            else if (_layersBuilderAction != null)
            {
                var layersBuilder = new LayersBuilder(result);
                _layersBuilderAction(layersBuilder);

                return layersBuilder.GetLayers();
            }

            return new Domain.Implementations.LayerList(result);
        }

        // test purposes only
        internal IImageResourceList ImageResourceList
        {
            get;
            set;
        }

        // test purposes only
        internal ILayerList Layers
        {
            get;
            set;
        }
    }
}
