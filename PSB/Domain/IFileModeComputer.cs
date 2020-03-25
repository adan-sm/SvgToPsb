namespace Psb.Domain
{
    public interface IFileModeComputer
    {
        Enums.FileMode GetFileMode(IPsdFile psdFile);
    }
}
