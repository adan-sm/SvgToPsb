using Psb.Domain.LayerAdditionalInfo;

namespace Psb.Infrastructure.Stream.Writer.LayerAdditionalInfoWriters.Implementations
{
    public class UnicodeLayerNameWriter : LayerAdditionalInfoWriter<Domain.LayerAdditionalInfo.IUnicodeLayerName>
    {
        public UnicodeLayerNameWriter(IUnicodeLayerName layerAdditionalInfo) 
            : base(layerAdditionalInfo)
        {
        }

        protected override bool LongBinaryLength => false;

        protected override void WriteInternal(IBinaryWriter binaryWriter)
        {
            binaryWriter.WriteUnicodeString(_layerAdditionalInfo.Owner.Name);
        }
    }
}
