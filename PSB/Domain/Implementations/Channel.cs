using Psb.Domain.ChannelAndBitmapData;
using System;

namespace Psb.Domain.Implementations
{
    public class Channel : IChannel
    {
        internal Channel(ILayer owner, ushort id, ChannelData channelData)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Id = id;
            ChannelData = channelData ?? throw new ArgumentNullException(nameof(channelData));
        }

        public ILayer Owner { get; }

        public ushort Id { get; }

        internal ChannelData ChannelData { get; }
    }
}
