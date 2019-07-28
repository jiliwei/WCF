namespace WCF.WCFControl
{
    partial class WCFDataGroup
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
            this.lvDataView = new System.Windows.Forms.ListView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panContent = new System.Windows.Forms.Panel();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtTips = new System.Windows.Forms.Label();
            this.panContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.SuspendLayout();
            // 
            // lvDataView
            // 
            this.lvDataView.HoverSelection = true;
            this.lvDataView.Location = new System.Drawing.Point(1, 1);
            this.lvDataView.Name = "lvDataView";
            this.lvDataView.Size = new System.Drawing.Size(500, 376);
            this.lvDataView.TabIndex = 0;
            this.lvDataView.UseCompatibleStateImageBehavior = false;
            this.lvDataView.View = System.Windows.Forms.View.Details;
            this.lvDataView.SelectedIndexChanged += new System.EventHandler(this.lvDataView_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(437, 63);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 60);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panContent
            // 
            this.panContent.Controls.Add(this.dgvContent);
            this.panContent.Controls.Add(this.btnRead);
            this.panContent.Controls.Add(this.btnUpdate);
            this.panContent.Location = new System.Drawing.Point(1, 379);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(500, 126);
            this.panContent.TabIndex = 9;
            // 
            // dgvContent
            // 
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(5, 2);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.RowTemplate.Height = 23;
            this.dgvContent.Size = new System.Drawing.Size(430, 122);
            this.dgvContent.TabIndex = 10;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(437, 2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(60, 60);
            this.btnRead.TabIndex = 9;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtTips
            // 
            this.txtTips.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTips.Location = new System.Drawing.Point(96, 379);
            this.txtTips.Name = "txtTips";
            this.txtTips.Size = new System.Drawing.Size(300, 126);
            this.txtTips.TabIndex = 11;
            this.txtTips.Text = "未选择";
            this.txtTips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WCFDataGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTips);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.lvDataView);
            this.Name = "WCFDataGroup";
            this.Size = new System.Drawing.Size(503, 505);
            this.Load += new System.EventHandler(this.WCFDataGroup_Load);
            this.SizeChanged += new System.EventHandler(this.WCFDataGroup_SizeChanged);
            this.panContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDataView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.DataGridView dgvContent;
        private System.Windows.Forms.Label txtTips;
    }
}
