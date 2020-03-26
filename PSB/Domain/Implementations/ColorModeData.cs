namespace Psb.Domain.Implementations
{
    /// <summary>
    /// TODO : remove "public"
    /// </summary>
    public class ColorModeData : IColorModeData
    {
        public IPsdFile Owner
        {
            get;
            internal set;
        }
    }
}
