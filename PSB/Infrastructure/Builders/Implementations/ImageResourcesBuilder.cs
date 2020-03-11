using Psb.Domain;

namespace Psb.Infrastructure.Builders.Implementations
{
    // TODO : change to internal
    public class ImageResourcesBuilder : IImageResourcesBuilder
    {
        public IImageResourcesBuilder Add()
        {

            return this;
        }

        public IImageResourceList Get()
        {
            return null;
        }
    }
}
