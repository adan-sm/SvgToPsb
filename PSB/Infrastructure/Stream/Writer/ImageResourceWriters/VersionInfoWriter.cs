namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    internal class VersionInfoWriter : ImageResourceWriter<Psb.Domain.ImageResources.IVersionInfo>
    {
        public VersionInfoWriter(Psb.Domain.ImageResources.IVersionInfo imageResource) : base(imageResource)
        {
        }

        protected internal override void WriteInternal(IBinaryWriter binaryWriter)
        {
            binaryWriter.WriteUInt32(_imageResource.Version);
            binaryWriter.WriteBool(_imageResource.HasRealMergedData);
            binaryWriter.WriteUnicodeString(_imageResource.WriterName);
            binaryWriter.WriteUnicodeString(_imageResource.ReaderName);
            binaryWriter.WriteUInt32(_imageResource.FileVersion);
        }
    }
}
