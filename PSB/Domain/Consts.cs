namespace Psb.Domain
{
    public static class Consts
    {
        public static class PsdFile
        {
            public const uint MinWidth = 1;
            public const uint MinHeight = 1;

            public const uint MaxWidth = 300000;
            public const uint MaxHeight = 300000;

            public const uint MaxRegularFileWidth = 30000;
            public const uint MaxRegularFileHeight = 30000;

            public const ushort MinChannelCount = 1;
            public const ushort MaxChannelCount = 56;

            public const Enums.ColorMode DefaultColorMode = Enums.ColorMode.Bitmap;
            public const Enums.NumberOfBitsPerChannel DefaultDepth = Enums.NumberOfBitsPerChannel._8;
        }
    }
}
