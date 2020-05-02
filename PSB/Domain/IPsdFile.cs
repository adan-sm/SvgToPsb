namespace Psb.Domain
{
    public interface IPsdFile
    {
        Enums.FileMode FileMode { get; }
        uint Width { get; }
        uint Height { get; }
        ushort ChannelCount { get; }
        Enums.NumberOfBitsPerChannel Depth { get; }
        Enums.ColorMode ColorMode { get; }

        IColorModeData ColorModeData { get; }
        IImageResourceList ImageResources { get; }
        ILayerList Layers { get; }
        ILayer BaseLayer { get; }
    }
}