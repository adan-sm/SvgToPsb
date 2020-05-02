using System;

namespace Psb.Infrastructure.Stream.Writer.Implementations
{
    internal class PaddingComputer : IPaddingComputer
    {
        public int GetPadding(long length, int padMultiple)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length must be >= 0", nameof(length));
            }

            if (padMultiple < 1)
            {
                throw new ArgumentException("Pad multiple must be > 0", nameof(padMultiple));
            }

            var remainder = length % padMultiple;
            if (remainder == 0)
            {
                return 0;
            }

            var padding = padMultiple - remainder;
            return (int)padding;
        }
    }
}
