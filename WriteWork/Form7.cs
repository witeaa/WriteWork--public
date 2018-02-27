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
using Octokit;


namespace WriteWork
{
    public partial class Form7 : Form
    {
        public string path;
        private string content;
        public string token = "b42b4784f90c574bdeec3a7982338ca2114f0dcf";
        libwebmanage.Article_Class gitUp = new libwebmanage.Article_Class();
        List<RepositoryContent> contents;


        public Form7()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
           // comboBox2.SelectedIndex = 0;
            gitUp.auth__token(token);
            toolStripStatusLabel1.Text = "ready";
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                content = File.ReadAllText(path, Encoding.UTF8);
                toolStripProgressBar1.Value = 20;
                gitUp.UploadByTopic__topic__name__content(comboBox1.SelectedItem.ToString(), Path.GetFileName(path), content);
                //GetUpload.UploadByTopic__token__topic__name__content(token, comboBox1.SelectedItem.ToString(), Path.GetFileName(path), content);
                toolStripProgressBar1.Value = 60;
                if (checkBox1.Checked)
                {
                   gitUp.UploadByTopic__topic__name__content( "post", Path.GetFileName(path), content);
                    toolStripProgressBar1.Value = 80;
                }
                toolStripProgressBar1.Value = 100;
            }
            else
            {
               DialogResult dr = MessageBox.Show("需要选择一个发布的位置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = false;
            buttonup.Enabled = true;
            listBox1.Enabled = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            buttondel.Enabled = true;
            buttoned.Enabled = true;
            buttonpr.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 10;

            listBox1.Items.Clear();
            contents = (List<RepositoryContent>)gitUp.GetArticleByTopic__topic(comboBox2.SelectedItem.ToString());
            toolStripProgressBar1.Value = 60;
            foreach (RepositoryContent content in contents)
            {
                listBox1.Items.Add(content.Name);
            }
            toolStripProgressBar1.Value = 100;
        }

        private void buttonpr_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 30;
            richTextBox1.Text = gitUp.GetArticleContent__topic__name(comboBox2.SelectedItem.ToString(), listBox1.SelectedItem.ToString());
            toolStripProgressBar1.Value = 100;
            

        }

        private void buttonup_Click(object sender, EventArgs e)
        {
            gitUp.UpdateArticleContent__topic__name__content(comboBox2.SelectedItem.ToString(), listBox1.SelectedItem.ToString(), richTextBox1.Text);
            listBox1.Enabled = true;
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            listBox1.Enabled = true;
            gitUp.DeleteArticle__topic__name(comboBox2.SelectedItem.ToString(), listBox1.SelectedItem.ToString());
            listBox1.Items.Clear();
            contents = (List<RepositoryContent>)gitUp.GetArticleByTopic__topic(comboBox2.SelectedItem.ToString());
            foreach (RepositoryContent content in contents)
            {
                listBox1.Items.Add(content.Name);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog
        //    {
        //        Filter = "Markdown|*.md"
        //    };
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        path = openFileDialog1.FileName;

        //    }
        //}
    }
}
