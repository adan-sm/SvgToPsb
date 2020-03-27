using System.Drawing;

namespace Psb.Domain
{
    public interface ILayer
    {
        string Name { get; }

        Enums.BlendModeKey BlendMode { get; }

        Rectangle Rectangle { get; }

        IPsdFile Owner { get; }

        byte Opacity { get; }

        bool Clipping { get; }

        Enums.LayerFlag Flags { get; }

        IChannelList Channels { get; }

        void SetImage(Bitmap bitmap);

        Bitmap GetImage();
    }
}
