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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webKitBrowser1.Url = new Uri(comboBox1.SelectedItem.ToString());
            toolStripStatusLabel1.Text = "正在连接...";
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(webKitBrowser1.CanGoBack)
            {
                webKitBrowser1.GoBack();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(webKitBrowser1.CanGoForward)
            {
                webKitBrowser1.GoForward();
            }
        }

        //private void webKitBrowser1_RegionChanged(object sender, EventArgs e)
        //{

        //}

        //private void webKitBrowser1_Layout(object sender, LayoutEventArgs e)
        //{

        //}

        //private void webKitBrowser1_PaddingChanged(object sender, EventArgs e)
        //{
            
        //}

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }



        private void webKitBrowser1_Load_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = null;
        }

        private void webKitBrowser1_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
            //toolStripStatusLabel1.Text = "Ready";
        }

        private void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }
    }
}
