using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Tanks : Form
    {
        static public int width = 400;
        static public int height = 400;
        static public int numberTanks = 5;
        static public int numberApples = 5;
        static public int speed = 10;

        private List<TextBox> textBoxes = new List<TextBox>();
        private bool viewReport = false;
        private bool gameIsRun = false;

        private PackmanController controller;
        private Report report;

        public Tanks()
        {
            InitializeComponent();

            pictureBoxMain.Width = width;
            pictureBoxMain.Height = height;

            gameTimer.Tick += GameTimer_Tick;

            textBoxNumberTanks.Text = numberTanks.ToString();
            textBoxNumberApples.Text = numberApples.ToString();
            textBoxWidth.Text = width.ToString();
            textBoxHeight.Text = height.ToString();
            textBoxSpeed.Text = speed.ToString();

            textBoxes.Add(textBoxNumberTanks);
            textBoxes.Add(textBoxNumberApples);
            textBoxes.Add(textBoxWidth);
            textBoxes.Add(textBoxHeight);
            textBoxes.Add(textBoxSpeed);

            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.SelectedIndex = 0;

            controller = new PackmanController();
            controller.GameOver += GameStop;
            controller.IncreaseScore += ChangeScore;
        }

        private void DrawEntities<T>(List<T> objects) where T : GameObject
        {
            Bitmap bitmap = new Bitmap(width, height);
            if (objects.Count > 0)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.SkyBlue);
                    foreach (T obj in objects)
                    {
                        g.DrawImage(obj.GetView().GetBitmap(), new Point(obj.X, obj.Y));
                    }
                }
            }

            pictureBoxMain.Image = bitmap;
        }
        private void ChangeScore(int score)
        {
            gameScore.Text = score.ToString();
        }
        private void GameStart()
        {
            numberTanks = Convert.ToInt32(textBoxNumberTanks.Text);
            numberApples = Convert.ToInt32(textBoxNumberApples.Text);
            width = Convert.ToInt32(textBoxWidth.Text);
            height = Convert.ToInt32(textBoxHeight.Text);
            gameTimer.Interval = Convert.ToInt32(textBoxSpeed.Text);

            if (comboBox1.SelectedIndex == 0)
            {
                controller.GameInit(new FileInfo(@"Resources\level1.txt"));
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                controller.GameInit(new FileInfo(@"Resources\level2.txt"));
            }
            else
            {
                controller.GameInit(new FileInfo(@"Resources\level3.txt"));
            }

            DrawEntities(controller.GetListGameObjects(true));
            gameTimer.Start();
            labelGameOver.Text = "";
            gameScore.Text = "0";

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enabled = false;
            }
            checkBoxReport.Enabled = false;
            comboBox1.Enabled = false;

            if (viewReport)
            {
                if (report == null || report.IsDisposed)
                {
                    report = new Report(this.Top, this.Left, this.Width);
                }
                report.Show();
                report.UpdateGrid(controller.GetListGameObjects(false));
            }

            this.Focus();
        }
        private void GameStop()
        {
            gameTimer.Stop();
            labelGameOver.Text = "Игра окончена!";
            gameIsRun = false;
            buttonStartStop.Text = "Старт";
            report.Close();
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enabled = true;
            }
            checkBoxReport.Enabled = true;
            comboBox1.Enabled = true;
        }

        //Обработчики работы с формой
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            controller.UpdateEntities();
            if (viewReport)
            {
                report.UpdateGrid(controller.GetListGameObjects(false));
            }
            DrawEntities(controller.GetListGameObjects(true));
        }
        private void Tanks_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameIsRun)
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
            }
        }
        private void Tanks_Load(object sender, EventArgs e)
        {
            report = new Report(this.Top, this.Left, this.Width);
        }
        private void TextBoxNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (number == 8)
            {
                e.Handled = false;
            }

            else if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
        private void CheckBoxReport_CheckedChanged(object sender, EventArgs e)
        {
            viewReport = !viewReport;
        }
        private void ButtonStartStop_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (!gameIsRun)
                {
                    GameStart();
                    this.ActiveControl = pictureBoxMain;
                    gameIsRun = true;
                    buttonStartStop.Text = "Стоп";
                }
                else
                {
                    GameStop();
                    this.ActiveControl = pictureBoxMain;
                    gameIsRun = false;
                    buttonStartStop.Text = "Старт";
                }
            }
        }
    }
}
