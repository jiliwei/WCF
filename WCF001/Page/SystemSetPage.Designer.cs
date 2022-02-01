
namespace WCF
{
    partial class SystemSetPage
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
            this.wcfSysPara = new WCF.WCFSysPara();
            this.SuspendLayout();
            // 
            // wcfSysPara
            // 
            this.wcfSysPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcfSysPara.Location = new System.Drawing.Point(0, 0);
            this.wcfSysPara.Name = "wcfSysPara";
            this.wcfSysPara.Size = new System.Drawing.Size(800, 450);
            this.wcfSysPara.TabIndex = 0;
            // 
            // SystemSetPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wcfSysPara);
            this.Name = "SystemSetPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置页面";
            this.Load += new System.EventHandler(this.SystemSetPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WCFSysPara wcfSysPara;
    }
}