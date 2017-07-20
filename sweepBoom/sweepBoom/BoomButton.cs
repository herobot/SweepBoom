using System;
using System.Collections.Generic;
using System.Data.OleDb;//引入button类
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sweepBoom
{
    //用枚举来列举按钮的标志
    enum BtnStatus
    {
        close,
        open,
        mark,
    }

    /// <summary>
    /// 雷的按钮，继承button类，重写
    /// </summary>
    class BoomButton : Button
    {
        //私有变量用_开头
        private BtnStatus _status;//标志格子的状态，close open mark
        private bool _hasBoom;//标志有无炸弹 false or true
        private int _countAround;//周围炸弹的数量
        private int _x;
        private int _y;

        /// <summary>
        /// boombutton的构造方法，用于初始化
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public BoomButton(int x, int y)
        {
            this._countAround = 0;
            this._hasBoom = false;
            this._status = BtnStatus.close;
            this._x = x;
            this._y = y;
        }


        /// <summary>
        /// 另一个构造函数
        /// </summary>
        public BoomButton()
        {
            this._countAround = 0;
            this._hasBoom = false;
            this._status = BtnStatus.close;
        }


        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// 获取和设置当前格子是否有地雷
        /// </summary>
        public bool hasBoom
        {
            get { return _hasBoom; }
            set { _hasBoom = value; }
        }

        /// <summary>
        /// 获取和设置当前格子的状态
        /// </summary>
        public BtnStatus status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 获取和设置当前格子周围的地雷数
        /// </summary>
        public int countAround
        {
            get { return _countAround; }
            set { _countAround = value; }
        }

        /// <summary>
        /// 构造鼠标双击事件
        /// </summary>
        public new event EventHandler DoubleClick;
        DateTime clickTime;
        bool isClicked = false;
        

        /// <summary>
        /// 重写双击事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
 	         base.OnClick(e);
             if (isClicked)
             {
                 TimeSpan span = DateTime.Now - clickTime;
                 if (span.Milliseconds < SystemInformation.DoubleClickTime)
                 {
                     DoubleClick(this, e);
                     isClicked = false;
                 }
             }
             else
             {
                 isClicked = true;
                 clickTime = DateTime.Now;
             }
        }

    }
}
