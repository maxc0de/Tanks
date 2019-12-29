using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class KolobokView : GameObjectView
    {
        Bitmap bmp = new Bitmap(Resources.kolobok);
        public RotateFlipType rt;

        public  KolobokView(Direction direction)
        {
            switch(direction)
            {
                case Direction.Down:
                    //bmp = new Bitmap(Resources.kolobok_full.Crop(new Rectangle(76,0,38,38)));
                    rt = RotateFlipType.Rotate180FlipNone;
                    break;
                case Direction.Left:
                    //bmp = new Bitmap(Resources.kolobok_full.Crop(new Rectangle(114, 0, 38, 38)));
                    rt = RotateFlipType.Rotate270FlipNone;
                    break;
                case Direction.Right:
                    //bmp = new Bitmap(Resources.kolobok_full.Crop(new Rectangle(38, 0, 38, 38)));
                    rt = RotateFlipType.Rotate90FlipNone;
                    break;
            }
        }

        public override Bitmap GetBitmap()
        {
            bmp.RotateFlip(rt);

            return bmp;
        }
    }
}
