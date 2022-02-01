
namespace WCF.Cont
{
    partial class WCFSocket
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
            this.flpSecket = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpSecket
            // 
            this.flpSecket.AutoScroll = true;
            this.flpSecket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSecket.Location = new System.Drawing.Point(0, 0);
            this.flpSecket.Name = "flpSecket";
            this.flpSecket.Size = new System.Drawing.Size(739, 651);
            this.flpSecket.TabIndex = 0;
            // 
            // WCFSocket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpSecket);
            this.Name = "WCFSocket";
            this.Size = new System.Drawing.Size(739, 651);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSecket;
    }
}
