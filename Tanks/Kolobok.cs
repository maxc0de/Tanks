using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Kolobok : GameObject
    {
        public Kolobok(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override void Move(int dX, int dY)
        {
            X += dX;
            Y += dY;
        }
    }
}
