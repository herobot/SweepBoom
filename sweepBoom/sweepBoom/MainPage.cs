using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace sweepBoom
{
    public partial class Form1 : Form
    {

        private int _BoomSize = 12;

        private int _BoomCount = 15;

        private int _sweepBoomCount = 0;

        public int BoomSize
        {
            get { return _BoomSize; }
            set { _BoomSize = value; }
        }

        public int BoomCount
        {
            get { return _BoomCount; }
            set { _BoomCount = value; }
        }

        public int sweepBoomCount
        {
            get { return _sweepBoomCount; }
            set { _sweepBoomCount = value; }
        }


        //记录是否已经成功完成,完成了禁止时间继续。1是不禁止，2,3是禁止的两种路径
        private int isFinish = 1;

        //记录完成时候的时间
        public static TimeSpan winTime;

        //设置时间变量记录时间
        public static DateTime startTime;

        //生成矩阵的大小
        private static bool[,] buttonHasBoom;
        private static BoomButton[,] boomButton;

        //声明新建窗体的线程
        private Thread thread;

        //声明需要新建的四种窗体模式
        private Form1 formSimple;
        private Form1 formMiddle;
        private Form1 formHard;
        private Form1 formCustom;

        /// <summary>
        /// form1的构造函数
        /// </summary>
        public Form1(int setBoomSize, int setBoomCount)
        {
            //初始化窗口
            InitializeComponent();

            this.BoomCount = setBoomCount;
            this.BoomSize = setBoomSize;

            //新建一个进程
            thread = new Thread(new ThreadStart(newForm));


            //用于产生雷阵
            boomButton = new BoomButton[setBoomSize, setBoomSize];
            buttonHasBoom = new bool[setBoomSize, setBoomSize];

            int i, j, boomCount = 0;

            startTime = DateTime.Now;

            Random random = new Random();
            for (i = 0; i < setBoomSize; ++i)
                for (j = 0; j < setBoomSize; ++j)
                    buttonHasBoom[i, j] = false;
            while (boomCount < setBoomCount)
            {
                i = random.Next(setBoomSize);
                j = random.Next(setBoomSize);
                if (buttonHasBoom[i, j] == false)
                {
                    buttonHasBoom[i, j] = true;
                    boomCount++;
                }
            }

            // 用于初始化所有雷
            for (i = 0; i < setBoomSize; ++i)
                for (j = 0; j < setBoomSize; ++j)
                {
                    boomButton[i, j] = new BoomButton(i, j);
                    boomButton[i, j].hasBoom = buttonHasBoom[i, j];

                    //确定好每个按钮的大小,使其大小各相同
                    boomButton[i, j].Width = 30;
                    boomButton[i, j].Height = 30;

                    //设置button里面的背景图片，默认为空
                    boomButton[i, j].FlatStyle = FlatStyle.Standard;
                    boomButton[i, j].BackColor = SystemColors.Control;
                    Image image = null;
                    boomButton[i, j].BackgroundImage = image;

                    //确定button里面字体的大小
                    float fontSize = 9f;
                    boomButton[i, j].Font = new Font(boomButton[i, j].Font.Name, fontSize,
                        boomButton[i, j].Font.Style, boomButton[i, j].Font.Unit);

                    //确定雷的分布位置
                    boomButton[i, j].Left = i * boomButton[i, j].Width;
                    boomButton[i, j].Top = j * boomButton[i, j].Height;

                    //确定扫雷的左右击事件
                    boomButton[i, j].Click += new EventHandler(BtnLeft_Click);
                    boomButton[i, j].MouseUp += new MouseEventHandler(BtnRight_Click);
                    boomButton[i, j].DoubleClick += new EventHandler(BtnLeft_OnMouseDoubleClick);

                    //将button添加到panel上
                    panel1.Controls.Add(boomButton[i, j]);
                }

            //计算周边雷的数目
            for (i = 0; i < setBoomSize; i++)
                for (j = 0; j < setBoomSize; j++)
                {
                    if (buttonHasBoom[i, j] == true)
                    {
                        if (i - 1 >= 0 && j - 1 >= 0)
                            boomButton[i - 1, j - 1].countAround++;
                        if (j - 1 >= 0)
                            boomButton[i, j - 1].countAround++;
                        if (i + 1 <= setBoomSize - 1 & j - 1 >= 0)
                            boomButton[i + 1, j - 1].countAround++;
                        if (i - 1 >= 0)
                            boomButton[i - 1, j].countAround++;
                        if (i + 1 <= setBoomSize - 1)
                            boomButton[i + 1, j].countAround++;
                        if (i - 1 >= 0 && j + 1 <= setBoomSize - 1)
                            boomButton[i - 1, j + 1].countAround++;
                        if (j + 1 <= setBoomSize - 1)
                            boomButton[i, j + 1].countAround++;
                        if (i + 1 <= setBoomSize - 1 && j + 1 <= setBoomSize - 1)
                            boomButton[i + 1, j + 1].countAround++;
                    }
                }



        }

        /// <summary>
        /// 左击事件排雷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeft_Click(object sender, EventArgs e)
        {
            BoomButton btn = (BoomButton)sender;

            //如果不是关闭的，return
            if (btn.status != BtnStatus.close) return;

            btn.status = BtnStatus.open;
            btn.FlatStyle = FlatStyle.Flat;

            if (btn.hasBoom == false)
            {
                //当前的周围没有雷，就进行递归的排雷      
                if (btn.countAround == 0)
                {
                    int i = btn.x, j = btn.y;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        BtnLeft_Click(boomButton[i - 1, j - 1], e);
                    if (j - 1 >= 0)
                        BtnLeft_Click(boomButton[i, j - 1], e);
                    if (i + 1 <= BoomSize - 1 & j - 1 >= 0)
                        BtnLeft_Click(boomButton[i + 1, j - 1], e);
                    if (i - 1 >= 0)
                        BtnLeft_Click(boomButton[i - 1, j], e);
                    if (i + 1 <= BoomSize - 1)
                        BtnLeft_Click(boomButton[i + 1, j], e);
                    if (i - 1 >= 0 && j + 1 <= BoomSize - 1)
                        BtnLeft_Click(boomButton[i - 1, j + 1], e);
                    if (j + 1 <= BoomSize - 1)
                        BtnLeft_Click(boomButton[i, j + 1], e);
                    if (i + 1 <= BoomSize - 1 && j + 1 <= BoomSize - 1)
                        BtnLeft_Click(boomButton[i + 1, j + 1], e);
                }
                else
                {
                    btn.Text = btn.countAround.ToString();
                }
            }
            else if (btn.hasBoom == true)
            {
                btn.BackgroundImage = imageList1.Images[1];
                btn.BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸
                //使得计数显示停止
                isFinish = 2;
                if (DialogResult.Yes == MessageBox.Show("You lose!\n是否开始新的一局游戏？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    Close();
                    thread.Start();
                }
                else
                {
                    //不做任何事
                }
            }

            checkGame();
        }

        /// <summary>
        /// 右击事件排雷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRight_Click(object sender, MouseEventArgs e)
        {
            BoomButton btn = (BoomButton)sender;

            //右击鼠标
            if (e.Button == MouseButtons.Right)
            {
                //如果已经翻开过，则返回
                if (btn.status == BtnStatus.open)
                    return;

                //未翻开
                if (btn.status == BtnStatus.close)
                {
                    btn.BackgroundImage = imageList1.Images[0];
                    btn.BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸

                    if (btn.hasBoom == true) sweepBoomCount++;

                    btn.status = BtnStatus.mark;
                }
                else  //标记扫雷
                {
                    //若已经标记的，则变回无标记
                    Image image = null;
                    btn.BackgroundImage = image;

                    if (btn.hasBoom == true) sweepBoomCount--;

                    btn.status = BtnStatus.close;
                }

                checkGame();
            }
        }

        /// <summary>
        /// 左击双击事件自动排雷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeft_OnMouseDoubleClick(object sender, EventArgs e)
        {
            BoomButton btn = (BoomButton)sender;
            int i = btn.x, j = btn.y;
            int m, n;
            int count = 0;
            if (btn.status == BtnStatus.open)
            {
                if (i - 1 >= 0 && j - 1 >= 0)
                    if (boomButton[i - 1, j - 1].status == BtnStatus.mark)
                        count++;
                if (j - 1 >= 0)
                    if (boomButton[i, j - 1].status == BtnStatus.mark)
                        count++;
                if (i + 1 <= BoomSize - 1 & j - 1 >= 0)
                    if (boomButton[i + 1, j - 1].status == BtnStatus.mark)
                        count++;
                if (i - 1 >= 0)
                    if (boomButton[i - 1, j].status == BtnStatus.mark)
                        count++;
                if (i + 1 <= BoomSize - 1)
                    if (boomButton[i + 1, j].status == BtnStatus.mark)
                        count++;
                if (i - 1 >= 0 && j + 1 <= BoomSize - 1)
                    if (boomButton[i - 1, j + 1].status == BtnStatus.mark)
                        count++;
                if (j + 1 <= BoomSize - 1)
                    if (boomButton[i, j + 1].status == BtnStatus.mark)
                        count++;
                if (i + 1 <= BoomSize - 1 && j + 1 <= BoomSize - 1)
                    if (boomButton[i + 1, j + 1].status == BtnStatus.mark)
                        count++;
                if (count == btn.countAround)
                    if (i + 1 == BoomSize)
                    {
                        for (m = i - 1; m < i + 1; ++m)
                            for (n = j - 1; n <= j + 1; ++n)
                                if (boomButton[m, n].status == BtnStatus.close)
                                {
                                    if (boomButton[m, n].hasBoom == true)
                                    {
                                        boomButton[m, n].BackgroundImage = imageList1.Images[2];
                                        boomButton[m, n].BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸
                                        //使得计数显示停止
                                        isFinish = 2;
                                        if (DialogResult.Yes == MessageBox.Show("You lose!\n是否开始新的一局游戏？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                                        {
                                            Close();
                                            thread.Start();
                                        }
                                        else
                                        {
                                            //不做任何事
                                        }
                                    }
                                    boomButton[m, n].status = BtnStatus.open;
                                    boomButton[m, n].FlatStyle = FlatStyle.Flat;
                                    if (boomButton[m, n].countAround != 0)
                                        boomButton[m, n].Text = boomButton[m, n].countAround.ToString();
                                }
                                else
                                    continue;
                    }
                    else if (i == 0)
                    {
                        for (m = i; m <= i + 1; ++m)
                            for (n = j - 1; n <= j + 1; ++n)
                                if (boomButton[m, n].status == BtnStatus.close)
                                {
                                    if (boomButton[m, n].hasBoom == true)
                                    {
                                        boomButton[m, n].BackgroundImage = imageList1.Images[2];
                                        boomButton[m, n].BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸
                                        MessageBox.Show("lose");
                                        //使得计数显示停止
                                        isFinish = 2;
                                    }
                                    boomButton[m, n].status = BtnStatus.open;
                                    boomButton[m, n].FlatStyle = FlatStyle.Flat;
                                    if (boomButton[m, n].countAround != 0)
                                        boomButton[m, n].Text = boomButton[m, n].countAround.ToString();
                                }
                                else
                                    continue;
                    }
                    else if (j == 0)
                    {
                        for (m = i - 1; m <= i + 1; ++m)
                            for (n = j; n <= j + 1; ++n)
                                if (boomButton[m, n].status == BtnStatus.close)
                                {
                                    if (boomButton[m, n].hasBoom == true)
                                    {
                                        boomButton[m, n].BackgroundImage = imageList1.Images[2];
                                        boomButton[m, n].BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸
                                        //使得计数显示停止
                                        isFinish = 2;
                                        if (DialogResult.Yes == MessageBox.Show("You lose!\n是否开始新的一局游戏？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                                        {
                                            Close();
                                            thread.Start();
                                        }
                                        else
                                        {
                                            //不做任何事
                                        }
                                    }
                                    boomButton[m, n].status = BtnStatus.open;
                                    boomButton[m, n].FlatStyle = FlatStyle.Flat;
                                    if (boomButton[m, n].countAround != 0)
                                        boomButton[m, n].Text = boomButton[m, n].countAround.ToString();
                                }
                                else
                                    continue;
                    }
                    else if (j + 1 == BoomSize)
                    {
                        for (m = i - 1; m <= i + 1; ++m)
                            for (n = j - 1; n < j + 1; ++n)
                                if (boomButton[m, n].status == BtnStatus.close)
                                {
                                    if (boomButton[m, n].hasBoom == true)
                                    {
                                        boomButton[m, n].BackgroundImage = imageList1.Images[2];
                                        boomButton[m, n].BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸
                                        //使得计数显示停止
                                        isFinish = 2;
                                        if (DialogResult.Yes == MessageBox.Show("You lose!\n是否开始新的一局游戏？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                                        {
                                            Close();
                                            thread.Start();
                                        }
                                        else
                                        {
                                            //不做任何事
                                        }
                                    }
                                    boomButton[m, n].status = BtnStatus.open;
                                    boomButton[m, n].FlatStyle = FlatStyle.Flat;
                                    if (boomButton[m, n].countAround != 0)
                                        boomButton[m, n].Text = boomButton[m, n].countAround.ToString();
                                }
                                else
                                    continue;
                    }
                    else
                    {
                        for (m = i - 1; m <= i + 1; ++m)
                            for (n = j - 1; n <= j + 1; ++n)
                                if (boomButton[m, n].status == BtnStatus.close)
                                {
                                    if (boomButton[m, n].hasBoom == true)
                                    {
                                        boomButton[m, n].BackgroundImage = imageList1.Images[2];
                                        boomButton[m, n].BackgroundImageLayout = ImageLayout.Stretch;//在按钮中拉伸
                                        //使得计数显示停止
                                        isFinish = 2;
                                        if (DialogResult.Yes == MessageBox.Show("You lose!\n是否开始新的一局游戏？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                                        {
                                            Close();
                                            thread.Start();
                                        }
                                        else
                                        {
                                            //不做任何事
                                        }
                                    }
                                    boomButton[m, n].status = BtnStatus.open;
                                    boomButton[m, n].FlatStyle = FlatStyle.Flat;
                                    if (boomButton[m, n].countAround != 0)
                                        boomButton[m, n].Text = boomButton[m, n].countAround.ToString();
                                }
                                else
                                    continue;
                    }


            }
            else
                return;
        }

        /// <summary>
        /// 检查雷是否被排光
        /// </summary>
        public void checkGame()
        {
            int i, j;

            //所有的雷已经排除完毕
            if (sweepBoomCount == BoomCount)
            {
                for (i = 0; i < BoomSize; ++i)
                    for (j = 0; j < BoomSize; ++j)
                        if (sweepBoomCount != BoomCount)
                            return;

                string winTime = DateTime.Parse(Form1.winTime.ToString()).ToString("mm:ss");

                isFinish = 2;


                //根据选择的模式选择写入到数据库中的哪一个记录中
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + "User.mdf" + ";Integrated Security=True;Connect Timeout=30";
                SqlCommand command = null;
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();

                    switch (modelChooseDlg.setModel)
                    {
                        case modelChooseDlg.model.simple:
                            command = new SqlCommand("update sweepuser set simpleScore = '" + winTime.Trim() + "' where loginUserName = '" + LoginDlg.loginUserName + "'" , conn);
                            break;
                        case modelChooseDlg.model.middle:
                            command = new SqlCommand("update sweepuser set middleScore = '" + winTime.Trim() + "' where loginUserName = '" + LoginDlg.loginUserName + "'", conn);
                            break;
                        case modelChooseDlg.model.hard:
                            command = new SqlCommand("update sweepuser set hardScore = '" + winTime.Trim() + "' where loginUserName = '" + LoginDlg.loginUserName + "'", conn);
                            break;
                        default:
                            break;
                    }

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("你已完成！\n你的记录已记录在英雄榜上！", "恭喜：", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null) conn.Close();
                    command.Dispose();
                }

               // MessageBox.Show("You win！！！", "恭喜！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == MessageBox.Show("是否开始新的一局游戏？", "温馨提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    Close();
                    thread.Start();
                }
                else
                {
                    //不做任何事
                }
            }
        }


        /// <summary>
        /// 窗口初始化
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始KToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始游戏OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新开始RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出游戏QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.难度设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.排行榜PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于作者AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 580);
            this.panel1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "flat.png");
            this.imageList1.Images.SetKeyName(1, "boom.jpg");
            this.imageList1.Images.SetKeyName(2, "boomfalse.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始KToolStripMenuItem,
            this.选项XToolStripMenuItem,
            this.关于作者AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始KToolStripMenuItem
            // 
            this.开始KToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始游戏OToolStripMenuItem,
            this.重新开始RToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出游戏QToolStripMenuItem});
            this.开始KToolStripMenuItem.Name = "开始KToolStripMenuItem";
            this.开始KToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.开始KToolStripMenuItem.Text = "开始(&K)";
            // 
            // 开始游戏OToolStripMenuItem
            // 
            this.开始游戏OToolStripMenuItem.Name = "开始游戏OToolStripMenuItem";
            this.开始游戏OToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.开始游戏OToolStripMenuItem.Text = "开始游戏(&O)";
            this.开始游戏OToolStripMenuItem.Click += new System.EventHandler(this.开始游戏OToolStripMenuItem_Click);
            // 
            // 重新开始RToolStripMenuItem
            // 
            this.重新开始RToolStripMenuItem.Name = "重新开始RToolStripMenuItem";
            this.重新开始RToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.重新开始RToolStripMenuItem.Text = "重新开始(R)";
            this.重新开始RToolStripMenuItem.Click += new System.EventHandler(this.重新开始RToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // 退出游戏QToolStripMenuItem
            // 
            this.退出游戏QToolStripMenuItem.Name = "退出游戏QToolStripMenuItem";
            this.退出游戏QToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.退出游戏QToolStripMenuItem.Text = "退出游戏(&Q)";
            this.退出游戏QToolStripMenuItem.Click += new System.EventHandler(this.退出游戏QToolStripMenuItem_Click);
            // 
            // 选项XToolStripMenuItem
            // 
            this.选项XToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.难度设置SToolStripMenuItem,
            this.toolStripSeparator2,
            this.排行榜PToolStripMenuItem});
            this.选项XToolStripMenuItem.Name = "选项XToolStripMenuItem";
            this.选项XToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.选项XToolStripMenuItem.Text = "选项(&X)";
            // 
            // 难度设置SToolStripMenuItem
            // 
            this.难度设置SToolStripMenuItem.Name = "难度设置SToolStripMenuItem";
            this.难度设置SToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.难度设置SToolStripMenuItem.Text = "难度设置(&S)";
            this.难度设置SToolStripMenuItem.Click += new System.EventHandler(this.难度设置SToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // 排行榜PToolStripMenuItem
            // 
            this.排行榜PToolStripMenuItem.Name = "排行榜PToolStripMenuItem";
            this.排行榜PToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.排行榜PToolStripMenuItem.Text = "排行榜(&P)";
            this.排行榜PToolStripMenuItem.Click += new System.EventHandler(this.排行榜PToolStripMenuItem_Click);
            // 
            // 关于作者AToolStripMenuItem
            // 
            this.关于作者AToolStripMenuItem.Name = "关于作者AToolStripMenuItem";
            this.关于作者AToolStripMenuItem.Size = new System.Drawing.Size(122, 29);
            this.关于作者AToolStripMenuItem.Text = "关于作者(&A)";
            this.关于作者AToolStripMenuItem.Click += new System.EventHandler(this.关于作者AToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "游戏时间：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.timeLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 63);
            this.panel2.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(339, 25);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(53, 18);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(893, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //设置panel1的位置和大小
            panel1.SetBounds(0, 60, BoomSize * 30, BoomSize * 30 + 60);

            //设置工作区大小
            ClientSize = new Size(BoomSize * 30, BoomSize * 30 + 60);

            //设置起始位置居中
            StartPosition = FormStartPosition.CenterScreen;

            //设置panel2的位置和大小
            panel2.SetBounds(0, 30, BoomSize * 30, 30);

            //设置时间label的位置
            label1.Parent = panel2;
            timeLabel.Parent = panel2;
            label1.SetBounds(panel2.Width / 2 - 50, panel2.Height / 2 - 10, 100, 20);
            timeLabel.SetBounds(panel2.Width / 2 + 50, panel2.Height / 2 - 10, 100, 20);

            //设置timer的间隔
            this.timer1.Interval = 1000;
            this.timer1.Start();


        }

        private void 关于作者AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by 刘广大.\nWeChat:511533061", "关于作者：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void 退出游戏QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        //设置线程需要运行的函数
        private void newForm()
        {
            switch (modelChooseDlg.setModel)
            {
                case modelChooseDlg.model.simple:
                    formSimple = new Form1(modelChooseDlg.setBoomSize, modelChooseDlg.setBoomCount);
                    Application.Run(formSimple);
                    break;
                case modelChooseDlg.model.middle:
                    formMiddle = new Form1(modelChooseDlg.setBoomSize, modelChooseDlg.setBoomCount);
                    Application.Run(formMiddle);
                    break;
                case modelChooseDlg.model.hard:
                    formHard = new Form1(modelChooseDlg.setBoomSize, modelChooseDlg.setBoomCount);
                    Application.Run(formHard);
                    break;
                case modelChooseDlg.model.custom:
                    formCustom = new Form1(modelChooseDlg.setBoomSize, modelChooseDlg.setBoomCount);
                    Application.Run(formCustom);
                    break;
            }
        }

        private void 难度设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelChooseDlg choose = new modelChooseDlg();
            choose.ShowDialog();
            if (choose.DialogResult == System.Windows.Forms.DialogResult.OK)
                thread.Start();
            choose.Close();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime nowTime = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan();
            winTime = timeSpan = nowTime - startTime;
            switch(isFinish)
            {
                case 1:
                    timeLabel.Text = DateTime.Parse(timeSpan.ToString()).ToString("mm:ss");
                    break;
                case 2:
                    //winTime = timeSpan;
                    timeLabel.Text = DateTime.Parse(winTime.ToString()).ToString("mm:ss");
                    isFinish = 3;
                    break;
                case 3:
                    break;
            }

            Application.DoEvents();
        }

        private void 重新开始RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            thread.Start();
        }

        private void 排行榜PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoreShowDlg scoreDlg = new ScoreShowDlg();
            scoreDlg.ShowDialog();
        }

        private void 开始游戏OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            thread.Start();
        }
    }
}
