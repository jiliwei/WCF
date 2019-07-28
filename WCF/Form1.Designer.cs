namespace WCF
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.wcfDataType = new WCF.WCFDataType();
            this.wcfDataGroup = new WCF.WCFControl.WCFDataGroup();
            this.wcfDataPata = new WCF.WCFData();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvWcfAxis = new WCF.WCFControl.WCFAxis();
            this.lvWcfDO = new WCF.WCFControl.WCFDO();
            this.lvWcfDI = new WCF.Resources.WCFDI();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.wcfCardEdit = new WCF.WCFCard();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1420, 894);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.wcfDataType);
            this.tabPage1.Controls.Add(this.wcfDataGroup);
            this.tabPage1.Controls.Add(this.wcfDataPata);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1412, 868);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "关于";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wcfDataType
            // 
            this.wcfDataType.Location = new System.Drawing.Point(6, 460);
            this.wcfDataType.Name = "wcfDataType";
            this.wcfDataType.Size = new System.Drawing.Size(360, 33);
            this.wcfDataType.TabIndex = 5;
            this.wcfDataType.DataUpdateClick += new System.EventHandler(this.wcfDataType_DataUpdateClick);
            // 
            // wcfDataGroup
            // 
            this.wcfDataGroup.Location = new System.Drawing.Point(6, 499);
            this.wcfDataGroup.Name = "wcfDataGroup";
            this.wcfDataGroup.Size = new System.Drawing.Size(427, 363);
            this.wcfDataGroup.TabIndex = 4;
            // 
            // wcfDataPata
            // 
            this.wcfDataPata.Location = new System.Drawing.Point(3, 6);
            this.wcfDataPata.Name = "wcfDataPata";
            this.wcfDataPata.Size = new System.Drawing.Size(567, 448);
            this.wcfDataPata.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvWcfAxis);
            this.tabPage3.Controls.Add(this.lvWcfDO);
            this.tabPage3.Controls.Add(this.lvWcfDI);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1412, 868);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "监控";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvWcfAxis
            // 
            this.lvWcfAxis.Location = new System.Drawing.Point(3, 351);
            this.lvWcfAxis.Name = "lvWcfAxis";
            this.lvWcfAxis.Size = new System.Drawing.Size(806, 460);
            this.lvWcfAxis.TabIndex = 6;
            // 
            // lvWcfDO
            // 
            this.lvWcfDO.Location = new System.Drawing.Point(409, 15);
            this.lvWcfDO.Name = "lvWcfDO";
            this.lvWcfDO.Size = new System.Drawing.Size(400, 330);
            this.lvWcfDO.TabIndex = 5;
            // 
            // lvWcfDI
            // 
            this.lvWcfDI.Location = new System.Drawing.Point(3, 15);
            this.lvWcfDI.Name = "lvWcfDI";
            this.lvWcfDI.Size = new System.Drawing.Size(400, 330);
            this.lvWcfDI.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.wcfCardEdit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1412, 868);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "卡数据管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // wcfCardEdit
            // 
            this.wcfCardEdit.Location = new System.Drawing.Point(3, 6);
            this.wcfCardEdit.Name = "wcfCardEdit";
            this.wcfCardEdit.Size = new System.Drawing.Size(1410, 777);
            this.wcfCardEdit.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WCF.Properties.Resources.Synopsis;
            this.pictureBox1.Location = new System.Drawing.Point(567, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(849, 629);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 915);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "WCF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WCFCard wcfCardEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WCFData wcfDataPata;
        private WCFControl.WCFDataGroup wcfDataGroup;
        private System.Windows.Forms.TabPage tabPage3;
        private WCFControl.WCFAxis lvWcfAxis;
        private WCFControl.WCFDO lvWcfDO;
        private Resources.WCFDI lvWcfDI;
        private WCFDataType wcfDataType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

