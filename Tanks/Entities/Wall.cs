using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Wall : GameObject
    {
        public int hitCount = 0;
        public static int strength = 2;
        public bool destructible;

        public Wall(int X, int Y, int sizeX, int sizeY, bool destructible)
        {
            Name = "Стена";

            this.X = X;
            this.Y = Y;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.destructible = destructible;
        }
        public Wall(int[] features, bool destructible) : this(features[0], features[1], features[2], features[3], destructible)
        {

        }
        public override GameObjectView GetView()
        {
            if (!destructible)
            {
                return new WallView(sizeX, sizeY);
            }
            else
            {
                return new WallView(sizeX, sizeY, destructible);
            }
        }
    }
}
