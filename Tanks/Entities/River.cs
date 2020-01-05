using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class River : GameObject
    {
        public River(int X, int Y, int sizeX, int sizeY)
        {
            Name = "Река";

            this.X = X;
            this.Y = Y;
            this.sizeX = sizeX;
            this.sizeY = sizeY;

        }

        public override GameObjectView GetView()
        {
            return new RiverView(sizeX, sizeY);
        }
    }
}
