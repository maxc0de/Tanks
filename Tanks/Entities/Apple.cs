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

        public Apple(GameObject gameObject)
        {
            this.X = gameObject.X;
            this.Y = gameObject.Y;
        }

        public override GameObjectView GetView()
        {
            return new AppleView();
        }
    }
}
