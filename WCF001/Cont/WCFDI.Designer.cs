namespace WCF
{
    partial class WCFDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WCFDI));
            this.ilImageList = new System.Windows.Forms.ImageList(this.components);
            this.tSignalRefresh = new System.Windows.Forms.Timer(this.components);
            this.lvDIView = new WCF.WCFListView();
            this.SuspendLayout();
            // 
            // ilImageList
            // 
            this.ilImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImageList.ImageStream")));
            this.ilImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ilImageList.Images.SetKeyName(0, "OFF.png");
            this.ilImageList.Images.SetKeyName(1, "ON.png");
            // 
            // tSignalRefresh
            // 
            this.tSignalRefresh.Interval = 300;
            this.tSignalRefresh.Tick += new System.EventHandler(this.tSignalRefresh_Tick);
            // 
            // lvDIView
            // 
            this.lvDIView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvDIView.HideSelection = false;
            this.lvDIView.Location = new System.Drawing.Point(3, 0);
            this.lvDIView.Name = "lvDIView";
            this.lvDIView.Size = new System.Drawing.Size(396, 462);
            this.lvDIView.TabIndex = 0;
            this.lvDIView.UseCompatibleStateImageBehavior = false;
            this.lvDIView.View = System.Windows.Forms.View.SmallIcon;
            // 
            // WCFDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvDIView);
            this.Name = "WCFDI";
            this.Size = new System.Drawing.Size(402, 465);
            this.Load += new System.EventHandler(this.WcfDI_Load);
            this.SizeChanged += new System.EventHandler(this.WcfDI_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private WCFListView lvDIView;
        private System.Windows.Forms.ImageList ilImageList;
        private System.Windows.Forms.Timer tSignalRefresh;
    }
}
