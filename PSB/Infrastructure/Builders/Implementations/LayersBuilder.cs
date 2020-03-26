using Psb.Domain;
using System;
using System.Collections.Generic;

namespace Psb.Infrastructure.Builders.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class LayersBuilder : ILayersBuilder
    {
        private readonly Domain.IPsdFile _owner;
        private readonly List<LayerBuilder> _layersBuilder = new List<LayerBuilder>();

        public LayersBuilder(IPsdFile owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public ILayerBuilder CreateLayer()
        {
            var result = new LayerBuilder(_owner);
            
            _layersBuilder.Add(result);

            return result;
        }

        internal Domain.ILayerList GetLayers()
        {
            var result = new Domain.Implementations.LayerList();

            _layersBuilder.ForEach(l => result.Add(l.GetLayer()));

            return result;
        }

        internal IReadOnlyList<LayerBuilder> LayerBuilders => _layersBuilder.AsReadOnly();
    }
}
