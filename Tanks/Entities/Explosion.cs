using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Explosion : GameObject
    {
        int n = 0;
        ExplosionView explosionView = new ExplosionView();
        public event Action<Explosion> remove;

        public Explosion(int X, int Y)
        {
            Name = "Взрыв";

            this.X = X;
            this.Y = Y;
        }
        public override GameObjectView GetView()
        {
            n += 1;

            if(n >= 13)
            {
                remove(this);
            }

            return explosionView;
        }
    }
}
