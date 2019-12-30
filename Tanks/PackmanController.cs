﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Properties;

namespace Tanks
{
    public class PackmanController
    {
        public static Random randomNum = new Random(42);

        public event Action GameOver;
        public event Action<int> IncreaseScore;

        private Kolobok kolobok;
        private List<Apple> apples;
        private List<Tank> tanks;
        private List<Wall> walls;

        private Direction currentDirection;
        private int score;

        public void GameInit(FileInfo file)
        {
            kolobok = new Kolobok(Tanks.width/2, Tanks.height-50);
            tanks = new List<Tank>();
            apples = new List<Apple>();
            walls = new List<Wall>();

            currentDirection = Direction.Right;
            score = 0;

            //Генерация cтен
            FileInfo level = file;
            if (level.Exists)
            {
                string[] arStr = File.ReadAllLines(level.FullName);
                foreach (string str in arStr)
                {
                    int[] f = str.Split(new char[] { ';' }).ToList().Select(s => Convert.ToInt32(s)).ToArray();
                    walls.AddRange(GetWall(f[0], f[1], f[2], f[3]));
                }
            }
                          
            //Генерация яблок
            apples.AddRange(GenerateGameObjects(Tanks.numberApples, GetApple).Cast<Apple>());

            //Генерация танков
            tanks.AddRange(GenerateGameObjects(Tanks.numberTanks, GetTank).Cast<Tank>());
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
                    apples.AddRange(GenerateGameObjects(1, GetApple).Cast<Apple>());
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
                        tanks[j].Collision();
                    }
                }
            }

            //Проверка взаимодействия пуль колобка
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
                            walls[j].hitCount++;
                            if (walls[j].hitCount >= Wall.strength)
                            {
                                walls.Remove(walls[j]);
                            }
                            break;
                        }
                    }
                }
            }

            //Проверка взаимодействия для танков
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

                for(int i = 0; i < tanks.Count; i++)
                {
                    if (!tank.Equals(tanks[i]))
                    {
                        if (CheckCollision(tank, tanks[i]))
                        {
                            if(tank.direction != tanks[i].direction)
                            {
                                tank.Reverse();
                                
                                tanks[i].Reverse();
                                tanks[i].Collision();
                            }
                            else
                            {
                                tank.Collision();
                                tank.Reverse();
                            }
                        }
                    }
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
                                if (walls[j].hitCount >= Wall.strength)
                                {
                                    walls.Remove(walls[j]);
                                }
                                break;
                            }
                        }
                    }
                }
            }
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
        public List<GameObject> GetListGameObjects(bool withBullets)
        {

            List<GameObject> gameObjects = new List<GameObject>();

            gameObjects.Add(kolobok);
            gameObjects.AddRange(tanks);
            gameObjects.AddRange(apples);


            if(!withBullets)
            {
                return gameObjects;
            }

            gameObjects.AddRange(walls);

            gameObjects.AddRange(kolobok.bullets);

            foreach(Tank tank in tanks)
            {
                gameObjects.AddRange(tank.bullets);
            }

            return gameObjects;
        }

        private bool CheckCollision(GameObject gameObject1, GameObject gameObject2)
        {
            return gameObject1.X + gameObject1.sizeX >= gameObject2.X && gameObject1.Y + gameObject1.sizeY >= gameObject2.Y &&
                gameObject1.X < gameObject2.X + gameObject2.sizeX && gameObject1.Y < gameObject2.Y + gameObject2.sizeY;
        }
        private List<GameObject> GenerateGameObjects(int nums, Func<GameObject> action)
        {
            List<GameObject> objects = new List<GameObject>();
            do
            {
                GameObject gameObject = action();

                bool noCollision = true;

                for (int i = 0; i < walls.Count; i++)
                {
                    if (CheckCollision(walls[i], gameObject))
                    {
                        noCollision = false;
                        break;
                    }
                }
                foreach(GameObject obj in objects)
                {
                    if (CheckCollision(obj, gameObject))
                    {
                        noCollision = false;
                        break;
                    }
                }

                if (noCollision)
                {
                    objects.Add(gameObject);
                }
            }
            while (objects.Count < nums);

            return objects;
        }
        private Apple GetApple()
        {
            return new Apple(randomNum.Next(0, (int)(Tanks.width * 0.9)), randomNum.Next(0, (int)(Tanks.height * 0.9)));
        }
        private Tank GetTank()
        {
            return new Tank(randomNum.Next(0, (int)(Tanks.width * 0.9)), randomNum.Next(0, Tanks.height / 2));
        }
        private List<Wall> GetWall(int X, int Y, int numX, int numY)
        {
            List<Wall> walls = new List<Wall>();
            int x = X;
            int y = Y;

            for(int i = 0; i<numX; i++)
            {
                for(int j = 0; j < numY; j++)
                {
                    walls.Add(new Wall(x, y, 20, 20));
                    y += 20;
                }
                x += 20;
                y = Y;
            }

            return walls;
        }
    }
}
