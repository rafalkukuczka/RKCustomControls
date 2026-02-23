using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
