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
                Rectangle rectangle = new Rectangle(0, 0, sizeX, sizeY);
                gr.FillRectangle(Brushes.DarkRed, rectangle);
                gr.DrawRectangle(new Pen(Color.White, 2), rectangle);
            }
        }
        public override Bitmap GetBitmap()
        {
            return bmp;
        }
    }
}
