using System;
using System.Drawing;
using System.Windows.Forms;

namespace WCF
{
    public partial class ShowPopup : Form
    {
        private int iLevel = 0;
        /// <summary>
        /// 创建窗口实例
        /// </summary>
        /// <param name="strTitle">标题</param>
        /// <param name="strContent">内容</param>
        /// <param name="iLevel">日志记录等级</param>
        /// <param name="iType">1：只显示确认按钮，2：显示确认按钮和取消按钮，3：确认、重试、取消三个按钮都显示</param>
        public ShowPopup(string strContent, string strTitle, int iLevel, int iType = 1)
        {
            InitializeComponent();

            this.iLevel = iLevel;
            txtShowPopupTitle.Text = strTitle;
            txtShowPopupContent.Text = strContent;
            if (iType == 1)
            {
                btnShowPopupRetry.Visible = false;
                btnShowPopupCancel.Visible = false;
            }
            else if(iType == 2)
            {
                btnShowPopupRetry.Visible = false;
            }
        }

        private int iCloseType = 0;
        private void btnShowPopupOK_Click(object sender, EventArgs e)
        {

            iCloseType = 1;
            Close();
        }

        private void btnShowPopupRetry_Click(object sender, EventArgs e)
        {

            iCloseType = 2;
            Close();
        }

        private void btnShowPopupCancel_Click(object sender, EventArgs e)
        {

            iCloseType = 3;
            Close();
        }

        private void ShowPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            string strReturn = "";
            if (iCloseType == 0)
                strReturn = "非点击按钮关闭窗口";
            else if (iCloseType == 1)
                strReturn = "点击确认按钮";
            else if (iCloseType == 2)
                strReturn = "点击重试按钮";
            else if (iCloseType == 3)
                strReturn = "点击取消";
            WDLog.InsertLog("弹窗记录", iLevel, txtShowPopupTitle.Text, txtShowPopupContent.Text +"<>"+ strReturn);
        }

        Point mPoint;
        private void btnShowMoveWin_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void btnShowMoveWin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
    }
}
