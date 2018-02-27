using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteWork
{

    public delegate void upData(string url);

    public partial class Form9 : Form
    {
        public event upData upData;

        public string picUrl;
        public string newUrl;
        private int size = 100;
        private string align = null;

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            //numericUpDown1.Value = size; 
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {   
                /////////
                size = (int)numericUpDown1.Value;
                newUrl = "<div align="+align+"><img src=\"" + picUrl + "\"width=\"" + size.ToString() + "\"></div>";
                upData(newUrl);
                /////////
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripButton2.Checked)
            {
                align = "\"center\"";
                /////////
                size = (int)numericUpDown1.Value;
                newUrl = "<div align=" + align + "><img src=\"" + picUrl + "\"width=\"" + size.ToString() + "\"></div>";
                upData(newUrl);
                /////////

            }
            else
            {
                align =null;
                /////////
                size = (int)numericUpDown1.Value;
                newUrl = "<div align=" + align + "><img src=\"" + picUrl + "\"width=\"" + size.ToString() + "\"></div>";
                upData(newUrl);
            }

        }
    }
}
