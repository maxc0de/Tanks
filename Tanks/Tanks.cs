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


        Graphics g;
        Bitmap bitmap;
        int speed = 10;

        Direction dirKolobok = Direction.Right;

        public Tanks()
        {
            InitializeComponent();

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 10;
            gameTimer.Start();

            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(bitmap);

            tanks.Add(new Tank(200, 200));
            tanks.Add(new Tank(200, 400));
            tanks.Add(new Tank(400, 200));
            tanks.Add(new Tank(400, 400));
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            kolobok.Move(dirKolobok);
            
            foreach(Tank tank in tanks)
            {
                tank.Move();
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
    }
}
