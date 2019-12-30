using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public abstract class WarVehicle : GameObject
    {
        int xStartBullet = 0;
        int yStartBullet = 0;

        DateTime lastFire = new DateTime();

        protected bool playerBullet = true;

        int step = 1;

        public Direction direction;
        public List<Bullet> bullets;

        public void Move(Direction dir)
        {
            direction = dir;
            switch (dir)
            {
                case Direction.Up:
                    Move(0, -step);
                    xStartBullet = X + sizeX / 2 - 5;
                    yStartBullet = Y - 5;
                    break;
                case Direction.Left:
                    Move(-step, 0);
                    xStartBullet = X - 5;
                    yStartBullet = Y + sizeY / 2 - 5;
                    break;
                case Direction.Down:
                    Move(0, step);
                    xStartBullet = X + sizeX / 2 - 5;
                    yStartBullet = Y + sizeY - 5;
                    break;
                case Direction.Right:
                    Move(step, 0);
                    xStartBullet = X + sizeX - 5;
                    yStartBullet = Y + sizeY / 2 - 5;
                    break;
            }
        }

        public void Fire(int speedFire)
        {
            if  (lastFire == new DateTime())
            {
                lastFire = DateTime.Now;
                bullets.Add(new Bullet(xStartBullet, yStartBullet, direction, speedFire, playerBullet));
            }
            else if(DateTime.Now - lastFire > TimeSpan.FromMilliseconds(300))
            {
                lastFire = DateTime.Now;
                bullets.Add(new Bullet(xStartBullet, yStartBullet, direction, speedFire, playerBullet));
            }
        }

        public void Collision()
        {
            Move(-dX, -dY);
        }

    }
}
