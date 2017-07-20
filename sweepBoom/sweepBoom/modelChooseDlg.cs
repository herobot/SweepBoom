using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweepBoom
{
    public partial class modelChooseDlg : Form
    {
        
        /// <summary>
        /// 用枚举来列举难度选择
        /// </summary>
        public enum model
        {
            simple,
            middle,
            hard,
            custom,
        }

        //用一个变量来记录，难度选择的是哪个,默认为简单模式
        public static model setModel = model.simple;

        public static int setBoomSize = 12;

        public static int setBoomCount = 15;



        public modelChooseDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 事件：确认键被按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modelChooseSureButton_Click(object sender, EventArgs e)
        {
            //分两种情况，一种是选择模式的确定，一种是自定义的确定行为
            //第一种，选择模式的确定
            switch(setModel)
            {
                case model.simple:
                    setBoomSize = 12;
                    setBoomCount = 15;
                    break;
                case model.middle:
                    setBoomSize = 16;
                    setBoomCount = 30;
                    break;
                case model.hard:
                    setBoomSize = 20;
                    setBoomCount = 50;
                    break;
                case model.custom:
                    //第二种情况，前提判断输入框中是否由输入再执行以下代码,即检测是否执行模式选择
                    if (boomSize.TextLength != 0)
                    {
                        //get输入框中的数字
                        int sizeboom = Convert.ToInt16(boomSize.Text);
                        int countboom = Convert.ToInt16(boomCount.Text);

                        if (sizeboom < 12 || sizeboom > 20 || countboom < 15 || countboom > 50)
                        {
                            MessageBox.Show("请输入正确范围内的数字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            boomSize.Clear();
                            boomCount.Clear();
                            boomSize.Focus();
                            return;
                        }
                        setBoomSize = sizeboom;
                        setBoomCount = countboom;
                        
                    }
                    break;

            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }

        /// <summary>
        /// 事件：选择模式窗口被加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modelChooseDlg_Load(object sender, EventArgs e)
        {
            hideCustom();
        }


        /// <summary>
        /// 事件：简单模式被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hideCustom();
            setModel = model.simple;
        }

        /// <summary>
        /// 事件：中等模式被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hideCustom();
            setModel = model.middle;
        }

        /// <summary>
        /// 事件：困难模式被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            hideCustom();
            setModel = model.hard;
        }

        /// <summary>
        /// 事件：自定义模式被选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            showCustom();
            boomSize.Focus();
            setModel = model.custom;
        }


        /// <summary>
        /// 加载的时候隐藏自定义按钮的功能键，当自定义被选择的时候显示
        /// </summary>
        private void hideCustom()
        {
            label5.Hide();
            label6.Hide();
            boomSize.Hide();
            boomCount.Hide();
        }


        /// <summary>
        /// 自定义被选择之后,自动弹出输入功能
        /// </summary>
        private void showCustom()
        { 
            label5.Show();
            label6.Show();
            boomSize.Show();
            boomCount.Show();
        }
    }
}
