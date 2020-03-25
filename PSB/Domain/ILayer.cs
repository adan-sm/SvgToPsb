using System.Drawing;

namespace Psb.Domain
{
    public interface ILayer
    {
        string Name { get; }

        Enums.BlendModeKey BlendMode { get; }

        Rectangle Rectangle { get; }

        IPsdFile Owner { get; }

        IChannelList Channels { get; }

        void SetImage(Bitmap bitmap);
    }
}
