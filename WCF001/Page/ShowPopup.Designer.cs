
namespace WCF
{
    partial class ShowPopup
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtShowPopupContent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtShowPopupTitle = new System.Windows.Forms.Label();
            this.btnShowMoveWin = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowPopupCancel = new System.Windows.Forms.Button();
            this.btnShowPopupRetry = new System.Windows.Forms.Button();
            this.btnShowPopupOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtShowPopupContent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 394);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtShowPopupContent
            // 
            this.txtShowPopupContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowPopupContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtShowPopupContent.Location = new System.Drawing.Point(3, 80);
            this.txtShowPopupContent.Name = "txtShowPopupContent";
            this.txtShowPopupContent.Size = new System.Drawing.Size(628, 264);
            this.txtShowPopupContent.TabIndex = 2;
            this.txtShowPopupContent.Text = "内容";
            this.txtShowPopupContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 74);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtShowPopupTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnShowMoveWin);
            this.splitContainer1.Size = new System.Drawing.Size(628, 74);
            this.splitContainer1.SplitterDistance = 587;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtShowPopupTitle
            // 
            this.txtShowPopupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowPopupTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtShowPopupTitle.Location = new System.Drawing.Point(0, 0);
            this.txtShowPopupTitle.Name = "txtShowPopupTitle";
            this.txtShowPopupTitle.Size = new System.Drawing.Size(587, 74);
            this.txtShowPopupTitle.TabIndex = 0;
            this.txtShowPopupTitle.Text = "标题";
            this.txtShowPopupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowMoveWin
            // 
            this.btnShowMoveWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowMoveWin.Image = global::WCF.Properties.Resources.moveWin;
            this.btnShowMoveWin.Location = new System.Drawing.Point(0, 0);
            this.btnShowMoveWin.Name = "btnShowMoveWin";
            this.btnShowMoveWin.Size = new System.Drawing.Size(36, 36);
            this.btnShowMoveWin.TabIndex = 2;
            this.btnShowMoveWin.UseVisualStyleBackColor = true;
            this.btnShowMoveWin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnShowMoveWin_MouseDown);
            this.btnShowMoveWin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnShowMoveWin_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnShowPopupCancel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnShowPopupRetry, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnShowPopupOK, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 347);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(628, 44);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnShowPopupCancel
            // 
            this.btnShowPopupCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShowPopupCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowPopupCancel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowPopupCancel.Location = new System.Drawing.Point(421, 3);
            this.btnShowPopupCancel.Name = "btnShowPopupCancel";
            this.btnShowPopupCancel.Size = new System.Drawing.Size(204, 38);
            this.btnShowPopupCancel.TabIndex = 3;
            this.btnShowPopupCancel.Text = "取  消";
            this.btnShowPopupCancel.UseVisualStyleBackColor = true;
            this.btnShowPopupCancel.Click += new System.EventHandler(this.btnShowPopupCancel_Click);
            // 
            // btnShowPopupRetry
            // 
            this.btnShowPopupRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnShowPopupRetry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowPopupRetry.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowPopupRetry.Location = new System.Drawing.Point(212, 3);
            this.btnShowPopupRetry.Name = "btnShowPopupRetry";
            this.btnShowPopupRetry.Size = new System.Drawing.Size(203, 38);
            this.btnShowPopupRetry.TabIndex = 2;
            this.btnShowPopupRetry.Text = "重  试";
            this.btnShowPopupRetry.UseVisualStyleBackColor = true;
            this.btnShowPopupRetry.Click += new System.EventHandler(this.btnShowPopupRetry_Click);
            // 
            // btnShowPopupOK
            // 
            this.btnShowPopupOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnShowPopupOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowPopupOK.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowPopupOK.Location = new System.Drawing.Point(3, 3);
            this.btnShowPopupOK.Name = "btnShowPopupOK";
            this.btnShowPopupOK.Size = new System.Drawing.Size(203, 38);
            this.btnShowPopupOK.TabIndex = 1;
            this.btnShowPopupOK.Text = "确  定";
            this.btnShowPopupOK.UseVisualStyleBackColor = true;
            this.btnShowPopupOK.Click += new System.EventHandler(this.btnShowPopupOK_Click);
            // 
            // ShowPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(634, 394);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShowPopup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowPopup_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtShowPopupContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtShowPopupTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnShowPopupCancel;
        private System.Windows.Forms.Button btnShowPopupRetry;
        private System.Windows.Forms.Button btnShowPopupOK;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnShowMoveWin;
    }
}