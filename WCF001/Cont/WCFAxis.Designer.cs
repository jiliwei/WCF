namespace WCF
{
    partial class WCFAxis
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
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtAxisNow = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lvAxisView = new WCF.WCFListView();
            this.button4 = new System.Windows.Forms.Button();
            this.tSignalRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(302, 427);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "使能";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(364, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(405, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(446, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "清除状态";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtAxisNow
            // 
            this.txtAxisNow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAxisNow.Location = new System.Drawing.Point(3, 427);
            this.txtAxisNow.Name = "txtAxisNow";
            this.txtAxisNow.Size = new System.Drawing.Size(221, 23);
            this.txtAxisNow.TabIndex = 5;
            this.txtAxisNow.Text = "未选中";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "10",
            "30",
            "60",
            "100"});
            this.comboBox1.Location = new System.Drawing.Point(230, 427);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(66, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "10";
            // 
            // lvAxisView
            // 
            this.lvAxisView.HideSelection = false;
            this.lvAxisView.HoverSelection = true;
            this.lvAxisView.Location = new System.Drawing.Point(2, 1);
            this.lvAxisView.MultiSelect = false;
            this.lvAxisView.Name = "lvAxisView";
            this.lvAxisView.Size = new System.Drawing.Size(622, 412);
            this.lvAxisView.TabIndex = 0;
            this.lvAxisView.UseCompatibleStateImageBehavior = false;
            this.lvAxisView.View = System.Windows.Forms.View.Details;
            this.lvAxisView.SelectedIndexChanged += new System.EventHandler(this.lvAxisView_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(561, 419);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 40);
            this.button4.TabIndex = 7;
            this.button4.Text = "复位";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tSignalRefresh
            // 
            this.tSignalRefresh.Interval = 500;
            this.tSignalRefresh.Tick += new System.EventHandler(this.tSignalRefresh_Tick);
            // 
            // WCFAxis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtAxisNow);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lvAxisView);
            this.Name = "WCFAxis";
            this.Size = new System.Drawing.Size(627, 460);
            this.Load += new System.EventHandler(this.WCFAxis_Load);
            this.SizeChanged += new System.EventHandler(this.WCFAxis_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WCFListView lvAxisView;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label txtAxisNow;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer tSignalRefresh;
    }
}
