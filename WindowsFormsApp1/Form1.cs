using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void toggleButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleButton2.Checked)
            {
                this.BackColor = SystemColors.Control;
            }
            else
            {
                this.BackColor = SystemColors.Desktop;
            }
        }

        private void toggleButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleButton6_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
