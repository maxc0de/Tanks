using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Apple : GameObject
    {
        public Apple(int X, int Y)
        {
            Name = "Яблоко";

            sizeX = 20;
            sizeY = 20;

            this.X = X;
            this.Y = Y;
        }

        public override GameObjectView GetView()
        {
            return new AppleView();
        }
    }
}
