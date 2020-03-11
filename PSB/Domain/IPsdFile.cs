namespace Psb.Domain
{
    public interface IPsdFile
    {
        uint Width { get; }
        uint Height { get; }
        NumberOfBitsPerChannel Depth { get; }
        ColorMode ColorMode { get; }
    }
}