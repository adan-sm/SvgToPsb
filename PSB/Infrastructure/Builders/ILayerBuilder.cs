using System.Drawing;

namespace Psb.Infrastructure.Builders
{
    public interface ILayerBuilder
    {
        ILayerBuilder WithName(string name);

        ILayerBuilder WithRectangle(Domain.Rectangle rectangle);

        ILayerBuilder WithImage(Bitmap bitmap);

        ILayerBuilder WithBlendMode(Domain.BlendModeKey blendMode);
    }
}
