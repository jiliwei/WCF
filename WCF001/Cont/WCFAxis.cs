using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WCF
{
    /// 类 	  名：WCFAxis
	/// 类 描 述：轴操作自定义控件
	/// WCF·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFAxis : UserControl
    {
        public WCFAxis()
        {
            InitializeComponent();
        }

        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFAxis_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
        }

        private void WCFAxis_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }
        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        public void ConInit(string GroupName = "")
        {
            int rtn = 0;
            DataTable dt;
            rtn = WDCard.SelectShowAxis(out dt, GroupName);
            if (rtn != 0)
            {
                WDLog.InsertLog("运动板卡", 0, "板卡异常", "轴界面加载时，无轴的数据");
                return;
            }
            lvAxisView.Columns.Add("轴名称", 120, HorizontalAlignment.Left);
            lvAxisView.Columns.Add("负限位", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("正限位", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("报警", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("复位", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("使能", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("实际位置", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("规划位置", 60, HorizontalAlignment.Center);



            string mGroupName = "";
            ListViewGroup mHeader = new ListViewGroup();
            ListViewItem mLvi;
            foreach (DataRow row in dt.Rows)
            {
                //创建列表组名并添加
                if (mGroupName != row[0].ToString())
                {
                    mGroupName = row[0].ToString();
                    mHeader = new ListViewGroup();
                    mHeader.Header = mGroupName;
                    mHeader.HeaderAlignment = HorizontalAlignment.Left;
                    lvAxisView.Groups.Add(mHeader);
                    lvAxisView.ShowGroups = true;
                }
                //添加数据
                mLvi = new ListViewItem();
                mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                mLvi.Text = row[1].ToString();
                mLvi.SubItems.Add("").BackColor = Color.Gray;
                mLvi.SubItems.Add("").BackColor = Color.Gray;
                mLvi.SubItems.Add("").BackColor = Color.Red;
                mLvi.SubItems.Add("").BackColor = Color.Gray;
                mLvi.SubItems.Add("").BackColor = Color.Gray;
                mLvi.SubItems.Add("0");
                mLvi.SubItems.Add("0");
                //添加到列表
                mHeader.Items.Add(mLvi);
                lvAxisView.Items.Add(mLvi);
            }
            tSignalRefresh.Enabled = true;
        }

        private void lvAxisView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvAxisView.FocusedItem != null)
                txtAxisNow.Text = lvAxisView.FocusedItem.SubItems[0].Text.ToString();
        }

        public bool isRefreshState = true;
        int mRefreshText = 0;
        private void tSignalRefresh_Tick(object sender, EventArgs e)
        {
            if (isRefreshState)
            {
                foreach (ListViewItem item in lvAxisView.Items)
                {
                    if (mRefreshText == 0)
                    {
                        mRefreshText = 1;
                        item.SubItems[1].BackColor = Color.Red;
                        item.SubItems[2].BackColor = Color.Gray;
                        item.SubItems[3].BackColor = Color.Red;
                        item.SubItems[4].BackColor = Color.Gray;
                        item.SubItems[5].BackColor = Color.Green;
                        item.SubItems[6].Text = "0";
                        item.SubItems[7].Text = "0";
                    }
                    else
                    {
                        mRefreshText = 0;
                        item.SubItems[1].BackColor = Color.Gray;
                        item.SubItems[2].BackColor = Color.Red;
                        item.SubItems[3].BackColor = Color.Gray;
                        item.SubItems[4].BackColor = Color.Green;
                        item.SubItems[5].BackColor = Color.Gray;
                        item.SubItems[6].Text = "1";
                        item.SubItems[7].Text = "1";
                    }
                   
                }
            }
        }
    }
}
