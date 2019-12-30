using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;


namespace Tanks
{
    class ExplosionView : GameObjectView
    {
        int n = 0;

        public override Bitmap GetBitmap()
        {
            if (n >= 500)
            {
                n = 0;
            }
            Bitmap bmp = new Bitmap(Resources.explosion.Crop(new Rectangle(0 + n, 0, 39, 39)));
            n += 39;
            return bmp;
        }
    }
}
