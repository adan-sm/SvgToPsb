namespace Psb.Infrastructure.Builders
{
    public interface IImageResourcesBuilder
    {
        IImageResourcesBuilder Add();

        Domain.IImageResourceList Get();
    }
}
