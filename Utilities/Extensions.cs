using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.Utilities
{
    internal static class Extensions
    {
        /// <summary>
        /// Makes the graphics object best quality (slower, but looks better).
        /// </summary>
        /// <param name="graphics"></param>
        public static void ToHighQuality(this Graphics graphics)
        {
            if (graphics.InterpolationMode == InterpolationMode.HighQualityBicubic) return; // saves 5 assigns each call

            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.PixelOffsetMode = PixelOffsetMode.Default;
        }
    }
}
