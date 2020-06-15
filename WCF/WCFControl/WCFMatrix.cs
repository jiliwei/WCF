using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WCF.WCFControl
{
    /// 类 	  名：WCFMatrix
	/// 类 描 述：矩阵的创建自定义控件
	/// 创 建 者：韦季李
	/// 创建时间：2019/8/2
	/// 源码网证：https://github.com/jiliwei/WCF
    public partial class WCFMatrix : UserControl
    {
        public WCFMatrix()
        {
            InitializeComponent();
        }

        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFMatrix_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);

            panTrayShow.MouseDown += new MouseEventHandler(MouseDown);
            panTrayShow.MouseUp += new MouseEventHandler(MouseUp);
            panTrayShow.MouseMove += new MouseEventHandler(MouseMove);
        }

        private void WCFMatrix_SizeChanged(object sender, EventArgs e)
        {
            panTrayShow.Controls.Clear();
            mAutoUI.controlAutoSize(this);
            
        }
        private WDataToolClass mWDataToolClass;
        private string sNameX;
        private string sNameY;
        public void ConInit(WDataToolClass mWDataToolClass, string sNameX, string sNameY)
        {
            this.mWDataToolClass = mWDataToolClass;
            this.sNameX = sNameX;
            this.sNameY = sNameY;

        }
        public Dictionary<int, string> dicBuffer = new Dictionary<int, string>();//当前矩阵数据字典
        private void btnOk_Click(object sender, EventArgs e)
        {
            int mTrayRow = int.Parse(txtTrayRow.Text.ToString());
            int mTrayColumn = int.Parse(txtTrayColumn.Text.ToString());
            int mTotal = mTrayRow * mTrayColumn;
            int mPosRow = 0;
            int mPosColumn = 0;
            int mNum = 0;
            int mSizeRow = panTrayShow.Size.Width / mTrayColumn;
            int mSizeColmn = panTrayShow.Size.Height / mTrayRow; 

            panTrayShow.Controls.Clear();
            Label mLabel;
            dicBuffer.Clear();//清除缓存数据
            for (int i = 0; i < mTotal; i++)
            {
                int mNowRow = i % mTrayColumn;
                mPosRow = mNowRow * (mSizeRow - 3) + 10;
                int mNowColmn = i / mTrayColumn;
                mPosColumn = mNowColmn * (mSizeColmn - 3) + 10;

                mLabel = new Label();
                mNum++;
                mLabel.Text = mNum.ToString();
                mLabel.Location = new Point(mPosRow, mPosColumn);
                mLabel.AutoSize = false;
                mLabel.TextAlign = ContentAlignment.MiddleCenter;
                mLabel.Size = new Size(mSizeRow - 8, mSizeColmn - 8);
                mLabel.BackColor = Color.LightSlateGray;
                mLabel.ContextMenuStrip = cmsLabel;
                mLabel.Click += new EventHandler(Label_Click);
                mLabel.MouseHover += new EventHandler(Label_MouseHover);

                panTrayShow.Controls.Add(mLabel);

                dicBuffer[i] = "0;0.0;0.0";//状态；X坐标；Y坐标
            }
        }
        private void Label_Click(object sender, EventArgs e)
        {
            Label mLabel = (Label)sender;
            if (mLabel.BackColor == Color.Yellow || mLabel.BackColor == Color.Lime)
            {
                if (MessageBox.Show("当前位置坐标已经设置，是否清除并选中", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string[] mValue = dicBuffer[int.Parse(mLabel.Text.ToString()) - 1].Split(';');
                    dicBuffer[int.Parse(mLabel.Text.ToString()) - 1] = "0;0.0;0.0";
                }
                else
                    return;
            }
            if (mLabel.BackColor == Color.Aqua)
                mLabel.BackColor = Color.LightSlateGray;
            else
                mLabel.BackColor = Color.Aqua;
                
        }
        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label mLabel = (Label)sender;
            string[] mValue = dicBuffer[int.Parse(mLabel.Text.ToString()) - 1].Split(';');
            string mStatus = "";
            if (mValue.Length == 3)
            {
                if (mValue[0] == "0")
                    mStatus = "正常";
                else
                    mStatus = "已删除";
                if (mValue[1] != "0.0")
                    mStatus = "状态：" + mStatus + Environment.NewLine + "X:" + mValue[1] + Environment.NewLine + "Y:" + mValue[2];
                else
                    mStatus = "状态：" + mStatus;

                tTipLabel.SetToolTip(mLabel, mStatus);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("读取将会更新矩阵数据，为原来的数据");
        }
        /// <summary>
        /// 获取当前的Label
        /// </summary>
        Label mLabelIng = null;
        private void cmsLabel_Opening(object sender, CancelEventArgs e)
        {
            mLabelIng = (Label)(((ContextMenuStrip)sender).SourceControl);
        }
        /// <summary>
        /// 删除/反删除
        /// </summary>
        private void tsmLabelDelete_Click(object sender, EventArgs e)
        {
            string[] mValue = dicBuffer[int.Parse(mLabelIng.Text.ToString())-1].Split(';');
            if (mLabelIng.BackColor == Color.Red)
            {
                mLabelIng.BackColor = Color.LightSlateGray;
                if(mValue.Length == 3)
                    dicBuffer[int.Parse(mLabelIng.Text.ToString())-1] = "0;"+ mValue[1]+";"+ mValue[2];
            }
            else
            {
                mLabelIng.BackColor = Color.Red;
                if (mValue.Length == 3)
                    dicBuffer[int.Parse(mLabelIng.Text.ToString())-1] = "1;" + mValue[1] + ";" + mValue[2];
            }
        }
        /// <summary>
        /// 删除选中的位置
        /// </summary>
        private void tsmLabelAllDelete_Click(object sender, EventArgs e)
        {
            string[] mValue ;
            int lDelete = 0;
            foreach (Label item in panTrayShow.Controls)
            {
                if (item.BackColor == Color.Aqua)
                {
                    lDelete = lDelete + 1;
                    item.BackColor = Color.Red;
                    mValue = dicBuffer[int.Parse(item.Text.ToString())-1].Split(';');
                    if (mValue.Length == 3)
                        dicBuffer[int.Parse(item.Text.ToString()) -1] = "1;" + mValue[1] + ";" + mValue[2];
                }
            }
            if (lDelete == 0)
                MessageBox.Show("无选中项");
            else
                MessageBox.Show("已经标识删除"+ lDelete.ToString()+"项");
        }
        /// <summary>
        /// 设置为当前坐标
        /// </summary>
        private void tsmLabelSetPos_Click(object sender, EventArgs e)
        {
            string[] mValue = dicBuffer[int.Parse(mLabelIng.Text.ToString()) - 1].Split(';');
            if (mValue.Length == 3)
            {
                dicBuffer[int.Parse(mLabelIng.Text.ToString()) - 1] = "0;0.00;0.00";
                dicBuffer[int.Parse(mLabelIng.Text.ToString()) - 1] = "0;300.00;0.00";
                dicBuffer[int.Parse(mLabelIng.Text.ToString()) - 1] = "0;0.00;300.00";
                mLabelIng.BackColor = Color.Yellow;
            }
        }
        /// <summary>
        /// 生成标准矩阵
        /// </summary>
        private void tsmLabelGenMatrix_Click(object sender, EventArgs e)
        {
            //1.获取矩阵左上角第一个点
            int lFirst = 0;//第一个点的位置
            foreach (Label item in panTrayShow.Controls)
                if (item.BackColor == Color.Aqua|| item.BackColor == Color.Yellow)
                {
                    lFirst = int.Parse(item.Text.ToString()) - 1;
                    break;
                }
            //2.获取第一行矩阵列数
            int mTrayRow = int.Parse(txtTrayRow.Text.ToString());
            int mTrayColumn = int.Parse(txtTrayColumn.Text.ToString());
            int lIngNum = lFirst;//遍历的位置（第一个）
            ArrayList lIngColumn = new ArrayList();//选中的第一行的集合；个数就是列数
            while (true)
            {
                if (lIngNum <= (mTrayColumn - 1)+((lFirst/ mTrayColumn)* mTrayColumn) && (
                    panTrayShow.Controls[lIngNum].BackColor == Color.Aqua|| 
                    panTrayShow.Controls[lIngNum].BackColor == Color.Yellow))
                    lIngColumn.Add(lIngNum);
                if (lIngNum > (mTrayColumn - 1) + ((lFirst / mTrayColumn) * mTrayColumn))//只遍历第一行
                    break;
                else
                    lIngNum = lIngNum + 1;
            }
            //3.获取第一列矩阵的行数
            int lExceptFor = lFirst % mTrayColumn;//除于
            int lExactDivision = lFirst / mTrayColumn;//整除
            lIngNum = lFirst;//遍历的位置（第一个）
            int lMax = (mTrayRow - 1) * mTrayColumn + lExceptFor;//当前列最后一个
            ArrayList lIngRow = new ArrayList();//选中的第一行的集合；个数就是列数
            while (true)
            {
                if (lIngNum <= lMax && (
                    panTrayShow.Controls[lIngNum].BackColor == Color.Aqua ||
                    panTrayShow.Controls[lIngNum].BackColor == Color.Yellow))
                    lIngRow.Add(lIngNum);
                if (lIngNum > lMax)
                    break;
                else
                {
                    lExactDivision = lExactDivision + 1;
                    lIngNum = lExactDivision * mTrayColumn + lExceptFor;
                }
            }
            //4.获取3个点数据
            Double dUpLeftRow = 0.0;
            Double dUpLeftColumn = 0.0;
            Double dUpRightRow = 0.0;
            Double dUpRightColumn = 0.0;
            Double dLoLeftRow = 0.0;
            Double dLoLeftColumn = 0.0;
            string[] mValue = dicBuffer[int.Parse(panTrayShow.Controls[(int)lIngColumn[0]].Text.ToString()) - 1].Split(';');
            if (mValue.Length == 3)
            {
                dUpLeftRow = double.Parse(mValue[1]);
                dUpLeftColumn = double.Parse(mValue[2]);
            }
            else
            {
                MessageBox.Show("矩阵右上角点位设置异常");
                return;
            }
            mValue = dicBuffer[int.Parse(panTrayShow.Controls[(int)lIngColumn[lIngColumn.Count - 1]].Text.ToString()) - 1].Split(';');
            if (mValue.Length == 3)
            {
                dUpRightRow = double.Parse(mValue[1]);
                dUpRightColumn = double.Parse(mValue[2]);
            }
            else
            {
                MessageBox.Show("矩阵左上角点位设置异常");
                return;
            }
            mValue = dicBuffer[int.Parse(panTrayShow.Controls[(int)lIngRow[lIngRow.Count - 1]].Text.ToString()) - 1].Split(';');
            if (mValue.Length == 3)
            {
                dLoLeftRow = double.Parse(mValue[1]);
                dLoLeftColumn = double.Parse(mValue[2]);
            }
            else
            {
                MessageBox.Show("矩阵右下角点位设置异常");
                return;
            }
            //5.生成矩阵并赋值
            int lTotalNum = lIngRow.Count * lIngColumn.Count;
            Double dIngRow = 0.0;
            Double dIngColumn = 0.0;
            int lNowNum = 0;
            for (int i = 0; i < lTotalNum; i++)
            {
                if(dUpRightRow - dUpLeftRow > dLoLeftRow - dUpLeftRow)
                {
                    dIngRow = dUpLeftRow + ((dUpRightRow - dUpLeftRow) / (lIngRow.Count-1)) * (i / lIngColumn.Count);
                    dIngColumn = dUpLeftColumn + ((dLoLeftColumn - dUpLeftColumn) / (lIngColumn.Count-1))* (i % lIngColumn.Count);
                }
                else
                {
                    dIngRow = dUpLeftRow + ((dLoLeftRow - dUpLeftRow) / (lIngRow.Count - 1)) * (i / lIngColumn.Count);
                    dIngColumn = dUpLeftColumn + ((dUpRightColumn - dUpLeftColumn) / (lIngColumn.Count - 1)) * (i % lIngColumn.Count);
                }


                lNowNum = (int)lIngColumn[i % lIngColumn.Count] + (int)lIngRow[i / lIngColumn.Count] - (int)lIngColumn[0];// + (i/ lIngRow.Count) * lIngColumn.Count;
                dicBuffer[lNowNum] = "0;"+dIngRow.ToString("0.0000")+";"+dIngColumn.ToString("0.0000");

                panTrayShow.Controls[lNowNum ].BackColor = Color.Lime;
            }
        }
        private void tsmLabelSettingsPos_Click(object sender, EventArgs e)
        {
            panSettingsPos.Visible = true;
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e)
        {
            panSettingsPos.Visible = false;
        }
        private void btnSettingsPos_Click(object sender, EventArgs e)
        {
            string[] mValue = dicBuffer[int.Parse(mLabelIng.Text.ToString()) - 1].Split(';');
            if (mValue.Length == 3)
            {
                dicBuffer[int.Parse(mLabelIng.Text.ToString()) - 1] = "0;"+ txtSettingsPosX.Text.ToString()+ ";"+ txtSettingsPosY.Text.ToString();
                mLabelIng.BackColor = Color.Yellow;
                txtSettingsPosX.Text = "";
                txtSettingsPosY.Text = "";
                panSettingsPos.Visible = false;
            }
        }




        
        //////////////////////////////让Panel可以框选
        #region mouseMove
        //定义两个变量 
        bool MouseIsDown = false;
        Rectangle MouseRect = Rectangle.Empty; //矩形（为鼠标画出矩形选区）
        //定义三个方法
        private void ResizeToRectangle(object sender, Point p)
        {
            DrawRectangle(sender);
            MouseRect.Width = p.X - MouseRect.Left;
            MouseRect.Height = p.Y - MouseRect.Top;
            DrawRectangle(sender);
        }
        private void DrawRectangle(object sender)
        {
            Rectangle rect = ((Panel)sender).RectangleToScreen(MouseRect);
            ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);
        }

        private void DrawStart(object sender, Point StartPoint)
        {
            ((Panel)sender).Capture = true;
            Cursor.Clip = ((Panel)sender).RectangleToScreen(((Panel)sender).Bounds);
            MouseRect = new Rectangle(StartPoint.X, StartPoint.Y, 0, 0);
        }

        private new void MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            DrawStart(sender, e.Location);
        }

        private new void MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            Cursor.Clip = Rectangle.Empty;
            MouseIsDown = false;
            DrawRectangle(sender);
            MouseRect = Rectangle.Empty;
        }

        private new void MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
                ResizeToRectangle(sender, e.Location);


            foreach (Control mLabel in ((Panel)sender).Controls)
            {
                if (MouseRect.IntersectsWith(mLabel.Bounds)) //相交( MouseRect.Contains  完全包含)
                {
                    mLabel.BackColor = Color.Aqua;
                }

            }

        }
        #endregion mouseMove
    }
}
