
namespace WCF
{
    partial class MonitorDOPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wcfDO = new WCF.WCFDO();
            this.SuspendLayout();
            // 
            // wcfDO
            // 
            this.wcfDO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcfDO.Location = new System.Drawing.Point(0, 0);
            this.wcfDO.Name = "wcfDO";
            this.wcfDO.Size = new System.Drawing.Size(800, 450);
            this.wcfDO.TabIndex = 0;
            // 
            // MonitorDOPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wcfDO);
            this.Name = "MonitorDOPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输出信号监控页面";
            this.ResumeLayout(false);

        }

        #endregion

        private WCFDO wcfDO;
    }
}