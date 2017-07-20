using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sweepBoom
{
    public partial class RegisterDlg : Form
    {
        public RegisterDlg()
        {
            InitializeComponent();
        }

        private void regisSureButton_Click(object sender, EventArgs e)
        {
            //读取用户输入的信息
            string regisUserName = regisUserNameText.Text;
            string regisPassWord1 = regisPassWordText1.Text;
            string regisPassWord2 = regisPassWordText2.Text;

            //如果用户未输入任何信息
            if(regisUserName.Length == 0 || regisPassWord1.Length == 0 || regisPassWord2.Length == 0)
            {
                MessageBox.Show("请输入正确的用户名以及密码", "温馨提示", MessageBoxButtons.OK);
                return;
            }

            //如果用户输入的两次密码不相同，清空并重新输入
            if (regisPassWord1 != regisPassWord2)
            {
                MessageBox.Show("两次输入的密码不相同\n请输入正确的密码!");
                regisPassWordText1.Clear();
                regisPassWordText2.Clear();
                return;
            }

            //如果用户输入正确，链接数据库，把数据写入
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "User.mdf" + ";Integrated Security=True;Connect Timeout=30";
            SqlCommand command = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand("insert into sweepuser values(@regisUserName, @regisPassWord, @simpleScore, @middleScore, @hardScore)", conn);

                command.Parameters.AddWithValue("@regisUserName", regisUserName.Trim());
                command.Parameters.AddWithValue("@regisPassWord", regisPassWord1.Trim());
                command.Parameters.AddWithValue("@simpleScore", "10:00");
                command.Parameters.AddWithValue("@middleScore", "10:00");
                command.Parameters.AddWithValue("@hardScore", "10:00");

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("成功注册！\nenjoy the game:)", "恭喜：", MessageBoxButtons.OK);
                    regisUserNameText.Clear();
                    regisPassWordText1.Clear();
                    regisPassWordText2.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                command.Dispose();
                Close();
            }

        }

        private void regisCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegisterDlg_Load(object sender, EventArgs e)
        {
            //设置用户名的框为焦点
            regisUserNameText.Focus();
        }
    }
}
