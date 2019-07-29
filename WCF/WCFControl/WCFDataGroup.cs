using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WCF.WCFControl
{
    /// 类 	  名：WCFDataGroup
	/// 类 描 述：分组显示参数自定义控件
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源码网证：https://github.com/jiliwei/WCF
	/// 版权许可：GNU通用公共许可第3版
    public partial class WCFDataGroup : UserControl
    {
        public WCFDataGroup()
        {
            InitializeComponent();
        }

        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFDataGroup_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
        }

        private void WCFDataGroup_SizeChanged(object sender, EventArgs e)
        {
            txtTips.Visible = true;
            panContent.Visible = false;
            btnRead.Visible = false;
            mAutoUI.controlAutoSize(this);
        }
        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        /// <param name="mWDataToolClass">数据库操作对象</param>
        WDataToolClass mWDataToolClass;
        string GroupName = "";
        public void ConInit(WDataToolClass mWDataToolClass, string GroupName = "")
        {
            this.mWDataToolClass = mWDataToolClass;
            this.GroupName = GroupName;
            UpdateData();
        }
        public void UpdateData()
        {
            lvDataView.Clear();
            int rtn = 0;
            DataTable dt;
            rtn = mWDataToolClass.SelectShowParameter(out dt, GroupName);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowAxis");
            }
            lvDataView.Columns.Add("参数名称", 120, HorizontalAlignment.Left);
            lvDataView.Columns.Add("参数值", 80, HorizontalAlignment.Center);
            lvDataView.Columns.Add("备注", 200, HorizontalAlignment.Center);



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
                    lvDataView.Groups.Add(mHeader);
                    lvDataView.ShowGroups = true;
                }
                //添加数据
                mLvi = new ListViewItem();
                mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                mLvi.Text = row[1].ToString();
                mLvi.SubItems.Add(row[2].ToString());
                mLvi.SubItems.Add(row[3].ToString());
                //添加到列表
                mHeader.Items.Add(mLvi);
                lvDataView.Items.Add(mLvi);
            }
        }

        private void lvDataView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDataView.FocusedItem != null)
            {
                string pataName = lvDataView.FocusedItem.SubItems[0].Text.ToString();
                if (pataName.Length > 2)
                {
                    string mStr = pataName.Substring(pataName.Length - 2, 2);
                    if(Regex.Matches(mStr, "[a-zA-Z]").Count == 2)
                        pataName = pataName.Substring(0, pataName.Length - 2);

                    int rtn = 0;
                    rtn = mWDataToolClass.SelectShowParameter(pataName,ref dgvContent);
                    if (rtn != 0)
                    {
                        MessageBox.Show("SelectShowAxis");
                    }
                    dgvContent.Columns[0].ReadOnly = true;
                    dgvContent.Columns[1].ReadOnly = false;
                    dgvContent.Columns[2].ReadOnly = true;

                    txtTips.Visible = false;
                    panContent.Visible = true;

                    //检查数据
                    for (int i = 0; i < dgvContent.Rows.Count; i++)
                    {
                        if (dgvContent.Rows[i].Cells[2].Value.ToString().Length > 0)
                        {
                            btnRead.Visible = true;
                            return;
                        }
                    }
                    btnRead.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                double Value = 0;
                if (dgvContent.Rows.Count > 0)
                {
                    //检查数据
                    for (int i = 0; i < dgvContent.Rows.Count ; i++)
                    {
                        if (WUseToolClass.isObjectNull(dgvContent.Rows[i].Cells[1].Value, "第" + (i + 1).ToString() + "行的参数值")) return;
                        try
                        {
                            Value = double.Parse(dgvContent.Rows[i].Cells[1].Value.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("参数类型错误");
                            return;
                        }
                    }
                    //更新数据
                    for (int i = 0; i < dgvContent.Rows.Count; i++)
                    {
                        //获取修改数据
                        double.TryParse(dgvContent.Rows[i].Cells[1].Value.ToString(), out Value);

                        if (mWDataToolClass.UpdateParameter(false, dgvContent.Rows[i].Cells[0].Value.ToString(), "", "", Value, "", "") != 0)
                        {
                            MessageBox.Show("参数数据修改失败");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选中要修改的参数");
                    return;
                }
                
                UpdateData();
                MessageBox.Show("参数数据修改成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                double mCurrentLocation = 0;
                for (int i = 0; i < dgvContent.Rows.Count; i++)
                {
                    if (dgvContent.Rows[i].Cells[2].Value.ToString().Length > 0)
                    {
                        WCardToolClass.getAxisCurrentLocation(dgvContent.Rows[i].Cells[0].Value.ToString(),out mCurrentLocation);
                        dgvContent.Rows[i].Cells[1].Value = mCurrentLocation.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
