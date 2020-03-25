namespace Psb.Domain
{
    /// <summary>
    /// Compute a file mode based on a psd file
    /// </summary>
    public interface IFileModeComputer
    {
        Enums.FileMode GetFileMode(IPsdFile psdFile);
    }
}
