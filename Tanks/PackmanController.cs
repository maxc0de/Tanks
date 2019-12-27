using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class PackmanController
    {
        public static Random randomNum = new Random(42);

        public event Action GameOver;
        public event Action<int> IncreaseScore;

        public Kolobok kolobok;
        public List<Apple> apples;
        public List<Tank> tanks;

        int score;

        Direction currentDirection = Direction.Right;

        public void GameInit()
        {
            kolobok = new Kolobok(225, 280);
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
                    IncreaseScore(score++);
                    apples.Add(new Apple(randomNum.Next(0, Tanks.width), randomNum.Next(0, Tanks.height)));
                    break;
                }
            }
            
            for (int i = 0; i < kolobok.bullets.Count; i++)
            {
                if (!kolobok.bullets[i].Move(kolobok.bullets[i].direction))
                {
                    kolobok.bullets.Remove(kolobok.bullets[i]);
                }
            }

            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < kolobok.bullets.Count; j++)
                {
                    if (CheckCollision(tanks[i], kolobok.bullets[j]))
                    {
                        tanks.Remove(tanks[i]);
                        kolobok.bullets.Remove(kolobok.bullets[j]);
                        break;
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
                    kolobok.Fire();
                    break;
            }
        }
    }
}
