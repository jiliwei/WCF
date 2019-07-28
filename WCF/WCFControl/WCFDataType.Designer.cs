namespace WCF
{
    partial class WCFDataType
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopyAdd = new System.Windows.Forms.Button();
            this.cbWcfData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panData = new System.Windows.Forms.Panel();
            this.btnDataCancel = new System.Windows.Forms.Button();
            this.btnDataOK = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(317, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCopyAdd
            // 
            this.btnCopyAdd.Location = new System.Drawing.Point(232, 4);
            this.btnCopyAdd.Name = "btnCopyAdd";
            this.btnCopyAdd.Size = new System.Drawing.Size(85, 23);
            this.btnCopyAdd.TabIndex = 7;
            this.btnCopyAdd.Text = "复制并新增";
            this.btnCopyAdd.UseVisualStyleBackColor = true;
            this.btnCopyAdd.Click += new System.EventHandler(this.btnCopyAdd_Click);
            // 
            // cbWcfData
            // 
            this.cbWcfData.FormattingEnabled = true;
            this.cbWcfData.Location = new System.Drawing.Point(107, 6);
            this.cbWcfData.Name = "cbWcfData";
            this.cbWcfData.Size = new System.Drawing.Size(122, 20);
            this.cbWcfData.TabIndex = 6;
            this.cbWcfData.SelectedIndexChanged += new System.EventHandler(this.cbWcfData_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "当前机种：";
            // 
            // panData
            // 
            this.panData.Controls.Add(this.btnDataCancel);
            this.panData.Controls.Add(this.btnDataOK);
            this.panData.Controls.Add(this.txtData);
            this.panData.Controls.Add(this.label3);
            this.panData.Location = new System.Drawing.Point(7, 0);
            this.panData.Name = "panData";
            this.panData.Size = new System.Drawing.Size(349, 30);
            this.panData.TabIndex = 11;
            this.panData.Visible = false;
            // 
            // btnDataCancel
            // 
            this.btnDataCancel.Location = new System.Drawing.Point(306, 4);
            this.btnDataCancel.Name = "btnDataCancel";
            this.btnDataCancel.Size = new System.Drawing.Size(40, 23);
            this.btnDataCancel.TabIndex = 5;
            this.btnDataCancel.Text = "取消";
            this.btnDataCancel.UseVisualStyleBackColor = true;
            this.btnDataCancel.Click += new System.EventHandler(this.btnDataCancel_Click);
            // 
            // btnDataOK
            // 
            this.btnDataOK.Location = new System.Drawing.Point(263, 4);
            this.btnDataOK.Name = "btnDataOK";
            this.btnDataOK.Size = new System.Drawing.Size(40, 23);
            this.btnDataOK.TabIndex = 4;
            this.btnDataOK.Text = "确定";
            this.btnDataOK.UseVisualStyleBackColor = true;
            this.btnDataOK.Click += new System.EventHandler(this.btnDataOK_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(72, 5);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(185, 21);
            this.txtData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新机种名称：";
            // 
            // WCFDataType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panData);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopyAdd);
            this.Controls.Add(this.cbWcfData);
            this.Controls.Add(this.label1);
            this.Name = "WCFDataType";
            this.Size = new System.Drawing.Size(360, 30);
            this.Load += new System.EventHandler(this.WCFDataType_Load);
            this.SizeChanged += new System.EventHandler(this.WCFDataType_SizeChanged);
            this.panData.ResumeLayout(false);
            this.panData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopyAdd;
        private System.Windows.Forms.ComboBox cbWcfData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panData;
        private System.Windows.Forms.Button btnDataCancel;
        private System.Windows.Forms.Button btnDataOK;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label3;
    }
}
