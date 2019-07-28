namespace WCF
{
    partial class WCFData
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbWcfData = new System.Windows.Forms.ComboBox();
            this.dgvParameter = new System.Windows.Forms.DataGridView();
            this.Cms_Pata = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsPataAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPataModify = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPataDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panPataAdd = new System.Windows.Forms.Panel();
            this.dgvPataAdd = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPataAddCorrAxis = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPataAddCancel = new System.Windows.Forms.Button();
            this.btnPataAddOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panData = new System.Windows.Forms.Panel();
            this.btnDataCancel = new System.Windows.Forms.Button();
            this.btnDataOK = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panPataModify = new System.Windows.Forms.Panel();
            this.dgvPataModify = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPataModifyCorrAxis = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPataModifyCancel = new System.Windows.Forms.Button();
            this.btnPataModifyOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameter)).BeginInit();
            this.Cms_Pata.SuspendLayout();
            this.panPataAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPataAdd)).BeginInit();
            this.panData.SuspendLayout();
            this.panPataModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPataModify)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前机种：";
            // 
            // cbWcfData
            // 
            this.cbWcfData.FormattingEnabled = true;
            this.cbWcfData.Location = new System.Drawing.Point(110, 7);
            this.cbWcfData.Name = "cbWcfData";
            this.cbWcfData.Size = new System.Drawing.Size(248, 20);
            this.cbWcfData.TabIndex = 1;
            this.cbWcfData.SelectedIndexChanged += new System.EventHandler(this.cbWcfData_SelectedIndexChanged);
            // 
            // dgvParameter
            // 
            this.dgvParameter.AllowUserToAddRows = false;
            this.dgvParameter.AllowUserToDeleteRows = false;
            this.dgvParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameter.ContextMenuStrip = this.Cms_Pata;
            this.dgvParameter.Location = new System.Drawing.Point(6, 33);
            this.dgvParameter.MultiSelect = false;
            this.dgvParameter.Name = "dgvParameter";
            this.dgvParameter.ReadOnly = true;
            this.dgvParameter.RowHeadersVisible = false;
            this.dgvParameter.RowTemplate.Height = 23;
            this.dgvParameter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameter.Size = new System.Drawing.Size(531, 471);
            this.dgvParameter.TabIndex = 2;
            // 
            // Cms_Pata
            // 
            this.Cms_Pata.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPataAdd,
            this.cmsPataModify,
            this.cmsPataDelete});
            this.Cms_Pata.Name = "Cms_Pata";
            this.Cms_Pata.Size = new System.Drawing.Size(101, 70);
            // 
            // cmsPataAdd
            // 
            this.cmsPataAdd.Name = "cmsPataAdd";
            this.cmsPataAdd.Size = new System.Drawing.Size(100, 22);
            this.cmsPataAdd.Text = "增加";
            this.cmsPataAdd.Click += new System.EventHandler(this.cmsPataAdd_Click);
            // 
            // cmsPataModify
            // 
            this.cmsPataModify.Name = "cmsPataModify";
            this.cmsPataModify.Size = new System.Drawing.Size(100, 22);
            this.cmsPataModify.Text = "修改";
            this.cmsPataModify.Click += new System.EventHandler(this.cmsPataModify_Click);
            // 
            // cmsPataDelete
            // 
            this.cmsPataDelete.Name = "cmsPataDelete";
            this.cmsPataDelete.Size = new System.Drawing.Size(100, 22);
            this.cmsPataDelete.Text = "删除";
            this.cmsPataDelete.Click += new System.EventHandler(this.cmsPataDelete_Click);
            // 
            // btnCopyAdd
            // 
            this.btnCopyAdd.Location = new System.Drawing.Point(364, 4);
            this.btnCopyAdd.Name = "btnCopyAdd";
            this.btnCopyAdd.Size = new System.Drawing.Size(85, 23);
            this.btnCopyAdd.TabIndex = 3;
            this.btnCopyAdd.Text = "复制并新增";
            this.btnCopyAdd.UseVisualStyleBackColor = true;
            this.btnCopyAdd.Click += new System.EventHandler(this.btnCopyAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(455, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panPataAdd
            // 
            this.panPataAdd.Controls.Add(this.dgvPataAdd);
            this.panPataAdd.Controls.Add(this.btnPataAddCancel);
            this.panPataAdd.Controls.Add(this.btnPataAddOK);
            this.panPataAdd.Controls.Add(this.label5);
            this.panPataAdd.Location = new System.Drawing.Point(10, 154);
            this.panPataAdd.Name = "panPataAdd";
            this.panPataAdd.Size = new System.Drawing.Size(527, 205);
            this.panPataAdd.TabIndex = 11;
            this.panPataAdd.Visible = false;
            // 
            // dgvPataAdd
            // 
            this.dgvPataAdd.AllowUserToDeleteRows = false;
            this.dgvPataAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPataAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dgvPataAddCorrAxis,
            this.Column2});
            this.dgvPataAdd.Location = new System.Drawing.Point(3, 32);
            this.dgvPataAdd.Name = "dgvPataAdd";
            this.dgvPataAdd.RowHeadersVisible = false;
            this.dgvPataAdd.RowTemplate.Height = 23;
            this.dgvPataAdd.Size = new System.Drawing.Size(521, 123);
            this.dgvPataAdd.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "组名";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "参数名称";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "值";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dgvPataAddCorrAxis
            // 
            this.dgvPataAddCorrAxis.HeaderText = "关联轴";
            this.dgvPataAddCorrAxis.Name = "dgvPataAddCorrAxis";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "备注";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // btnPataAddCancel
            // 
            this.btnPataAddCancel.Location = new System.Drawing.Point(289, 161);
            this.btnPataAddCancel.Name = "btnPataAddCancel";
            this.btnPataAddCancel.Size = new System.Drawing.Size(100, 30);
            this.btnPataAddCancel.TabIndex = 7;
            this.btnPataAddCancel.Text = "取消";
            this.btnPataAddCancel.UseVisualStyleBackColor = true;
            this.btnPataAddCancel.Click += new System.EventHandler(this.btnPataAddCancel_Click);
            // 
            // btnPataAddOK
            // 
            this.btnPataAddOK.Location = new System.Drawing.Point(132, 161);
            this.btnPataAddOK.Name = "btnPataAddOK";
            this.btnPataAddOK.Size = new System.Drawing.Size(100, 30);
            this.btnPataAddOK.TabIndex = 6;
            this.btnPataAddOK.Text = "确定";
            this.btnPataAddOK.UseVisualStyleBackColor = true;
            this.btnPataAddOK.Click += new System.EventHandler(this.btnPataAddOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(218, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "参数增加";
            // 
            // panData
            // 
            this.panData.Controls.Add(this.btnDataCancel);
            this.panData.Controls.Add(this.btnDataOK);
            this.panData.Controls.Add(this.txtData);
            this.panData.Controls.Add(this.label3);
            this.panData.Controls.Add(this.label2);
            this.panData.Location = new System.Drawing.Point(79, 54);
            this.panData.Name = "panData";
            this.panData.Size = new System.Drawing.Size(394, 126);
            this.panData.TabIndex = 10;
            this.panData.Visible = false;
            // 
            // btnDataCancel
            // 
            this.btnDataCancel.Location = new System.Drawing.Point(220, 83);
            this.btnDataCancel.Name = "btnDataCancel";
            this.btnDataCancel.Size = new System.Drawing.Size(100, 30);
            this.btnDataCancel.TabIndex = 5;
            this.btnDataCancel.Text = "取消";
            this.btnDataCancel.UseVisualStyleBackColor = true;
            this.btnDataCancel.Click += new System.EventHandler(this.btnDataCancel_Click);
            // 
            // btnDataOK
            // 
            this.btnDataOK.Location = new System.Drawing.Point(63, 83);
            this.btnDataOK.Name = "btnDataOK";
            this.btnDataOK.Size = new System.Drawing.Size(100, 30);
            this.btnDataOK.TabIndex = 4;
            this.btnDataOK.Text = "确定";
            this.btnDataOK.UseVisualStyleBackColor = true;
            this.btnDataOK.Click += new System.EventHandler(this.btnDataOK_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(142, 54);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(178, 21);
            this.txtData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新机种名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(119, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "复制并新增机种";
            // 
            // panPataModify
            // 
            this.panPataModify.Controls.Add(this.dgvPataModify);
            this.panPataModify.Controls.Add(this.btnPataModifyCancel);
            this.panPataModify.Controls.Add(this.btnPataModifyOK);
            this.panPataModify.Controls.Add(this.label4);
            this.panPataModify.Location = new System.Drawing.Point(10, 251);
            this.panPataModify.Name = "panPataModify";
            this.panPataModify.Size = new System.Drawing.Size(524, 127);
            this.panPataModify.TabIndex = 12;
            this.panPataModify.Visible = false;
            // 
            // dgvPataModify
            // 
            this.dgvPataModify.AllowUserToAddRows = false;
            this.dgvPataModify.AllowUserToDeleteRows = false;
            this.dgvPataModify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPataModify.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dgvPataModifyCorrAxis,
            this.dataGridViewTextBoxColumn4});
            this.dgvPataModify.Location = new System.Drawing.Point(3, 32);
            this.dgvPataModify.Name = "dgvPataModify";
            this.dgvPataModify.RowHeadersVisible = false;
            this.dgvPataModify.RowTemplate.Height = 23;
            this.dgvPataModify.Size = new System.Drawing.Size(518, 60);
            this.dgvPataModify.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "组名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "参数名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "值";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dgvPataModifyCorrAxis
            // 
            this.dgvPataModifyCorrAxis.HeaderText = "关联轴";
            this.dgvPataModifyCorrAxis.Name = "dgvPataModifyCorrAxis";
            this.dgvPataModifyCorrAxis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPataModifyCorrAxis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "备注";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // btnPataModifyCancel
            // 
            this.btnPataModifyCancel.Location = new System.Drawing.Point(289, 94);
            this.btnPataModifyCancel.Name = "btnPataModifyCancel";
            this.btnPataModifyCancel.Size = new System.Drawing.Size(100, 30);
            this.btnPataModifyCancel.TabIndex = 7;
            this.btnPataModifyCancel.Text = "取消";
            this.btnPataModifyCancel.UseVisualStyleBackColor = true;
            this.btnPataModifyCancel.Click += new System.EventHandler(this.btnPataModifyCancel_Click);
            // 
            // btnPataModifyOK
            // 
            this.btnPataModifyOK.Location = new System.Drawing.Point(132, 94);
            this.btnPataModifyOK.Name = "btnPataModifyOK";
            this.btnPataModifyOK.Size = new System.Drawing.Size(100, 30);
            this.btnPataModifyOK.TabIndex = 6;
            this.btnPataModifyOK.Text = "确定";
            this.btnPataModifyOK.UseVisualStyleBackColor = true;
            this.btnPataModifyOK.Click += new System.EventHandler(this.btnPataModifyOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(218, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "参数修改";
            // 
            // WCFData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panPataModify);
            this.Controls.Add(this.panPataAdd);
            this.Controls.Add(this.panData);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopyAdd);
            this.Controls.Add(this.dgvParameter);
            this.Controls.Add(this.cbWcfData);
            this.Controls.Add(this.label1);
            this.Name = "WCFData";
            this.Size = new System.Drawing.Size(544, 510);
            this.Load += new System.EventHandler(this.WCFData_Load);
            this.SizeChanged += new System.EventHandler(this.WCFData_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameter)).EndInit();
            this.Cms_Pata.ResumeLayout(false);
            this.panPataAdd.ResumeLayout(false);
            this.panPataAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPataAdd)).EndInit();
            this.panData.ResumeLayout(false);
            this.panData.PerformLayout();
            this.panPataModify.ResumeLayout(false);
            this.panPataModify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPataModify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWcfData;
        private System.Windows.Forms.DataGridView dgvParameter;
        private System.Windows.Forms.Button btnCopyAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip Cms_Pata;
        private System.Windows.Forms.ToolStripMenuItem cmsPataAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsPataModify;
        private System.Windows.Forms.ToolStripMenuItem cmsPataDelete;
        private System.Windows.Forms.Panel panPataAdd;
        private System.Windows.Forms.DataGridView dgvPataAdd;
        private System.Windows.Forms.Button btnPataAddCancel;
        private System.Windows.Forms.Button btnPataAddOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panData;
        private System.Windows.Forms.Button btnDataCancel;
        private System.Windows.Forms.Button btnDataOK;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panPataModify;
        private System.Windows.Forms.DataGridView dgvPataModify;
        private System.Windows.Forms.Button btnPataModifyCancel;
        private System.Windows.Forms.Button btnPataModifyOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvPataAddCorrAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvPataModifyCorrAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
