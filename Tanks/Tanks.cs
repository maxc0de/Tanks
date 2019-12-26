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
        Graphics g;
        Bitmap bitmap;
        int speed = 10;

        Direction dir = Direction.Right;

        public Tanks()
        {
            InitializeComponent();

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 10;
            gameTimer.Start();

            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(bitmap);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            kolobok.Move(dir);
            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    dir = Direction.Up;
                    break;
                case Keys.A:
                    dir = Direction.Left;
                    break;
                case Keys.S:
                    dir = Direction.Down;
                    break;
                case Keys.D:
                    dir = Direction.Right;
                    break;
            }

            kolobok.Move(dir);
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

            pictureBoxMain.Image = bitmap;
        }
    }
}
