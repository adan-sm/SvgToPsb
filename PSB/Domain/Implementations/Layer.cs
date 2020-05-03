using Psb.Domain.ChannelAndBitmapData;
using Psb.Domain.Enums;
using System;
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

            ConstructChannels(bitmap);
        }

        private void ConstructChannels(Bitmap bitmap)
        {
            if (Owner.ColorMode == ColorMode.Bitmap)
            {
                Channels = new ChannelList
                {
                    new Channel(this, ChannelId.RedId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.RedId, bitmap, CompressionMode.RawImageData)),
                    new Channel(this, ChannelId.GreenId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.GreenId, bitmap, CompressionMode.RawImageData)),
                    new Channel(this, ChannelId.BlueId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.BlueId, bitmap, CompressionMode.RawImageData)),
                    new Channel(this, ChannelId.AlphaId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.AlphaId, bitmap, CompressionMode.RawImageData)),
                };

                return;
            }

            if (Owner.ColorMode == ColorMode.RGB)
            {
                Channels = new ChannelList
                {
                    new Channel(this, ChannelId.RedId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.RedId, bitmap, CompressionMode.RawImageData)),
                    new Channel(this, ChannelId.GreenId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.GreenId, bitmap, CompressionMode.RawImageData)),
                    new Channel(this, ChannelId.BlueId, DataBuilder.BuildChannelDataFromBitmap(ChannelId.BlueId, bitmap, CompressionMode.RawImageData)),
                };

                return;
            }

            throw new NotImplementedException();
        }

        public Bitmap GetImage()
        {
            return _image;
        }
    }
}
