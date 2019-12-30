using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Tank : WarVehicle
    {
        private Direction nextDirection;
        private int i = 0;

        public Tank(int X, int Y)
        {
            Name = "Танк";

            direction = (Direction)PackmanController.randomNum.Next(0, 4);

            this.X = X;
            this.Y = Y;

            sizeX = 38;
            sizeY = 38;

            playerBullet = false;

            bullets = new List<Bullet>();
        }

        public void Move()
        {
            if (i == 40)
            {
                Fire(3);
            }
            if (i == 50)
            {
                nextDirection = (Direction)PackmanController.randomNum.Next(0, 4);
                if (nextDirection != direction)
                {
                    direction = nextDirection;
                }

                i = 0;
            }

            i++;

            Move(direction);
        }
        public void Reverse()
        {
            if (direction == Direction.Left)
            {
                direction = Direction.Right;
            }
            else if (direction == Direction.Right)
            {
                direction = Direction.Left;
            }
            else if (direction == Direction.Up)
            {
                direction = Direction.Down;
            }
            else if (direction == Direction.Down)
            {
                direction = Direction.Up;
            }
        }
        public override GameObjectView GetView()
        {
            return new TankView(direction);
        }

    }
}
