using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sweepBoom
{
    public partial class LoginDlg : Form
    {
        public LoginDlg()
        {
            InitializeComponent();
        }

        public static string loginUserName;
        public static string loginPassWord;

        /// <summary>
        /// 事件：点击了登录游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginSureButton_Click(object sender, EventArgs e)
        {
            loginUserName = userNameText.Text;
            loginPassWord = passWordText.Text;
            string getRegisPassWord = "";
            bool findTheUserName = false;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+System.AppDomain.CurrentDomain.BaseDirectory + "User.mdf" + ";Integrated Security=True;Connect Timeout=30";
            SqlCommand command = null;
            SqlConnection conn = null;
            DataSet dataSet = new DataSet();
            try
            {
                
                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand("select * from sweepuser", conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dataSet, "sweepuser");
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; ++i)
                {
                    if (loginUserName == dataSet.Tables[0].Rows[i][0].ToString().Trim())
                    {
                        getRegisPassWord = dataSet.Tables[0].Rows[i][1].ToString().Trim();
                        findTheUserName = true;
                        break;
                    }
                }
                if(findTheUserName == false)
                {
                    MessageBox.Show("请输入正确的用户名\n或注册正式用户名", "温馨提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userNameText.Clear();
                    passWordText.Clear();
                    userNameText.Focus();
                    return;
                }
                else
                {
                    //在数据库中找到相应的用户名
                    //从数据库读取密码，与用户输入是否想对应
                    if(getRegisPassWord == loginPassWord)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;

                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("请检查密码是否正确输入！", "温馨提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        passWordText.Clear();
                        passWordText.Focus();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //关闭数据库等
                if (conn != null) conn.Close();
                command.Dispose();
                
            }
            
        }

        private void LoginDlg_Load(object sender, EventArgs e)
        {
            userNameText.Focus();
        }


        /// <summary>
        /// 事件：点击注册用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterDlg regisDlg = new RegisterDlg();
            regisDlg.Show();
            
        }


        /// <summary>
        /// 事件：点击了忘记密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("该功能未开放\n如有忘记密码\n请重新注册！","温馨提示:",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loginCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        /// <summary>
        /// 事件：点击了免注册玩游戏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nonRegister_Click(object sender, EventArgs e)
        {
            //判断对话框用户点击了是还是否
            if(MessageBox.Show("该模式不会记录所完成的成绩\n是否确定继续进入该模式？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Dispose();
            }
            else
            {
                //如果点击了否,不做任何事

            }
        }
    }
}
