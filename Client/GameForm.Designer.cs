using Client.Assets.Levels;
using System;
using System.Windows.Forms;

namespace Client
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        GameLoop gameLoop;
        string originalText;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            originalText = Text;
            gameLoop = new GameLoop();

            GameState state = GameState.Instance;
            state.gameLevel = GameLevelCreator.GetGameLevel(
                "forest", (float)state.mapSize.X, (float)state.mapSize.Y, 20, 20, 2);

            gameLoop.StartGame();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            gameLoop.Manage(e);
            Text = originalText + gameLoop.FPS + " FPS";
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            GameState.Instance.focused = true;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            GameState.Instance.focused = false;
            base.OnLostFocus(e);
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
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 639);
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "GameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tank Game ";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

