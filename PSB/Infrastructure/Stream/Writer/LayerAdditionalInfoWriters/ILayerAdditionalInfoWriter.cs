namespace Psb.Infrastructure.Stream.Writer.LayerAdditionalInfoWriters
{
    public interface ILayerAdditionalInfoWriter
    {
        void Write(IBinaryWriter binaryWriter);
    }
}
