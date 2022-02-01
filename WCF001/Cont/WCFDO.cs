using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace WCF
{
    /// 类 	  名：WCFDO
	/// 类 描 述：输出信号可分组显示自定义控件
	/// WCF·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFDO : UserControl
    {
        public WCFDO()
        {
            InitializeComponent();
        }

        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFDO_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
        }

        private void WCFDO_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }
        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        /// <param name="mWDataToolClass">数据库操作对象</param>
        public void ConInit( string GroupName = "")
        {
            lvDOView.Clear();
            DataTable dt;
            int rtn = WDCard.SelectShowDO(out dt, GroupName);
            if (rtn != 0)
            {
                WDLog.InsertLog("运动板卡", 0, "板卡异常", "输出信号加载时，无输出信号数据");
                return;
            }
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
                    lvDOView.Groups.Add(mHeader);
                    lvDOView.ShowGroups = true;
                }
                //添加数据
                mLvi = new ListViewItem();
                mLvi.ImageIndex = 0;
                mLvi.Text = row[1].ToString();
                mLvi.SubItems.Add(row[2].ToString());
                mLvi.SubItems.Add(row[3].ToString());
                mLvi.SubItems.Add(row[4].ToString());
                mLvi.SubItems.Add(row[5].ToString());
                mLvi.SubItems.Add(row[6].ToString());
                //添加到列表
                mHeader.Items.Add(mLvi);
                lvDOView.Items.Add(mLvi);
            }
        }

        private void lvDOView_MouseUp(object sender, MouseEventArgs e)
        {
            if (lvDOView.SelectedItems.Count > 0)
            {
                int iIndex = lvDOView.SelectedItems[0].Index;
                if (lvDOView.Items[iIndex].ImageIndex == 0)
                    lvDOView.Items[iIndex].ImageIndex = 1;
                else
                    lvDOView.Items[iIndex].ImageIndex = 0;

                //输出信号的操作(等待运动控制卡操作类完成后完善)
                string m = lvDOView.Items[iIndex].SubItems[0].Text.ToString() + "!"
                + lvDOView.Items[iIndex].SubItems[1].Text.ToString() + "!"
                + lvDOView.Items[iIndex].SubItems[2].Text.ToString() + "!"
                + lvDOView.Items[iIndex].SubItems[3].Text.ToString() + "!"
                + lvDOView.Items[iIndex].SubItems[4].Text.ToString() + "!"
                + lvDOView.Items[iIndex].SubItems[5].Text.ToString() + "!";
            }

            //m = userControlListView1.Items[e.Index].Text.ToString();
            //m = userControlListView1.Items[e.Index].Text.ToString() + userControlListView1.Items[e.Index].SubItems[0].Text.ToString();
            //+ userControlListView1.Items[e.Index].SubItems[1].Text.ToString()+ userControlListView1.Items[e.Index].SubItems[2].Text.ToString()
            //+ userControlListView1.Items[e.Index].SubItems[3].Text.ToString()+ userControlListView1.Items[e.Index].SubItems[4].Text.ToString();
            //if (lvDOView.Items[e.Index].Checked)//获取选择之前的状态
            //    WTool.Tc_弹窗("TRUE当前选中数：" + m.ToString());
            //else
            //    WTool.Tc_弹窗("FALSE当前选中数：" + m.ToString());
        }
    }
}
