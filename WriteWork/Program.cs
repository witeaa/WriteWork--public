using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WriteWork
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string path=null;
            try
            {
                if (args != null)
                {
                    path = args[0];
                }
            }
            catch(IndexOutOfRangeException)
            {
                path = null;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1()
            {
                fileName = path
            };
            Application.Run(form1);
        }
    }
}
