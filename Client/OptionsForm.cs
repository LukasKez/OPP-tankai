using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class OptionsForm : Form
    {
        string oldName;

        public OptionsForm()
        {
            InitializeComponent();

            textBox1.Text = Options.name;
            checkBox1.Checked = Options.shadows;
            checkBox2.Checked = Options.smoothing;
            checkBox3.Checked = Options.pixelOffset;
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            CenterToParent();

            oldName = Options.name;
        }

        private void OptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (oldName != Options.name)
            {
                (Owner as GameForm).UpdatePlayerUI();
                Networking.SetNameAsync(Options.name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Options.name = (sender as TextBox).Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Options.shadows = (sender as CheckBox).Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Options.smoothing = (sender as CheckBox).Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Options.pixelOffset = (sender as CheckBox).Checked;
        }
    }
}
