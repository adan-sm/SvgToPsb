using Psb.Domain.Enums;
using System.Drawing;

namespace Psb.Domain.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class Layer : ILayer
    {
        private Bitmap _image;

        public Layer()
        {
            LayerInformations = new LayerAdditionalInfo.LayerAdditionalInfoList
            {
                new LayerAdditionalInfo.UnicodeLayerName
                {
                    Owner = this
                }
            };

            Visible = true;
        }

        public string Name
        {
            get;
            internal set;
        }

        public BlendModeKey BlendMode
        {
            get;
            internal set;
        }

        public Rectangle Rectangle
        {
            get;
            internal set;
        }

        public IPsdFile Owner
        {
            get;
            internal set;
        }

        public IChannelList Channels
        {
            get;
            internal set;
        }

        public byte Opacity
        {
            get;
            internal set;
        }

        public bool Clipping
        {
            get;
            internal set;
        }

        public LayerFlags Flags
        {
            get;
            internal set;
        }

        public bool Visible
        {
            get => Flags.HasFlag(LayerFlags.Visibility);
            set
            {
                if (value)
                {
                    Flags |= LayerFlags.Visibility;
                }
                else
                {
                    Flags &= ~LayerFlags.Visibility;
                }
            }
        }

        public LayerAdditionalInfo.ILayerAdditionalInfoList LayerInformations
        {
            get;
            internal set;
        }

        public void SetImage(Bitmap bitmap)
        {
            _image = bitmap;
        }

        public Bitmap GetImage()
        {
            return _image;
        }
    }
}
