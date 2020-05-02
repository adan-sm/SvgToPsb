namespace Psb.Domain.ImageResources.Implementations
{
    /// <summary>
    /// TODO : remove public
    /// </summary>
    public class VersionInfo : IVersionInfo
    {
        public static IVersionInfo CreateDefaultVersionInfo()
        {
            var version = System.Reflection.Assembly.GetAssembly(typeof(VersionInfo)).GetName().Version;
            var writerName = $"Svg2Psb {version.Major}.{version.Minor}.{version.Build}";

            return new VersionInfo
            {
                Version = (uint)version.Major,
                FileVersion = (uint)version.Major,
                HasRealMergedData = false,
                Name = string.Empty,
                ReaderName = string.Empty,
                WriterName = writerName
            };
        }

        public ushort Id => ImageResourcesId.PS6_VersionInfo;

        public uint Version
        {
            get;
            internal set;
        }

        public bool HasRealMergedData
        {
            get;
            internal set;
        }

        public string ReaderName
        {
            get;
            internal set;
        }

        public string WriterName
        {
            get;
            internal set;
        }

        public uint FileVersion
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }
    }
}
