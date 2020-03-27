namespace Psb.Infrastructure.Stream.Writer
{
    internal interface IPaddingComputer
    {
        int GetPadding(long length, int padMultiple);
    }
}
