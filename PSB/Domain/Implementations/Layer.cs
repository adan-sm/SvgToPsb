﻿using Psb.Domain.Enums;
using System;
using System.Drawing;

namespace Psb.Domain.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class Layer : ILayer
    {
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

        public void SetImage(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
    }
}
