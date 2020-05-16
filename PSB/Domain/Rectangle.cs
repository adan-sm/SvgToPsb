using System;

namespace Psb.Domain
{
    public struct Rectangle
    {
        public Rectangle(int top,
                         int left,
                         int width,
                         int height)
        {
            Top = top;
            Left = left;
            Bottom = top + height;
            Right = left + width;
        }

        public int Top { get; }

        public int Left { get; }

        public int Bottom { get; }

        public int Right { get; }

        public static Rectangle Merge(Rectangle r1, Rectangle r2)
        {
            var t = Math.Min(r1.Top, r2.Top);
            var l = Math.Min(r1.Left, r2.Left);
            var b = Math.Max(r1.Bottom, r2.Bottom);
            var r = Math.Max(r1.Right, r2.Right);

            return new Rectangle(t, l, b, r);
        }
    }
}
