using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        DateTime time1 = DateTime.Now;
        DateTime time2 = DateTime.Now;

        private Tank playerTank;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;

            playerTank = new Tank(0, 0, 20, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            time2 = DateTime.Now;
            float deltaTime = (time2.Ticks - time1.Ticks) / (float)(TimeSpan.TicksPerSecond);

            //base.OnPaint(e);
            Update(deltaTime);
            Render(e);
            Refresh();

            time1 = time2;
        }

        void Update(float deltaTime)
        {
            playerTank.Update(deltaTime);
        }

        void Render(PaintEventArgs e)
        {
            playerTank.Render(e);
        }

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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}

