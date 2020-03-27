namespace Psb.Infrastructure.Builders
{
    public interface IImageResourcesBuilder
    {
        IImageResourcesBuilder Add(Domain.IImageResource imageResource);

        Domain.IImageResourceList Get();
    }
}
