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
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.ChatEntriesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChatSendButton = new System.Windows.Forms.Button();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.PlayerListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tankLabel = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PlayerListPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(7, 38);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(253, 28);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Join Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuPanel.Controls.Add(this.ChatPanel);
            this.MenuPanel.Controls.Add(this.PlayerListPanel);
            this.MenuPanel.Controls.Add(this.ButtonsPanel);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuPanel.Location = new System.Drawing.Point(1064, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(267, 729);
            this.MenuPanel.TabIndex = 0;
            // 
            // ChatPanel
            // 
            this.ChatPanel.Controls.Add(this.ChatEntriesPanel);
            this.ChatPanel.Controls.Add(this.panel2);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatPanel.Location = new System.Drawing.Point(0, 173);
            this.ChatPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ChatPanel.Size = new System.Drawing.Size(267, 471);
            this.ChatPanel.TabIndex = 1;
            // 
            // ChatEntriesPanel
            // 
            this.ChatEntriesPanel.AutoScroll = true;
            this.ChatEntriesPanel.AutoScrollMargin = new System.Drawing.Size(0, 4);
            this.ChatEntriesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatEntriesPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.ChatEntriesPanel.Location = new System.Drawing.Point(7, 6);
            this.ChatEntriesPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatEntriesPanel.Name = "ChatEntriesPanel";
            this.ChatEntriesPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ChatEntriesPanel.Size = new System.Drawing.Size(253, 423);
            this.ChatEntriesPanel.TabIndex = 1;
            this.ChatEntriesPanel.WrapContents = false;
            this.ChatEntriesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ChatEntriesPanel_Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ChatSendButton);
            this.panel2.Controls.Add(this.ChatTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(7, 429);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 36);
            this.panel2.TabIndex = 0;
            // 
            // ChatSendButton
            // 
            this.ChatSendButton.Location = new System.Drawing.Point(193, 4);
            this.ChatSendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatSendButton.Name = "ChatSendButton";
            this.ChatSendButton.Size = new System.Drawing.Size(53, 27);
            this.ChatSendButton.TabIndex = 1;
            this.ChatSendButton.Text = "Send";
            this.ChatSendButton.UseVisualStyleBackColor = true;
            this.ChatSendButton.Click += new System.EventHandler(this.ChatSendButton_Click);
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Location = new System.Drawing.Point(4, 5);
            this.ChatTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(180, 22);
            this.ChatTextBox.TabIndex = 0;
            this.ChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatTextBox_KeyDown);
            // 
            // PlayerListPanel
            // 
            this.PlayerListPanel.AutoSize = true;
            this.PlayerListPanel.Controls.Add(this.panel1);
            this.PlayerListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PlayerListPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.PlayerListPanel.Location = new System.Drawing.Point(0, 644);
            this.PlayerListPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlayerListPanel.MaximumSize = new System.Drawing.Size(267, 263);
            this.PlayerListPanel.Name = "PlayerListPanel";
            this.PlayerListPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerListPanel.Size = new System.Drawing.Size(267, 85);
            this.PlayerListPanel.TabIndex = 2;
            this.PlayerListPanel.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Size = new System.Drawing.Size(253, 73);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(212, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 30);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 30);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.AutoSize = true;
            this.ButtonsPanel.Controls.Add(this.comboBox2);
            this.ButtonsPanel.Controls.Add(this.tankLabel);
            this.ButtonsPanel.Controls.Add(this.IpLabel);
            this.ButtonsPanel.Controls.Add(this.IpTextBox);
            this.ButtonsPanel.Controls.Add(this.comboBox1);
            this.ButtonsPanel.Controls.Add(this.levelLabel);
            this.ButtonsPanel.Controls.Add(this.StartButton);
            this.ButtonsPanel.Controls.Add(this.OptionsButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonsPanel.Size = new System.Drawing.Size(267, 173);
            this.ButtonsPanel.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(95, 143);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(164, 24);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // tankLabel
            // 
            this.tankLabel.AutoSize = true;
            this.tankLabel.Location = new System.Drawing.Point(7, 146);
            this.tankLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tankLabel.Name = "tankLabel";
            this.tankLabel.Size = new System.Drawing.Size(76, 17);
            this.tankLabel.TabIndex = 0;
            this.tankLabel.Text = "Tank Type";
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(7, 10);
            this.IpLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(76, 17);
            this.IpLabel.TabIndex = 0;
            this.IpLabel.Text = "IP Address";
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(92, 6);
            this.IpTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(167, 22);
            this.IpTextBox.TabIndex = 0;
            this.IpTextBox.TextChanged += new System.EventHandler(this.IpBox_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(95, 110);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(7, 113);
            this.levelLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(78, 17);
            this.levelLabel.TabIndex = 0;
            this.levelLabel.Text = "Level Type";
            // 
            // OptionsButton
            // 
            this.OptionsButton.Location = new System.Drawing.Point(7, 74);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(253, 28);
            this.OptionsButton.TabIndex = 2;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1331, 729);
            this.Controls.Add(this.MenuPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1349, 776);
            this.MinimumSize = new System.Drawing.Size(1349, 776);
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
            this.ChatPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PlayerListPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.ButtonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartButton;
        private Panel MenuPanel;
        private TextBox IpTextBox;
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
        private Panel ButtonsPanel;
        private FlowLayoutPanel ChatEntriesPanel;
        private Panel panel2;
        private Button ChatSendButton;
        private TextBox ChatTextBox;
        private Panel ChatPanel;
    }
}

