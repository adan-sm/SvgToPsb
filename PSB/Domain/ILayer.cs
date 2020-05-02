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

        LayerAdditionalInfo.ILayerAdditionalInfoList LayerInformations { get; }

        Enums.LayerFlags Flags { get; }

        void SetImage(Bitmap bitmap);

        Bitmap GetImage();
    }
}
