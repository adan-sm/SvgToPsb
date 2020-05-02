using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    internal class ImageResourceWriterFactory : IImageResourceWriterFactory
    {
        public IImageResourceWriter Get(IImageResource imageResource)
        {
            switch (imageResource.Id)
            {
                case Psb.Domain.ImageResources.ImageResourcesId.PS6_VersionInfo: return new VersionInfoWriter(imageResource as Domain.ImageResources.IVersionInfo);
            }

            throw new NotImplementedException();
        }
    }
}
