
namespace WCF
{
    partial class MonitorAxisPage
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
            this.wcfAxis = new WCF.WCFAxis();
            this.SuspendLayout();
            // 
            // wcfAxis
            // 
            this.wcfAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcfAxis.Location = new System.Drawing.Point(0, 0);
            this.wcfAxis.Name = "wcfAxis";
            this.wcfAxis.Size = new System.Drawing.Size(800, 450);
            this.wcfAxis.TabIndex = 0;
            // 
            // MonitorAxisPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wcfAxis);
            this.Name = "MonitorAxisPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "轴监控页面";
            this.ResumeLayout(false);

        }

        #endregion

        private WCFAxis wcfAxis;
    }
}