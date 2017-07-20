using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sweepBoom
{
    public partial class ScoreShowDlg : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "User.mdf" + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        
        //声明存储三种模式的数据集
        DataSet simpleDataSet = null;
        DataSet middleDataSet = null;
        DataSet hardDataSet = null;


        public ScoreShowDlg()
        {
            //窗口的初始化
            InitializeComponent();

            //读取简单模式下的用户名和分数
            try
            {
                string sql = "select loginUserName, simpleScore from sweepuser order by simpleScore asc";
                conn = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter(sql, conn);
                simpleDataSet = new DataSet();
                adapter.Fill(simpleDataSet, "sweepuser");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            simpleGridView.DataSource = simpleDataSet.Tables[0];
            simpleGridView.Columns[0].HeaderCell.Value = "姓名"; 
            simpleGridView.Columns[1].HeaderCell.Value = "分数";

            //读取中等模式下的用户名和分数
            try
            {
                string sql = "select loginUserName, middleScore from sweepuser order by middleScore asc";
                //conn = new OleDbConnection(connectionString);
                //adapter = new OleDbDataAdapter(sql, conn);
                conn = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter(sql, conn);
                middleDataSet = new DataSet();
                adapter.Fill(middleDataSet, "sweepuser");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            middleGridView.DataSource = middleDataSet.Tables[0];
            middleGridView.Columns[0].HeaderCell.Value = "姓名";
            middleGridView.Columns[1].HeaderCell.Value = "分数";

            //读取困难模式下的用户名和分数
            try
            {
                string sql = "select loginUserName, hardScore from sweepuser order by hardScore asc";
                //conn = new OleDbConnection(connectionString);
                //adapter = new OleDbDataAdapter(sql, conn);
                conn = new SqlConnection(connectionString);
                adapter = new SqlDataAdapter(sql, conn);
                hardDataSet = new DataSet();
                adapter.Fill(hardDataSet, "sweepuser");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            hardGridView.DataSource = hardDataSet.Tables[0];
            hardGridView.Columns[0].HeaderCell.Value = "姓名";
            hardGridView.Columns[1].HeaderCell.Value = "分数";


        }



        private void ScoreShowDlg_Load(object sender, EventArgs e)
        {

        }

    }
}
