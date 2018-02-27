using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WriteWork
{
    public partial class Form2 : Form
    {
        public string webUrl;
        
       
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             webKitBrowser1.Url = new Uri(webUrl);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete(webUrl);
        }
    }
}
