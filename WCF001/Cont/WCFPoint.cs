using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF
{
    /// 类 	  名：WCFPoint
	/// 类 描 述：点位列表自定义控件
	/// WCF·769838889@qq.com
	/// 创建时间：2021/11/03
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFPoint : UserControl
    {
        private string strMoveType = "位置";
        public WCFPoint()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化参数管理控件
        /// </summary>
        public void ConInit()
        {
            InitViewPoint();//点位列表显示
            InitViewAxis(); //显示轴列表
        }
        #region 页面初始化
        private void InitViewAxis()
        {
            DataTable dt;
            int rtn = WDCard.SelectShowAxisName(out dt);
            if (rtn != 0)
            {
                WDLog.InsertLog("运动板卡", 0, "板卡异常", "点位编辑界面加载时，无轴的数据");
                return;
            }
            lvAxisView.Columns.Add("ID", 60, HorizontalAlignment.Center);
            lvAxisView.Columns.Add("轴名称", 120, HorizontalAlignment.Left);

            string mGroupName = "";
            ListViewGroup mHeader = new ListViewGroup();
            ListViewItem mLvi;
            foreach (DataRow row in dt.Rows)
            {
                //创建列表组名并添加
                if (mGroupName != row[1].ToString())
                {
                    mGroupName = row[1].ToString();
                    mHeader = new ListViewGroup();
                    mHeader.Header = mGroupName;
                    mHeader.HeaderAlignment = HorizontalAlignment.Left;
                    lvAxisView.Groups.Add(mHeader);
                    lvAxisView.ShowGroups = true;
                }
                //添加数据
                mLvi = new ListViewItem();
                mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                mLvi.Text = row[0].ToString();
                mLvi.SubItems.Add(row[2].ToString());
                //添加到列表
                mHeader.Items.Add(mLvi);
                lvAxisView.Items.Add(mLvi);
            }
        }
        private Dictionary<string, List<PointMain>> dicPointMain = new Dictionary<string, List<PointMain>>();
        private void InitViewPoint()
        {
            #region 点位列表的显示
            TabControl mTabControl;
            int iTabControlNum = this.Controls.Find("mTabControlPoint", true).Length;
            if (iTabControlNum == 0)
            {
                mTabControl = new TabControl();
                mTabControl.Name = "mTabControlPoint";
                mTabControl.SelectedIndex = 0;
                mTabControl.Dock = DockStyle.Fill;
            }
            else
            {
                mTabControl = this.Controls.Find("mTabControlPoint", true)[0] as TabControl;
                mTabControl.Controls.Clear();
            }
            dicPointMain = WDPoint.DicPointMain;
            cbPointName.Items.Clear();//点位名称集合
            foreach (KeyValuePair<string, List<PointMain>> itemGroup in dicPointMain)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Name = "tp_" + itemGroup.Key;
                mTabPage.Padding = new Padding(3);
                mTabPage.Text = itemGroup.Key;
                mTabPage.UseVisualStyleBackColor = true;
                mTabPage.Controls.Add(CreaterDataGridView(itemGroup.Key, itemGroup.Value));
                foreach (PointMain itemPoint in itemGroup.Value)
                    cbPointName.Items.Add(itemPoint.PointName);
                mTabControl.Controls.Add(mTabPage);
            }
            tlpPoint.Controls.Add(mTabControl, 0, 0);
            #region 点位下拉框数据填充

            #endregion
            #endregion
            #region 组名下拉框数据填充
            List<string> strCBData = new List<string>();
            //添加任务名称
            foreach (KeyValuePair<string, TaskData> item in WDTask.DicTaskData)
            {
                strCBData.Add(item.Key);
            }
            //添加现有的组名名称
            foreach (KeyValuePair<string, List<PointMain>> itemGroup in dicPointMain)
            {
                if (!strCBData.Contains(itemGroup.Key))
                {
                    strCBData.Add(itemGroup.Key);
                }
            }
            cbGroupName.Items.Clear();
            foreach (string item in strCBData)
            {
                cbGroupName.Items.Add(item);
            }
            #endregion
        }
        private DataGridView CreaterDataGridView(string name, List<PointMain> paraPos)
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgv_" + name;
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("点 位 名 称", Type.GetType("System.String"));
            dt.Columns.Add("轴名称1", Type.GetType("System.String"));//1
            dt.Columns.Add("值1", Type.GetType("System.String"));
            dt.Columns.Add("轴名称2", Type.GetType("System.String"));//2
            dt.Columns.Add("值2", Type.GetType("System.String"));
            dt.Columns.Add("轴名称3", Type.GetType("System.String"));//3
            dt.Columns.Add("值3", Type.GetType("System.String"));
            dt.Columns.Add("轴名称4", Type.GetType("System.String"));//4
            dt.Columns.Add("值4", Type.GetType("System.String"));
            dt.Columns.Add("轴名称5", Type.GetType("System.String"));//5
            dt.Columns.Add("值5", Type.GetType("System.String"));
            dt.Columns.Add("轴名称6", Type.GetType("System.String"));//6
            dt.Columns.Add("值6", Type.GetType("System.String"));
            dt.Columns.Add("轴名称7", Type.GetType("System.String"));//7
            dt.Columns.Add("值7", Type.GetType("System.String"));
            dt.Columns.Add("轴名称8", Type.GetType("System.String"));//8
            dt.Columns.Add("值8", Type.GetType("System.String"));
            dt.Columns.Add("轴名称9", Type.GetType("System.String"));//8
            dt.Columns.Add("值9", Type.GetType("System.String"));
            dt.Columns.Add("轴名称10", Type.GetType("System.String"));//10
            dt.Columns.Add("值10", Type.GetType("System.String"));

            dt.Columns["点 位 名 称"].ReadOnly = true;
            dt.Columns["轴名称1"].ReadOnly = true;//1
            dt.Columns["轴名称2"].ReadOnly = true;//2
            dt.Columns["轴名称3"].ReadOnly = true;//3
            dt.Columns["轴名称4"].ReadOnly = true;//4
            dt.Columns["轴名称5"].ReadOnly = true;//5
            dt.Columns["轴名称6"].ReadOnly = true;//6
            dt.Columns["轴名称7"].ReadOnly = true;//7
            dt.Columns["轴名称8"].ReadOnly = true;//8
            dt.Columns["轴名称9"].ReadOnly = true;//9
            dt.Columns["轴名称10"].ReadOnly = true;//10

            dgvParaConfig.AllowUserToAddRows = false;
            dgvParaConfig.AllowUserToDeleteRows = false;
            dgvParaConfig.RowHeadersVisible = false;

            //添加显示的数据
            if (paraPos != null)
            {
                //key,序号_value_提示
                foreach (PointMain item in paraPos)
                {
                    DataRow mRow = dt.NewRow();
                    mRow[0] = item.PointName;
                    int iNum = 1;
                    foreach (KeyValuePair<string, PointValue> itemPos in item.DicPos)
                    {
                        mRow[(iNum - 1) * 2 + 1] = itemPos.Key;
                        if(strMoveType.Equals("位置"))
                            mRow[(iNum - 1) * 2 + 2] = itemPos.Value.Pos.ToString(); 
                        else if (strMoveType.Equals("速度"))
                            mRow[(iNum - 1) * 2 + 2] = itemPos.Value.Speed.ToString();
                        else if (strMoveType.Equals("加速度"))
                            mRow[(iNum - 1) * 2 + 2] = itemPos.Value.Acc.ToString();
                        else if (strMoveType.Equals("减速度"))
                            mRow[(iNum - 1) * 2 + 2] = itemPos.Value.Dec.ToString();
                        else if (strMoveType.Equals("平滑时间"))
                            mRow[(iNum - 1) * 2 + 2] = itemPos.Value.Smooth.ToString();
                        iNum++;
                    }
                    dt.Rows.Add(mRow);
                }
            }
            dgvParaConfig.DataSource = dt;
            //设置列的宽度比例
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //禁止排序
            foreach (DataGridViewColumn item in dgvParaConfig.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //添加右键菜单
            components = new Container();

            ToolStripMenuItem cmsExportData = new ToolStripMenuItem();
            cmsExportData.Name = "cmsExportData_" + name;
            cmsExportData.Size = new Size(152, 22);
            cmsExportData.Text = "生成Excel";
            cmsExportData.Click += new EventHandler(cmsExportData_Click);

            ToolStripMenuItem cmsDeleteData = new ToolStripMenuItem();
            cmsDeleteData.Name = "cmsExportData_" + name;
            cmsDeleteData.Size = new Size(152, 22);
            cmsDeleteData.Text = "删除";
            cmsDeleteData.Click += new EventHandler(cmsDeleteData_Click);

            ToolStripMenuItem cmsParaMenuSave = new ToolStripMenuItem();
            cmsParaMenuSave.Name = "cmsParaMenuSave_" + name;
            cmsParaMenuSave.Size = new Size(152, 22);
            cmsParaMenuSave.Text = "保存";
            cmsParaMenuSave.Click += new EventHandler(cmsParaMenuSave_Click);

            ContextMenuStrip cmsParaMenu = new ContextMenuStrip(components);
            cmsParaMenu.SuspendLayout();
            cmsParaMenu.Items.AddRange(new ToolStripItem[] { cmsDeleteData, cmsExportData, cmsParaMenuSave });

            cmsParaMenu.Name = "cmsParaMenu_" + name;
            cmsParaMenu.Size = new Size(153, 48);
            cmsParaMenu.ResumeLayout(false);

            dgvParaConfig.ContextMenuStrip = cmsParaMenu;//参数保存使用

            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            ((ISupportInitialize)(dgvParaConfig)).EndInit();

            return dgvParaConfig;
        }
        #endregion
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
        private void cmsDeleteData_Click(object sender, EventArgs e)
        {
            //获取对应的列表
            DataGridView mDataGridView = (((sender as ToolStripMenuItem).Owner) as ContextMenuStrip).SourceControl as DataGridView;
            if (mDataGridView == null)
            {
                WTool.Popup("获取控件异常，保存失败");
                return;
            }
            string pointName = mDataGridView.SelectedCells[0].Value.ToString();//列表选中的值
            if (mDataGridView.SelectedCells[0].ColumnIndex != 0)
            {
                WTool.Popup("请选择需要编辑关联的参数名称，再右键“删除”");
                return;
            }
            WDPoint.DeletePoint(pointName);
            InitViewPoint();
        }
        private void cmsParaMenuSave_Click(object sender, EventArgs e)
        {
            ////获取对应的列表
            //DataGridView mDataGridView = (((sender as ToolStripMenuItem).Owner) as ContextMenuStrip).SourceControl as DataGridView;
            //if (mDataGridView == null)
            //{
            //    WTool.Popup("获取控件异常，保存失败");
            //    return;
            //}
            //mDataGridView.EndEdit();//结束编辑
            //String rtnText;
            //int iRtn = dgvSave(out rtnText, mDataGridView);
            //if (iRtn == 0) { }//保存成功不去处理，因为界面上已经有提示
            //else if (iRtn == -1)
            //{
            //    WTool.Popup(rtnText);
            //    InitView();//保存异常时恢复之前的数据
            //}
        }

        private void btnPointAdd_Click(object sender, EventArgs e)
        {
            if (lvAxisView.CheckedItems.Count == 0)
            {
                WTool.Popup("至少要选中一个轴");
                return;
            }
            Dictionary<int, double> Pos = new Dictionary<int, double>();
            foreach (ListViewItem item in lvAxisView.CheckedItems)
            {
                Pos.Add(int.Parse(item.Text),0);
            }
            //获取numOrder 
            string groupName = cbGroupName.Text;
            string pointName = txtPointName.Text;
            if (groupName.Length == 0)
            {
                WTool.Popup("组名不能为空");
                return;
            }
            if (pointName.Length == 0)
            {
                WTool.Popup("点位名称不能为空");
                return;
            }
            double numOrder = 0;//大于0，表示有几个组，小数位为具体的组内排序
            if (dicPointMain.Count > 0)//如果有数据，则最后一个排序值加0.001
            {
                foreach (KeyValuePair<string, List<PointMain>> itemGroup in dicPointMain)
                {
                    if (groupName.Equals(itemGroup.Key))
                    {
                        numOrder = itemGroup.Value[0].NumOrder;//获取列表的第一个数据的排序值
                        foreach (PointMain item in itemGroup.Value)
                        {
                            if (numOrder < item.NumOrder)
                                numOrder = item.NumOrder;//获取最后一个排序值
                        }
                        break;
                    }
                }
                numOrder += 0.001;//在组的最后追加
                if (numOrder == 0.001)//已经有点位组，但是新的组名，故需要读取组的个数加0.001
                    numOrder = dicPointMain.Count + 0.001;
            }
            else
                numOrder = 1.001;//没有数据则默认第一个点位的排序序号为 1.001

            WDPoint.InsertPoint(numOrder,groupName,pointName,Pos);
            InitViewPoint();//点位列表显示
        }

        private void btnPointTeaching_Click(object sender, EventArgs e)
        {

        }

        private void btnPointMotion_Click(object sender, EventArgs e)
        {

        }

        private void timeRefresh_Tick(object sender, EventArgs e)
        {
            #region 没有值的点位数据，设置为只读
            foreach (KeyValuePair<string, List<PointMain>> itemGroup in dicPointMain)
            {
                if (Controls.Count > 0)
                {
                    DataGridView mDataGridView = Controls.Find("dgv_" + itemGroup.Key, true)[0] as DataGridView;
                    for (int i = 0; i < mDataGridView.Rows.Count; i++)
                    {
                        for (int j = 1; j < mDataGridView.Rows[i].Cells.Count; j = j + 2)
                        {
                            if (mDataGridView.Rows[i].Cells[j].Value.ToString().Length == 0)
                                mDataGridView.Rows[i].Cells[j + 1].ReadOnly = true;
                        }
                    }
                }    
            }
            #endregion

        }

        private void txtMoveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            strMoveType = txtMoveType.Text;
            InitViewPoint();
        }
    }
}
