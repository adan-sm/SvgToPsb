using Psb.Domain.Enums;
using System;
using System.Drawing;

namespace Psb.Domain.ChannelAndBitmapData
{
    internal static class DataBuilder
    {
        internal static ChannelData BuildChannelDataFromBitmap(short id, Bitmap bitmap, CompressionMode compressionMode)
        {
            switch(compressionMode)
            {
                case CompressionMode.Rle:
                case CompressionMode.ZipWithouPrediction:
                case CompressionMode.ZipWithPrediction:
                    throw new NotImplementedException();

                case CompressionMode.RawImageData:
                    return new ChannelData(CompressionMode.RawImageData, BuildChannelUncompressed(id, bitmap));
            }

            throw new InvalidOperationException();
        }

        private static byte[] BuildChannelUncompressed(short id, Bitmap bitmap)
        {
            var result = new byte[bitmap.Width * bitmap.Height];

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var idx = y * bitmap.Width + x;

                    byte value;

                    switch(id)
                    {
                        case ChannelId.AlphaId: value = pixel.A; break;
                        case ChannelId.RedId: value = pixel.R; break;
                        case ChannelId.GreenId: value = pixel.G; break;
                        case ChannelId.BlueId: value = pixel.B; break;

                        default:
                            throw new InvalidOperationException("Unkown channel id");
                    }

                    result[idx] = value;
                }
            }

            return result;
        }

        internal static ImageData BuildImageDataFromBitmap(Bitmap bitmap, CompressionMode compressionMode, ColorMode colorMode)
        {
            switch (compressionMode)
            {
                case CompressionMode.Rle:
                case CompressionMode.ZipWithouPrediction:
                case CompressionMode.ZipWithPrediction:
                    throw new NotImplementedException();

                case CompressionMode.RawImageData:
                    return new ImageData(CompressionMode.RawImageData, BuildImageDataUncompressed(bitmap, colorMode));
            }

            throw new InvalidOperationException();
        }

        private static byte[] BuildImageDataUncompressed(Bitmap bitmap, ColorMode colorMode)
        {
            switch(colorMode)
            {
                case ColorMode.CMYK:
                case ColorMode.DuoTone:
                case ColorMode.Grayscale:
                case ColorMode.Indexed:
                case ColorMode.Lab:
                case ColorMode.Multichannel:
                    throw new NotImplementedException("Color mode not implemented");
            }

            var dataSize = colorMode == ColorMode.RGB ? 3 * 8 : 4 * 8;
            var result = new byte[bitmap.Width * bitmap.Height * dataSize];

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    
                    WriteColorValue(pixel, x, y, bitmap, result, colorMode);
                }
            }

            return result;
        }

        private static void WriteColorValue(Color pixel, int x, int y, Bitmap bitmap, byte[] result, ColorMode colorMode)
        {
            var idx = y * bitmap.Width + x;

            switch(colorMode)
            {
                case ColorMode.Bitmap:
                    result[idx + 0] = pixel.R;
                    result[idx + 1] = pixel.G;
                    result[idx + 2] = pixel.B;
                    result[idx + 3] = pixel.A;
                    break;

                case ColorMode.RGB:
                    result[idx + 0] = pixel.R;
                    result[idx + 1] = pixel.G;
                    result[idx + 2] = pixel.B;
                    break;
            }
        }
    }
}
