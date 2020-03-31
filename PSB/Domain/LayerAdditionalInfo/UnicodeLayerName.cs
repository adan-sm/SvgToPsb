namespace Psb.Domain.LayerAdditionalInfo
{
    /// <summary>
    /// TODO : remove public
    /// </summary>
    public class UnicodeLayerName : IUnicodeLayerName
    {
        public AdditionalLayerInfoType Key => AdditionalLayerInfoType.UnicodeLayerName;

        public ILayer Owner
        {
            get;
            internal set;
        }
    }
}
