namespace WCF.WCFControl
{
    partial class WCFAutoScript
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAsRun = new System.Windows.Forms.Button();
            this.btnAsSave = new System.Windows.Forms.Button();
            this.panelAsProcess = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAsRun);
            this.splitContainer1.Panel1.Controls.Add(this.btnAsSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelAsProcess);
            this.splitContainer1.Size = new System.Drawing.Size(676, 585);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnAsRun
            // 
            this.btnAsRun.Location = new System.Drawing.Point(84, 5);
            this.btnAsRun.Name = "btnAsRun";
            this.btnAsRun.Size = new System.Drawing.Size(75, 23);
            this.btnAsRun.TabIndex = 4;
            this.btnAsRun.Text = "运行";
            this.btnAsRun.UseVisualStyleBackColor = true;
            this.btnAsRun.Click += new System.EventHandler(this.btnAsRun_Click);
            // 
            // btnAsSave
            // 
            this.btnAsSave.Location = new System.Drawing.Point(3, 5);
            this.btnAsSave.Name = "btnAsSave";
            this.btnAsSave.Size = new System.Drawing.Size(75, 23);
            this.btnAsSave.TabIndex = 3;
            this.btnAsSave.Text = "保存";
            this.btnAsSave.UseVisualStyleBackColor = true;
            this.btnAsSave.Click += new System.EventHandler(this.btnAsSave_Click);
            // 
            // panelAsProcess
            // 
            this.panelAsProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAsProcess.Location = new System.Drawing.Point(0, 0);
            this.panelAsProcess.Name = "panelAsProcess";
            this.panelAsProcess.Size = new System.Drawing.Size(676, 550);
            this.panelAsProcess.TabIndex = 1;
            // 
            // WCFAutoScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "WCFAutoScript";
            this.Size = new System.Drawing.Size(676, 585);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAsRun;
        private System.Windows.Forms.Button btnAsSave;
        private System.Windows.Forms.Panel panelAsProcess;
    }
}
