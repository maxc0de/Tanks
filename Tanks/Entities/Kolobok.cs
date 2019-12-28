using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Kolobok : WarVehicle
    {
        public Kolobok(int X, int Y)
        {
            Name = "Колобок";

            this.X = X;
            this.Y = Y;

            sizeX = 38;
            sizeY = 38;

            bullets = new List<Bullet>();
        }

        public override GameObjectView GetView()
        {
            return new KolobokView(direction);
        }
        public void Collision()
        {
            Move(-dX, -dY);
        }
    }
}
