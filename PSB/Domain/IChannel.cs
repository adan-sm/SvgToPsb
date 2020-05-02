namespace Psb.Domain
{
    public interface IChannel
    {

        ILayer Owner { get; }
    }
}
