using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    abstract class GameObject
    {
        public int X;
        public int Y;
        public int sizeX = 25;
        public int sizeY = 25;

        public virtual void Move(int dX, int dY)
        {
            if (X+dX >=0 && Y+dY >= 0 && X + 50 +dX < Tanks.width && Y + 50 + dY < Tanks.height)
            {
                X += dX;
                Y += dY;
            }
            else
            {
                Console.WriteLine();
            }

        }
    }

    enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }
}
