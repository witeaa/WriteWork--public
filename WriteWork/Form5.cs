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
    public partial class Form5 : Form
    {
        public string txt;
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

 

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("hh:mm:ss")+"+08:00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == null) || (textBox3.Text == null))
            {
                DialogResult dr = MessageBox.Show("请填写完整", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                txt = "+++\nauthor = \"" + textBox1.Text + "\"\n" + "date = " + "\"" + textBox2.Text + "\"\n" + "share = \"false\"\ndraft = \"false\"\n" + "title = \"" + textBox3.Text + "\"\n+++\n";
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
