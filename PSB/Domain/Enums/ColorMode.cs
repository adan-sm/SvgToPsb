namespace Psb.Domain
{
    public enum ColorMode : ushort
    {
        Bitmap = 0,
        Grayscale = 1,
        Indexed = 2,
        RGB = 3,
        CMYK = 4,
        Multichannel = 7,
        DuoTone = 8,
        Lab = 9
    }
}
