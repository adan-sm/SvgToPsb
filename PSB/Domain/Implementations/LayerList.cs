using System;
using System.Collections.Generic;
using System.Text;

namespace Psb.Domain.Implementations
{
    /// <summary>
    /// TODO : remove public
    /// </summary>
    public class LayerList : List<ILayer>, ILayerList
    {
        public LayerList(IPsdFile owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public IPsdFile Owner
        {
            get;
        }
    }
}
