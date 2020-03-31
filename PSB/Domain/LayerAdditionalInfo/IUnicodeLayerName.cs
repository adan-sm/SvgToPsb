namespace Psb.Domain.LayerAdditionalInfo
{
    public interface IUnicodeLayerName : ILayerAdditionalInfo
    {
        ILayer Owner { get; }
    }
}