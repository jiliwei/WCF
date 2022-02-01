
namespace WCF
{
    partial class WCFLog
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLogMenu = new System.Windows.Forms.Button();
            this.panQueryCriteria = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpLogStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpLogEnd = new System.Windows.Forms.DateTimePicker();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.txtLabelDetails = new System.Windows.Forms.Label();
            this.txtLabelName = new System.Windows.Forms.Label();
            this.txtLabelLevel = new System.Windows.Forms.Label();
            this.txtLabelType = new System.Windows.Forms.Label();
            this.txtLabelDate = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogQuery = new System.Windows.Forms.Button();
            this.btnLogReset = new System.Windows.Forms.Button();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.cmsLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLogShow30 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogShow50 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogShow100 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogShow10000 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogDelete30 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogDelete60 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogDelete90 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogStop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogStart = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLogDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panQueryCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.cmsLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogMenu
            // 
            this.btnLogMenu.BackgroundImage = global::WCF.Properties.Resources.expandMenu;
            this.btnLogMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogMenu.Location = new System.Drawing.Point(4, 8);
            this.btnLogMenu.Name = "btnLogMenu";
            this.btnLogMenu.Size = new System.Drawing.Size(32, 32);
            this.btnLogMenu.TabIndex = 3;
            this.btnLogMenu.UseVisualStyleBackColor = true;
            this.btnLogMenu.Click += new System.EventHandler(this.btnLogMenu_Click);
            // 
            // panQueryCriteria
            // 
            this.panQueryCriteria.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panQueryCriteria.Controls.Add(this.splitContainer1);
            this.panQueryCriteria.Location = new System.Drawing.Point(42, 4);
            this.panQueryCriteria.Name = "panQueryCriteria";
            this.panQueryCriteria.Size = new System.Drawing.Size(700, 46);
            this.panQueryCriteria.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(700, 46);
            this.splitContainer1.SplitterDistance = 629;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.33134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41717F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41716F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41716F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41716F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDetails, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLevel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLabelDetails, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLabelName, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLabelLevel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLabelType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLabelDate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtType, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 46);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dtpLogStart, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpLogEnd, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(285, 22);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // dtpLogStart
            // 
            this.dtpLogStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpLogStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpLogStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLogStart.Location = new System.Drawing.Point(0, 0);
            this.dtpLogStart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpLogStart.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpLogStart.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpLogStart.Name = "dtpLogStart";
            this.dtpLogStart.Size = new System.Drawing.Size(132, 21);
            this.dtpLogStart.TabIndex = 4;
            this.dtpLogStart.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Location = new System.Drawing.Point(135, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "至";
            // 
            // dtpLogEnd
            // 
            this.dtpLogEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpLogEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpLogEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLogEnd.Location = new System.Drawing.Point(152, 0);
            this.dtpLogEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dtpLogEnd.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpLogEnd.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpLogEnd.Name = "dtpLogEnd";
            this.dtpLogEnd.Size = new System.Drawing.Size(133, 21);
            this.dtpLogEnd.TabIndex = 3;
            this.dtpLogEnd.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // txtDetails
            // 
            this.txtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetails.Location = new System.Drawing.Point(546, 21);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(80, 21);
            this.txtDetails.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(462, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(78, 21);
            this.txtName.TabIndex = 8;
            // 
            // txtLevel
            // 
            this.txtLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLevel.Location = new System.Drawing.Point(378, 21);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(78, 21);
            this.txtLevel.TabIndex = 7;
            // 
            // txtLabelDetails
            // 
            this.txtLabelDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLabelDetails.AutoSize = true;
            this.txtLabelDetails.Location = new System.Drawing.Point(571, 3);
            this.txtLabelDetails.Name = "txtLabelDetails";
            this.txtLabelDetails.Size = new System.Drawing.Size(29, 12);
            this.txtLabelDetails.TabIndex = 4;
            this.txtLabelDetails.Text = "详情";
            // 
            // txtLabelName
            // 
            this.txtLabelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLabelName.AutoSize = true;
            this.txtLabelName.Location = new System.Drawing.Point(486, 3);
            this.txtLabelName.Name = "txtLabelName";
            this.txtLabelName.Size = new System.Drawing.Size(29, 12);
            this.txtLabelName.TabIndex = 3;
            this.txtLabelName.Text = "名称";
            // 
            // txtLabelLevel
            // 
            this.txtLabelLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLabelLevel.AutoSize = true;
            this.txtLabelLevel.Location = new System.Drawing.Point(402, 3);
            this.txtLabelLevel.Name = "txtLabelLevel";
            this.txtLabelLevel.Size = new System.Drawing.Size(29, 12);
            this.txtLabelLevel.TabIndex = 2;
            this.txtLabelLevel.Text = "等级";
            // 
            // txtLabelType
            // 
            this.txtLabelType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLabelType.AutoSize = true;
            this.txtLabelType.Location = new System.Drawing.Point(318, 3);
            this.txtLabelType.Name = "txtLabelType";
            this.txtLabelType.Size = new System.Drawing.Size(29, 12);
            this.txtLabelType.TabIndex = 1;
            this.txtLabelType.Text = "类型";
            // 
            // txtLabelDate
            // 
            this.txtLabelDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLabelDate.AutoSize = true;
            this.txtLabelDate.Location = new System.Drawing.Point(131, 3);
            this.txtLabelDate.Name = "txtLabelDate";
            this.txtLabelDate.Size = new System.Drawing.Size(29, 12);
            this.txtLabelDate.TabIndex = 0;
            this.txtLabelDate.Text = "日期";
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Location = new System.Drawing.Point(294, 21);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(78, 21);
            this.txtType.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnLogQuery, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnLogReset, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(67, 46);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnLogQuery
            // 
            this.btnLogQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogQuery.Location = new System.Drawing.Point(0, 23);
            this.btnLogQuery.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogQuery.Name = "btnLogQuery";
            this.btnLogQuery.Size = new System.Drawing.Size(67, 23);
            this.btnLogQuery.TabIndex = 1;
            this.btnLogQuery.Text = "查询";
            this.btnLogQuery.UseVisualStyleBackColor = true;
            this.btnLogQuery.Click += new System.EventHandler(this.btnLogQuery_Click);
            // 
            // btnLogReset
            // 
            this.btnLogReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogReset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogReset.Location = new System.Drawing.Point(0, 0);
            this.btnLogReset.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogReset.Name = "btnLogReset";
            this.btnLogReset.Size = new System.Drawing.Size(67, 23);
            this.btnLogReset.TabIndex = 0;
            this.btnLogReset.Text = "重置";
            this.btnLogReset.UseVisualStyleBackColor = true;
            this.btnLogReset.Click += new System.EventHandler(this.btnLogReset_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.ContextMenuStrip = this.cmsLog;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgvLog.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(800, 600);
            this.dgvLog.TabIndex = 1;
            this.dgvLog.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvLog_RowPrePaint);
            // 
            // cmsLog
            // 
            this.cmsLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLogShow30,
            this.cmsLogShow50,
            this.cmsLogShow100,
            this.cmsLogShow10000,
            this.cmsLogDelete30,
            this.cmsLogDelete60,
            this.cmsLogDelete90,
            this.cmsLogStop,
            this.cmsLogStart,
            this.cmsLogExcel,
            this.cmsLogDelete});
            this.cmsLog.Name = "cmsLog";
            this.cmsLog.Size = new System.Drawing.Size(184, 246);
            // 
            // cmsLogShow30
            // 
            this.cmsLogShow30.Name = "cmsLogShow30";
            this.cmsLogShow30.Size = new System.Drawing.Size(183, 22);
            this.cmsLogShow30.Text = "显示前30条数据";
            this.cmsLogShow30.Click += new System.EventHandler(this.cmsLogShow30_Click);
            // 
            // cmsLogShow50
            // 
            this.cmsLogShow50.Name = "cmsLogShow50";
            this.cmsLogShow50.Size = new System.Drawing.Size(183, 22);
            this.cmsLogShow50.Text = "显示前50条数据";
            this.cmsLogShow50.Click += new System.EventHandler(this.cmsLogShow50_Click);
            // 
            // cmsLogShow100
            // 
            this.cmsLogShow100.Name = "cmsLogShow100";
            this.cmsLogShow100.Size = new System.Drawing.Size(183, 22);
            this.cmsLogShow100.Text = "显示前100条数据";
            this.cmsLogShow100.Click += new System.EventHandler(this.cmsLogShow100_Click);
            // 
            // cmsLogShow10000
            // 
            this.cmsLogShow10000.Name = "cmsLogShow10000";
            this.cmsLogShow10000.Size = new System.Drawing.Size(183, 22);
            this.cmsLogShow10000.Text = "显示前10000条数据";
            this.cmsLogShow10000.Click += new System.EventHandler(this.cmsLogShow10000_Click);
            // 
            // cmsLogDelete30
            // 
            this.cmsLogDelete30.Name = "cmsLogDelete30";
            this.cmsLogDelete30.Size = new System.Drawing.Size(183, 22);
            this.cmsLogDelete30.Text = "删除30天前的数据";
            this.cmsLogDelete30.Click += new System.EventHandler(this.cmsLogDelete30_Click);
            // 
            // cmsLogDelete60
            // 
            this.cmsLogDelete60.Name = "cmsLogDelete60";
            this.cmsLogDelete60.Size = new System.Drawing.Size(183, 22);
            this.cmsLogDelete60.Text = "删除60天前的数据";
            this.cmsLogDelete60.Click += new System.EventHandler(this.cmsLogDelete60_Click);
            // 
            // cmsLogDelete90
            // 
            this.cmsLogDelete90.Name = "cmsLogDelete90";
            this.cmsLogDelete90.Size = new System.Drawing.Size(183, 22);
            this.cmsLogDelete90.Text = "删除90天前的数据";
            this.cmsLogDelete90.Click += new System.EventHandler(this.cmsLogDelete90_Click);
            // 
            // cmsLogStop
            // 
            this.cmsLogStop.Name = "cmsLogStop";
            this.cmsLogStop.Size = new System.Drawing.Size(183, 22);
            this.cmsLogStop.Text = "停止定时刷新";
            this.cmsLogStop.Click += new System.EventHandler(this.cmsLogStop_Click);
            // 
            // cmsLogStart
            // 
            this.cmsLogStart.Name = "cmsLogStart";
            this.cmsLogStart.Size = new System.Drawing.Size(183, 22);
            this.cmsLogStart.Text = "启动定时刷新";
            this.cmsLogStart.Click += new System.EventHandler(this.cmsLogStart_Click);
            // 
            // cmsLogExcel
            // 
            this.cmsLogExcel.Name = "cmsLogExcel";
            this.cmsLogExcel.Size = new System.Drawing.Size(183, 22);
            this.cmsLogExcel.Text = "生成Excel";
            this.cmsLogExcel.Click += new System.EventHandler(this.cmsLogExcel_Click);
            // 
            // cmsLogDelete
            // 
            this.cmsLogDelete.Name = "cmsLogDelete";
            this.cmsLogDelete.Size = new System.Drawing.Size(183, 22);
            this.cmsLogDelete.Text = "删除所有数据";
            this.cmsLogDelete.Click += new System.EventHandler(this.cmsLogDelete_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 600;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // WCFLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panQueryCriteria);
            this.Controls.Add(this.btnLogMenu);
            this.Controls.Add(this.dgvLog);
            this.Name = "WCFLog";
            this.Size = new System.Drawing.Size(800, 600);
            this.panQueryCriteria.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.cmsLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogMenu;
        private System.Windows.Forms.Panel panQueryCriteria;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label txtLabelDetails;
        private System.Windows.Forms.Label txtLabelName;
        private System.Windows.Forms.Label txtLabelLevel;
        private System.Windows.Forms.Label txtLabelType;
        private System.Windows.Forms.Label txtLabelDate;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnLogQuery;
        private System.Windows.Forms.Button btnLogReset;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker dtpLogStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpLogEnd;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.ContextMenuStrip cmsLog;
        private System.Windows.Forms.ToolStripMenuItem cmsLogShow30;
        private System.Windows.Forms.ToolStripMenuItem cmsLogShow50;
        private System.Windows.Forms.ToolStripMenuItem cmsLogShow100;
        private System.Windows.Forms.ToolStripMenuItem cmsLogShow10000;
        private System.Windows.Forms.ToolStripMenuItem cmsLogDelete30;
        private System.Windows.Forms.ToolStripMenuItem cmsLogDelete60;
        private System.Windows.Forms.ToolStripMenuItem cmsLogDelete90;
        private System.Windows.Forms.ToolStripMenuItem cmsLogExcel;
        private System.Windows.Forms.ToolStripMenuItem cmsLogDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsLogStop;
        private System.Windows.Forms.ToolStripMenuItem cmsLogStart;
    }
}
