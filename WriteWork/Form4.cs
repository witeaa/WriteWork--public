using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using ImageProcessor;

namespace WriteWork
{
    public partial class Form4 : Form
    {
        public string localPath;
        public const int APP_ID = 1252834524;
        public string ImgUrl;
        const string SECRET_ID = "AKIDJZmU8bCzypVL2dvLuNqRfCpMk1Ma25e7";
        const string SECRET_KEY = "d6PvdAiqtnX9ihgspgPXZS9eBZow0xmQ";
        public string url;

        const string bucketName = "bucket1";
        string time;
        string remotePath;
        const string folder = "/upload/";

        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图像|*.bmp;*.jpeg;*.png;*.jpg";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                localPath = ofd.FileName;
                time = DateTime.Now.ToFileTimeUtc().ToString();
                remotePath = "/upload/" + time + System.IO.Path.GetExtension(localPath);
                progressBar1.Value = 10;


            }

           
            //var result = "";
            var cos = new QCloud.CosApi.Api.CosCloud(APP_ID, SECRET_ID, SECRET_KEY);
            //上传文件（不论文件是否分片，均使用本接口）
            var uploadParasDic = new Dictionary<string, string>();
            progressBar1.Value = 50;
            uploadParasDic.Add(QCloud.CosApi.Common.CosParameters.PARA_BIZ_ATTR, "");
            uploadParasDic.Add(QCloud.CosApi.Common.CosParameters.PARA_INSERT_ONLY, "0");
            uploadParasDic.Add(QCloud.CosApi.Common.CosParameters.PARA_SLICE_SIZE, QCloud.CosApi.Common.SLICE_SIZE.SLIZE_SIZE_3M.ToString());
            string result = cos.UploadFile(bucketName, remotePath, localPath, uploadParasDic);
            progressBar1.Value = 100;
            DialogResult dr = MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == "上传成功")
            {

                ImgUrl = "http://bucket1-1252834524.picgz.myqcloud.com/upload/" + time + System.IO.Path.GetExtension(localPath);
               // url = ImgUrl;
                // textBox1.Text = result + localPath;
                //Clipboard.Clear();
                this.textBox1.Text = ImgUrl;
                //Clipboard.SetDataObject("http://bucket1-1252834524.cosgz.myqcloud.com/upload/" + time + System.IO.Path.GetExtension(localPath));
                //DialogResult dr = MessageBox.Show("链接已经复制到剪切板中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //http://bucket1-1252834524.picgz.myqcloud.com/upload/
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != null)
            {
                url = textBox1.Text;
                ImgUrl = "![" + textBox2.Text + "](" + textBox1.Text + ")";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            //if(checkBox1.Checked)
            //{
            //    textBox1.Text += "/witeaa";
            //}
            //else
            //{
            //    textBox1.Text = url;
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
