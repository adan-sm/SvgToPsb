namespace Psb.Domain.ImageResources
{
    public interface IVersionInfo : IImageResource
    {
        uint Version { get; }

        bool HasRealMergedData { get; }

        string ReaderName { get; }

        string WriterName { get; }

        uint FileVersion { get; }
    }
}
