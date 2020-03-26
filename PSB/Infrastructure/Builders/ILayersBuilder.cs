using System.Collections;

namespace Psb.Infrastructure.Builders
{
    public interface ILayersBuilder
    {
        ILayerBuilder CreateLayer();
    }
}
