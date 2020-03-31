using Psb.Domain.Enums;
using System;
using System.Drawing;
using System.Linq;

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
            LayerInformations = new LayerAdditionalInfo.LayerAdditionalInfoList();

            LayerInformations.Add(new LayerAdditionalInfo.UnicodeLayerName
            {
                Owner = this
            });
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

        public LayerFlag Flags
        {
            get;
            internal set;
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
