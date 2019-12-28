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
        public Wall(int X, int Y, int sizeX, int sizeY)
        {
            Name = "Стена";

            this.X = X;
            this.Y = Y;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        public Wall(int[] features)
        {
            Name = "Стена";

            this.X = features[0];        
            this.Y = features[1];        
            this.sizeX = features[2];        
            this.sizeY = features[3];        
        }
        public override GameObjectView GetView()
        {
            return new WallView(sizeX, sizeY);
        }
    }
}
