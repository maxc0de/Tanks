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
        Kolobok kolobok = new Kolobok(100,100);
        Graphics g;
        Bitmap bitmap;
        int speed = 3;
        public Tanks()
        {
            InitializeComponent();

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 100;
            gameTimer.Start();

            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(bitmap);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            kolobok.Move(1,0);
            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int dX = 0;
            int dY = 0;

            switch (e.KeyCode)
            {
                case Keys.W:
                    dY = -speed;
                    break;
                case Keys.A:
                    dX = -speed;
                    break;
                case Keys.S:
                    dY = speed;
                    break;
                case Keys.D:
                    dX = speed;
                    break;
            }

            kolobok.Move(dX, dY);
            Draw();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            g.Clear(Color.White);
            g.DrawImage(new Bitmap(@"triangle.png"), new Point(kolobok.X, kolobok.Y));

            pictureBoxMain.Image = bitmap;
        }
    }
}
