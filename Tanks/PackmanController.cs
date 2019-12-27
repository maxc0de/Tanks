using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class PackmanController
    {
        public static Random randomNum = new Random(42);

        public event Action GameOver;

        public Kolobok kolobok;
        public List<Apple> apples;
        public List<Tank> tanks;
        public List<Bullet> kolobokBullets;

        int score;

        Direction currentDirection = Direction.Right;

        public void GameInit()
        {
            kolobok = new Kolobok(225, 280);
            kolobokBullets = new List<Bullet>();
            tanks = new List<Tank>();
            apples = new List<Apple>();

            score = 0;

            do
            {
                tanks.Add(new Tank(randomNum.Next(0, Tanks.width), randomNum.Next(0, Tanks.height)));
            }
            while (tanks.Count < Tanks.numberTanks);

            do
            {
                apples.Add(new Apple(randomNum.Next(0, Tanks.width), randomNum.Next(0, Tanks.height)));
            }
            while (apples.Count < Tanks.numberApples);
        }
        public void UpdateEntities()
        {
            kolobok.Move(currentDirection);

            for (int i = 0; i < apples.Count; i++)
            {
                if (CheckCollision(apples[i], kolobok))
                {
                    apples.Remove(apples[i]);
                    score += 1;
                    break;
                }
            }

            for (int i = 0; i < kolobokBullets.Count; i++)
            {
                if (!kolobokBullets[i].Move(kolobokBullets[i].direction))
                {
                    kolobokBullets.Remove(kolobokBullets[i]);
                }
            }

            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < kolobokBullets.Count; j++)
                {
                    if (CheckCollision(tanks[i], kolobokBullets[j]))
                    {
                        tanks.Remove(tanks[i]);
                        kolobokBullets.Remove(kolobokBullets[j]);
                    }
                }
            }

            foreach (Tank tank in tanks)
            {
                tank.Move();
                if (CheckCollision(tank, kolobok))
                {
                    GameOver();
                    break;
                }

                for (int i = 0; i < tank.bullets.Count; i++)
                {
                    if (CheckCollision(tank.bullets[i], kolobok))
                    {
                        GameOver();
                        break;
                    }
                    if (!tank.bullets[i].Move(tank.bullets[i].direction))
                    {
                        tank.bullets.Remove(tank.bullets[i]);
                    }
                }
            }
        }

        private bool CheckCollision(GameObject gameObject1, GameObject gameObject2)
        {
            return gameObject1.X + gameObject1.sizeX >= gameObject2.X && gameObject1.Y + gameObject1.sizeY >= gameObject2.Y &&
                gameObject1.X < gameObject2.X + gameObject2.sizeY && gameObject1.Y < gameObject2.Y + gameObject2.sizeY;
        }

        public void UserControl(int keyCode)
        {
            switch (keyCode)
            {
                case 87:
                    currentDirection = Direction.Up;
                    break;
                case 65:
                    currentDirection = Direction.Left;
                    break;
                case 83:
                    currentDirection = Direction.Down;
                    break;
                case 68:
                    currentDirection = Direction.Right;
                    break;
                case 32:
                    kolobokBullets.Add(new Bullet(kolobok.X + kolobok.sizeX / 2, kolobok.Y + kolobok.sizeY / 2, currentDirection, 5));
                    break;
            }
        }
    }
}
