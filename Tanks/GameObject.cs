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

        public virtual void Move(int dX, int dY)
        {
            X += dX;
            Y += dY;
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
