using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace WCF
{
    public partial class WCFPara : UserControl
    {
        public WCFPara()
        {
            InitializeComponent();
            gbAllEdit.Visible = false;
            gbRelevance.Visible = false;
            gbLevel.Visible = false;

        }
        public void ConInit()
        {
            wcfLog.ConInit("参数模块");
            InitView();
        }
        #region 列表数据显示

        private void InitView()
        {
            TabControl mTabControl;
            int iTabControlNum = this.Controls.Find("mTabControl", true).Length;
            if (iTabControlNum == 0)
            {
                mTabControl = new TabControl();
                mTabControl.Name = "mTabControl";
                mTabControl.SelectedIndex = 0;
                mTabControl.Dock = DockStyle.Fill;
            }
            else
            {
                mTabControl = this.Controls.Find("mTabControl", true)[0] as TabControl;
                mTabControl.Controls.Clear();
            }
            List<ParaTab> listParaTab = WDPara.ListParaTab;
            foreach (ParaTab itemTab in listParaTab)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Name = "tp_" + itemTab.ID;
                mTabPage.Padding = new System.Windows.Forms.Padding(3);
                mTabPage.Text = itemTab.Name;
                mTabPage.UseVisualStyleBackColor = true;
                if (itemTab.ListParaTable.Count == 1)
                {
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        mTabPage.Controls.Add(CreaterDataGridView(itemTab.ID + "_" + itemTable.ID, itemTable.ListParaTable));
                    }
                }
                else if (itemTab.ListParaTable.Count == 2)
                {
                    SplitContainer mSplitContainer = new SplitContainer();
                    mSplitContainer.Dock = DockStyle.Fill;
                    mSplitContainer.SplitterDistance = mSplitContainer.Width / 2;
                    int i = 1;
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        if (i == 1)
                            mSplitContainer.Panel1.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        else
                            mSplitContainer.Panel2.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        i++;
                    }
                    mTabPage.Controls.Add(mSplitContainer);
                }
                else if (itemTab.ListParaTable.Count == 3)
                {
                    SplitContainer mSplitContainer1 = new SplitContainer();
                    mSplitContainer1.Dock = DockStyle.Fill;
                    mSplitContainer1.SplitterDistance = mSplitContainer1.Width / 3;
                    SplitContainer mSplitContainer2 = new SplitContainer();
                    mSplitContainer2.Dock = DockStyle.Fill;
                    mSplitContainer2.SplitterDistance = mSplitContainer2.Width / 2;
                    mSplitContainer1.Panel2.Controls.Add(mSplitContainer2);
                    int i = 1;
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        //参数列表标题
                        if (i == 1)
                            mSplitContainer1.Panel1.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        else if (i == 2)
                            mSplitContainer2.Panel1.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        else
                            mSplitContainer2.Panel2.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        i++;
                    }
                    mTabPage.Controls.Add(mSplitContainer1);
                }
                else if (itemTab.ListParaTable.Count == 4)
                {
                    SplitContainer mSplitContainer1 = new SplitContainer();
                    mSplitContainer1.Dock = DockStyle.Fill;
                    mSplitContainer1.SplitterDistance = mSplitContainer1.Height / 2;
                    mSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
                    SplitContainer mSplitContainer2 = new SplitContainer();
                    mSplitContainer2.Dock = DockStyle.Fill;
                    mSplitContainer2.SplitterDistance = mSplitContainer2.Width / 2;
                    mSplitContainer1.Panel1.Controls.Add(mSplitContainer2);
                    SplitContainer mSplitContainer3 = new SplitContainer();
                    mSplitContainer3.Dock = DockStyle.Fill;
                    mSplitContainer3.SplitterDistance = mSplitContainer3.Width / 2;
                    mSplitContainer1.Panel2.Controls.Add(mSplitContainer3);
                    int i = 1;
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        if (i == 1)
                            mSplitContainer2.Panel1.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        else if (i == 2)
                            mSplitContainer2.Panel2.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        else if (i == 3)
                            mSplitContainer3.Panel1.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        else
                            mSplitContainer3.Panel2.Controls.Add(CreaterGroupBox(itemTab.ID, itemTable, itemTable.ListParaTable));
                        i++;
                    }
                    mTabPage.Controls.Add(mSplitContainer1);
                }
                if (itemTab.ListParaTable.Count > 0)
                {
                    mTabControl.Controls.Add(mTabPage);
                }
            }
            if (mTabControl.RowCount == 0)//在没有参数的情况下有用，不能删除
            {
                //添加右键菜单
                components = new System.ComponentModel.Container();

                ToolStripMenuItem cmsParaMenuAllEdit = new ToolStripMenuItem();
                cmsParaMenuAllEdit.Name = "cmsParaMenuTapAdd";
                cmsParaMenuAllEdit.Size = new Size(152, 22);
                cmsParaMenuAllEdit.Text = "整体编辑";
                cmsParaMenuAllEdit.Click += new System.EventHandler(this.cmsParaMenuAllEdit_Click);

                ContextMenuStrip cmsParaMenu = new ContextMenuStrip(this.components);
                cmsParaMenu.SuspendLayout();

                cmsParaMenu.Items.AddRange(new ToolStripItem[] { cmsParaMenuAllEdit });

                cmsParaMenu.Name = "cmsParaMenu";
                cmsParaMenu.Size = new Size(153, 48);
                cmsParaMenu.ResumeLayout(false);

                tlpPara.ContextMenuStrip = cmsParaMenu;//参数保存使用

            }
            else
                tlpPara.Controls.Add(mTabControl, 0, 0);

            SettingDataGridView(listParaTab);
        }

        private DataGridView CreaterDataGridView(string name, List<ParaCurr> paraCurrs)
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgv_" + name;
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", Type.GetType("System.String"));
            dt.Columns.Add("名称", Type.GetType("System.String"));
            dt.Columns.Add("值", Type.GetType("System.String"));
            dt.Columns.Add("提示", Type.GetType("System.String"));
            if ( WData.iPriLevel >=2 )
            {
                dt.Columns["序号"].ReadOnly = false;
                dt.Columns["名称"].ReadOnly = false;
                dt.Columns["值"].ReadOnly = false;
                dt.Columns["提示"].ReadOnly = false;
                dgvParaConfig.AllowUserToAddRows = true;
                dgvParaConfig.AllowUserToDeleteRows = true;
                dgvParaConfig.RowHeadersVisible = true;
            }
            else
            {
                dt.Columns["序号"].ReadOnly = true;
                dt.Columns["名称"].ReadOnly = true;
                dt.Columns["值"].ReadOnly = false;
                dt.Columns["提示"].ReadOnly = true;
                dgvParaConfig.AllowUserToAddRows = false;
                dgvParaConfig.AllowUserToDeleteRows = false;
                dgvParaConfig.RowHeadersVisible = false;
            }

            //添加显示的数据
            if (paraCurrs != null)
            {
                //key,序号_value_提示
                foreach (ParaCurr item in paraCurrs)
                {
                    DataRow mRow = dt.NewRow();
                    if(item.NumOrder < 10)
                        mRow[0] = "0"+item.NumOrder.ToString() ;
                    else
                        mRow[0] = item.NumOrder.ToString();
                    mRow[1] = item.Name;
                    mRow[2] = item.ParaValue;
                    mRow[3] = item.Tips;
                    dt.Rows.Add(mRow);
                }
            }
            dgvParaConfig.DataSource = dt;
            //设置列的宽度比例
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvParaConfig.Columns.Count > 2)
            {
                //使用第一列（序号列）来排序
                dgvParaConfig.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
                //禁止排序
                foreach (DataGridViewColumn item in dgvParaConfig.Columns)
                {
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            //添加右键菜单
            components = new Container();

            ToolStripMenuItem cmsExportData = new ToolStripMenuItem();
            cmsExportData.Name = "cmsExportData_" + name;
            cmsExportData.Size = new Size(152, 22);
            cmsExportData.Text = "生成Excel";
            cmsExportData.Click += new EventHandler(cmsExportData_Click);

            ToolStripMenuItem cmsParaMenuAllEdit = new ToolStripMenuItem();
            cmsParaMenuAllEdit.Name = "cmsParaMenuTapAdd_" + name;
            cmsParaMenuAllEdit.Size = new Size(152, 22);
            cmsParaMenuAllEdit.Text = "整体编辑";
            cmsParaMenuAllEdit.Click += new EventHandler(cmsParaMenuAllEdit_Click);

            ToolStripMenuItem cmsRelevanceEdit = new ToolStripMenuItem();
            cmsRelevanceEdit.Name = "cmsRelevanceEdit_" + name;
            cmsRelevanceEdit.Size = new Size(152, 22);
            cmsRelevanceEdit.Text = "编辑关联值";
            cmsRelevanceEdit.Click += new EventHandler(cmsRelevanceEdit_Click);

            ToolStripMenuItem cmsLevelEdit = new ToolStripMenuItem();
            cmsLevelEdit.Name = "cmsRelevanceEdit_" + name;
            cmsLevelEdit.Size = new Size(152, 22);
            cmsLevelEdit.Text = "编辑参数等级";
            cmsLevelEdit.Click += new EventHandler(cmsLevelEdit_Click);

            ToolStripMenuItem cmsParaMenuSave = new ToolStripMenuItem();
            cmsParaMenuSave.Name = "cmsParaMenuSave_" + name;
            cmsParaMenuSave.Size = new Size(152, 22);
            cmsParaMenuSave.Text = "保存";
            cmsParaMenuSave.Click += new EventHandler(cmsParaMenuSave_Click);

            ContextMenuStrip cmsParaMenu = new ContextMenuStrip(components);
            cmsParaMenu.SuspendLayout();

            if (WData.iPriLevel >= 2)
                cmsParaMenu.Items.AddRange(new ToolStripItem[] { cmsRelevanceEdit, cmsLevelEdit, cmsParaMenuAllEdit, cmsExportData, cmsParaMenuSave });
            else
                cmsParaMenu.Items.AddRange(new ToolStripItem[] {  cmsExportData, cmsParaMenuSave });

            cmsParaMenu.Name = "cmsParaMenu_" + name;
            cmsParaMenu.Size = new Size(153, 48);
            cmsParaMenu.ResumeLayout(false);

            dgvParaConfig.ContextMenuStrip = cmsParaMenu;//参数保存使用

            ((ISupportInitialize)(dgvParaConfig)).EndInit();
            return dgvParaConfig;
        }
        private GroupBox CreaterGroupBox(int iTabID, ParaTable mTable, List<ParaCurr> paraCurrs)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Dock = DockStyle.Fill;
            groupBox.Name = "gb_" + iTabID.ToString()+ "_" + mTable.ID.ToString();
            groupBox.Text = mTable.Name;
            groupBox.Controls.Add(CreaterDataGridView(iTabID + "_" + mTable.ID, paraCurrs));
            return groupBox;
        }
        private void SettingDataGridView(List<ParaTab> listParaTab)
        {
            foreach (ParaTab itemTab in listParaTab)
            {
                foreach (ParaTable itemTable in itemTab.ListParaTable)
                {
                    DataGridView mDataGridView = this.Controls.Find(
                        "dgv_" + itemTab.ID + "_" + itemTable.ID,
                        true)[0] as DataGridView;
                    if (mDataGridView.Columns.Count > 2)
                    {
                        //使用第一列（序号列）来排序
                        mDataGridView.Sort(mDataGridView.Columns[0], ListSortDirection.Ascending);
                        //设置列的宽度比例
                        mDataGridView.Columns[0].FillWeight = 30;
                        mDataGridView.Columns[2].FillWeight = 50;
                        mDataGridView.Columns[3].FillWeight = 180;
                        //禁止排序
                        foreach (DataGridViewColumn item in mDataGridView.Columns)
                        {
                            item.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    }
                    //当不是编辑模式时，根据权限等级禁止参数修改（把参数改为只读）
                    if (WData.iPriLevel < 2)
                    {
                        int iNum = 0;
                        foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                        {
                            iNum++;
                            int ilimits = itemCurr.Level;
                            if (mDataGridView.Rows.Count > iNum && ilimits >= WData.iPriLevel)
                                mDataGridView.Rows[iNum].ReadOnly = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 参数导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsExportData_Click(object sender, EventArgs e)
        {
            //string strDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            //SaveFileDialog savedialog = new SaveFileDialog();
            //savedialog.Title = "请选择另存为的文件夹位置";
            //savedialog.Filter = "Excel表格(*.xlsx)|*.xlsx";
            //savedialog.FilterIndex = 0;
            //savedialog.RestoreDirectory = true;
            //savedialog.CheckPathExists = true;
            //savedialog.FileName = "Log" + strDate;
            //if (savedialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filepath = savedialog.FileName;
            //    IWorkbook book = new XSSFWorkbook();
            //    ISheet sheet = book.CreateSheet("standard_template");
            //    //创建Excel行
            //    IRow row = sheet.CreateRow(0);
            //    DataTable dt = (DataTable)dgvLog.DataSource;
            //    //将DataTable的列名显示在Excel表第一行
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            //    }
            //    //遍历DataTable，给Excel赋值
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        IRow rowItem = sheet.CreateRow(i + 1);
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {
            //            rowItem.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
            //        }
            //    }
            //    FileStream file = new FileStream(filepath, FileMode.Create);
            //    book.Write(file);
            //    file.Close();
            //    book.Close();
            //    file.Dispose();
            //    WTool.Tc_弹窗("保存成功");
            //}
        }
        private void cmsParaMenuAllEdit_Click(object sender, EventArgs e)
        {
            //给树形控件添加数据
            tvParaNames.Nodes.Clear();
            gbAllEdit.Visible = true;
            List<ParaTab> listParaTab = WDPara.ListParaTab;
            if (listParaTab.Count == 0) return;
            foreach (ParaTab itemTab in listParaTab)
            {
                TreeNode mTreeNode = tvParaNames.Nodes.Add(itemTab.Name);
                foreach (ParaTable itemTable in itemTab.ListParaTable)
                {
                    TreeNode son = new TreeNode(itemTable.Name);
                    mTreeNode.Nodes.Add(son);
                }
            }
        }
        private static string strCell = "";
        private void cmsRelevanceEdit_Click(object sender, EventArgs e)
        {
            //获取对应的列表
            DataGridView mDataGridView = (((sender as ToolStripMenuItem).Owner) as ContextMenuStrip).SourceControl as DataGridView;
            if (mDataGridView == null)
            {
                WTool.Popup("获取控件异常，保存失败");
                return;
            }
            mDataGridView.EndEdit();//结束编辑
            strCell = mDataGridView.SelectedCells[0].Value.ToString();//列表选中的值
            if (mDataGridView.SelectedCells[0].ColumnIndex != 1)
            {
                WTool.Popup("请选择需要编辑关联的参数名称，再右键“编辑关联值”");
                return;
            }
            string strRelevance = "";
            foreach (ParaTab itemTab in WDPara.ListParaTab)
            {
                foreach (ParaTable itemTable in itemTab.ListParaTable)
                {
                    foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                    {
                        if (itemCurr.Name.Equals(strCell))
                        {
                            strRelevance = itemCurr.Relation;
                            break;
                        }
                    }
                }
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("模式名称", Type.GetType("System.String"));
            dt.Columns.Add("关联值", Type.GetType("System.String"));
            string[] strRelevances = strRelevance.Split('；');
            foreach (string item in strRelevances)
            {
                string[] strItems = item.Split('：');
                if (strItems.Length == 2)
                {
                    DataRow mRow = dt.NewRow();
                    mRow[0] = strItems[0];
                    mRow[1] = strItems[1];
                    dt.Rows.Add(mRow);
                }
            }
            dgvRelevanceEdit.DataSource = dt;
            gbRelevance.Visible = true;
        }
        #region 关联参数修改功能按钮事件
        private void btnRelevanceOk_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ParaTab itemTab in WDPara.ListParaTab)
                {
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                        {
                            if (itemCurr.Name.Equals(strCell))
                            {
                                string strRelevance = "";
                                foreach (DataGridViewRow item in dgvRelevanceEdit.Rows)
                                {
                                    if (item.Cells[0].Value != null &&
                                        item.Cells[1].Value != null)
                                    {
                                        if (strRelevance.Length > 0)
                                            strRelevance += "；";
                                        strRelevance +=
                                            item.Cells[0].Value.ToString() + "：" +
                                            item.Cells[1].Value.ToString();
                                    }
                                }
                                itemCurr.Relation = strRelevance;
                                //更新数据库的参数
                                WDPara.UpdatePara(itemCurr);
                                gbRelevance.Visible = false;
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                WTool.Popup("关联值修改失败，请检查");
            }
        }
        private void btnRelevanceCancel_Click(object sender, EventArgs e)
        {
            gbRelevance.Visible = false;
        }
        #endregion
        private static Dictionary<string, int> dicLevel = new Dictionary<string, int>();
        private void cmsLevelEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //获取对应的列表
                DataGridView mDataGridView = (((sender as ToolStripMenuItem).Owner) as ContextMenuStrip).SourceControl as DataGridView;
                if (mDataGridView == null)
                {
                    WTool.Popup("获取控件异常，保存失败");
                    return;
                }
                //获取列表对应的Name,并用 _ 拆分
                string[] strName = mDataGridView.Name.Split('_');
                if (strName.Length != 3)
                {
                    WTool.Popup("获取数据失败");
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("参数名称", Type.GetType("System.String"));
                dt.Columns.Add("参数等级", Type.GetType("System.String"));
                dt.Columns["参数名称"].ReadOnly = true;
                dt.Columns["参数等级"].ReadOnly = false;
                dgvLevelEdit.AllowUserToAddRows = false;
                dgvLevelEdit.AllowUserToDeleteRows = false;
                dgvLevelEdit.RowHeadersVisible = false;

                dicLevel.Clear();
                //读取数据
                foreach (ParaTab itemTab in WDPara.ListParaTab)
                {
                    if (!strName[1].Equals(itemTab.ID.ToString()))
                        continue;
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        if (!strName[2].Equals(itemTable.ID.ToString()))
                            continue;
                        foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                        {
                            DataRow mRow = dt.NewRow();
                            mRow[0] = itemCurr.Name;
                            mRow[1] = itemCurr.Level;
                            dt.Rows.Add(mRow);
                            //保存时比较使用
                            dicLevel.Add(itemCurr.Name, itemCurr.Level);
                        }
                        break;
                    }
                    break;
                }
                dgvLevelEdit.DataSource = dt;
                gbLevel.Visible = true;
            }
            catch (Exception)
            {
                WTool.Popup("打开等级编辑出现异常，请检查是否参数名有重复");
            }
            
        }
        #region 参数等级修改功能按钮事件
        private void btnLevelOk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvLevelEdit.Rows)
            {
                string name = item.Cells[0].Value.ToString();
                string level = item.Cells[1].Value.ToString();
                if (!WContTool.IsNumeric(level))
                {
                    WTool.Popup("参数："+name +"的等级不是数字，请检查");
                    return;
                }
                int iLevel = int.Parse(level);
                if (iLevel != dicLevel[name])
                {
                    //参数修改记录
                    WDLog.InsertLog("参数模块", 0, name + "-参数等级修改", 
                        name + ",修改前：" + dicLevel[name].ToString() + ",修改后：" + level);
                    WDPara.UpdateCurr(iLevel,name);
                }
            }
            gbLevel.Visible = false;
            WTool.Popup("等级修改成功");
        }

        private void btnLevelCancel_Click(object sender, EventArgs e)
        {
            gbLevel.Visible = false;
        }
        #endregion
        private void cmsParaMenuSave_Click(object sender, EventArgs e)
        {
            //获取对应的列表
            DataGridView mDataGridView = (((sender as ToolStripMenuItem).Owner) as ContextMenuStrip).SourceControl as DataGridView;
            if (mDataGridView == null)
            {
                WTool.Popup("获取控件异常，保存失败");
                return;
            }
            mDataGridView.EndEdit();//结束编辑
            String rtnText;
            int iRtn = dgvSave(out rtnText, mDataGridView);
            if (iRtn == 0) { }//保存成功不去处理，因为界面上已经有提示
            else if (iRtn == -1)
            {
                WTool.Popup(rtnText);
                InitView();//保存异常时恢复之前的数据
            }
        }
        private int dgvSave(out string rtnText, DataGridView mDataGridView)
        {
            rtnText = "";
            //获取列表对应的Name,并用 _ 拆分
            string[] strName = mDataGridView.Name.Split('_');
            if (strName.Length != 3)
            {
                rtnText = "获取数据失败";
                return -1;
            }
            List<ParaCurr> listParaCurr = new List<ParaCurr>();
            List<ParaTab> listParaTab = WDPara.ListParaTab;
            foreach (DataGridViewRow item in mDataGridView.Rows)
            {

                //当为编辑状态，blnIsEdit == true，最后一行为空，不能保存，需要跳过
                if (item.Index == mDataGridView.Rows.Count - 1 && WData.iPriLevel >= 2)
                    break;

                string numOrder = item.Cells[0].Value.ToString();
                string name = item.Cells[1].Value.ToString();
                string paraValue = item.Cells[2].Value.ToString();
                string dataValue = "";
                string tips = "";
                if (item.Cells[3].Value != null)
                    tips = item.Cells[3].Value.ToString();
                //读取数据
                foreach (ParaTab itemTab in listParaTab)
                {
                    if (!strName[1].Equals(itemTab.ID.ToString()))
                        continue;
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        if (!strName[2].Equals(itemTable.ID.ToString()))
                            continue;
                        foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                        {
                            if (itemCurr.Name.Equals(name))
                            {
                                dataValue = itemCurr.ParaValue;
                                break;
                            }
                        }
                    }
                    break;
                }

                if (name.Length <= 0)
                {
                    rtnText = "参数名称不能为空";
                    return -1;
                }
                if (numOrder.Length <= 0)
                {
                    rtnText = "参数名称“" + name + "”对应的序号不能为空";
                    return -1;
                }
                if (paraValue.Length <= 0)
                {
                    rtnText = "参数名称“" + name + "”对应的参数值不能为空";
                    return -1;
                }
                foreach (ParaTab itemTab in listParaTab)
                {
                    foreach (ParaTable itemTable in itemTab.ListParaTable)
                    {
                        //排除本列表的数据
                        if (strName[1].Equals(itemTab.ID.ToString()) && strName[2].Equals(itemTable.ID.ToString()))
                            continue;
                        foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                        {
                            if (itemCurr.Name.Equals(name))
                            {
                                rtnText = "参数名称“" + name + "”有重复，重复的参数在：选项卡“" +
                                    itemTab.Name + "”的列表“" + itemTable.Name + "”";
                                return -1;
                            }
                        }
                    }
                }
                int iRepeat = 0;
                foreach (DataGridViewRow itemRepeat in mDataGridView.Rows)
                {
                    if (itemRepeat.Index == mDataGridView.Rows.Count - 1)
                        break;
                    if (name.Equals(itemRepeat.Cells[1].Value.ToString()))
                    {
                        iRepeat++;
                    }
                }
                if (iRepeat > 1)
                {
                    rtnText = "参数名称“" + name + "”有重复，重复的参数在本列表";
                    return -1;
                }
                if (paraValue.Equals("-"))
                {
                    rtnText = "参数名称“" + name + "”对应的参数值不能只为“-”";
                    return -1;
                }
                if (!WContTool.IsNumeric(numOrder))
                {
                    rtnText = "参数名称“" + name + "”对应的“序号”不是数字，请检查";
                    return -1;
                }
                if (name.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0 ||
                    name.IndexOf("-") >= 0 || name.IndexOf(",") >= 0 || name.IndexOf(".") >= 0)
                {
                    rtnText = "参数名称“" + name + "”不能包含特殊字符，请检查";
                    return -1;
                }
                if (tips.IndexOf(",") >= 0 || tips.IndexOf("\"") >= 0 ||
                    tips.IndexOf(".") >= 0 || tips.IndexOf("_") >= 0)
                {
                    rtnText = "参数“" + name + "”的提示不能包含特殊字符";
                    return -1;
                }
                if (tips.Contains("(字符串)"))
                {
                    #region string类型的参数校验
                    if (dataValue.Length == 0)
                    {
                        //参数修改记录
                        WDLog.InsertLog("参数模块", 0, "参数增加", "增加参数：" + name + "；参数值：" + paraValue);
                    }
                    else if (dataValue.Equals(paraValue))
                    {
                        //参数修改判断
                        //if (SR.yxms_运行模式 == 1 && relevance.Contains("生产模式"))
                        //{
                        //    rtnText = "生产模式时，参数“" + name + "”不能修改";
                        //    return -1;
                        //}
                        //if (Global.WorkVar.tag_workState == 1 && relevance.Contains("生产模式"))
                        //{
                        //    rtnText = "正在生产中，参数“" + name + "”不能修改";
                        //    return -1;
                        //}
                        //参数修改记录
                        WDLog.InsertLog("参数模块", 0, "参数修改", name + ",修改前：" + dataValue + ",修改后：" + paraValue + ",参数提示是：" + tips);
                    }
                    #endregion
                }
                else
                {
                    if (!WContTool.IsNumeric(paraValue))
                    {
                        rtnText = "参数名称“" + name + "”对应的“值”不是数字，请检查";
                        return -1;
                    }
                    //检查参数“提示”的后缀是否是 ； 若是，则需要删除；当后缀有“；”时会导致校验无效
                    if (tips.Length > 0)
                    {
                        int tipsCS = tips.LastIndexOf('；');
                        if (tipsCS == (tips.Length - 1))
                        {
                            tips = tips.Substring(0, tips.Length - 1);
                            item.Cells[3].Value = tips;
                        }
                    }
                    if (tips != null && tips.Length > 0)
                    {
                        string[] strValue = tips.Split('；');
                        int isAccord = 0;//是否满足条件的次数
                        foreach (string itemValue in strValue)
                        {
                            //当不包含分隔符‘：’表示不是状态的变量，则不进行符合条件的判断
                            string[] itemValueSon = itemValue.Split('：');
                            if (itemValueSon.Length <= 1)
                            {
                                isAccord++;
                                break;
                            }
                            if (paraValue.Equals(itemValueSon[0])) isAccord++;
                        }
                        if (isAccord == 0)
                        {
                            rtnText = "参数“" + name + "”的值不能设置为：" + paraValue + "；正确的值为：" + tips;
                            return -1;
                        }
                    }
                    if (tips.IndexOf("(>0)") >= 0)
                    {
                        if (double.Parse(paraValue) <= 0)
                        {
                            rtnText = "参数“" + name + "”的值不能小于等于0，请检查。";
                            return -1;
                        }
                    }
                    if (tips.IndexOf("(>=0)") >= 0)
                    {
                        if (double.Parse(paraValue) < 0)
                        {
                            rtnText = "参数“" + name + "”的值不能小于0，请检查。";
                            return -1;
                        }
                    }
                    if (tips.IndexOf("(>=1)") >= 0)
                    {
                        if (double.Parse(paraValue) < 1)
                        {
                            rtnText = "参数“" + name + "”的值不能小于1，请检查。";
                            return -1;
                        }
                    }
                    if (tips.Contains("值>"))
                    {
                        if (tips.Split('(').Length == 2 && tips.Split(')').Length == 2)
                        {
                            if (tips.IndexOf(">=值>=") >= 0)
                            {
                                string strRep = tips.Replace(">=值>=", "?");
                                string[] strTest = strRep.Split('?');
                                string strMin = strTest[0].Replace("(", "?");
                                string[] strMins = strMin.Split('?');
                                double dMin = double.Parse(strMins[1]);
                                string strMax = strTest[1].Replace(")", "?");
                                string[] strMaxs = strMax.Split('?');
                                double dMax = double.Parse(strMaxs[0]);
                                if (double.Parse(paraValue) < dMin || double.Parse(paraValue) > dMax)
                                {
                                    rtnText = "参数“" + name + "”的值设置不在范围内，\n" +
                                        "当前为：" + paraValue +
                                        "，不能小于：" + dMin.ToString() +
                                        "，不能大于：" + dMax.ToString() +
                                        "\n请检查。";
                                    return -1;
                                }
                            }
                            else if (tips.IndexOf(">值>=") >= 0)
                            {
                                string strRep = tips.Replace(">值>=", "?");
                                string[] strTest = strRep.Split('?');
                                string strMin = strTest[0].Replace("(", "?");
                                string[] strMins = strMin.Split('?');
                                double dMin = double.Parse(strMins[1]);
                                string strMax = strTest[1].Replace(")", "?");
                                string[] strMaxs = strMax.Split('?');
                                double dMax = double.Parse(strMaxs[0]);
                                if (double.Parse(paraValue) <= dMin || double.Parse(paraValue) > dMax)
                                {
                                    rtnText = "参数“" + name + "”的值设置不在范围内，\n" +
                                        "当前为：" + paraValue +
                                        "，不能小于等于：" + dMin.ToString() +
                                        "，不能大于：" + dMax.ToString() +
                                        "\n请检查。";
                                    return -1;
                                }
                            }
                            else if (tips.IndexOf(">=值>") >= 0)
                            {
                                string strRep = tips.Replace(">=值>", "?");
                                string[] strTest = strRep.Split('?');
                                string strMin = strTest[0].Replace("(", "?");
                                string[] strMins = strMin.Split('?');
                                double dMin = double.Parse(strMins[1]);
                                string strMax = strTest[1].Replace(")", "?");
                                string[] strMaxs = strMax.Split('?');
                                double dMax = double.Parse(strMaxs[0]);
                                if (double.Parse(paraValue) < dMin || double.Parse(paraValue) >= dMax)
                                {
                                    rtnText = "参数“" + name + "”的值设置不在范围内，\n" +
                                        "当前为：" + paraValue +
                                        "，不能小于：" + dMin.ToString() +
                                        "，不能大于等于：" + dMax.ToString() +
                                        "\n请检查。";
                                    return -1;
                                }
                            }
                            else if (tips.IndexOf(">值>") >= 0)
                            {
                                string strRep = tips.Replace(">值>", "?");
                                string[] strTest = strRep.Split('?');
                                string strMin = strTest[0].Replace("(", "?");
                                string[] strMins = strMin.Split('?');
                                double dMin = double.Parse(strMins[1]);
                                string strMax = strTest[1].Replace(")", "?");
                                string[] strMaxs = strMax.Split('?');
                                double dMax = double.Parse(strMaxs[0]);
                                if (double.Parse(paraValue) <= dMin || double.Parse(paraValue) >= dMax)
                                {
                                    rtnText = "参数“" + name + "”的值设置不在范围内，\n" +
                                        "当前为：" + paraValue +
                                        "，不能小于等于：" + dMin.ToString() +
                                        "，不能大于等于：" + dMax.ToString() +
                                        "\n请检查。";
                                    return -1;
                                }
                            }
                        }
                        else
                        {
                            rtnText = "当包含“值>”为区间判断。当为区间判断时，\n" +
                                "提示内容\n必须仅有一个“(”字符，\n必须仅有一个“)”字符" +
                                "\n当前“提示”内容输入错误，请检查";
                            return -1;
                        }
                    }
                    double dValue = 0;
                    if (!double.TryParse(paraValue, out dValue))
                        dValue = 0;
                    string strEnd = dValue.ToString();
                    if (paraValue.Length != strEnd.Length)
                    {
                        rtnText = "参数“" + name + "”的值包含小数点，\n但没有小数，整数值，需要去掉小数点";
                        return -1;
                    }
                    if (dataValue.Length == 0)
                    {   
                        //参数修改记录
                        WDLog.InsertLog("参数模块", 0, "参数增加", "增加参数："+name+"；参数值："+ paraValue);
                    }
                    else if (double.Parse(dataValue) != dValue)
                    {
                        //参数修改判断
                        //if (SR.yxms_运行模式 == 1 && relevance.Contains("生产模式"))
                        //{
                        //    rtnText = "生产模式时，参数“" + name + "”不能修改";
                        //    return -1;
                        //}
                        //if (Global.WorkVar.tag_workState == 1 && relevance.Contains("生产模式"))
                        //{
                        //    rtnText = "正在生产中，参数“" + name + "”不能修改";
                        //    return -1;
                        //}
                        //参数修改记录
                        WDLog.InsertLog("参数模块", 0, "参数修改", name + ",修改前：" + dataValue + ",修改后：" + paraValue + ",参数提示是：" + tips);
                    }
                }

                if (tips.Length == 0)
                    tips = "暂无";

                ParaCurr mParaCurr = new ParaCurr();
                mParaCurr.NumOrder = double.Parse(numOrder);
                mParaCurr.Name = name;
                mParaCurr.ParaValue = paraValue.ToString();
                mParaCurr.Tips = tips;
                listParaCurr.Add(mParaCurr);
            }
            //补充数据
            //修改的数据（找到Name）
            List<ParaCurr> listParaCurrUpdate = new List<ParaCurr>();
            //删除的数据（找不到Name）
            List<ParaCurr> listParaCurrDelete = new List<ParaCurr>();
            //新增的数据（旧数据没有的Name）
            List<ParaCurr> listParaCurrInsert = new List<ParaCurr>();

            foreach (ParaTab itemTab in listParaTab)
            {
                if (!strName[1].Equals(itemTab.ID.ToString()))
                    continue;
                foreach (ParaTable itemTable in itemTab.ListParaTable)
                {
                    if (!strName[2].Equals(itemTable.ID.ToString()))
                        continue;
                    foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                    {
                        bool isFind = true;
                        foreach (ParaCurr itemCurrNow in listParaCurr)
                        {
                            if (itemCurr.Name.Equals(itemCurrNow.Name))
                            {
                                isFind = false;
                                ParaCurr mParaCurr = new ParaCurr();
                                mParaCurr.ID = itemCurr.ID;
                                mParaCurr.TableID = itemTable.ID;
                                mParaCurr.NumOrder = itemCurrNow.NumOrder;
                                mParaCurr.Name = itemCurrNow.Name;
                                mParaCurr.ParaValue = itemCurrNow.ParaValue;
                                mParaCurr.Tips = itemCurrNow.Tips;
                                mParaCurr.Level = itemCurr.Level;
                                mParaCurr.Relation = itemCurr.Relation;
                                listParaCurrUpdate.Add(mParaCurr);
                                continue;
                            }
                        }
                        if (isFind)
                        {
                            ParaCurr mParaCurr = new ParaCurr();
                            mParaCurr.ID = itemCurr.ID;
                            mParaCurr.TableID = itemTable.ID;
                            mParaCurr.NumOrder = itemCurr.NumOrder;
                            mParaCurr.Name = itemCurr.Name;
                            mParaCurr.ParaValue = itemCurr.ParaValue;
                            mParaCurr.Tips = itemCurr.Tips;
                            mParaCurr.Level = itemCurr.Level;
                            mParaCurr.Relation = itemCurr.Relation;
                            listParaCurrDelete.Add(mParaCurr);
                        }

                    }
                    foreach (ParaCurr itemCurrNow in listParaCurr)
                    {
                        bool isFind = true;
                        foreach (ParaCurr itemCurr in itemTable.ListParaTable)
                        {
                            if (itemCurr.Name.Equals(itemCurrNow.Name))
                            {
                                isFind = false;
                                continue;
                            }
                        }
                        if (isFind)
                        {
                            ParaCurr mParaCurr = new ParaCurr();
                            mParaCurr.ID = itemCurrNow.ID;
                            mParaCurr.TableID = itemTable.ID;
                            mParaCurr.NumOrder = itemCurrNow.NumOrder;
                            mParaCurr.Name = itemCurrNow.Name;
                            mParaCurr.ParaValue = itemCurrNow.ParaValue;
                            mParaCurr.Tips = itemCurrNow.Tips;
                            mParaCurr.Level = 0;//默认等级
                            mParaCurr.Relation = itemCurrNow.Relation;
                            listParaCurrInsert.Add(mParaCurr);
                        }
                    }
                    break;
                }
                break;
            }
            //数据库操作
            foreach (ParaCurr item in listParaCurrUpdate)
                WDPara.UpdatePara(item);
            foreach (ParaCurr item in listParaCurrDelete)
            {
                WDLog.InsertLog("参数模块", 0, "参数删除", "删除参数：" + item.Name);
                WDPara.DeletePara(item);
            }
            foreach (ParaCurr item in listParaCurrInsert)
                WDPara.InsertPara(item);

            return 0;
        }
        #endregion
        #region 选项卡和列表的编辑
        private bool tvParaNamesRepeat(string value, TreeNodeCollection Nodes)
        {
            foreach (TreeNode item in Nodes)
            {
                if (item.Text.Equals(value))
                    return true;
                else
                    return tvParaNamesRepeat(value, item.Nodes);
            }
            return false;
        }
        private void btnAddTabName_Click(object sender, EventArgs e)
        {
            string value = txtParaNameEdit.Text;
            if (WContTool.IsTrim(ref value))
                return;
            if (tvParaNamesRepeat(value, tvParaNames.Nodes))
            {
                WTool.Popup("名称有重复，请检查");
                return;
            }
            tvParaNames.Nodes.Add(value);
            WDPara.InsertTab(value);
        }
        private void btnAddListName_Click(object sender, EventArgs e)
        {
            if (tvParaNames.SelectedNode == null)
            {
                WTool.Popup("请先选中父节点");
                return;
            }
            string value = txtParaNameEdit.Text;
            if (WContTool.IsTrim(ref value))
                return;
            if (tvParaNamesRepeat(value, tvParaNames.Nodes))
            {
                WTool.Popup("名称有重复，请检查");
                return;
            }
            if (tvParaNames.SelectedNode.Nodes.Count >= 4)
            {
                WTool.Popup("当前一个选项卡最多包含4个列表");
                return;
            }
            if (tvParaNames.SelectedNode.Parent != null)
            {
                if (tvParaNames.SelectedNode.Parent.Nodes.Count >= 4)
                {
                    WTool.Popup("当前一个选项卡最多包含4个列表");
                    return;
                }
                tvParaNames.SelectedNode.Parent.Nodes.Add(value);
            }
            else
            {
                tvParaNames.SelectedNode.Nodes.Add(value);
            }
            //在数据库增加列表名称
            string strRename = tvParaNames.SelectedNode.Text;//树形控件选中的值
            foreach (ParaTab itemTab in WDPara.ListParaTab)
            {
                if (itemTab.Name.Equals(strRename))
                {
                    double dNumOrder = (double)(itemTab.ListParaTable.Count + 1) / 1000;
                    WDPara.InsertTable(itemTab.ID, dNumOrder, value);
                    break;
                }
            }

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (tvParaNames.SelectedNode == null)
            {
                WTool.Popup("请先选中需要重命名的节点");
                return;
            }
            string value = txtParaNameEdit.Text;//将要修改的值
            if (WContTool.IsTrim(ref value))
                return;
            if (tvParaNamesRepeat(value, tvParaNames.Nodes))
            {
                WTool.Popup("名称有重复，请检查");
                return;
            }
            string strRename = tvParaNames.SelectedNode.Text;//树形控件选中的值
            //修改数据库内的值
            foreach (ParaTab itemTab in WDPara.ListParaTab)
            {
                if (itemTab.Name.Equals(strRename))
                {
                    WDPara.UpdateTab(itemTab.ID, value);
                    break;
                }
                else
                {
                    foreach (var itemTable in itemTab.ListParaTable)
                    {
                        if (itemTable.Name.Equals(strRename))
                        {
                            WDPara.UpdateTable(itemTable.ID, value);
                            break;
                        }
                    }
                }
            }
            tvParaNames.SelectedNode.Text = value;
        }
        private void btnDeleteTab_Click(object sender, EventArgs e)
        {
            if (tvParaNames.SelectedNode == null)
            {
                WTool.Popup("请先选中需要删除的节点");
                return;
            }
            string strRename = tvParaNames.SelectedNode.Text;//树形控件选中的值
            //修改数据库内的值
            foreach (ParaTab itemTab in WDPara.ListParaTab)
            {
                if (itemTab.Name.Equals(strRename))
                {
                    WDPara.DeleteTab(itemTab.ID);
                    break;
                }
                else
                {
                    foreach (var itemTable in itemTab.ListParaTable)
                    {
                        if (itemTable.Name.Equals(strRename))
                        {
                            WDPara.DeleteTable(itemTable.ID);
                            break;
                        }
                    }
                }
            }
            tvParaNames.SelectedNode.Remove();
        }

        private void btnCloseTab_Click(object sender, EventArgs e)
        {
            gbAllEdit.Visible = false;
            InitView();
        }
        #endregion

    }
}
