namespace WCF
{
    partial class WCFAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WCFAbout));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.llb_WCF = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(472, 181);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("仿宋", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(200, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "WCF";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(173, 102);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(149, 12);
            this.lbl_Version.TabIndex = 2;
            this.lbl_Version.Text = "版本： 0.0.0.2（鉴赏版）";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(415, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llb_WCF
            // 
            this.llb_WCF.AutoSize = true;
            this.llb_WCF.Location = new System.Drawing.Point(155, 122);
            this.llb_WCF.Name = "llb_WCF";
            this.llb_WCF.Size = new System.Drawing.Size(185, 12);
            this.llb_WCF.TabIndex = 4;
            this.llb_WCF.TabStop = true;
            this.llb_WCF.Text = "https://github.com/jiliwei/WCF";
            this.llb_WCF.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbWCF_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("仿宋", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(151, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "简单并高效且代码少";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "联系方式(微信QQ同号)：769838889";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "作者：韦季李  你的名字（如果您愿意一起完善）";
            // 
            // WCFAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 393);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.llb_WCF);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.label1);
            this.Name = "WCFAbout";
            this.Text = "关于 WCF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llb_WCF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}