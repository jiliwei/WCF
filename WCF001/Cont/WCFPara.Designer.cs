
namespace WCF
{
    partial class WCFPara
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
            this.tlpPara = new System.Windows.Forms.TableLayoutPanel();
            this.wcfLog = new WCF.WCFLog();
            this.gbAllEdit = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvParaNames = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteTab = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnAddListName = new System.Windows.Forms.Button();
            this.btnAddTabName = new System.Windows.Forms.Button();
            this.txtParaNameEdit = new System.Windows.Forms.TextBox();
            this.btnCloseTab = new System.Windows.Forms.Button();
            this.gbRelevance = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvRelevanceEdit = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnRelevanceOk = new System.Windows.Forms.Button();
            this.btnRelevanceCancel = new System.Windows.Forms.Button();
            this.gbLevel = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvLevelEdit = new System.Windows.Forms.DataGridView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnLevelOk = new System.Windows.Forms.Button();
            this.btnLevelCancel = new System.Windows.Forms.Button();
            this.tlpPara.SuspendLayout();
            this.gbAllEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbRelevance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelevanceEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.gbLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevelEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPara
            // 
            this.tlpPara.ColumnCount = 1;
            this.tlpPara.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPara.Controls.Add(this.wcfLog, 0, 1);
            this.tlpPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPara.Location = new System.Drawing.Point(0, 0);
            this.tlpPara.Name = "tlpPara";
            this.tlpPara.RowCount = 2;
            this.tlpPara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpPara.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpPara.Size = new System.Drawing.Size(1020, 760);
            this.tlpPara.TabIndex = 0;
            // 
            // wcfLog
            // 
            this.wcfLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcfLog.IsQuery = false;
            this.wcfLog.Location = new System.Drawing.Point(3, 687);
            this.wcfLog.Name = "wcfLog";
            this.wcfLog.Size = new System.Drawing.Size(1014, 70);
            this.wcfLog.TabIndex = 0;
            // 
            // gbAllEdit
            // 
            this.gbAllEdit.Controls.Add(this.splitContainer1);
            this.gbAllEdit.Location = new System.Drawing.Point(6, 6);
            this.gbAllEdit.Name = "gbAllEdit";
            this.gbAllEdit.Size = new System.Drawing.Size(353, 285);
            this.gbAllEdit.TabIndex = 1;
            this.gbAllEdit.TabStop = false;
            this.gbAllEdit.Text = "整体编辑";
            this.gbAllEdit.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvParaNames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(347, 265);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvParaNames
            // 
            this.tvParaNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvParaNames.Location = new System.Drawing.Point(0, 0);
            this.tvParaNames.Name = "tvParaNames";
            this.tvParaNames.Size = new System.Drawing.Size(197, 265);
            this.tvParaNames.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnDeleteTab, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnRename, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnAddListName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnAddTabName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtParaNameEdit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCloseTab, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.19006F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.76199F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.76199F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.76199F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.76199F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.76199F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(146, 265);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnDeleteTab
            // 
            this.btnDeleteTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteTab.Location = new System.Drawing.Point(3, 173);
            this.btnDeleteTab.Name = "btnDeleteTab";
            this.btnDeleteTab.Size = new System.Drawing.Size(140, 41);
            this.btnDeleteTab.TabIndex = 0;
            this.btnDeleteTab.Text = "删除选中项";
            this.btnDeleteTab.UseVisualStyleBackColor = true;
            this.btnDeleteTab.Click += new System.EventHandler(this.btnDeleteTab_Click);
            // 
            // btnRename
            // 
            this.btnRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRename.Location = new System.Drawing.Point(3, 126);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(140, 41);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "重命名当前选项";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnAddListName
            // 
            this.btnAddListName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddListName.Location = new System.Drawing.Point(3, 79);
            this.btnAddListName.Name = "btnAddListName";
            this.btnAddListName.Size = new System.Drawing.Size(140, 41);
            this.btnAddListName.TabIndex = 0;
            this.btnAddListName.Text = "新增列表名称";
            this.btnAddListName.UseVisualStyleBackColor = true;
            this.btnAddListName.Click += new System.EventHandler(this.btnAddListName_Click);
            // 
            // btnAddTabName
            // 
            this.btnAddTabName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTabName.Location = new System.Drawing.Point(3, 32);
            this.btnAddTabName.Name = "btnAddTabName";
            this.btnAddTabName.Size = new System.Drawing.Size(140, 41);
            this.btnAddTabName.TabIndex = 0;
            this.btnAddTabName.Text = "增加选项卡名称";
            this.btnAddTabName.UseVisualStyleBackColor = true;
            this.btnAddTabName.Click += new System.EventHandler(this.btnAddTabName_Click);
            // 
            // txtParaNameEdit
            // 
            this.txtParaNameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtParaNameEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtParaNameEdit.Location = new System.Drawing.Point(3, 3);
            this.txtParaNameEdit.Name = "txtParaNameEdit";
            this.txtParaNameEdit.Size = new System.Drawing.Size(140, 26);
            this.txtParaNameEdit.TabIndex = 0;
            // 
            // btnCloseTab
            // 
            this.btnCloseTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseTab.Location = new System.Drawing.Point(3, 220);
            this.btnCloseTab.Name = "btnCloseTab";
            this.btnCloseTab.Size = new System.Drawing.Size(140, 42);
            this.btnCloseTab.TabIndex = 1;
            this.btnCloseTab.Text = "关闭";
            this.btnCloseTab.UseVisualStyleBackColor = true;
            this.btnCloseTab.Click += new System.EventHandler(this.btnCloseTab_Click);
            // 
            // gbRelevance
            // 
            this.gbRelevance.Controls.Add(this.splitContainer2);
            this.gbRelevance.Location = new System.Drawing.Point(3, 3);
            this.gbRelevance.Name = "gbRelevance";
            this.gbRelevance.Size = new System.Drawing.Size(191, 194);
            this.gbRelevance.TabIndex = 3;
            this.gbRelevance.TabStop = false;
            this.gbRelevance.Text = "关联值的编辑";
            this.gbRelevance.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 17);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvRelevanceEdit);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(185, 174);
            this.splitContainer2.SplitterDistance = 145;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvRelevanceEdit
            // 
            this.dgvRelevanceEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelevanceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelevanceEdit.Location = new System.Drawing.Point(0, 0);
            this.dgvRelevanceEdit.Name = "dgvRelevanceEdit";
            this.dgvRelevanceEdit.RowTemplate.Height = 23;
            this.dgvRelevanceEdit.Size = new System.Drawing.Size(185, 145);
            this.dgvRelevanceEdit.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnRelevanceOk);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnRelevanceCancel);
            this.splitContainer3.Size = new System.Drawing.Size(185, 25);
            this.splitContainer3.SplitterDistance = 95;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnRelevanceOk
            // 
            this.btnRelevanceOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRelevanceOk.Location = new System.Drawing.Point(0, 0);
            this.btnRelevanceOk.Name = "btnRelevanceOk";
            this.btnRelevanceOk.Size = new System.Drawing.Size(95, 25);
            this.btnRelevanceOk.TabIndex = 0;
            this.btnRelevanceOk.Text = "保存修改";
            this.btnRelevanceOk.UseVisualStyleBackColor = true;
            this.btnRelevanceOk.Click += new System.EventHandler(this.btnRelevanceOk_Click);
            // 
            // btnRelevanceCancel
            // 
            this.btnRelevanceCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRelevanceCancel.Location = new System.Drawing.Point(0, 0);
            this.btnRelevanceCancel.Name = "btnRelevanceCancel";
            this.btnRelevanceCancel.Size = new System.Drawing.Size(86, 25);
            this.btnRelevanceCancel.TabIndex = 0;
            this.btnRelevanceCancel.Text = "关闭";
            this.btnRelevanceCancel.UseVisualStyleBackColor = true;
            this.btnRelevanceCancel.Click += new System.EventHandler(this.btnRelevanceCancel_Click);
            // 
            // gbLevel
            // 
            this.gbLevel.Controls.Add(this.splitContainer4);
            this.gbLevel.Location = new System.Drawing.Point(8, 8);
            this.gbLevel.Name = "gbLevel";
            this.gbLevel.Size = new System.Drawing.Size(191, 283);
            this.gbLevel.TabIndex = 4;
            this.gbLevel.TabStop = false;
            this.gbLevel.Text = "参数等级的编辑";
            this.gbLevel.Visible = false;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 17);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvLevelEdit);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(185, 263);
            this.splitContainer4.SplitterDistance = 233;
            this.splitContainer4.TabIndex = 0;
            // 
            // dgvLevelEdit
            // 
            this.dgvLevelEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLevelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLevelEdit.Location = new System.Drawing.Point(0, 0);
            this.dgvLevelEdit.Name = "dgvLevelEdit";
            this.dgvLevelEdit.RowTemplate.Height = 23;
            this.dgvLevelEdit.Size = new System.Drawing.Size(185, 233);
            this.dgvLevelEdit.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnLevelOk);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.btnLevelCancel);
            this.splitContainer5.Size = new System.Drawing.Size(185, 26);
            this.splitContainer5.SplitterDistance = 94;
            this.splitContainer5.TabIndex = 0;
            // 
            // btnLevelOk
            // 
            this.btnLevelOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLevelOk.Location = new System.Drawing.Point(0, 0);
            this.btnLevelOk.Name = "btnLevelOk";
            this.btnLevelOk.Size = new System.Drawing.Size(94, 26);
            this.btnLevelOk.TabIndex = 0;
            this.btnLevelOk.Text = "保存修改";
            this.btnLevelOk.UseVisualStyleBackColor = true;
            this.btnLevelOk.Click += new System.EventHandler(this.btnLevelOk_Click);
            // 
            // btnLevelCancel
            // 
            this.btnLevelCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLevelCancel.Location = new System.Drawing.Point(0, 0);
            this.btnLevelCancel.Name = "btnLevelCancel";
            this.btnLevelCancel.Size = new System.Drawing.Size(87, 26);
            this.btnLevelCancel.TabIndex = 0;
            this.btnLevelCancel.Text = "关闭";
            this.btnLevelCancel.UseVisualStyleBackColor = true;
            this.btnLevelCancel.Click += new System.EventHandler(this.btnLevelCancel_Click);
            // 
            // WCFPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLevel);
            this.Controls.Add(this.gbRelevance);
            this.Controls.Add(this.gbAllEdit);
            this.Controls.Add(this.tlpPara);
            this.Name = "WCFPara";
            this.Size = new System.Drawing.Size(1020, 760);
            this.tlpPara.ResumeLayout(false);
            this.gbAllEdit.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gbRelevance.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelevanceEdit)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.gbLevel.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLevelEdit)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPara;
        private WCFLog wcfLog;
        private System.Windows.Forms.GroupBox gbAllEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvParaNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCloseTab;
        private System.Windows.Forms.Button btnDeleteTab;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnAddListName;
        private System.Windows.Forms.Button btnAddTabName;
        private System.Windows.Forms.TextBox txtParaNameEdit;
        private System.Windows.Forms.GroupBox gbRelevance;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvRelevanceEdit;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnRelevanceOk;
        private System.Windows.Forms.Button btnRelevanceCancel;
        private System.Windows.Forms.GroupBox gbLevel;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvLevelEdit;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnLevelOk;
        private System.Windows.Forms.Button btnLevelCancel;
    }
}
