using System;
using System.Data;
using System.Windows.Forms;

namespace WCF.Resources
{
    public partial class WCFDI : UserControl
    {
        public WCFDI()
        {
            InitializeComponent();
        }

        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WcfDI_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
        }

        private void WcfDI_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }
        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        /// <param name="mWDataToolClass">数据库操作对象</param>
        WDataToolClass mWDataToolClass;
        public void ConInit(WDataToolClass mWDataToolClass, string GroupName = "")
        {
            this.mWDataToolClass = mWDataToolClass;

            int rtn = 0;
            DataTable dt;
            rtn = mWDataToolClass.SelectShowDI(out dt, GroupName);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowModel");
            }
            string mGroupName = "";
            ListViewGroup mHeader = new ListViewGroup();
            ListViewItem mLvi;
            lvDIView.SmallImageList = ilImageList;
            foreach (DataRow row in dt.Rows)
            {
                //创建列表组名并添加
                if (mGroupName != row[0].ToString())
                {
                    mGroupName = row[0].ToString();
                    mHeader = new ListViewGroup();
                    mHeader.Header = mGroupName;
                    mHeader.HeaderAlignment = HorizontalAlignment.Left;
                    lvDIView.Groups.Add(mHeader);
                    lvDIView.ShowGroups = true;
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
                lvDIView.Items.Add(mLvi);
            }
            //启动信号刷新定时器
            tSignalRefresh.Enabled = true;
        }
        public bool isRefreshState = true;
        private void tSignalRefresh_Tick(object sender, EventArgs e)
        {
            if (isRefreshState)
            {
                for (int i = 0; i < lvDIView.Items.Count ; i++)
                {
                    //获取数据来更新输入信号的图标(等待运动控制卡操作类完成后完善)
                    if (lvDIView.Items[i].ImageIndex == 1)
                        lvDIView.Items[i].ImageIndex = 0;
                    else
                        lvDIView.Items[i].ImageIndex = 1;
                }
            }
        }
    }
}
