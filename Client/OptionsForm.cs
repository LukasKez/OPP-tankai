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
        public OptionsForm()
        {
            InitializeComponent();

            checkBox1.Checked = Options.shadows;
            textBox1.Text = Options.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Options.shadows = (sender as CheckBox).Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Options.name = (sender as TextBox).Text;
        }
    }
}
