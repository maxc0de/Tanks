using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    class AppleView
    {
        Bitmap bmp = new Bitmap(Resources.apple);

        public Bitmap GetBitmap()
        {
            return bmp;
        }
    }
}
