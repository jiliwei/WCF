using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WCF
{
    public partial class WCFLog : UserControl
    {
        private Boolean isQuery = false;
        [Description("是否显示查询功能")]
        public Boolean IsQuery { get => isQuery; set => isQuery = value; }
        private int iNumber = 50;
        private DateTime nowTime = DateTime.Now;
        public WCFLog()
        {
            InitializeComponent();
            panQueryCriteria.Visible = false;

            nowTime = DateTime.Now;
            dtpLogStart.Value = nowTime;
            dtpLogEnd.Value = nowTime;
        }
        private string strType = "";//筛选类型用（比如只显示流程运行信息时，strType=流程运行）
        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="type">只显示某个类型时不为空</param>
        public void ConInit(string type = "")
        {
            strType = type;
            btnLogMenu.Visible = IsQuery;
            if (IsQuery)
            {
                iNumber = 100;
                timerRefresh.Enabled = false;
            }
            else
            {
                iNumber = 30;
                timerRefresh.Enabled = true;
                cmsLogShow30.Visible = false;
                cmsLogShow50.Visible = false;
                cmsLogShow100.Visible = false;
                cmsLogShow10000.Visible = false;
                cmsLogDelete30.Visible = false;
                cmsLogDelete60.Visible = false;
                cmsLogDelete90.Visible = false;
                cmsLogExcel.Visible = false;
                cmsLogDelete.Visible = false;
            }
            initQueryView();
        }
        /// <summary>
        /// 查询并显示列表数据
        /// </summary>
        private void initQueryView()
        {
            string strStartDate = "";
            if (dtpLogStart.Value != nowTime)
                strStartDate = dtpLogStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndDate = "";
            if (dtpLogEnd.Value != nowTime)
                strEndDate = dtpLogEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int iLevel = -1;
            if (txtLevel.Text.Length > 0)
            {
                string strLevel = txtLevel.Text;
                if (!strLevel.Equals("0") && !strLevel.Equals("1") && !strLevel.Equals("2"))
                {
                    WTool.Popup("查询条件中，等级只能为0，1，2");
                    return;
                }
                iLevel = int.Parse(strLevel);
            }
            if (strType.Length > 0)
                txtType.Text = strType;
            WDLog.SelectLog(ref dgvLog, iNumber,
                strStartDate, strEndDate,
                txtType.Text,
                iLevel,
                txtName.Text,
                txtDetails.Text);//显示数据
            if(dgvLog.Columns.Count > 0)
                dgvLog.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

        }
        private void btnLogMenu_Click(object sender, EventArgs e)
        {
            if (panQueryCriteria.Visible)
            {
                panQueryCriteria.Visible = false;
                btnLogMenu.BackgroundImage = global::WCF.Properties.Resources.expandMenu;
            }
            else
            {
                panQueryCriteria.Visible = true;
                btnLogMenu.BackgroundImage = global::WCF.Properties.Resources.stowMenu;
            }
        }

        private void dgvLog_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow item in dgvLog.Rows)
            {
                if (int.Parse(item.Cells[2].Value.ToString()) == 1)
                    item.DefaultCellStyle.BackColor = Color.White;
                else if (int.Parse(item.Cells[2].Value.ToString()) == 2)
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void btnLogReset_Click(object sender, EventArgs e)
        {
            nowTime = DateTime.Now;
            dtpLogStart.Value = nowTime;
            dtpLogEnd.Value = nowTime;
            txtType.Text = "";
            txtLevel.Text = "";
            txtName.Text = "";
            txtDetails.Text = "";
        }

        private void btnLogQuery_Click(object sender, EventArgs e)
        {
            initQueryView();
        }

        private void cmsLogShow30_Click(object sender, EventArgs e)
        {
            iNumber = 30;
            initQueryView();
        }

        private void cmsLogShow50_Click(object sender, EventArgs e)
        {
            iNumber = 50;
            initQueryView();
        }

        private void cmsLogShow100_Click(object sender, EventArgs e)
        {
            iNumber = 100;
            initQueryView();
        }

        private void cmsLogShow10000_Click(object sender, EventArgs e)
        {
            iNumber = 10000;
            initQueryView();
        }

        private void cmsLogDelete30_Click(object sender, EventArgs e)
        {
            deleteLog(-30);
        }

        private void cmsLogDelete60_Click(object sender, EventArgs e)
        {
            deleteLog(-60);
        }

        private void cmsLogDelete90_Click(object sender, EventArgs e)
        {
            deleteLog(-90);
        }
        private void deleteLog(int iDate)
        {
            string strDate = DateTime.Now.AddDays(iDate).ToString("yyyy-MM-dd HH:mm:ss");
            if (iDate != 0)
                WDLog.DeleteLog(strDate);
            else
                WDLog.DeleteLog(strDate,true);
        }
        private void cmsLogExcel_Click(object sender, EventArgs e)
        {
            string strDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "请选择另存为的文件夹位置";
            savedialog.Filter = "Excel表格(*.xlsx)|*.xlsx";
            savedialog.FilterIndex = 0;
            savedialog.RestoreDirectory = true;
            savedialog.CheckPathExists = true;
            savedialog.FileName = "Log"+ strDate;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = savedialog.FileName;
                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("standard_template");
                //创建Excel行
                IRow row = sheet.CreateRow(0);
                DataTable dt = (DataTable)dgvLog.DataSource;
                //将DataTable的列名显示在Excel表第一行
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }
                //遍历DataTable，给Excel赋值
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow rowItem = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        rowItem.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
                FileStream file = new FileStream(filepath, FileMode.Create);
                book.Write(file);
                file.Close();
                book.Close();
                file.Dispose();
                WTool.Popup("保存成功");
            }
        }
        private void cmsLogStop_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
        }

        private void cmsLogStart_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
        }

        private void cmsLogDelete_Click(object sender, EventArgs e)
        {
            deleteLog(0);
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            initQueryView();
        }

    }
}
