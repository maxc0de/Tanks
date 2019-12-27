using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Kolobok : GameObject
    {
        private int dY = 1;
        private int dX = 1;

        public Direction direction;
        public List<Bullet> bullets;

        public Kolobok(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            bullets = new List<Bullet>();
        }

        public void Move(Direction dir)
        {
            direction = dir;
            switch (dir)
            {
                case Direction.Up:
                    Move(0, -dY);
                    break;
                case Direction.Left:
                    Move(-dX, 0);
                    break;
                case Direction.Down:
                    Move(0, dY);
                    break;
                case Direction.Right:
                    Move(dX, 0);
                    break;
            }
        }
        public void Fire()
        {
            bullets.Add(new Bullet(X + sizeX / 2, Y + sizeY / 2, direction, 5));
        }
        public override GameObjectView GetView()
        {
            return new KolobokView(direction);
        }
    }
}
