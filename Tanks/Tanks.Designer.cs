﻿using System.Windows.Forms;

namespace Tanks
{
    partial class Tanks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.textBoxNumberTanks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumberApples = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.checkBoxReport = new System.Windows.Forms.CheckBox();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gameScore
            // 
            this.gameScore.AutoSize = true;
            this.gameScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameScore.Location = new System.Drawing.Point(508, 23);
            this.gameScore.Name = "gameScore";
            this.gameScore.Size = new System.Drawing.Size(18, 20);
            this.gameScore.TabIndex = 2;
            this.gameScore.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(407, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Счёт игры: ";
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 1);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGameOver.ForeColor = System.Drawing.Color.Red;
            this.labelGameOver.Location = new System.Drawing.Point(407, 89);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(0, 20);
            this.labelGameOver.TabIndex = 5;
            // 
            // textBoxNumberTanks
            // 
            this.textBoxNumberTanks.Location = new System.Drawing.Point(516, 133);
            this.textBoxNumberTanks.Name = "textBoxNumberTanks";
            this.textBoxNumberTanks.Size = new System.Drawing.Size(36, 20);
            this.textBoxNumberTanks.TabIndex = 6;
            this.textBoxNumberTanks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumbers_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество танков";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество яблок";
            // 
            // textBoxNumberApples
            // 
            this.textBoxNumberApples.Location = new System.Drawing.Point(516, 159);
            this.textBoxNumberApples.Name = "textBoxNumberApples";
            this.textBoxNumberApples.Size = new System.Drawing.Size(36, 20);
            this.textBoxNumberApples.TabIndex = 9;
            this.textBoxNumberApples.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumbers_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ширина поля";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Скорость";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Высота поля";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(516, 187);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(36, 20);
            this.textBoxWidth.TabIndex = 13;
            this.textBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumbers_KeyPress);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(516, 213);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(36, 20);
            this.textBoxHeight.TabIndex = 14;
            this.textBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumbers_KeyPress);
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(516, 239);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(36, 20);
            this.textBoxSpeed.TabIndex = 15;
            this.textBoxSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumbers_KeyPress);
            // 
            // checkBoxReport
            // 
            this.checkBoxReport.AutoSize = true;
            this.checkBoxReport.Location = new System.Drawing.Point(411, 317);
            this.checkBoxReport.Name = "checkBoxReport";
            this.checkBoxReport.Size = new System.Drawing.Size(118, 17);
            this.checkBoxReport.TabIndex = 16;
            this.checkBoxReport.Text = "Отображать отчёт";
            this.checkBoxReport.UseVisualStyleBackColor = true;
            this.checkBoxReport.CheckedChanged += new System.EventHandler(this.CheckBoxReport_CheckedChanged);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartStop.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonStartStop.Location = new System.Drawing.Point(462, 358);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(90, 31);
            this.buttonStartStop.TabIndex = 17;
            this.buttonStartStop.Text = "Старт";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonStartStop_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(516, 265);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(36, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Уровень";
            // 
            // Tanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 401);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.checkBoxReport);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNumberApples);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumberTanks);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameScore);
            this.Controls.Add(this.pictureBoxMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Танки";
            this.Load += new System.EventHandler(this.Tanks_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tanks_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label gameScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.TextBox textBoxNumberTanks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNumberApples;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.CheckBox checkBoxReport;
        private System.Windows.Forms.Button buttonStartStop;
        private ComboBox comboBox1;
        private Label label7;

        public class DataGridViewEx : DataGridView
        {
            protected override bool DoubleBuffered { get => true; }
        }
    }
}

