using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class Bullet : GameObject
    {
        protected int dX;
        protected int dY;

        bool playerBullet;

        public Direction direction;
        public int speed;
        public Bullet(int X, int Y, Direction dir, int speed, bool playerBullet)
        {
            Name = "Пуля";

            this.X = X;
            this.Y = Y;
            this.dX = speed;
            this.dY = speed;
            this.sizeX = 10;
            this.sizeY = 10;

            this.playerBullet = playerBullet;

            Move(dir);
        }
        public bool Move(Direction dir)
        {
            direction = dir;
            switch (dir)
            {
                case Direction.Up:
                    return Move(0, -dY);

                case Direction.Left:
                    return Move(-dX, 0);

                case Direction.Down:
                    return Move(0, dY);

                case Direction.Right:
                    return Move(dX, 0);

            }
            return false;
        }
        public override GameObjectView GetView()
        {
            return new BulletView(playerBullet);
        }
    }

    public class BulletView : GameObjectView
    {
        bool enemyBullet;
        public BulletView(bool enemyBullet)
        {
            this.enemyBullet = enemyBullet;
        }

        public override Bitmap GetBitmap()
        {
            Bitmap bmp = enemyBullet? new Bitmap(Resources.kolobok_bullet) : new Bitmap(Resources.tank_bullet);
            return bmp;
        }
    }
}
