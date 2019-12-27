using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    class KolobokView
    {
        Bitmap bmp = new Bitmap(Resources.kolobok);
        public RotateFlipType rt;

        public KolobokView(Direction direction)
        {
            switch(direction)
            {
                case Direction.Down:
                    rt = RotateFlipType.Rotate180FlipNone;
                    break;
                case Direction.Left:
                    rt = RotateFlipType.Rotate270FlipNone;
                    break;
                case Direction.Right:
                    rt = RotateFlipType.Rotate90FlipNone;
                    break;
            }
        }

        public Bitmap GetBitmap()
        {
            bmp.RotateFlip(rt);

            return bmp;
        }
    }
}
