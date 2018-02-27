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
using MarkdownSharp;
using System.Diagnostics;

namespace WriteWork
{
    public partial class Form1 : Form
    {
        public string fileName;
        public string tpFilename;
        public string htmlStr;
        public bool isTextChanged = false;
        Markdown markdown = new Markdown();


        public Form1()
        {
            InitializeComponent();
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);

        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void 恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void 撤销ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void 恢复ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 剪切ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Markdown|*.md"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.UTF8);

            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            if (fileName != null)
            {
                File.WriteAllText(fileName, richTextBox1.Text);
                isTextChanged = false;
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Markdown|*.md"
                };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
                    isTextChanged = false;
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Markdown|*.md"
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
            }
        }

        private void 加粗字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "****");
            richTextBox1.SelectionStart = index + 2;
        }

        private void 斜体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "**");
            richTextBox1.SelectionStart = index + 1;
        }

        private void quoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "    ");
            richTextBox1.SelectionStart = index;
        }

        private void heading1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "#  #");
            richTextBox1.SelectionStart = index + 2;
        }

        private void heading2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "##  ##");
            richTextBox1.SelectionStart = index + 3;
        }

        private void heading3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "###  ###");
            richTextBox1.SelectionStart = index + 4;
        }

        private void headong4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "####  ####");
            richTextBox1.SelectionStart = index + 5;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
            if (toolStripButton17.Checked)
            {
                //Markdown markdown = new Markdown();
                htmlStr = markdown.Transform(richTextBox1.Text);

                //tpFilename = Path.GetTempPath();

                //tpFilename += "preview.html";
                File.WriteAllText(tpFilename, htmlStr, Encoding.UTF8);
                webKitBrowser1.Url = new Uri(tpFilename);

                //Form2 fm2 = new Form2
                //{
                //    webUrl = tpFilename
                //};
                //fm2.Show();
            }

        }

        private void hyperlinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            DialogResult ddr = fm3.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                int index;
                richTextBox1.Focus();
                index = richTextBox1.SelectionStart;
                this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm3.urlstr);
                richTextBox1.SelectionStart = index;
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {

            //Markdown markdown = new Markdown();
            htmlStr = markdown.Transform(richTextBox1.Text);

            //tpFilename = Path.GetTempPath();

            //tpFilename += "preview.html";
            File.WriteAllText(tpFilename, htmlStr, Encoding.UTF8);
            webKitBrowser1.Url = new Uri(tpFilename);

            //Form2 fm2 = new Form2
            //{
            //    webUrl = tpFilename
            //};
            //fm2.Show();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                DialogResult dr = MessageBox.Show("当前文档有更改，是否保存更改", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {

                    if (fileName != null)
                    {
                        File.WriteAllText(fileName, richTextBox1.Text);
                        isTextChanged = false;
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Filter = "Markdown|*.md"
                        };
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            fileName = saveFileDialog1.FileName;
                            File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
                            isTextChanged = false;
                        }
                    }
                    fileName = null;

                }
                if (dr == DialogResult.No)
                {
                    richTextBox1.Text = null;
                    isTextChanged = false;
                    fileName = null;
                }

            }
            else
            {
                richTextBox1.Text = null;
                isTextChanged = false;
                fileName = null;
            }
        }


        public void refreshPic(string url)
        {
            int index;

            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            htmlStr = markdown.Transform(richTextBox1.Text.Insert(richTextBox1.SelectionStart, url));
            File.WriteAllText(tpFilename, htmlStr, Encoding.UTF8);
            webKitBrowser1.Url = new Uri(tpFilename);

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fm4 = new Form4();
            DialogResult ddr = fm4.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                if (fm4.ImgUrl != null)
                {

                    Form9 form9 = new Form9()
                    {
                        picUrl = fm4.url
                        
                    };

                    form9.upData += new upData(refreshPic);

                    if (form9.ShowDialog() == DialogResult.OK)
                    {
                        int index;
                        richTextBox1.Focus();
                        index = richTextBox1.SelectionStart;
                        if (form9.newUrl == null) form9.newUrl = fm4.ImgUrl;
                        this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, form9.newUrl);
                        richTextBox1.SelectionStart = index;
                    }
                    else
                    {
                        int index;
                        richTextBox1.Focus();
                        index = richTextBox1.SelectionStart;
                        this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm4.ImgUrl);
                        richTextBox1.SelectionStart = index;
                    }


                    //int index;
                    //richTextBox1.Focus();
                    //index = richTextBox1.SelectionStart;
                    //this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm4.ImgUrl);
                    //richTextBox1.SelectionStart = index;

                }
            }

        }
        /// <summary>
        /// 注册委托事件，打开图片编辑工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            //Form8 form8 = new Form8();
            //form8.insertTempPic += new DelegateInsertTempPic(insertTempPic);
            //form8.Refresh += new DelegateRefresh(Refresh);
            //form8.Show();

            //Form4 fm4 = new Form4();
            //DialogResult ddr = fm4.ShowDialog();
            //if (ddr == DialogResult.OK)
            //{
            //    if (fm4.ImgUrl != null)
            //    {
            //        int index;
            //        richTextBox1.Focus();
            //        index = richTextBox1.SelectionStart;
            //        this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm4.ImgUrl);
            //        richTextBox1.SelectionStart = index;

            //    }
            //}
        }
        /// <summary>
        /// 定义Form8委托事件
        /// </summary>
        /// <param name="url"></param>
        //public void insertTempPic(string url)
        //{
        //    int index;
        //   this.richTextBox1.Focus();
        //    index = this.richTextBox1.SelectionStart;
        //    this.richTextBox1.Text = this.richTextBox1.Text.Insert(this.richTextBox1.SelectionStart, "![预览](" + url + ")");
        //    this.richTextBox1.SelectionStart = index;
        //}
        //public void refreshPage()
        //{

        //    this.webKitBrowser1.Refresh();
        //}

        /// ////////////////////////////////////////////////////

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            DialogResult ddr = fm3.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                int index;
                richTextBox1.Focus();
                index = richTextBox1.SelectionStart;
                this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm3.urlstr);
                richTextBox1.SelectionStart = index;
            }
        }

        private void 文章头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            DialogResult ddr = fm5.ShowDialog();
            if (ddr == DialogResult.OK)
            {

                this.richTextBox1.Text = this.richTextBox1.Text.Insert(0, fm5.txt);
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            DialogResult ddr = fm5.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                this.richTextBox1.Text = this.richTextBox1.Text.Insert(0, fm5.txt);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                DialogResult dr = MessageBox.Show("当前文档有更改，是否保存更改", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {

                    if (fileName != null)
                    {
                        File.WriteAllText(fileName, richTextBox1.Text);
                        isTextChanged = false;
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Filter = "Markdown|*.md"
                        };
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            fileName = saveFileDialog1.FileName;
                            File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
                            isTextChanged = false;
                        }
                    }

                }
                if (dr == DialogResult.No)
                {
                    richTextBox1.Text = null;
                    isTextChanged = false;
                }

            }
            else
            {
                richTextBox1.Text = null;
                isTextChanged = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Markdown|*.md"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.UTF8);

            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {


            if (fileName != null)
            {
                File.WriteAllText(fileName, richTextBox1.Text);
                isTextChanged = false;
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Markdown|*.md"
                };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
                    isTextChanged = false;
                }
            }

        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Markdown|*.md"
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "****");
            richTextBox1.SelectionStart = index + 2;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "**");
            richTextBox1.SelectionStart = index + 1;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "> ");
            richTextBox1.SelectionStart = index + 2;
        }

        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n    ");
            richTextBox1.SelectionStart = index + 5;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n    ");
            richTextBox1.SelectionStart = index + 5;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n--------\n");
            richTextBox1.SelectionStart = index + 10;
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n--------\n");
            richTextBox1.SelectionStart = index + 10;
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n1. ");
            richTextBox1.SelectionStart = index + 4;
        }

        private void orderedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n1. ");
            richTextBox1.SelectionStart = index + 4;
        }

        private void unorderedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n- ");
            richTextBox1.SelectionStart = index + 3;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            int index;
            richTextBox1.Focus();
            index = richTextBox1.SelectionStart;
            this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, "\n- ");
            richTextBox1.SelectionStart = index + 3;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

        }

        private void 预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Markdown markdown = new Markdown();
            htmlStr = markdown.Transform(richTextBox1.Text);

            tpFilename = Path.GetTempPath();
            tpFilename += "preview.html";
            File.WriteAllText(tpFilename, htmlStr, Encoding.UTF8);

            Form2 fm2 = new Form2
            {
                webUrl = tpFilename
            };
            fm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tpFilename = Path.GetTempPath();
            tpFilename += "preview.html";
            if((fileName!=null)&&(Path.GetExtension(fileName)==".md"))
            {
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.UTF8);

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTextChanged)
            {
                DialogResult dr = MessageBox.Show("当前文档有更改，是否保存更改", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {

                    if (fileName != null)
                    {
                        File.WriteAllText(fileName, richTextBox1.Text);
                        isTextChanged = false;
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Filter = "Markdown|*.md"
                        };
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            fileName = saveFileDialog1.FileName;
                            File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
                            isTextChanged = false;
                        }
                    }
                }
            }

            File.Delete(tpFilename);
        }

        private void 发布助手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (toolStripButton17.Checked)
            {
                isTextChanged = true;
                //Markdown markdown = new Markdown();
                htmlStr = markdown.Transform(richTextBox1.Text);

                //tpFilename = Path.GetTempPath();

                //tpFilename += "preview.html";
                File.WriteAllText(tpFilename, htmlStr, Encoding.UTF8);
                webKitBrowser1.Url = new Uri(tpFilename);

                //Form2 fm2 = new Form2
                //{
                //    webUrl = tpFilename
                //};
                //fm2.Show();
            }
        }

        private void 在线图库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fm6 = new Form6();
            fm6.Show();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(Path.GetExtension(path[0])==".md")
            {
                fileName = path[0];
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.UTF8);

            }
           

        }

   

        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Path.GetExtension(path[0]) == ".md")
            {
                fileName = path[0];
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.UTF8);

            }
        }

        private void 网站管理中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                File.WriteAllText(fileName, richTextBox1.Text);
                isTextChanged = false;

                string head = richTextBox1.Lines[0];
                if (head != "+++")
                {
                    DialogResult dr = MessageBox.Show("文档必须包含文章头才可以发布", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {


                    //open发布助手
                    Form7 fm7 = new Form7()
                    {
                        path = fileName
                    };
                    fm7.ShowDialog();

                }


            }
            else
            {
                DialogResult dr = MessageBox.Show("必须将文档保存才可以发布", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog
                    {
                        Filter = "Markdown|*.md"
                    };
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveFileDialog1.FileName;
                        File.WriteAllText(fileName, richTextBox1.Text, Encoding.UTF8);
                        isTextChanged = false;
                    }

                    try
                    {
                        string head = richTextBox1.Lines[0];
                        if (head != "+++")
                        {
                            dr = MessageBox.Show("文档必须包含文章头才可以发布", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {


                            //open发布助手
                            Form7 fm7 = new Form7()
                            {
                                path = fileName
                            };
                            fm7.ShowDialog();

                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        dr = MessageBox.Show("这是一篇空文档，空白文档的发布会引起未知的错误，请至少插入文章头", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }




                }


            }
        }

        private void toolStripButton12_Click_1(object sender, EventArgs e)
        {
            Form4 fm4 = new Form4();
            DialogResult ddr = fm4.ShowDialog();
            if (ddr == DialogResult.OK)
            {
                if (fm4.ImgUrl != null)
                {

                    Form9 form9 = new Form9()
                    {
                        picUrl = fm4.url

                    };

                    form9.upData += new upData(refreshPic);

                    if (form9.ShowDialog() == DialogResult.OK)
                    {
                        int index;
                        richTextBox1.Focus();
                        index = richTextBox1.SelectionStart;
                        this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, form9.newUrl);
                        richTextBox1.SelectionStart = index;
                    }
                    else
                    {
                        int index;
                        richTextBox1.Focus();
                        index = richTextBox1.SelectionStart;
                        this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm4.ImgUrl);
                        richTextBox1.SelectionStart = index;
                    }


                    //int index;
                    //richTextBox1.Focus();
                    //index = richTextBox1.SelectionStart;
                    //this.richTextBox1.Text = this.richTextBox1.Text.Insert(richTextBox1.SelectionStart, fm4.ImgUrl);
                    //richTextBox1.SelectionStart = index;

                }
            }
        }

        //private void toolStripButton12_Click(object sender, EventArgs e)
        //{

        //}
    }
}
