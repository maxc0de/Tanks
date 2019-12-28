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
        static public double width;
        static public double height;
        static public int numberTanks = 3;
        static public int numberApples = 3;
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

            report = new Report();
            report.Show();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            controller.UpdateEntities();
            report.UpdateGrid(controller.gameObjects);
            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                controller.UserControl(1);
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                controller.UserControl(2);
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                controller.UserControl(3);
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                controller.UserControl(4);
            }
            if (e.KeyCode == Keys.Space)
            {
                controller.UserControl(5);
            }

            Draw();
        }

        private void Draw()
        {
            g.Clear(Color.White);

            DrawEntities(controller.gameObjects);
            DrawEntities(controller.kolobok.bullets);

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
            labelGameOver.Text = "";
            report.UpdateGrid(controller.gameObjects);

            this.Focus();
        }

        private void IncreaseScore(int score)
        {
            gameScore.Text = score.ToString();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            labelGameOver.Text = "Игра окончена!";
        }

        public class DataGridViewEx : DataGridView
        {
            protected override bool DoubleBuffered { get => true; }
        }
    }

}
