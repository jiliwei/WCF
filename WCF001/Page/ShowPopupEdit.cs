using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WCF
{
    public partial class ShowPopupEdit : Form
    {
        private Dictionary<string, string> mPara;
        /// <summary>
        /// 参数编辑弹窗
        /// </summary>
        /// <param name="mPara">参数内容</param>
        /// <param name="strTitle">标题</param>
        public ShowPopupEdit(Dictionary<string, string> mPara, string strTitle)
        {
            InitializeComponent();

            this.mPara = mPara;
            txtShowPopupTitle.Text = strTitle;
            InitView();
        }
        private void InitView()
        {
            if(mPara.Count > 6)
            {
                WTool.Popup("参数编辑控件最多支持6个参数，当前已经超出，不显示");
                return;
            }
            string name;
            Label txtName;
            TextBox txtValue;
            List<string> lPara = new List<string>(mPara.Keys);
            #region 遍历数据设置控件名称及显示或隐藏
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        txtName = txtName1;
                        txtValue = txtValue1;
                        if (mPara.Count >= i)
                            name = lPara[i];
                        else
                            name = "";
                        break;
                    case 1:
                        txtName = txtName2;
                        txtValue = txtValue2;
                        if (mPara.Count >= i)
                            name = lPara[i];
                        else
                            name = "";
                        break;
                    case 2:
                        txtName = txtName3;
                        txtValue = txtValue3;
                        if (mPara.Count >= i)
                            name = lPara[i];
                        else
                            name = "";
                        break;
                    case 3:
                        txtName = txtName4;
                        txtValue = txtValue4;
                        if (mPara.Count >= i)
                            name = lPara[i];
                        else
                            name = "";
                        break;
                    case 4:
                        txtName = txtName5;
                        txtValue = txtValue5;
                        if (mPara.Count >= i)
                            name = lPara[i];
                        else
                            name = "";
                        break;
                    default:
                        txtName = txtName6;
                        txtValue = txtValue6;
                        if (mPara.Count >= i)
                            name = lPara[i];
                        else
                            name = "";
                        break;
                }
                editPara(name, txtName, txtValue);
            }
            #endregion
        }

        //private int iCloseType = 0;
        private void btnShowPopupOK_Click(object sender, EventArgs e)
        {
            string name;
            string value;
            #region 遍历数据设置对应的值
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        name = txtName1.Text;
                        value = txtValue1.Text;
                        break;
                    case 1:
                        name = txtName2.Text;
                        value = txtValue2.Text;
                        break;
                    case 2:
                        name = txtName3.Text;
                        value = txtValue3.Text;
                        break;
                    case 3:
                        name = txtName4.Text;
                        value = txtValue4.Text;
                        break;
                    case 4:
                        name = txtName5.Text;
                        value = txtValue5.Text;
                        break;
                    default:
                        name = txtName6.Text;
                        value = txtValue6.Text;
                        break;
                }
                if (mPara.Count >= i)
                {
                    if (WContTool.IsTrim(ref value, "参数“" + name + "”"))
                        return;
                    if (mPara.ContainsKey(name))
                        mPara[name] = value;
                }
                else
                    break;
            }
            #endregion

            //iCloseType = 1;
            Close();
        }

        private void btnShowPopupCancel_Click(object sender, EventArgs e)
        {

            //iCloseType = 3;
            Close();
        }

        private void ShowPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            //string strReturn = "";
            //if (iCloseType == 0)
            //    strReturn = "非点击按钮关闭窗口";
            //else if (iCloseType == 1)
            //    strReturn = "点击确认按钮";
            //else if (iCloseType == 3)
            //    strReturn = "点击取消";
            //WDLog.InsertLog("弹窗记录", iLevel, txtShowPopupTitle.Text, txtShowPopupContent.Text +"<>"+ strReturn);
        }
        #region 参数和值控件的赋值
        private void editPara(string name, Label txtName, TextBox txtValue)
        {
            if (name.Length == 0)
            {
                txtName.Visible = false;
                txtValue.Visible = false;
            }
            else
            {
                txtName.Text = name;
                txtName.Visible = true;
                txtValue.Visible = true;
            }
        }
        #endregion
        #region 窗口移动
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
        #endregion
    }
}
