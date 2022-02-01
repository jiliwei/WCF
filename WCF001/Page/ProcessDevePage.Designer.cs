
namespace WCF
{
    partial class ProcessDevePage
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
            this.wcfTask = new WCF.WCFTask();
            this.SuspendLayout();
            // 
            // wcfTask
            // 
            this.wcfTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcfTask.Location = new System.Drawing.Point(0, 0);
            this.wcfTask.Name = "wcfTask";
            this.wcfTask.Size = new System.Drawing.Size(1008, 729);
            this.wcfTask.TabIndex = 0;
            // 
            // ProcessDevePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.wcfTask);
            this.Name = "ProcessDevePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流程开发页面";
            this.ResumeLayout(false);

        }

        #endregion

        private WCFTask wcfTask;
    }
}