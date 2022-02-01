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
    public partial class WCFSysPara : UserControl
    {
        public WCFSysPara()
        {
            InitializeComponent();
        }
        public void ConInit()
        {
            initView();
        }
        private void initView()
        {
            WDSysPara.SelectSysPara();
            Controls.Add(CreaterDataGridView()); 
        }
        private DataGridView CreaterDataGridView()
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            //dgvParaConfig.ContextMenuStrip = this.cmsParaMenu;//参数保存使用
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgvSysPara";
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", Type.GetType("System.String"));
            dt.Columns.Add("名称", Type.GetType("System.String"));
            dt.Columns.Add("值", Type.GetType("System.String"));
            dt.Columns.Add("提示", Type.GetType("System.String"));
            dt.Columns["序号"].ReadOnly = false;
            dt.Columns["名称"].ReadOnly = false;
            dt.Columns["值"].ReadOnly = false;
            dt.Columns["提示"].ReadOnly = false;
            dgvParaConfig.AllowUserToAddRows = true;
            dgvParaConfig.AllowUserToDeleteRows = true;
            dgvParaConfig.RowHeadersVisible = true;

            //添加显示的数据
            if (WDSysPara.listSysPara != null)
            {
                //key,序号_value_提示
                foreach (SysPara item in WDSysPara.listSysPara)
                {
                    DataRow mRow = dt.NewRow();
                    if (item.Id < 10)
                        mRow[0] = "0" + item.Id.ToString();
                    else
                        mRow[0] = item.Id.ToString();
                    mRow[1] = item.Name;
                    if (WData.iPriLevel >= 2)
                    {
                        mRow[2] = item.Value;
                    }
                    else
                    {
                        if (mRow[1].Equals("技术员") || mRow[1].Equals("管理员"))
                            mRow[2] = "管理员才能修改";
                        else
                            mRow[2] = item.Value;
                    }
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

            ToolStripMenuItem cmsParaMenuSave = new ToolStripMenuItem();
            cmsParaMenuSave.Name = "cmsParaMenuSaveSysPara";
            cmsParaMenuSave.Size = new Size(152, 22);
            cmsParaMenuSave.Text = "保存";
            cmsParaMenuSave.Click += new EventHandler(cmsParaMenuSave_Click);

            ContextMenuStrip cmsParaMenu = new ContextMenuStrip(components);
            cmsParaMenu.SuspendLayout();

            cmsParaMenu.Items.AddRange(new ToolStripItem[] { cmsParaMenuSave });

            cmsParaMenu.Name = "cmsParaMenuSysPara";
            cmsParaMenu.Size = new Size(153, 48);
            cmsParaMenu.ResumeLayout(false);

            dgvParaConfig.ContextMenuStrip = cmsParaMenu;//参数保存使用

            ((ISupportInitialize)(dgvParaConfig)).EndInit();
            return dgvParaConfig;
        }
        private void cmsParaMenuSave_Click(object sender, EventArgs e)
        {
            //获取对应的列表
            DataGridView mDataGridView = (((sender as ToolStripMenuItem).Owner) as ContextMenuStrip).SourceControl as DataGridView;
            if (mDataGridView == null)
            {
                WTool.Popup("获取控件异常，保存失败");
                return;
            }
            dgvSave(mDataGridView);
        }
        private void dgvSave(DataGridView mDataGridView)
        {
            List<SysPara> lSysPara = new List<SysPara>();
            foreach (DataGridViewRow item in mDataGridView.Rows)
            {
                //最后一行为空，不能保存，需要跳过
                if (item.Index == mDataGridView.Rows.Count - 1 )
                    break;
                SysPara mSysPara = new SysPara();
                int iId = 0;
                if (!int.TryParse(item.Cells[0].Value.ToString(), out iId))
                {
                    WTool.Popup("序号必须为数字，请检查");
                    return;
                }
                mSysPara.Id = iId;
                mSysPara.Name = item.Cells[1].Value.ToString();

                if (WData.iPriLevel < 2)
                {
                    if (mSysPara.Name.Equals("技术员") || mSysPara.Name.Equals("管理员"))
                    {
                        foreach (SysPara itemSon in WDSysPara.listSysPara)
                        {
                            if (mSysPara.Name.Equals(itemSon.Name))
                            {
                                mSysPara.Value = itemSon.Value;//还原密码
                            }
                        }
                    }
                    else
                        mSysPara.Value = item.Cells[2].Value.ToString();
                }
                else
                {
                    mSysPara.Value = item.Cells[2].Value.ToString();
                }

                mSysPara.Value = item.Cells[2].Value.ToString();
                mSysPara.Tips = item.Cells[3].Value.ToString();
                lSysPara.Add(mSysPara);
            }

            foreach (SysPara item in lSysPara)
            {
                int iIdRepeat = 0;
                int iNameRepeat = 0;
                foreach (SysPara itemSon in lSysPara)
                {
                    if (item.Id == itemSon.Id)
                        iIdRepeat++;
                    if (item.Name.Equals(itemSon.Name))
                        iNameRepeat++;
                }
                if(iIdRepeat >= 2)
                {
                    WTool.Popup("序号有重复，请检查");
                    return;
                }
                if (iNameRepeat >= 2)
                {
                    WTool.Popup("参数名称有重复，请检查");
                    return;
                }
            }

            WDSysPara.DeleteSysPara();
            foreach (SysPara item in lSysPara)
                WDSysPara.InsertSysPara(item);
        }
    }
}
