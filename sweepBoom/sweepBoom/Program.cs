using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweepBoom
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginDlg logindlg = new LoginDlg();
            logindlg.StartPosition = FormStartPosition.CenterScreen;//在屏幕中居中显示
            logindlg.ShowDialog();

            //声明简单模式窗口，默认是简单模式
            Form1 formSimple;

            if (logindlg.DialogResult == DialogResult.OK)
            {
                formSimple = new Form1(modelChooseDlg.setBoomSize, modelChooseDlg.setBoomCount);
                Application.Run(formSimple);
            }

        }
    }
}
