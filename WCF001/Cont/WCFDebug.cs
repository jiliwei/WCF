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
    /// 类 	  名：WCFDebug
	/// 类 描 述：调试界面自定义控件
	/// WCF·769838889@qq.com
	/// 创建时间：2021/11/03
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFDebug : UserControl
    {
        public WCFDebug()
        {
            InitializeComponent();
        }
        public void ConInit(string TaskName = "")
        {
            wcfDI.ConInit(TaskName);
            wcfDO.ConInit(TaskName);
            flpAxisShortcut.Controls.Clear();
            foreach (KeyValuePair< string, List<AxisData>> item in WDCard.DicListAxis)
            {
                if (item.Key.Equals(TaskName) || TaskName.Length == 0)
                {
                    foreach (AxisData itemAxis in item.Value)
                    {
                        WCFAxisShortcut mWCFAxisShortcut = new WCFAxisShortcut(itemAxis);
                        //宽减去滚动条的宽度
                        mWCFAxisShortcut.Size = new Size(flpAxisShortcut.Size.Width - 30, mWCFAxisShortcut.Size.Height-10);
                        flpAxisShortcut.Controls.Add(mWCFAxisShortcut);
                    }
                }
            }
            //加载点位列表
            InitViewPoint();
        }
        #region 增加点位列表
        private string strMoveType = "位置";
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
            tableLayoutPanel3.Controls.Add(mTabControl, 0, 0);
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
                        if (strMoveType.Equals("位置"))
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

            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            ((ISupportInitialize)(dgvParaConfig)).EndInit();

            return dgvParaConfig;
        }
        private void txtMoveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            strMoveType = txtMoveType.Text;
            InitViewPoint();
        }
        #endregion

    }
}
