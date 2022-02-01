
namespace WCF
{
    partial class MonitorDIPage
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
            this.wcfDI = new WCF.WCFDI();
            this.SuspendLayout();
            // 
            // wcfDI
            // 
            this.wcfDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcfDI.Location = new System.Drawing.Point(0, 0);
            this.wcfDI.Name = "wcfDI";
            this.wcfDI.Size = new System.Drawing.Size(800, 450);
            this.wcfDI.TabIndex = 0;
            // 
            // MonitorDIPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wcfDI);
            this.Name = "MonitorDIPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入信号监控页面";
            this.ResumeLayout(false);

        }

        #endregion

        private WCFDI wcfDI;
    }
}