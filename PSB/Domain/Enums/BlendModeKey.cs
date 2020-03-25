using System.ComponentModel;

namespace Psb.Domain.Enums
{
    public enum BlendModeKey
    {
        [Description("pass")]
        PassThrough,
        [Description("norm")]
        Normal,
        [Description("diss")]
        Dissolve,
        [Description("dark")]
        Darken,
        [Description("mul")]
        Multiply,
        [Description("idiv")]
        ColorBurn,
        [Description("lbrn")]
        LinearBurn,
        [Description("dkCl")]
        DarkerColor,
        [Description("lite")]
        Lighten,
        [Description("scrn")]
        Screen,
        [Description("div ")]
        ColorDodge,
        [Description("lddg")]
        LinearDodge,
        [Description("lgCl")]
        LighterColor,
        [Description("over")]
        Overlay,
        [Description("sLit")]
        SoftLight,
        [Description("hLit")]
        HardLight,
        [Description("vLit")]
        VividLight,
        [Description("lLit")]
        LinearLight,
        [Description("pLit")]
        PinLight,
        [Description("hMix")]
        HardMix,
        [Description("diff")]
        Difference,
        [Description("smud")]
        Exclusion,
        [Description("fsub")]
        Subtract,
        [Description("fdiv")]
        Divide,
        [Description("hue")]
        Hue,
        [Description("sat ")]
        Saturation,
        [Description("colr")]
        Color,
        [Description("lum ")]
        Luminosity,
    }
}
