namespace WCF.WCFControl
{
    partial class WCFMatrix
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
            this.panTrayShow = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTrayColumn = new System.Windows.Forms.TextBox();
            this.txtTrayRow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.tTipLabel = new System.Windows.Forms.ToolTip(this.components);
            this.cmsLabel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmLabelDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLabelAllDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLabelSetPos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLabelGenMatrix = new System.Windows.Forms.ToolStripMenuItem();
            this.panSettingsPos = new System.Windows.Forms.Panel();
            this.btnSettingsPos = new System.Windows.Forms.Button();
            this.txtSettingsPosY = new System.Windows.Forms.TextBox();
            this.txtSettingsPosX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tsmLabelSettingsPos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.cmsLabel.SuspendLayout();
            this.panSettingsPos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTrayShow
            // 
            this.panTrayShow.AutoScroll = true;
            this.panTrayShow.Location = new System.Drawing.Point(3, 28);
            this.panTrayShow.Name = "panTrayShow";
            this.panTrayShow.Size = new System.Drawing.Size(555, 466);
            this.panTrayShow.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(202, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(62, 21);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "设置矩阵";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTrayColumn
            // 
            this.txtTrayColumn.Location = new System.Drawing.Point(144, 3);
            this.txtTrayColumn.Name = "txtTrayColumn";
            this.txtTrayColumn.Size = new System.Drawing.Size(52, 21);
            this.txtTrayColumn.TabIndex = 10;
            this.txtTrayColumn.Text = "6";
            // 
            // txtTrayRow
            // 
            this.txtTrayRow.Location = new System.Drawing.Point(38, 3);
            this.txtTrayRow.Name = "txtTrayRow";
            this.txtTrayRow.Size = new System.Drawing.Size(52, 21);
            this.txtTrayRow.TabIndex = 9;
            this.txtTrayRow.Text = "6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "列数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "行数：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(284, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 21);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(328, 0);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(38, 21);
            this.btnRead.TabIndex = 14;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // cmsLabel
            // 
            this.cmsLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLabelDelete,
            this.tsmLabelAllDelete,
            this.tsmLabelSettingsPos,
            this.tsmLabelSetPos,
            this.tsmLabelGenMatrix});
            this.cmsLabel.Name = "cmsLabel";
            this.cmsLabel.Size = new System.Drawing.Size(161, 114);
            this.cmsLabel.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLabel_Opening);
            // 
            // tsmLabelDelete
            // 
            this.tsmLabelDelete.Name = "tsmLabelDelete";
            this.tsmLabelDelete.Size = new System.Drawing.Size(160, 22);
            this.tsmLabelDelete.Text = "删除/取消删除";
            this.tsmLabelDelete.Click += new System.EventHandler(this.tsmLabelDelete_Click);
            // 
            // tsmLabelAllDelete
            // 
            this.tsmLabelAllDelete.Name = "tsmLabelAllDelete";
            this.tsmLabelAllDelete.Size = new System.Drawing.Size(160, 22);
            this.tsmLabelAllDelete.Text = "删除选中的位置";
            this.tsmLabelAllDelete.Click += new System.EventHandler(this.tsmLabelAllDelete_Click);
            // 
            // tsmLabelSetPos
            // 
            this.tsmLabelSetPos.Name = "tsmLabelSetPos";
            this.tsmLabelSetPos.Size = new System.Drawing.Size(160, 22);
            this.tsmLabelSetPos.Text = "设置为当前坐标";
            this.tsmLabelSetPos.Click += new System.EventHandler(this.tsmLabelSetPos_Click);
            // 
            // tsmLabelGenMatrix
            // 
            this.tsmLabelGenMatrix.Name = "tsmLabelGenMatrix";
            this.tsmLabelGenMatrix.Size = new System.Drawing.Size(160, 22);
            this.tsmLabelGenMatrix.Text = "生成矩阵";
            this.tsmLabelGenMatrix.Click += new System.EventHandler(this.tsmLabelGenMatrix_Click);
            // 
            // panSettingsPos
            // 
            this.panSettingsPos.Controls.Add(this.btnSettingsCancel);
            this.panSettingsPos.Controls.Add(this.label5);
            this.panSettingsPos.Controls.Add(this.btnSettingsPos);
            this.panSettingsPos.Controls.Add(this.txtSettingsPosY);
            this.panSettingsPos.Controls.Add(this.txtSettingsPosX);
            this.panSettingsPos.Controls.Add(this.label1);
            this.panSettingsPos.Controls.Add(this.label4);
            this.panSettingsPos.Location = new System.Drawing.Point(178, 114);
            this.panSettingsPos.Name = "panSettingsPos";
            this.panSettingsPos.Size = new System.Drawing.Size(165, 105);
            this.panSettingsPos.TabIndex = 0;
            this.panSettingsPos.Visible = false;
            // 
            // btnSettingsPos
            // 
            this.btnSettingsPos.Location = new System.Drawing.Point(86, 39);
            this.btnSettingsPos.Name = "btnSettingsPos";
            this.btnSettingsPos.Size = new System.Drawing.Size(40, 48);
            this.btnSettingsPos.TabIndex = 16;
            this.btnSettingsPos.Text = "设置点位";
            this.btnSettingsPos.UseVisualStyleBackColor = true;
            this.btnSettingsPos.Click += new System.EventHandler(this.btnSettingsPos_Click);
            // 
            // txtSettingsPosY
            // 
            this.txtSettingsPosY.Location = new System.Drawing.Point(30, 66);
            this.txtSettingsPosY.Name = "txtSettingsPosY";
            this.txtSettingsPosY.Size = new System.Drawing.Size(52, 21);
            this.txtSettingsPosY.TabIndex = 15;
            // 
            // txtSettingsPosX
            // 
            this.txtSettingsPosX.Location = new System.Drawing.Point(30, 39);
            this.txtSettingsPosX.Name = "txtSettingsPosX";
            this.txtSettingsPosX.Size = new System.Drawing.Size(52, 21);
            this.txtSettingsPosX.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Y：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "X：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "设置点位坐标";
            // 
            // tsmLabelSettingsPos
            // 
            this.tsmLabelSettingsPos.Name = "tsmLabelSettingsPos";
            this.tsmLabelSettingsPos.Size = new System.Drawing.Size(160, 22);
            this.tsmLabelSettingsPos.Text = "输入设置点位";
            this.tsmLabelSettingsPos.Click += new System.EventHandler(this.tsmLabelSettingsPos_Click);
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Location = new System.Drawing.Point(129, 39);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(24, 48);
            this.btnSettingsCancel.TabIndex = 18;
            this.btnSettingsCancel.Text = "取消";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // WCFMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panSettingsPos);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panTrayShow);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTrayColumn);
            this.Controls.Add(this.txtTrayRow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "WCFMatrix";
            this.Size = new System.Drawing.Size(561, 497);
            this.Load += new System.EventHandler(this.WCFMatrix_Load);
            this.SizeChanged += new System.EventHandler(this.WCFMatrix_SizeChanged);
            this.cmsLabel.ResumeLayout(false);
            this.panSettingsPos.ResumeLayout(false);
            this.panSettingsPos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTrayShow;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtTrayColumn;
        private System.Windows.Forms.TextBox txtTrayRow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ToolTip tTipLabel;
        private System.Windows.Forms.ContextMenuStrip cmsLabel;
        private System.Windows.Forms.ToolStripMenuItem tsmLabelDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmLabelAllDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmLabelSetPos;
        private System.Windows.Forms.ToolStripMenuItem tsmLabelGenMatrix;
        private System.Windows.Forms.Panel panSettingsPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSettingsPos;
        private System.Windows.Forms.TextBox txtSettingsPosY;
        private System.Windows.Forms.TextBox txtSettingsPosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem tsmLabelSettingsPos;
        private System.Windows.Forms.Button btnSettingsCancel;
    }
}
