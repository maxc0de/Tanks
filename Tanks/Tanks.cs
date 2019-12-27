using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Tanks : Form
    {
        //public static Random randomNum = new Random(42);

        //Kolobok kolobok;
        //List<Apple> apples;
        //List<Tank> tanks;
        //List<Bullet> bullets;

        static public int width;
        static public int height;
        static public int numberTanks = 5;
        static public int numberApples = 5;
        static public int speed;

        Graphics g;
        Bitmap bitmap;
        PackmanController controller;

        //int score;
        //Direction dirKolobok = Direction.Right;

        public Tanks()
        {
            InitializeComponent();

            this.Location = new Point(100, 100);

            Report report = new Report();
            report.Show();

            width = pictureBoxMain.Width;
            height = pictureBoxMain.Height;

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 10;

            controller = new PackmanController();
            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(bitmap);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            controller.UpdateEntities();
            //kolobok.Move(dirKolobok);
            
            //for (int i = 0; i < apples.Count; i++)
            //{
            //    if (CheckCollision(apples[i], kolobok))
            //    {
            //        apples.Remove(apples[i]);
            //        score += 1;
            //        break;
            //    }
            //}

            //for (int i = 0; i < bullets.Count; i++)
            //{
            //    if (!bullets[i].Move(bullets[i].direction))
            //    {
            //        bullets.Remove(bullets[i]);
            //    }
            //}        

            //for (int i=0; i < tanks.Count; i++)
            //{
            //    for(int j=0; j<bullets.Count; j++)
            //    {
            //        if(CheckCollision(tanks[i], bullets[j]))
            //        {
            //            tanks.Remove(tanks[i]);
            //            bullets.Remove(bullets[j]);
            //        }
            //    }
            //}

            //foreach(Tank tank in tanks)
            //{
            //    tank.Move();
            //    if (CheckCollision(tank, kolobok))
            //    {
            //        GameOver();
            //        break;
            //    }

            //    for (int i = 0; i < tank.bullets.Count; i++)
            //    {
            //        if (CheckCollision(tank.bullets[i], kolobok))
            //        {
            //            GameOver();
            //            break;
            //        }
            //        if (!tank.bullets[i].Move(tank.bullets[i].direction))
            //        {
            //            tank.bullets.Remove(tank.bullets[i]);
            //        }
            //    }
            //}

            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.W:
            //        dirKolobok = Direction.Up;
            //        break;
            //    case Keys.A:
            //        dirKolobok = Direction.Left;
            //        break;
            //    case Keys.S:
            //        dirKolobok = Direction.Down;
            //        break;
            //    case Keys.D:
            //        dirKolobok = Direction.Right;
            //        break;
            //    case Keys.Space:
            //        bullets.Add(new Bullet(kolobok.X+kolobok.sizeX/2, kolobok.Y+kolobok.sizeY/2, dirKolobok, 5));
            //        break;
            //}

            controller.UserControl(e.KeyValue);

            Draw();
        }

        private void Draw()
        {
            g.Clear(Color.White);


            //g.DrawImage();


            //g.DrawImage(kolobok.GetView().GetBitmap(), new Point(kolobok.X, kolobok.Y));

            //foreach (Apple apple in apples)
            //{
            //    g.DrawImage(apple.GetView().GetBitmap(), new Point(apple.X, apple.Y));
            //}

            //foreach (Tank tank in tanks)
            //{
            //    g.DrawImage(tank.GetView().GetBitmap(), new Point(tank.X, tank.Y));

            //    if (tank.bullets.Count != 0)
            //    {
            //        foreach (Bullet bullet in tank.bullets)
            //        {
            //            g.DrawImage(bullet.GetTankView().GetBitmap(), new Point(bullet.X, bullet.Y));
            //        }
            //    }
            //}

            DrawEntities(controller.kolobokBullets);
            DrawEntities(controller.tanks);

            //gameScore.Text = score.ToString();

            DrawEntity(controller.kolobok);

            pictureBoxMain.Image = bitmap;
        }

        private void DrawEntity(GameObject gameObject)
        {
            g.DrawImage(gameObject.GetView().GetBitmap(), new Point(gameObject.X, gameObject.Y));
        }

        private void DrawEntities<T>(List<T> objects) where T : GameObject
        {
            foreach (T obj in objects)
            {
                DrawEntity(obj);
            }
        }

        private bool CheckCollision(GameObject gameObject1, GameObject gameObject2)
        {
            return gameObject1.X + gameObject1.sizeX >= gameObject2.X && gameObject1.Y + gameObject1.sizeY >= gameObject2.Y &&
                gameObject1.X < gameObject2.X + gameObject2.sizeY && gameObject1.Y < gameObject2.Y + gameObject2.sizeY;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kolobok = new Kolobok(225, 280);
            //bullets = new List<Bullet>();
            //tanks = new List<Tank>();
            //apples = new List<Apple>();

            //score = 0;

            //tanks.Add(new Tank(150, 100));
            //tanks.Add(new Tank(150, 200));
            //tanks.Add(new Tank(350, 100));
            //tanks.Add(new Tank(350, 200));

            //do
            //{
            //    apples.Add(new Apple(randomNum.Next(0, width), randomNum.Next(0, height)));
            //}
            //while (apples.Count < 4);

            controller.GameInit();

            Draw();

            gameTimer.Start();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Конец игры");
        }
    }
}
