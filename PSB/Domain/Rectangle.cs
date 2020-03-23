using System;

namespace Psb.Domain
{
    public struct Rectangle
    {
        public int Top { get; set; }

        public int Left { get; set; }

        public int Bottom { get; set; }

        public int Right { get; set; }

        public static Rectangle Merge(Rectangle r1, Rectangle r2)
        {
            var t = Math.Min(r1.Top, r2.Top);
            var l = Math.Min(r1.Left, r2.Left);
            var b = Math.Max(r1.Bottom, r2.Bottom);
            var r = Math.Max(r1.Right, r2.Right);

            return new Rectangle
            {
                Top = t,
                Left = l,
                Bottom = b,
                Right = r,
            };
        }
    }
}
