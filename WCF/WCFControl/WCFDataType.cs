using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF
{
    public partial class WCFDataType : UserControl
    {
        public WCFDataType()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据更新事件
        /// </summary>
        public event EventHandler DataUpdateClick;
        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFDataType_Load(object sender, EventArgs e)
        {
            panData.Visible = false;
            mAutoUI.controllInitializeSize(this);
        }

        private void WCFDataType_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }
        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        /// <param name="mWDataToolClass">数据库操作对象</param>
        WDataToolClass mWDataToolClass;
        public void ConInit(WDataToolClass mWDataToolClass,bool isEdit = true)
        {
            this.mWDataToolClass = mWDataToolClass;
            if (isEdit)
            {
                btnCopyAdd.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnCopyAdd.Visible = false;
                btnDelete.Visible = false;
            }
            int rtn = 0;
            rtn = mWDataToolClass.SelectShowModel("", ref cbWcfData);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowModel");
            }
        }
        private void btnCopyAdd_Click(object sender, EventArgs e)
        {
            panData.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mPataName = cbWcfData.Text.ToString();
            if (mPataName.Length == 0)
            {
                MessageBox.Show("机种名称为空 异常");
                return;
            }
            int rtn = 0;
            if (mPataName == "默认机种")
            {
                MessageBox.Show("默认机种不能删除");
                return;
            }
            else if (MessageBox.Show("是否删除当前机种:" + mPataName, "机种删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (mWDataToolClass.DeleteModel(mPataName) == 0)
                {
                    rtn = mWDataToolClass.SelectShowModel("", ref cbWcfData);
                    if (rtn != 0)
                    {
                        MessageBox.Show("切换机种失败");
                    }
                    MessageBox.Show("机种删除成功");
                    DataUpdateClick(sender,e);
                }
                else
                    MessageBox.Show("机种删除失败");
            }
        }

        private void btnDataOK_Click(object sender, EventArgs e)
        {
            string mPataName = txtData.Text.ToString();
            if (mPataName.Length == 0)
                MessageBox.Show("机种名称不能为空");
            else
            {
                if (mWDataToolClass.SelectShowModelName(mPataName) == 1)
                {
                    MessageBox.Show("机种名称有重复");
                    return;
                }
                if (mWDataToolClass.InsertModel(mPataName) == 0)
                {
                    int rtn = 0;
                    rtn = mWDataToolClass.SelectShowModel("", ref cbWcfData);
                    if (rtn != 0)
                    {
                        MessageBox.Show("SelectShowModel");
                    }
                    panData.Visible = false;
                    MessageBox.Show("机种新增成功");
                    DataUpdateClick(sender, e);
                }
                else
                    MessageBox.Show("机种新增失败");
            }
        }

        private void btnDataCancel_Click(object sender, EventArgs e)
        {
            panData.Visible = false;
        }
        private string mWcfDataName = "默认机种";
        private void cbWcfData_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rtn = 0;
            if (mWcfDataName != cbWcfData.Text.ToString())
            {
                mWcfDataName = cbWcfData.Text.ToString();
                rtn = mWDataToolClass.SelectShowModel(mWcfDataName, ref cbWcfData);
                if (rtn != 0)
                {
                    MessageBox.Show("切换机种失败");
                }
                DataUpdateClick(sender, e);
            }
        }
    }
}
