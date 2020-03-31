using System;

namespace Psb.Infrastructure.Stream.Writer.LayerAdditionalInfoWriters.Implementations
{
    /// <summary>
    /// TODO : remove public
    /// </summary>
    public class LayerAdditionalInfoWriterFactory : ILayerAdditionalInfoWriterFactory
    {
        public ILayerAdditionalInfoWriter Get(Domain.LayerAdditionalInfo.ILayerAdditionalInfo layerAdditionalInfo)
        {
            switch (layerAdditionalInfo.Key)
            {
                case Domain.LayerAdditionalInfo.AdditionalLayerInfoType.UnicodeLayerName: return new UnicodeLayerNameWriter(layerAdditionalInfo as Domain.LayerAdditionalInfo.IUnicodeLayerName);
            }

            throw new ArgumentException("Unable to get writer");
        }
    }
}
