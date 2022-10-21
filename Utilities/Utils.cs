using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Utilities
{
    internal static class Utils
    {
        /// <summary>
        /// Resizes an image.
        /// </summary>
        /// <param name="canvasWidth"></param>
        /// <param name="canvasHeight"></param>
        /// <returns></returns>
        internal static Image ResizeImage(Image image, int canvasWidth, int canvasHeight)
        {
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            Image thumbnail = new Bitmap(canvasWidth, canvasHeight); // changed parm names
            using (Graphics graphic = Graphics.FromImage(thumbnail))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;

                // Figure out the ratio
                double ratioX = canvasWidth / (double)originalWidth;
                double ratioY = canvasHeight / (double)originalHeight;

                double ratio = ratioX < ratioY ? ratioX : ratioY; // use whichever multiplier is smaller

                // now we can get the new height and width
                int newHeight = Convert.ToInt32(originalHeight * ratio);
                int newWidth = Convert.ToInt32(originalWidth * ratio);

                // Now calculate the X,Y position of the upper-left corner 
                // (one of these will always be zero)
                int posX = Convert.ToInt32((canvasWidth - originalWidth * ratio) / 2);
                int posY = Convert.ToInt32((canvasHeight - originalHeight * ratio) / 2);

                graphic.Clear(Color.Transparent); // white padding
                graphic.DrawImage(image, posX, posY, newWidth, newHeight);
            }

            return thumbnail;
        }
    }
}
