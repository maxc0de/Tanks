using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class WallView : GameObjectView
    {
        Bitmap bmp;
        public WallView(int sizeX, int sizeY)
        {
            bmp = new Bitmap(sizeX, sizeY);

            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.FillRectangle(Brushes.BurlyWood, 0, 0, sizeX, sizeY);
            }
        }
        public override Bitmap GetBitmap()
        {
            return bmp;
        }
    }
}
