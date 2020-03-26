using Psb.Domain;
using Psb.Domain.Enums;
using System;
using System.Drawing;

namespace Psb.Infrastructure.Builders.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class LayerBuilder : ILayerBuilder
    {
        private readonly Domain.IPsdFile _owner;
        private BlendModeKey _blendModeKey;
        private string _name;
        private Domain.Rectangle _rectangle;
        private Bitmap _bitmap;

        public LayerBuilder(IPsdFile owner)
        {
            _blendModeKey = Consts.Layer.DefaultBlendModeKey;

            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public ILayerBuilder WithBlendMode(BlendModeKey blendMode)
        {
            _blendModeKey = blendMode;

            return this;
        }

        public ILayerBuilder WithImage(Bitmap bitmap)
        {
            _bitmap = bitmap;

            return this;
        }

        public ILayerBuilder WithName(string name)
        {
            _name = name;

            return this;
        }

        public ILayerBuilder WithRectangle(Domain.Rectangle rectangle)
        {
            _rectangle = rectangle;

            return this;
        }

        internal Domain.ILayer GetLayer()
        {
            var result = new Domain.Implementations.Layer
            {
                BlendMode = _blendModeKey,
                Name = _name,
                Rectangle = _rectangle,
                Owner = _owner
            };

            result.SetImage(_bitmap);

            return result;
        }
    }
}
