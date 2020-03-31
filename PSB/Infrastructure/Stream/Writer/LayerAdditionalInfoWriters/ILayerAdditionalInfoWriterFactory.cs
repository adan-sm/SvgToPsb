namespace Psb.Infrastructure.Stream.Writer.LayerAdditionalInfoWriters
{
    public interface ILayerAdditionalInfoWriterFactory
    {
        ILayerAdditionalInfoWriter Get(Domain.LayerAdditionalInfo.ILayerAdditionalInfo layerAdditionalInfo);
    }
}
