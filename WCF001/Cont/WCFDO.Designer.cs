namespace WCF
{
    partial class WCFDO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WCFDO));
            this.lvDOView = new WCF.WCFListView();
            this.ilImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvDOView
            // 
            this.lvDOView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvDOView.HideSelection = false;
            this.lvDOView.Location = new System.Drawing.Point(3, 3);
            this.lvDOView.MultiSelect = false;
            this.lvDOView.Name = "lvDOView";
            this.lvDOView.Size = new System.Drawing.Size(377, 435);
            this.lvDOView.SmallImageList = this.ilImageList;
            this.lvDOView.TabIndex = 0;
            this.lvDOView.UseCompatibleStateImageBehavior = false;
            this.lvDOView.View = System.Windows.Forms.View.SmallIcon;
            this.lvDOView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvDOView_MouseUp);
            // 
            // ilImageList
            // 
            this.ilImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImageList.ImageStream")));
            this.ilImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ilImageList.Images.SetKeyName(0, "OFF.png");
            this.ilImageList.Images.SetKeyName(1, "ON.png");
            // 
            // WCFDO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvDOView);
            this.Name = "WCFDO";
            this.Size = new System.Drawing.Size(383, 438);
            this.Load += new System.EventHandler(this.WCFDO_Load);
            this.SizeChanged += new System.EventHandler(this.WCFDO_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private WCFListView lvDOView;
        private System.Windows.Forms.ImageList ilImageList;
    }
}
