using System.Collections.Generic;

namespace Psb.Domain
{
    public interface ILayerList : IList<ILayer>
    {
        IPsdFile Owner { get; }
    }
}
