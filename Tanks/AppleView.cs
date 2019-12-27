﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    class AppleView : GameObjectView
    {
        Bitmap bmp = new Bitmap(Resources.apple);

        public override Bitmap GetBitmap()
        {
            return bmp;
        }
    }
}
