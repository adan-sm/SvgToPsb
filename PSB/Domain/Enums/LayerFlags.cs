using System;

namespace Psb.Domain.Enums
{
    [Flags]
    public enum LayerFlags
    {
        None,
        TransparencyProtection = None,
        Visibility,
        Obsolete,
        Bit4IsRelevant,
        PixelDataIrrelevantToDocumentAppearance
    }
}
