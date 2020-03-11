using System;
using System.Collections.Generic;
using System.Text;

namespace Psb.Domain
{
    public interface IChannel
    {

        ILayer Owner { get; }
    }
}
