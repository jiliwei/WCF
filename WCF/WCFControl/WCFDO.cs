using System;
using System.Data;
using System.Windows.Forms;

namespace WCF.WCFControl
{
    /// 类 	  名：WCFDO
	/// 类 描 述：输出信号可分组显示自定义控件
	/// 创 建 者：韦季李
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
        /// <param name="GroupName">为空时显示所有数据，否则只显示输入的组</param>
        WDataToolClass mWDataToolClass;
        public void ConInit(WDataToolClass mWDataToolClass, string GroupName = "")
        {
            this.mWDataToolClass = mWDataToolClass;

            int rtn = 0;
            DataTable dt;
            rtn = mWDataToolClass.SelectShowDO(out dt, GroupName);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowModel");
            }
            string mGroupName = "";
            ListViewGroup mHeader = new ListViewGroup();
            ListViewItem mLvi;
            lvDOView.CheckBoxes = true;
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

        private void lvDOView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
                //输出信号的操作(等待运动控制卡操作类完成后完善)
                string m = lvDOView.Items[e.Index].SubItems[0].Text.ToString() + "!"
                + lvDOView.Items[e.Index].SubItems[1].Text.ToString() + "!"
                + lvDOView.Items[e.Index].SubItems[2].Text.ToString() + "!"
                + lvDOView.Items[e.Index].SubItems[3].Text.ToString() + "!"
                + lvDOView.Items[e.Index].SubItems[4].Text.ToString() + "!"
                + lvDOView.Items[e.Index].SubItems[5].Text.ToString() + "!";
            //m = userControlListView1.Items[e.Index].Text.ToString();
            //m = userControlListView1.Items[e.Index].Text.ToString() + userControlListView1.Items[e.Index].SubItems[0].Text.ToString();
            //+ userControlListView1.Items[e.Index].SubItems[1].Text.ToString()+ userControlListView1.Items[e.Index].SubItems[2].Text.ToString()
            //+ userControlListView1.Items[e.Index].SubItems[3].Text.ToString()+ userControlListView1.Items[e.Index].SubItems[4].Text.ToString();
            if (lvDOView.Items[e.Index].Checked)//获取选择之前的状态
                MessageBox.Show("TRUE当前选中数：" + m.ToString());
            else
                MessageBox.Show("FALSE当前选中数：" + m.ToString());
        }
    }
}
