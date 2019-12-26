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

        public abstract void Move(int dX, int dY);
    }
}
