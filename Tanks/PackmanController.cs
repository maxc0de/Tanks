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
        public List<Wall> walls;

        public List<GameObject> gameObjects = new List<GameObject>();

        int score;

        Direction currentDirection = Direction.Right;

        public void GameInit()
        {
            kolobok = new Kolobok(225, 280);
            tanks = new List<Tank>();
            apples = new List<Apple>();
            walls = new List<Wall>();

            walls.Add(new Wall((int)Tanks.width/4, 100, 30, 100));
            walls.Add(new Wall((int)Tanks.width/2, 0, 30, 100));
            walls.Add(new Wall((int)(Tanks.width/1.25), 100, 30, 100));

            score = 0;

            do
            {
               Tank tank = new Tank(randomNum.Next(0, (int)(Tanks.width * 0.9)), randomNum.Next(0, (int)Tanks.height/2));
               bool noCollision = true;

               for (int i=0; i<walls.Count; i++)
               {
                    if(CheckCollision(walls[i], tank))
                    {
                        noCollision = false;
                        break;
                    }
               }
               if (noCollision)
               {
                    tanks.Add(tank);
                    noCollision = true;
               }
            }
            while (tanks.Count < Tanks.numberTanks);

            GenerateApple();

            GetList();
        }
        public void UpdateEntities()
        {
            kolobok.Move(currentDirection);

            //Проверка взаимодействий с яблоками
            for (int i = 0; i < apples.Count; i++)
            {
                if (CheckCollision(apples[i], kolobok))
                {
                    apples.Remove(apples[i]);
                    IncreaseScore(++score);
                    GenerateApple();
                    break;
                }
            }

            //Проверка взаимодействия со стенами
            for(int i = 0; i < walls.Count; i++)
            {
                if (CheckCollision(walls[i], kolobok))
                {
                    kolobok.Collision();
                }

                for (int j = 0; j < tanks.Count; j++)
                {
                    if(CheckCollision(walls[i], tanks[j]))
                    {
                        if (tanks[j].direction == Direction.Left)
                        {
                            tanks[j].direction = Direction.Right;
                        }
                        else if (tanks[j].direction == Direction.Right)
                        {
                            tanks[j].direction = Direction.Left;
                        }
                        else if (tanks[j].direction == Direction.Up)
                        {
                            tanks[j].direction = Direction.Down;
                        }
                        else if (tanks[j].direction == Direction.Down)
                        {
                            tanks[j].direction = Direction.Up;
                        }
                    }
                }
            }
            
            for (int i = 0; i < kolobok.bullets.Count; i++)
            {
                if (!kolobok.bullets[i].Move(kolobok.bullets[i].direction))
                {
                    kolobok.bullets.Remove(kolobok.bullets[i]);
                }

                else if (kolobok.bullets.Count > 0)
                {
                    for (int j = 0; j < walls.Count; j++)
                    {
                        if (CheckCollision(walls[j], kolobok.bullets[i]))
                        {
                            kolobok.bullets.Remove(kolobok.bullets[i]);
                            walls[j].hitCount += 1;
                            if (walls[j].hitCount > 5)
                            {
                                walls.Remove(walls[j]);
                            }
                            break;
                        }
                    }
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
                    else if (!tank.bullets[i].Move(tank.bullets[i].direction))
                    {
                        tank.bullets.Remove(tank.bullets[i]);
                    }
                    else
                    {
                        for (int j = 0; j < walls.Count; j++)
                        {
                            if (CheckCollision(tank.bullets[i], walls[j]))
                            {
                                tank.bullets.Remove(tank.bullets[i]);
                                walls[j].hitCount += 1;
                                if (walls[j].hitCount > 5)
                                {
                                    walls.Remove(walls[j]);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            GetList();
        }

        private bool CheckCollision(GameObject gameObject1, GameObject gameObject2)
        {
            return gameObject1.X + gameObject1.sizeX >= gameObject2.X && gameObject1.Y + gameObject1.sizeY >= gameObject2.Y &&
                gameObject1.X < gameObject2.X + gameObject2.sizeX && gameObject1.Y < gameObject2.Y + gameObject2.sizeY;
        }

        public void UserControl(int keyCode)
        {
            switch (keyCode)
            {
                case 1:
                    currentDirection = Direction.Up;
                    break;
                case 2:
                    currentDirection = Direction.Left;
                    break;
                case 3:
                    currentDirection = Direction.Down;
                    break;
                case 4:
                    currentDirection = Direction.Right;
                    break;
                case 5:
                    kolobok.Fire(5);
                    break;
            }
        }

        private void GenerateApple()
        {
            do
            {
                Apple apple = new Apple(randomNum.Next(0, (int)(Tanks.width * 0.9)), randomNum.Next(0, (int)(Tanks.height * 0.9)));
                bool noCollision = true;

                for (int i = 0; i < walls.Count; i++)
                {
                    if (CheckCollision(walls[i], apple))
                    {
                        noCollision = false;
                        break;
                    }
                }
                if (noCollision)
                {
                    apples.Add(apple);
                    noCollision = true;
                }
            }
            while (apples.Count < Tanks.numberApples);
        }

        public void GetList()
        {
            gameObjects.Clear();
            gameObjects.Add(kolobok);
            gameObjects.AddRange(tanks);
            gameObjects.AddRange(apples);
            gameObjects.AddRange(walls);
        }
    }
}
