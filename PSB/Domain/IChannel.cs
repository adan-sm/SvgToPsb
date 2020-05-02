namespace Psb.Domain
{
    public interface IChannel
    {
        ILayer Owner { get; }

        // TODO : implement ChannelId type
        ushort Id { get;  }
    }
}
