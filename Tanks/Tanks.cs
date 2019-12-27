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
        public static Random randomNum = new Random(42);

        Kolobok kolobok = new Kolobok(100,100);

        List<Tank> tanks = new List<Tank>();

        static public int width = 600;
        static public int height = 400;

        Graphics g;
        Bitmap bitmap;
        int speed = 10;

        Direction dirKolobok = Direction.Right;

        public Tanks()
        {
            InitializeComponent();

            width = pictureBoxMain.Width;
            height = pictureBoxMain.Height;

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 10;
            gameTimer.Start();

            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(bitmap);

            tanks.Add(new Tank(150, 100));
            tanks.Add(new Tank(150, 300));
            tanks.Add(new Tank(450, 100));
            tanks.Add(new Tank(450, 300));
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            kolobok.Move(dirKolobok);
            
            foreach(Tank tank in tanks)
            {
               tank.Move();
               if(CheckCollision(tank, kolobok))
                {
                    
                }

            }

            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    dirKolobok = Direction.Up;
                    break;
                case Keys.A:
                    dirKolobok = Direction.Left;
                    break;
                case Keys.S:
                    dirKolobok = Direction.Down;
                    break;
                case Keys.D:
                    dirKolobok = Direction.Right;
                    break;
            }

            kolobok.Move(dirKolobok);
            Draw();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            g.Clear(Color.White);

            g.DrawImage(kolobok.GetView().GetBitmap(), new Point(kolobok.X, kolobok.Y));

            foreach(Tank tank in tanks)
            {
                g.DrawImage(tank.GetView().GetBitmap(), new Point(tank.X, tank.Y));
            }
            

            pictureBoxMain.Image = bitmap;
        }

        private bool CheckCollision(GameObject gameObject1, GameObject gameObject2)
        {
            return gameObject1.X + gameObject1.sizeX >= gameObject2.X && gameObject1.Y + gameObject1.sizeY >= gameObject2.Y &&
                gameObject1.X < gameObject2.X + gameObject2.sizeY && gameObject1.Y < gameObject2.Y + gameObject2.sizeY;
        }
    }
}
