using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Tank : GameObject
    {
        public Direction direction;

        private int dY = 1;
        private int dX = 1;

        int i = 0;

        public Tank(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Move()
        {
            if (i == 50)
            {
                direction = (Direction)Tanks.randomNum.Next(0, 4);
                i = 0;
            }
            else
            {
                i++;
            }


            Move(direction);
        }
        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    Move(0, -dY);
                    break;
                case Direction.Left:
                    Move(-dX, 0);
                    break;
                case Direction.Down:
                    Move(0, dY);
                    break;
                case Direction.Right:
                    Move(dX, 0);
                    break;
            }
        }
        public TankView GetView()
        {
            return new TankView(direction);
        }
    }
}
