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
        static public int width;
        static public int height;
        static public int numberTanks = 5;
        static public int numberApples = 5;
        static public int speed;

        Graphics g;
        Bitmap bitmap;
        PackmanController controller;
        Report report;

        public Tanks()
        {
            InitializeComponent();

            this.Location = new Point(100, 100);

            width = pictureBoxMain.Width;
            height = pictureBoxMain.Height;

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 10;

            controller = new PackmanController();
            controller.GameOver += GameOver;
            controller.IncreaseScore += IncreaseScore;
            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            g = Graphics.FromImage(bitmap);


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //report.UpdateForm();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            controller.UpdateEntities();

            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            controller.UserControl(e.KeyValue);
            Draw();
        }

        private void Draw()
        {
            g.Clear(Color.White);

            DrawEntity(controller.kolobok);

            DrawEntities(controller.apples);
            DrawEntities(controller.kolobok.bullets);
            DrawEntities(controller.tanks);

            foreach (Tank tank in controller.tanks)
            {
                DrawEntities(tank.bullets);
            }

            pictureBoxMain.Image = bitmap;
        }

        private void DrawEntity(GameObject gameObject)
        {
            g.DrawImage(gameObject.GetView().GetBitmap(), new Point(gameObject.X, gameObject.Y));
        }

        private void DrawEntities<T>(List<T> objects) where T : GameObject
        {
            if (objects.Count > 0)
            {
                foreach (T obj in objects)
                {
                    DrawEntity(obj);
                }
            }
        }

        private void menu_GameStart(object sender, EventArgs e)
        {
            controller.GameInit();
            Draw();
            gameTimer.Start();

            report = new Report(controller.tanks);
            report.Show();

            this.Focus();
        }

        private void IncreaseScore(int score)
        {
            gameScore.Text = score.ToString();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Конец игры");
        }
    }
}
