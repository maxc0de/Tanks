using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Kolobok : GameObject
    {
        private int dY = 1;
        private int dX = 1;

        public Direction direction;

        public Kolobok(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Move(Direction dir)
        {
            direction = dir;
            switch (dir)
            {
                case Direction.Up:
                    Y -= dY;
                    break;
                case Direction.Left:
                    X -= dX;
                    break;
                case Direction.Down:
                    Y += dY;
                    break;
                case Direction.Right:
                    X += dX;
                    break;
            }
        }
        public KolobokView GetView()
        {
            return new KolobokView(direction);
        }
    }
}
