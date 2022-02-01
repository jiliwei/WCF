
namespace WCF
{
    partial class WCFAxisShortcut
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
            this.tlpAxisShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.btnNegative = new System.Windows.Forms.Button();
            this.txtActual = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.Label();
            this.txtAxisName = new System.Windows.Forms.Label();
            this.btnPositive = new System.Windows.Forms.Button();
            this.timerRefersh = new System.Windows.Forms.Timer(this.components);
            this.tlpAxisShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAxisShortcut
            // 
            this.tlpAxisShortcut.ColumnCount = 5;
            this.tlpAxisShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAxisShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpAxisShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpAxisShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAxisShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAxisShortcut.Controls.Add(this.btnNegative, 4, 0);
            this.tlpAxisShortcut.Controls.Add(this.txtActual, 2, 0);
            this.tlpAxisShortcut.Controls.Add(this.txtState, 1, 0);
            this.tlpAxisShortcut.Controls.Add(this.txtAxisName, 0, 0);
            this.tlpAxisShortcut.Controls.Add(this.btnPositive, 3, 0);
            this.tlpAxisShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAxisShortcut.Location = new System.Drawing.Point(0, 0);
            this.tlpAxisShortcut.Name = "tlpAxisShortcut";
            this.tlpAxisShortcut.RowCount = 1;
            this.tlpAxisShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAxisShortcut.Size = new System.Drawing.Size(407, 35);
            this.tlpAxisShortcut.TabIndex = 0;
            // 
            // btnNegative
            // 
            this.btnNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNegative.Location = new System.Drawing.Point(375, 3);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(29, 29);
            this.btnNegative.TabIndex = 4;
            this.btnNegative.Text = "-";
            this.btnNegative.UseVisualStyleBackColor = true;
            this.btnNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNegative_MouseDown);
            this.btnNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnNegative_MouseUp);
            // 
            // txtActual
            // 
            this.txtActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActual.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtActual.Location = new System.Drawing.Point(260, 10);
            this.txtActual.Name = "txtActual";
            this.txtActual.Size = new System.Drawing.Size(74, 14);
            this.txtActual.TabIndex = 2;
            this.txtActual.Text = "99999.999";
            this.txtActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtState.Location = new System.Drawing.Point(200, 10);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(54, 14);
            this.txtState.TabIndex = 1;
            this.txtState.Text = "状态";
            this.txtState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAxisName
            // 
            this.txtAxisName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAxisName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAxisName.Location = new System.Drawing.Point(3, 8);
            this.txtAxisName.Name = "txtAxisName";
            this.txtAxisName.Size = new System.Drawing.Size(191, 18);
            this.txtAxisName.TabIndex = 0;
            this.txtAxisName.Text = "轴名称";
            this.txtAxisName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPositive
            // 
            this.btnPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPositive.Location = new System.Drawing.Point(340, 3);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(29, 29);
            this.btnPositive.TabIndex = 3;
            this.btnPositive.Text = "+";
            this.btnPositive.UseVisualStyleBackColor = true;
            this.btnPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseDown);
            this.btnPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPositive_MouseUp);
            // 
            // timerRefersh
            // 
            this.timerRefersh.Enabled = true;
            this.timerRefersh.Interval = 666;
            this.timerRefersh.Tick += new System.EventHandler(this.timerRefersh_Tick);
            // 
            // WCFAxisShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpAxisShortcut);
            this.Name = "WCFAxisShortcut";
            this.Size = new System.Drawing.Size(407, 35);
            this.tlpAxisShortcut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAxisShortcut;
        private System.Windows.Forms.Button btnNegative;
        private System.Windows.Forms.Label txtActual;
        private System.Windows.Forms.Label txtState;
        private System.Windows.Forms.Label txtAxisName;
        private System.Windows.Forms.Button btnPositive;
        private System.Windows.Forms.Timer timerRefersh;
    }
}
