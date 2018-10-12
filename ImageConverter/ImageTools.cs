using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConverter
{
    class ImageTools
    {
        public static byte GetGrayScale(byte r, byte g, byte b)
        {
            return (byte)Math.Floor(0.21 * r + 0.72 * g + 0.07 * b);
        }

        public static byte[,] LoadBitmap(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,] pixels = new byte[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    //bool isBlack = (color.R <255 || color.G <255 || color.B <255);
                    bool isBlack = GetGrayScale(color.R, color.G, color.B) < 127;
                    pixels[i, j] = (isBlack ? (byte)1 : (byte)0);
                }
            return pixels;
        }

        public static byte[,] ResizeImage(byte[,] origPixels, int newWidth, int newHeight)
        {
            byte[,] newPixels = new byte[newHeight, newWidth];
            int widthScale = origPixels.GetLength(1) / newWidth;
            int heightScale = origPixels.GetLength(0) / newHeight;
            for (int i = 0; i < newHeight; i++)
            {
                for (int j = 0; j < newWidth; j++)
                {
                    int sum = 0;
                    for (int ii = i * heightScale; ii < (i + 1) * heightScale; ii++)
                    {
                        for (int jj = j * widthScale; jj < (j + 1) * widthScale; jj++)
                        {
                            sum += origPixels[ii, jj];
                        }
                    }
                    if (sum >= widthScale * heightScale)
                        newPixels[i, j] = 1;
                    else
                        newPixels[i, j] = 0;
                }
            }
            return newPixels;
        }

        public static byte[,] ResizeImageCentered(byte[,] pixels, int newWidth, int newHeight)
        {
            byte[,] pixelsNew = new byte[newHeight, newWidth];
            for (int i = 0; i < pixelsNew.GetLength(0); i++)
                for (int j = 0; j < pixelsNew.GetLength(1); j++)
                    pixelsNew[i, j] = 0;
            int width = newWidth;
            int height = newHeight;
            bool needsCentering = false;
            if (height > newWidth)
            {
                height = newWidth;
                needsCentering = true;
            }
            byte[,] pixelsScaled = ResizeImage(pixels, width, height);
            int heightShift = 0;
            if (needsCentering)
                heightShift = (newHeight - newWidth) / 2;
            for (int i = 0; i < pixelsScaled.GetLength(0); i++)
                for (int j = 0; j < pixelsScaled.GetLength(1); j++)
                    pixelsNew[i + heightShift, j] = pixelsScaled[i, j];
            return pixelsNew;
        }

        public static string ConvertToText(byte[,] pixels)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    sb.Append(pixels[i, j].ToString());
                }
                sb.Append("\r\n");
            }

            return sb.ToString();
        }
    }
}
