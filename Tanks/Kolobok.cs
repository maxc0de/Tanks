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

        int xStartBullet = 0;
        int yStartBullet = 0;

        int step = 1;

        public Direction direction;
        public List<Bullet> bullets;

        public Kolobok(int X, int Y)
        {
            this.X = X;
            this.Y = Y;

            sizeX = 38;
            sizeY = 38;

            bullets = new List<Bullet>();
        }

        public void Move(Direction dir)
        {
            direction = dir;
            switch (dir)
            {
                case Direction.Up:
                    Move(0, -step);
                    xStartBullet = X + sizeX/2 - 5;
                    yStartBullet = Y - 5;
                    break;
                case Direction.Left:
                    Move(-step, 0);
                    xStartBullet = X - 5;
                    yStartBullet = Y + sizeY/2 - 5;
                    break;
                case Direction.Down:
                    Move(0, step);
                    xStartBullet = X + sizeX / 2 - 5;
                    yStartBullet = Y + sizeY -5;
                    break;
                case Direction.Right:
                    Move(step, 0);
                    xStartBullet = X + sizeX - 5;
                    yStartBullet = Y + sizeY / 2 - 5;
                    break;
            }
        }
        public void Fire()
        {
            bullets.Add(new Bullet(xStartBullet, yStartBullet, direction, 5));
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
