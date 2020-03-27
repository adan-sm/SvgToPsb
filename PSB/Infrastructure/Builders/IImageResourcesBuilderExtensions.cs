namespace Psb.Infrastructure.Builders
{
    public static class IImageResourcesBuilderExtensions
    {
        public static IImageResourcesBuilder AddDefaultVersionInfo(this IImageResourcesBuilder imageResourcesBuilder)
        {
            var result = Psb.Domain.ImageResources.Implementations.VersionInfo.CreateDefaultVersionInfo();

            imageResourcesBuilder.Add(result);

            return imageResourcesBuilder;
        }
    }
}
