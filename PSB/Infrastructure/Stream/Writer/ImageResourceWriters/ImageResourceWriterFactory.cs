using Psb.Domain;
using System;

namespace Psb.Infrastructure.Stream.Writer.ImageResourceWriters
{
    internal class ImageResourceWriterFactory : IImageResourceWriterFactory
    {
        public ImageResourceWriter Get(IImageResource imageResource)
        {
            switch(imageResource.Id)
            {
                case Psb.Domain.ImageResources.ImageResourcesId.PS6_VersionInfo: return new VersionInfoWriter(imageResource);
            }

            throw new NotImplementedException();
        }
    }
}
