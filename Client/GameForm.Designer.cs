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
            this.StartButton = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.tankLabel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PlayerListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.IpBox = new System.Windows.Forms.TextBox();
            this.MenuPanel.SuspendLayout();
            this.PlayerListPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(5, 31);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(190, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Join Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuPanel.Controls.Add(this.tankLabel);
            this.MenuPanel.Controls.Add(this.comboBox2);
            this.MenuPanel.Controls.Add(this.levelLabel);
            this.MenuPanel.Controls.Add(this.comboBox1);
            this.MenuPanel.Controls.Add(this.PlayerListPanel);
            this.MenuPanel.Controls.Add(this.IpLabel);
            this.MenuPanel.Controls.Add(this.OptionsButton);
            this.MenuPanel.Controls.Add(this.IpBox);
            this.MenuPanel.Controls.Add(this.StartButton);
            this.MenuPanel.Location = new System.Drawing.Point(800, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Padding = new System.Windows.Forms.Padding(2);
            this.MenuPanel.Size = new System.Drawing.Size(200, 600);
            this.MenuPanel.TabIndex = 0;
            // 
            // tankLabel
            // 
            this.tankLabel.AutoSize = true;
            this.tankLabel.Location = new System.Drawing.Point(5, 119);
            this.tankLabel.Margin = new System.Windows.Forms.Padding(3);
            this.tankLabel.Name = "tankLabel";
            this.tankLabel.Size = new System.Drawing.Size(59, 13);
            this.tankLabel.TabIndex = 8;
            this.tankLabel.Text = "Tank Type";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(71, 116);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(124, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(5, 92);
            this.levelLabel.Margin = new System.Windows.Forms.Padding(3);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(60, 13);
            this.levelLabel.TabIndex = 6;
            this.levelLabel.Text = "Level Type";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PlayerListPanel
            // 
            this.PlayerListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerListPanel.Controls.Add(this.panel1);
            this.PlayerListPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.PlayerListPanel.Location = new System.Drawing.Point(0, 300);
            this.PlayerListPanel.Name = "PlayerListPanel";
            this.PlayerListPanel.Padding = new System.Windows.Forms.Padding(2);
            this.PlayerListPanel.Size = new System.Drawing.Size(200, 300);
            this.PlayerListPanel.TabIndex = 4;
            this.PlayerListPanel.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 233);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(190, 60);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(159, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 24);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(5, 8);
            this.IpLabel.Margin = new System.Windows.Forms.Padding(3);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(58, 13);
            this.IpLabel.TabIndex = 3;
            this.IpLabel.Text = "IP Address";
            // 
            // OptionsButton
            // 
            this.OptionsButton.Location = new System.Drawing.Point(5, 60);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(190, 23);
            this.OptionsButton.TabIndex = 2;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // IpBox
            // 
            this.IpBox.Location = new System.Drawing.Point(69, 5);
            this.IpBox.Name = "IpBox";
            this.IpBox.Size = new System.Drawing.Size(126, 20);
            this.IpBox.TabIndex = 1;
            this.IpBox.TextChanged += new System.EventHandler(this.IpBox_TextChanged);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.MenuPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1016, 639);
            this.MinimumSize = new System.Drawing.Size(1016, 639);
            this.Name = "GameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tank Game ";
            this.Activated += new System.EventHandler(this.GameForm_Activated);
            this.Deactivate += new System.EventHandler(this.GameForm_Deactivate);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.PlayerListPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartButton;
        private Panel MenuPanel;
        private TextBox IpBox;
        private Button OptionsButton;
        private Label IpLabel;
        private FlowLayoutPanel PlayerListPanel;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private Label levelLabel;
        private Label tankLabel;
        private ComboBox comboBox2;
    }
}

