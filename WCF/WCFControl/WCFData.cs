using System;
using System.Data;
using System.Windows.Forms;

namespace WCF
{
    /// 类 	  名：WCFData
	/// 类 描 述：参数数据自定义控件
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFData : UserControl
    {
        public WCFData()
        {
            InitializeComponent();
        }

        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFData_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
        }

        private void WCFData_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }

        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        /// <param name="mWDataToolClass">数据库操作对象</param>
        WDataToolClass mWDataToolClass;
        DataTable dtCorrAxis;
        public void ConInit(WDataToolClass mWDataToolClass)
        {
            this.mWDataToolClass = mWDataToolClass;

            int rtn = 0;
            rtn = mWDataToolClass.SelectShowModel("", ref cbWcfData);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowModel");
            }
            UpdateCorrAxis();
            rtn = mWDataToolClass.SelectShowParameter(ref dgvParameter);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowAxis");
            }
        }
        /// <summary>
        /// 更新下拉列表数据
        /// </summary>
        public void UpdateCorrAxis()
        {
            int rtn = 0;
            rtn = mWDataToolClass.getDataAxis(out dtCorrAxis);
            if (rtn != 0)
            {
                MessageBox.Show("SelectShowModel");
            }
            if (dtCorrAxis.Rows.Count > 0)
            {
                dgvPataAddCorrAxis.Items.Clear();
                dgvPataModifyCorrAxis.Items.Clear();
                dgvPataAddCorrAxis.Items.Add("无");
                dgvPataModifyCorrAxis.Items.Add("无");
                for (int i = 0; i < dtCorrAxis.Rows.Count; i++)
                {
                    dgvPataAddCorrAxis.Items.Add(dtCorrAxis.Rows[i]["Name"].ToString());
                    dgvPataModifyCorrAxis.Items.Add(dtCorrAxis.Rows[i]["Name"].ToString());
                }
            }

        }
        private void btnCopyAdd_Click(object sender, EventArgs e)
        {
            showPanelUI("增加设备");
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
                rtn = mWDataToolClass.SelectShowParameter(ref dgvParameter);
                if (rtn != 0)
                {
                    MessageBox.Show("SelectShowAxis");
                }
            }
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
                    rtn = mWDataToolClass.SelectShowParameter(ref dgvParameter);
                    if (rtn != 0)
                    {
                        MessageBox.Show("SelectShowAxis");
                    }
                    MessageBox.Show("机种删除成功");
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
                    rtn = mWDataToolClass.SelectShowParameter(ref dgvParameter);
                    if (rtn != 0)
                    {
                        MessageBox.Show("SelectShowAxis");
                    }
                    closePanelUI();
                    MessageBox.Show("机种新增成功");
                }
                else
                    MessageBox.Show("机种新增失败");
            }
        }

        private void btnDataCancel_Click(object sender, EventArgs e)
        {
            closePanelUI();
        }

        private void cmsPataAdd_Click(object sender, EventArgs e)
        {
            UpdateCorrAxis();
            showPanelUI("参数增加");
        }

        private void btnPataAddOK_Click(object sender, EventArgs e)
        {
            string GroupName = "";
            string Name = "";
            double Value = 0.0;
            string CorrAxis = "";
            string Remarks = "";
            try
            {

                if (dgvPataAdd.Rows.Count > 0)
                {
                    //检查数据
                    for (int i = 0; i < dgvPataAdd.Rows.Count - 1; i++)
                    {
                        //检查数据是否为空
                        if (WUseToolClass.isObjectNull(dgvPataAdd.Rows[i].Cells[0].Value, "第" + (i + 1).ToString() + "行的组名")) return;
                        if (WUseToolClass.isObjectNull(dgvPataAdd.Rows[i].Cells[1].Value, "第" + (i + 1).ToString() + "行的参数名称"))  return;
                        if (WUseToolClass.isObjectNull(dgvPataAdd.Rows[i].Cells[2].Value, "第" + (i + 1).ToString() + "行的参数值")) return;

                        //检查是否已经存在重复数据
                        Name = dgvPataAdd.Rows[i].Cells[1].Value.ToString();
                        
                        if (mWDataToolClass.SelectShowParameterName(Name) == 1)
                        {
                            MessageBox.Show("第" + (i + 1).ToString() + "行的参数名称:" + Name + "；已存在，请检查");
                            return;
                        }
                        

                        //增加的数据判断
                        int numRepeatName = 0;
                        for (int j = 0; j < dgvPataAdd.Rows.Count - 1; j++)
                        {
                            if (i != j)
                            {
                                if (Name == dgvPataAdd.Rows[j].Cells[1].Value.ToString())
                                {
                                    numRepeatName++;
                                }
                            }
                        }
                        if (numRepeatName > 0)
                        {
                            MessageBox.Show("第" + (i + 1).ToString() + "行的参数名称有重复，请检查");
                            return;
                        }
                    }
                    //把所有数据插入
                    for (int i = 0; i < dgvPataAdd.Rows.Count - 1; i++)
                    {
                        GroupName = dgvPataAdd.Rows[i].Cells[0].Value.ToString();
                        Name = dgvPataAdd.Rows[i].Cells[1].Value.ToString();
                        Value = double.Parse(dgvPataAdd.Rows[i].Cells[2].Value.ToString());
                        if (dgvPataAdd.Rows[i].Cells[3].Value != null)
                            CorrAxis = WUseToolClass.getCorrAxisID(dtCorrAxis,dgvPataAdd.Rows[i].Cells[3].Value.ToString());
                        else
                            CorrAxis = "";
                        if (dgvPataAdd.Rows[i].Cells[4].Value != null)
                            Remarks = dgvPataAdd.Rows[i].Cells[4].Value.ToString();
                        else
                            Remarks = "";

                        if (mWDataToolClass.InsertParameter(GroupName, Name, Value, CorrAxis, Remarks) != 0)
                        {
                            MessageBox.Show("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                    closePanelUI();
                    //刷新轴数据
                    mWDataToolClass.SelectShowParameter(ref dgvParameter);
                    dgvPataAdd.Rows.Clear();
                    MessageBox.Show("轴数据添加成功");
                }
                else
                {
                    MessageBox.Show("添加的数据为空");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPataAddCancel_Click(object sender, EventArgs e)
        {
            closePanelUI();
        }

        private void cmsPataModify_Click(object sender, EventArgs e)
        {
            if (dgvParameter.SelectedRows.Count == 1)
            {
                dgvPataModify.Rows.Clear();
                int mIndex = dgvParameter.CurrentRow.Index;
                int nowIndex = dgvPataModify.Rows.Add();

                dgvPataModify.Rows[nowIndex].Cells[0].Value = dgvParameter.Rows[mIndex].Cells[0].Value.ToString();
                dgvPataModify.Rows[nowIndex].Cells[1].Value = dgvParameter.Rows[mIndex].Cells[1].Value.ToString();
                dgvPataModify.Rows[nowIndex].Cells[2].Value = dgvParameter.Rows[mIndex].Cells[2].Value.ToString();
                dgvPataModify.Rows[nowIndex].Cells[3].Value = dgvParameter.Rows[mIndex].Cells[3].Value.ToString();
                dgvPataModify.Rows[nowIndex].Cells[4].Value = dgvParameter.Rows[mIndex].Cells[4].Value.ToString();

                UpdateCorrAxis();
                showPanelUI("参数修改");
            }
            else
            {
                MessageBox.Show("当前未选中数据");
            }
        }

        private void btnPataModifyOK_Click(object sender, EventArgs e)
        {
            try
            {

                if (WUseToolClass.isObjectNull( dgvPataModify.Rows[0].Cells[0].Value, "组名"))
                    return;
                if (WUseToolClass.isObjectNull(dgvPataModify.Rows[0].Cells[1].Value, "参数名称"))
                    return;
                if (WUseToolClass.isObjectNull(dgvPataModify.Rows[0].Cells[2].Value, "参数值"))
                    return;


                string GroupName = dgvPataModify.Rows[0].Cells[0].Value.ToString();
                string Name = dgvPataModify.Rows[0].Cells[1].Value.ToString();
                double Value = 0.0;
                try
                {
                    Value = double.Parse(dgvPataModify.Rows[0].Cells[2].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("参数的值输入类型错误，只能是数值");
                    return;
                }
                string CorrAxis = "";
                if (dgvPataModify.Rows[0].Cells[3].Value != null)
                    CorrAxis = WUseToolClass.getCorrAxisID(dtCorrAxis, dgvPataModify.Rows[0].Cells[3].Value.ToString());
                string Remarks = "";
                if(dgvPataModify.Rows[0].Cells[4].Value != null)
                    Remarks = dgvPataModify.Rows[0].Cells[4].Value.ToString();

                int mIndex = dgvParameter.CurrentRow.Index;
                string oldGroupName = dgvParameter.Rows[mIndex].Cells[0].Value.ToString();
                string oldName = dgvParameter.Rows[mIndex].Cells[1].Value.ToString();
                string oldCorrAxis = "";
                if (dgvParameter.Rows[mIndex].Cells[3].Value != null)
                    oldCorrAxis = WUseToolClass.getCorrAxisID(dtCorrAxis, dgvParameter.Rows[mIndex].Cells[3].Value.ToString());
                string oldRemarks = "";
                if (dgvParameter.Rows[mIndex].Cells[4].Value != null)
                    oldRemarks = dgvParameter.Rows[mIndex].Cells[4].Value.ToString();

                if (Name != oldName && mWDataToolClass.SelectShowParameterName(Name) == 1)
                {
                    MessageBox.Show("参数名称:" + Name + "；已存在，请检查");
                    return;
                }
                bool isUpdateName = true;//是否更新组名和参数名称，true更新false不更新
                if (oldGroupName == GroupName && oldName == Name && oldCorrAxis == CorrAxis && oldRemarks == Remarks)
                {
                    isUpdateName = false;
                }
                if (mWDataToolClass.UpdateParameter(isUpdateName, oldName, GroupName, Name, Value, CorrAxis, Remarks) != 0)
                {
                    MessageBox.Show("参数数据更改失败");
                    return;
                }
                closePanelUI();
                //刷新参数数据
                mWDataToolClass.SelectShowParameter(ref dgvParameter);
                dgvPataModify.Rows.Clear();
                MessageBox.Show("参数数据更改成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPataModifyCancel_Click(object sender, EventArgs e)
        {
            closePanelUI();
        }

        private void cmsPataDelete_Click(object sender, EventArgs e)
        {
            if (dgvParameter.SelectedRows.Count == 1)
            {
                int mIndex = dgvParameter.CurrentRow.Index;

                string Name = dgvParameter.Rows[mIndex].Cells[1].Value.ToString();
                if (mWDataToolClass.DeleteParameter(Name) != 0)
                {
                    MessageBox.Show("参数数据参数失败");
                    return;
                }
                //刷新参数数据
                mWDataToolClass.SelectShowParameter(ref dgvParameter);
                MessageBox.Show("参数数据删除成功");
            }
            else
            {
                MessageBox.Show("当前未选中数据");
            }
        }
        /// <summary>
        /// 判断并打开对应编辑的页面
        /// </summary>
        /// <param name="mName">打开的页面</param>
        public void showPanelUI(string mName)
        {
            if (mName == "增加设备")
                panData.Visible = true;
            else if (mName == "参数增加")
                panPataAdd.Visible = true;
            else if (mName == "参数修改")
                panPataModify.Visible = true;
            else
                MessageBox.Show("界面打开判断有误");

            dgvParameter.Enabled = false;

        }
        /// <summary>
        /// 关闭所有编辑页面
        /// </summary>
        public void closePanelUI()
        {
            panData.Visible = false;

            panPataAdd.Visible = false;
            panPataModify.Visible = false;

            dgvParameter.Enabled = true;

        }
    }
}
