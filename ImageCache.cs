using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SonarSNKRS
{
    class ImageCache
    {
        public Image BitmapImage { get; private set; }
        public string StyleCode { get; private set; }

        public ImageCache(Image bitmap, string styleCode)
        {
            BitmapImage = bitmap;
            StyleCode = styleCode;
        }
    }
}
