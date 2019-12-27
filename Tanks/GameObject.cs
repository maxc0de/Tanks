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

        public virtual bool Move(int dX, int dY)
        {
            if (X+dX >=0 && Y+dY >= 0 && X + sizeX +dX < Tanks.width && Y + sizeY + dY < Tanks.height)
            {
                X += dX;
                Y += dY;
                return true;
            }
            else
            {
                return false;
            }

        }
        public abstract GameObjectView GetView();
    }

    enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }
}
