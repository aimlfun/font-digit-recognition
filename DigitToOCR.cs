using Digits.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    /// <summary>
    /// Tracks the "pixels" representing the digit in the specified font.
    /// </summary>
    internal class DigitToOCR
    {
        /// <summary>
        /// This is how many bytes each pixel occupies in the track bitmap.
        /// </summary>
        const int s_bytesPerPixelDisplay = 4;
                
        /// <summary>
        /// This is the "pixel" data for the digit shape. It's grey scale, 1 double per pixel.
        /// </summary>
        internal double[] pixelsToLearn = new double[14 * 14];

        /// <summary>
        /// Create a digit to "OCR".
        /// </summary>
        /// <param name="digit"></param>
        /// <param name="fontName"></param>
        internal DigitToOCR(int digit, string fontName)
        {
            pixelsToLearn = BitmapGetImage(digit, fontName, out _);
        }

        /// <summary>
        /// Paints the digit on a 14x14 image, centered.
        /// </summary>
        /// <param name="digit"></param>
        /// <param name="fontName"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        internal static double[] BitmapGetImage(int digit, string fontName, out Bitmap image )
        {
            using Font font = new(fontName, 10);

            float imgSize = 14;
            
            image = new((int)imgSize, (int)imgSize);
            
            using Graphics g = Graphics.FromImage(image);
            g.Clear(Color.Black);

            // center the "digit" on the image
            SizeF size = g.MeasureString(digit.ToString(), font);
            GetRealSize(digit, font, size, out PointF offset);

            g.DrawString(digit.ToString(), font, Brushes.White, new PointF(imgSize / 2 - size.Width / 2 - offset.X, imgSize / 2 - size.Height / 2 - offset.Y));

            g.Flush();

            // enable us to see what it has created
            image.Save($@"c:\temp\digits\{digit}-{fontName}.png");

            return AIPixelsFromImage(image);
        }

        /// <summary>
        /// Correct for the fact size isn't accurate, when it comes to centering. It has descending/ascending parts, leading to some very off center.
        /// We measure with pixel accuracy.
        /// </summary>
        /// <param name="digit"></param>
        /// <param name="font"></param>
        /// <param name="size"></param>
        /// <param name="offset"></param>
        internal static void GetRealSize(int digit, Font font, SizeF size, out PointF offset)
        {
            using Bitmap image = new((int)Math.Round(size.Width), (int)Math.Round(size.Height));

            using Graphics g = Graphics.FromImage(image);
            g.Clear(Color.Black);

            g.DrawString(digit.ToString(), font, Brushes.White, new PointF(0,0));

            g.Flush();

            PointF min = new(int.MaxValue, int.MaxValue);
            PointF max = new(0, 0);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    // x,y within bounds we already know, skip checking pixels
                    if ((x >= min.X && x <= max.X) &&
                        (y >= min.Y && y <= max.Y)) continue;

                    {
                        if (image.GetPixel(x, y).R != 0) // 0 = background, 255 for r,g,b = white
                        {
                            if (x < min.X) min.X = x;
                            if (x > max.X) max.X = x;
                            if (y < min.Y) min.Y = y;
                            if (y > max.Y) max.Y = y;
                        }
                    }
                }
            }

            offset = new PointF((max.X + min.X) / 2F - (float)size.Width / 2F, (max.Y + min.Y) / 2F - (float) size.Height / 2F);
        }
        
        /// <summary>
        /// We need all 196 pixels (14px * 14px) as a byte array to input into AI.
        /// </summary>
        internal static byte[] CopyImageOfVideoDisplayToAnAccessibleInMemoryArray(Bitmap img)
        {
            if (img is null) throw new ArgumentNullException(nameof(img), "image should be populated before calling this."); // can't cache what has been drawn!

            Bitmap? s_srcDisplayBitMap = img;
         
            BitmapData?  s_srcDisplayMapData = s_srcDisplayBitMap.LockBits(new Rectangle(0, 0, s_srcDisplayBitMap.Width, s_srcDisplayBitMap.Height), ImageLockMode.ReadOnly, img.PixelFormat);

            IntPtr s_srcDisplayMapDataPtr = s_srcDisplayMapData.Scan0;

            int s_strideDisplay = s_srcDisplayMapData.Stride;

            int s_totalLengthDisplay = Math.Abs(s_strideDisplay) * s_srcDisplayBitMap.Height;

            byte[] s_rgbValuesDisplay = new byte[s_totalLengthDisplay];

            System.Runtime.InteropServices.Marshal.Copy(s_srcDisplayMapDataPtr, s_rgbValuesDisplay, 0, s_totalLengthDisplay);

            s_srcDisplayBitMap.UnlockBits(s_srcDisplayMapData);

            return s_rgbValuesDisplay;
        }

        /// <summary>
        /// Returns ALL the pixels as a "double" array. The element containing a 1 has the ball.
        /// </summary>
        /// <returns></returns>
        internal static double[] AIPixelsFromImage(Bitmap image)
        {
            double[] pixels = new double[14 * 14];

            byte[] s_rgbValuesDisplay = DigitToOCR.CopyImageOfVideoDisplayToAnAccessibleInMemoryArray(image);

            // convert 4 bytes per pixel to 1. (ARGB). Pixels are 255 R, 255 G, 255 B, 255 Alpha. We don't need to check all.
            // There is a simple "grey-scale" algorithm (RGB get different weightings), but we're doing black/white.
            for (int i = 0; i < pixels.Length; i++)
            {
                //float pixel = 1F - (float)s_rgbValuesDisplay[i * s_bytesPerPixelDisplay] / 255;
                float pixel = (float)s_rgbValuesDisplay[i * s_bytesPerPixelDisplay] / 255;
                pixels[i] = pixel;
            }

            return pixels;
        }

        internal static double[] BitmapGetImage(Image sourceImage, out Bitmap scaledImage)
        {
            float imgSize = 14;

            scaledImage = (Bitmap) Utils.ResizeImage(sourceImage, (int) imgSize, (int)imgSize);

            // enable us to see what it has created
            scaledImage.Save($@"c:\temp\digits\hand-written.png");

            return AIPixelsFromImage(scaledImage);
        }
    }
}
