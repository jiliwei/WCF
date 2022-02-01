using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace WCF
{
    /// 类 	  名：WCFCard
	/// 类 描 述：运动控制卡数据编辑自定义控件
	/// WCF·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFCard : UserControl
    {
        public WCFCard()
        {
            InitializeComponent();
        }
        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFCard_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
        }

        private void WCFCard_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }
        public void ConInit()
        {
            int rtn = 0;
            rtn = WDCard.SelectShowAxis(ref dgvAxis);
            if (rtn != 0)
            {
                WDLog.InsertLog("运动板卡", 0, "板卡异常", "板卡数据加载时，无轴的数据");
            }
            rtn = WDCard.SelectShowDI(ref dgvDI);
            if (rtn != 0)
            {
                WDLog.InsertLog("运动板卡", 0, "板卡异常", "板卡数据加载时，无输入信号的数据");
            }
            rtn = WDCard.SelectShowDO(ref dgvDO);
            if (rtn != 0)
            {
                WDLog.InsertLog("运动板卡", 0, "板卡异常", "板卡数据加载时，无输出信号的数据");
            }
        }

        private void Cms_AxisAdd_Click(object sender, EventArgs e)
        {
            showPanelUI("轴添加");
        }
        private void btnAxisAddCancel_Click(object sender, EventArgs e)
        {
            closePanelUI();
        }
        private void btnAxisAddOk_Click(object sender, EventArgs e)
        {
            String GroupName = "";
            String Name = "";
            Int32 CardNum = 0;
            Int32 AxisNum = 0;
            Int32 Pulse = 0;
            Int32 Acc = 0;
            Int32 Speed = 0;
            Int32 ResetNum = 0;
            try
            {
                if (dgvAxisAdd.Rows.Count > 0)
                {
                    //检查数据
                    for (int i = 0; i < dgvAxisAdd.Rows.Count - 1; i++)
                    {
                        //检查数据是否为空
                        if (dgvAxisAdd.Rows[i].Cells[0].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的组名称为空，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[1].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称为空，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[2].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号未选择，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[3].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴号未选择，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[4].Value != null && !int.TryParse(dgvAxisAdd.Rows[i].Cells[4].Value.ToString(), out Speed))
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的脉冲当量不是整数，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[5].Value != null &&  !int.TryParse( dgvAxisAdd.Rows[i].Cells[5].Value.ToString(),out Acc))
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的加速度不是整数，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[6].Value != null && !int.TryParse(dgvAxisAdd.Rows[i].Cells[6].Value.ToString(), out Speed))
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的速度不是整数，请检查");
                            return;
                        }
                        if (dgvAxisAdd.Rows[i].Cells[7].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的复位顺序未选择，请检查");
                            return;
                        }
                        //检查是否已经存在重复数据
                        Name = dgvAxisAdd.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgvAxisAdd.Rows[i].Cells[2].Value.ToString());
                        AxisNum = int.Parse(dgvAxisAdd.Rows[i].Cells[3].Value.ToString());
                        if (WDCard.SelectShowAxisCheck(" Name='"+Name+"'") == 1)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称:" + Name + "；已存在，请检查");
                            return;
                        }
                        if (WDCard.SelectShowAxisCheck(" CardNum=" + CardNum + " And AxisNum=" + AxisNum) == 1)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号和轴号已存在，请检查");
                            return;
                        }
                        //增加的数据判断
                        int numRepeatName = 0;
                        int numRepeatCA = 0;
                        for (int j = 0; j < dgvAxisAdd.Rows.Count - 1; j++)
                        {
                            if (i != j)
                            {
                                if (Name == dgvAxisAdd.Rows[j].Cells[1].Value.ToString())
                                {
                                    numRepeatName++;
                                }
                                if (CardNum == int.Parse(dgvAxisAdd.Rows[j].Cells[2].Value.ToString()) &&
                                    AxisNum == int.Parse(dgvAxisAdd.Rows[j].Cells[3].Value.ToString()))
                                {
                                    numRepeatCA++;
                                }
                            }
                        }
                        if (numRepeatName > 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称有重复，请检查");
                            return;
                        }
                        if (numRepeatCA > 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号和轴号有重复，请检查");
                            return;
                        }
                    }
                    //把所有数据插入
                    for (int i = 0; i < dgvAxisAdd.Rows.Count - 1; i++)
                    {
                        GroupName = dgvAxisAdd.Rows[i].Cells[0].Value.ToString();
                        Name = dgvAxisAdd.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgvAxisAdd.Rows[i].Cells[2].Value.ToString());
                        AxisNum = int.Parse(dgvAxisAdd.Rows[i].Cells[3].Value.ToString());
                        if (dgvAxisAdd.Rows[i].Cells[4].Value == null)
                            Pulse = 100;
                        else
                            Pulse = int.Parse(dgvAxisAdd.Rows[i].Cells[4].Value.ToString());
                        if (dgvAxisAdd.Rows[i].Cells[5].Value == null)
                            Acc = 100;
                        else
                            Acc = int.Parse(dgvAxisAdd.Rows[i].Cells[5].Value.ToString());
                        if (dgvAxisAdd.Rows[i].Cells[6].Value == null)
                            Speed = 10;
                        else
                            Speed = int.Parse(dgvAxisAdd.Rows[i].Cells[6].Value.ToString());
                        ResetNum = int.Parse(dgvAxisAdd.Rows[i].Cells[7].Value.ToString());

                        if (WDCard.InsertAxis(GroupName,Name, CardNum, AxisNum, Pulse, Acc, Speed, ResetNum) != 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                    closePanelUI();
                    //刷新轴数据
                    WDCard.SelectShowAxis(ref dgvAxis);
                    dgvAxisAdd.Rows.Clear();
                    WTool.Popup("轴数据添加成功");
                }
                else
                {
                    WTool.Popup("添加的数据为空");
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
            }
        }

        private void Cms_AxisModify_Click(object sender, EventArgs e)
        {
            if (dgvAxis.SelectedRows.Count == 1)
            {
                int mIndex = dgvAxis.CurrentRow.Index;
                int nowIndex = dgvAxisModify.Rows.Add();
                dgvAxisModify.Rows[nowIndex].Cells[0].Value = dgvAxis.Rows[mIndex].Cells[0].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[1].Value = dgvAxis.Rows[mIndex].Cells[1].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[2].Value = dgvAxis.Rows[mIndex].Cells[2].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[3].Value = dgvAxis.Rows[mIndex].Cells[3].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[4].Value = dgvAxis.Rows[mIndex].Cells[4].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[5].Value = dgvAxis.Rows[mIndex].Cells[5].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[6].Value = dgvAxis.Rows[mIndex].Cells[6].Value.ToString();
                dgvAxisModify.Rows[nowIndex].Cells[7].Value = dgvAxis.Rows[mIndex].Cells[7].Value.ToString();
                showPanelUI("轴修改");
            }
            else
            {
                WTool.Popup("当前未选中数据");
            }
        }
        private void btnAxisModifyOk_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvAxisModify.Rows[0].Cells[0].Value == null)
                { 
                    WTool.Popup("组名不能为空");
                    return;
                }
                String GroupName = dgvAxisModify.Rows[0].Cells[0].Value.ToString();
                if (dgvAxisModify.Rows[0].Cells[1].Value == null)
                { 
                    WTool.Popup("轴名称不能为空");
                    return;
                }
                String Name = dgvAxisModify.Rows[0].Cells[1].Value.ToString();
                Int32 CardNum = int.Parse(dgvAxisModify.Rows[0].Cells[2].Value.ToString());
                Int32 AxisNum = int.Parse(dgvAxisModify.Rows[0].Cells[3].Value.ToString());
                Int32 Pulse = 0;
                if (dgvAxisModify.Rows[0].Cells[4].Value == null)
                    Pulse = 1000;
                else
                {
                    if (!int.TryParse(dgvAxisModify.Rows[0].Cells[4].Value.ToString(), out Pulse))
                    {
                        WTool.Popup("脉冲当量不是整数类型，请检查");
                        return;
                    }
                }
                Int32 Acc = 0;
                if (dgvAxisModify.Rows[0].Cells[5].Value == null)
                    Acc = 100;
                else
                {
                    if(!int.TryParse(dgvAxisModify.Rows[0].Cells[5].Value.ToString(),out Acc))
                    {
                        WTool.Popup("加速度不是整数类型，请检查");
                        return;
                    }
                }
                Int32 Speed = 0;
                if (dgvAxisModify.Rows[0].Cells[6].Value == null)
                    Speed = 10;
                else
                {
                    if (!int.TryParse(dgvAxisModify.Rows[0].Cells[6].Value.ToString(), out Speed))
                    {
                        WTool.Popup("速度不是整数类型，请检查");
                        return;
                    }
                }
                Int32 ResetNum = int.Parse(dgvAxisModify.Rows[0].Cells[7].Value.ToString());
                int isModifyNum = 0;
                int mIndex = dgvAxis.CurrentRow.Index;
                String oldName = dgvAxis.Rows[mIndex].Cells[1].Value.ToString();
                if (Name != oldName)
                {
                    if (WDCard.SelectShowAxisCheck(" Name='" + Name + "'") == 1)
                    {
                        WTool.Popup("轴名称已存在，请检查");
                        return;
                    }
                }
                else
                {
                    isModifyNum++;
                }

                if (CardNum == int.Parse(dgvAxis.Rows[mIndex].Cells[2].Value.ToString()) &&
                    AxisNum == int.Parse(dgvAxis.Rows[mIndex].Cells[3].Value.ToString()))
                {
                    isModifyNum++;
                }
                else
                {
                    if (WDCard.SelectShowAxisCheck(" CardNum=" + CardNum + " And AxisNum=" + AxisNum) == 1)
                    {
                        WTool.Popup("卡号和轴号已存在，请检查");
                        return;
                    }
                }
                if (Pulse == int.Parse(dgvAxis.Rows[mIndex].Cells[4].Value.ToString()) &&
                    GroupName == dgvAxis.Rows[0].Cells[0].Value.ToString() &&
                    Acc == int.Parse(dgvAxis.Rows[mIndex].Cells[5].Value.ToString()) &&
                    Speed == int.Parse(dgvAxis.Rows[mIndex].Cells[6].Value.ToString()) &&
                    ResetNum == int.Parse(dgvAxis.Rows[mIndex].Cells[7].Value.ToString()))
                {
                    isModifyNum++;
                }
                if (isModifyNum == 3)
                {
                    WTool.Popup("当前数据未有改动");
                    return;
                }
                if (WDCard.UpdateAxis(oldName,GroupName, Name, CardNum, AxisNum, Pulse, Acc,Speed, ResetNum) != 0)
                {
                    WTool.Popup("轴数据修改失败");
                    return;
                }
                //刷新轴数据
                WDCard.SelectShowAxis(ref dgvAxis);
            }
            catch (Exception ex)
            {
                WTool.Popup("轴数据修改出异常" + ex.ToString());
            }
            dgvAxisModify.Rows.Clear();
            closePanelUI();
            WTool.Popup("轴数据修改成功");
        }

        private void btnAxisModifyCancel_Click(object sender, EventArgs e)
        {
            dgvAxisModify.Rows.Clear();
            closePanelUI();
        }

        private void Cms_AxisDelete_Click(object sender, EventArgs e)
        {
            if (dgvAxis.SelectedRows.Count == 1)
            {
                int mIndex = dgvAxis.CurrentRow.Index;
                String mName = dgvAxis.Rows[mIndex].Cells[1].Value.ToString();
                int rtn = WDCard.DeleteAxis(mName);
                if (rtn == 0)
                {
                    //刷新轴数据
                    WDCard.SelectShowAxis(ref dgvAxis);
                    WTool.Popup("删除成功");
                }
                else
                {
                    WTool.Popup("删除失败");
                }
            }
            else
            {
                WTool.Popup("当前未选中数据");
            }
        }

        private void cms_DIAdd_Click(object sender, EventArgs e)
        {
            showPanelUI("输入添加");
        }
        private void btnDIAddCancel_Click(object sender, EventArgs e)
        {
            closePanelUI();
        }

        private void btnDIAddOk_Click(object sender, EventArgs e)
        {
            String GroupName = "";
            String Name = "";
            Int32 CardNum = 0;
            Int32 IoID = 0;
            String mIoType = "";
            Int32 IoType = 0;
            String mIoState = "";
            Int32 IoState = 0;
            Int32 ExtendNum = 0;
            try
            {
                if (dgvDIAdd.Rows.Count > 0)
                {
                    //检查数据
                    for (int i = 0; i < dgvDIAdd.Rows.Count - 1; i++)
                    {
                        //检查数据是否为空
                        if (dgvDIAdd.Rows[i].Cells[0].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的组名为空，请检查");
                            return;
                        }
                        if (dgvDIAdd.Rows[i].Cells[1].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口名称为空，请检查");
                            return;
                        }
                        if (dgvDIAdd.Rows[i].Cells[2].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号未选择，请检查");
                            return;
                        }
                        if (dgvDIAdd.Rows[i].Cells[3].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口号未选择，请检查");
                            return;
                        }
                        if (dgvDIAdd.Rows[i].Cells[4].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口类型选择，请检查");
                            return;
                        }
                        if (dgvDIAdd.Rows[i].Cells[5].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口状态选择，请检查");
                            return;
                        }
                        if (dgvDIAdd.Rows[i].Cells[4].Value.ToString() == "扩展" &&
                            dgvDIAdd.Rows[i].Cells[6].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的扩展卡号选择，请检查");
                            return;
                        }
                        //检查是否已经存在重复数据
                        Name = dgvDIAdd.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgvDIAdd.Rows[i].Cells[2].Value.ToString());
                        IoID = int.Parse(dgvDIAdd.Rows[i].Cells[3].Value.ToString());
                        mIoType = dgvDIAdd.Rows[i].Cells[4].Value.ToString();

                        if (dgvDIAdd.Rows[i].Cells[6].Value == null)
                            ExtendNum = 0;
                        else
                            ExtendNum = int.Parse(dgvDIAdd.Rows[i].Cells[6].Value.ToString());

                        if (WDCard.SelectShowDICheck(" Name='" + Name+"' ") == 1)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称:" + Name + "；已存在，请检查");
                            return;
                        }
                        if (mIoType == "扩展")
                        {
                            IoType = WContTool.getIoType(mIoType);

                            if (WDCard.SelectShowDICheck(
                                " CardNum=" + CardNum.ToString() +
                                " and IoID=" + IoID.ToString() +
                                " and IoType=" + IoType.ToString() +
                                " and ExtendNum=" + ExtendNum.ToString()
                                ) == 1)
                            {
                                WTool.Popup("第" + (i + 1).ToString() + "行的卡号、端口号、端口类型和扩展卡号已存在，请检查");
                                return;
                            }
                        }
                        else
                        {
                            IoType = WContTool.getIoType(mIoType);

                            if (WDCard.SelectShowDICheck(
                               " CardNum=" + CardNum.ToString() +
                               " and IoID=" + IoID.ToString() +
                               " and IoType=" + IoType.ToString()
                               ) == 1)
                            {
                                WTool.Popup("第" + (i + 1).ToString() + "行的卡号、端口号和端口类型已存在，请检查");
                                return;
                            }
                        }

                        //增加的数据判断
                        int numRepeatName = 0;
                        int numRepeatCA = 0;
                        for (int j = 0; j < dgvDIAdd.Rows.Count - 1; j++)
                        {
                            if (i != j)
                            {
                                if (Name == dgvDIAdd.Rows[j].Cells[0].Value.ToString())
                                {
                                    numRepeatName++;
                                }
                                if (mIoType == "扩展")
                                {
                                    if (CardNum == int.Parse(dgvDIAdd.Rows[j].Cells[2].Value.ToString()) &&
                                    IoID == int.Parse(dgvDIAdd.Rows[j].Cells[3].Value.ToString()) &&
                                    IoType == int.Parse(dgvDIAdd.Rows[j].Cells[4].Value.ToString()) &&
                                    ExtendNum == int.Parse(dgvDIAdd.Rows[j].Cells[6].Value.ToString()))
                                    {
                                        numRepeatCA++;
                                    }
                                }
                                else
                                {
                                    if (CardNum == int.Parse(dgvDIAdd.Rows[j].Cells[2].Value.ToString()) &&
                                    IoID == int.Parse(dgvDIAdd.Rows[j].Cells[3].Value.ToString()) &&
                                    IoType == int.Parse(dgvDIAdd.Rows[j].Cells[4].Value.ToString()))
                                    {
                                        numRepeatCA++;
                                    }
                                }

                            }
                        }
                        if (numRepeatName > 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称有重复，请检查");
                            return;
                        }
                        if (numRepeatCA > 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号、端口号和端口类型（扩展卡号）有重复，请检查");
                            return;
                        }
                    }
                    //把所有数据插入
                    for (int i = 0; i < dgvDIAdd.Rows.Count - 1; i++)
                    {
                        GroupName = dgvDIAdd.Rows[i].Cells[0].Value.ToString();
                        Name = dgvDIAdd.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgvDIAdd.Rows[i].Cells[2].Value.ToString());
                        IoID = int.Parse(dgvDIAdd.Rows[i].Cells[3].Value.ToString());
                        mIoType = dgvDIAdd.Rows[i].Cells[4].Value.ToString();
                        mIoState = dgvDIAdd.Rows[i].Cells[5].Value.ToString();
                        if (dgvDIAdd.Rows[i].Cells[6].Value == null)
                            ExtendNum = 0;
                        else
                            ExtendNum = int.Parse(dgvDIAdd.Rows[i].Cells[6].Value.ToString());

                        IoType = WContTool.getIoType(mIoType);
                        IoState = WContTool.getIoState(mIoState);

                        if (WDCard.InsertDI(GroupName, Name, CardNum, IoID, IoType, IoState, ExtendNum) != 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                    closePanelUI();
                    //刷新轴数据
                    WDCard.SelectShowDI(ref dgvDI);
                    dgvDIAdd.Rows.Clear();
                    WTool.Popup("轴数据添加成功");
                }
                else
                {
                    WTool.Popup("添加的数据为空");
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
            }
        }

        private void cms_DIModify_Click(object sender, EventArgs e)
        {
            if (dgvDI.SelectedRows.Count == 1)
            {
                int mIndex = dgvDI.CurrentRow.Index;
                int nowIndex = dgvDIModify.Rows.Add();

                dgvDIModify.Rows[nowIndex].Cells[0].Value = dgvDI.Rows[mIndex].Cells[0].Value.ToString();
                dgvDIModify.Rows[nowIndex].Cells[1].Value = dgvDI.Rows[mIndex].Cells[1].Value.ToString();
                dgvDIModify.Rows[nowIndex].Cells[2].Value = dgvDI.Rows[mIndex].Cells[2].Value.ToString();
                dgvDIModify.Rows[nowIndex].Cells[3].Value = dgvDI.Rows[mIndex].Cells[3].Value.ToString();
                dgvDIModify.Rows[nowIndex].Cells[4].Value = dgvDI.Rows[mIndex].Cells[4].Value.ToString();
                dgvDIModify.Rows[nowIndex].Cells[5].Value = dgvDI.Rows[mIndex].Cells[5].Value.ToString();
                dgvDIModify.Rows[nowIndex].Cells[6].Value = dgvDI.Rows[mIndex].Cells[6].Value.ToString();
                showPanelUI("输入修改");
            }
            else
            {
                WTool.Popup("当前未选中数据");
            }
        }

        private void cms_DIDelete_Click(object sender, EventArgs e)
        {
            if (dgvDI.SelectedRows.Count == 1)
            {
                int mIndex = dgvDI.CurrentRow.Index;
                String mName = dgvDI.Rows[mIndex].Cells[1].Value.ToString();
                int rtn = WDCard.DeleteDI(mName);
                if (rtn == 0)
                {
                    //刷新轴数据
                    WDCard.SelectShowDI(ref dgvDI);
                    WTool.Popup("删除成功");
                }
                else
                {
                    WTool.Popup("删除失败");
                }
            }
            else
            {
                WTool.Popup("当前未选中数据");
            }
        }
        private void btnDIModifyCancel_Click(object sender, EventArgs e)
        {
            dgvDIModify.Rows.Clear();
            closePanelUI();
        }

        private void btnDIModifyOk_Click(object sender, EventArgs e)
        {
            //获取修改的数据
            String GroupName = dgvDIModify.Rows[0].Cells[0].Value.ToString();
            String Name = dgvDIModify.Rows[0].Cells[1].Value.ToString();
            Int32 CardNum = int.Parse(dgvDIModify.Rows[0].Cells[2].Value.ToString());
            Int32 IoID = int.Parse(dgvDIModify.Rows[0].Cells[3].Value.ToString());
            String mIoType = dgvDIModify.Rows[0].Cells[4].Value.ToString();
            Int32 IoType = WContTool.getIoType(dgvDIModify.Rows[0].Cells[4].Value.ToString());
            String mIoState = dgvDIModify.Rows[0].Cells[5].Value.ToString();
            Int32 IoState = WContTool.getIoState(dgvDIModify.Rows[0].Cells[5].Value.ToString());
            Int32 ExtendNum = int.Parse(dgvDIModify.Rows[0].Cells[6].Value.ToString());
            try
            {
                int isModifyNum = 0;
                int mIndex = dgvDI.CurrentRow.Index;
                String oldName = dgvDI.Rows[mIndex].Cells[1].Value.ToString();
                if (Name != oldName)
                {
                    if (WDCard.SelectShowDICheck(" Name='" + Name+"'") == 1)
                    {
                        WTool.Popup("端口名称已存在，请检查");
                        return;
                    }
                }
                else
                {
                    isModifyNum++;
                }

                if (IoType == 1023)
                {
                    if (CardNum == int.Parse(dgvDI.Rows[mIndex].Cells[2].Value.ToString()) &&
                        IoID == int.Parse(dgvDI.Rows[mIndex].Cells[3].Value.ToString()) &&
                        mIoType == dgvDI.Rows[mIndex].Cells[4].Value.ToString() &&
                        ExtendNum == int.Parse(dgvDI.Rows[mIndex].Cells[6].Value.ToString()))
                    {
                        isModifyNum++;
                    }
                    else
                    {
                        if (WDCard.SelectShowDICheck(
                            " CardNum=" + CardNum.ToString() +
                            " and IoID=" + IoID.ToString() +
                            " and IoType=" + IoType.ToString() +
                            " and ExtendNum=" + ExtendNum.ToString()
                            ) == 1)
                        {
                            WTool.Popup("卡号、端口号、端口类型和扩展卡号已存在，请检查");
                            return;
                        }
                    }
                }
                else
                {
                    if (CardNum == int.Parse(dgvDI.Rows[mIndex].Cells[2].Value.ToString()) &&
                        IoID == int.Parse(dgvDI.Rows[mIndex].Cells[3].Value.ToString()) &&
                        mIoType == dgvDI.Rows[mIndex].Cells[4].Value.ToString())
                    {
                        isModifyNum++;
                    }
                    else
                    {
                        if (WDCard.SelectShowDICheck(
                           " CardNum=" + CardNum.ToString() +
                           " and IoID=" + IoID.ToString() +
                           " and IoType=" + IoType.ToString()
                           ) == 1)
                        {
                            WTool.Popup("卡号、端口号和端口类型已存在，请检查");
                            return;
                        }
                    }
                }
                if (GroupName == dgvDI.Rows[mIndex].Cells[0].Value.ToString() &&
                    mIoState == dgvDI.Rows[mIndex].Cells[5].Value.ToString())
                {
                    isModifyNum++;
                }
                if (isModifyNum == 3)
                {
                    WTool.Popup("当前数据未有改动");
                    return;
                }
                if (WDCard.UpdateDI(oldName, GroupName, Name, CardNum, IoID, IoType, IoState, ExtendNum) != 0)
                {
                    WTool.Popup("轴数据修改失败");
                    return;
                }
                //刷新轴数据
                WDCard.SelectShowDI(ref dgvDI);
                dgvDIModify.Rows.Clear();
                closePanelUI();
                WTool.Popup("轴数据修改成功");
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
            }
        }

        private void cms_DOAdd_Click(object sender, EventArgs e)
        {
            showPanelUI("输出添加");
        }
        private void btnDOAddOk_Click(object sender, EventArgs e)
        {
            String GroupName = "";
            String Name = "";
            Int32 CardNum = 0;
            Int32 IoID = 0;
            String mIoType = "";
            Int32 IoType = 0;
            String mIoState = "";
            Int32 IoState = 0;
            Int32 ExtendNum = 0;
            try
            {
                if (dgvDOAdd.Rows.Count > 0)
                {
                    //检查数据
                    for (int i = 0; i < dgvDOAdd.Rows.Count - 1; i++)
                    {
                        //检查数据是否为空
                        if (dgvDOAdd.Rows[i].Cells[0].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的组名为空，请检查");
                            return;
                        }
                        if (dgvDOAdd.Rows[i].Cells[1].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口名称为空，请检查");
                            return;
                        }
                        if (dgvDOAdd.Rows[i].Cells[2].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号未选择，请检查");
                            return;
                        }
                        if (dgvDOAdd.Rows[i].Cells[3].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口号未选择，请检查");
                            return;
                        }
                        if (dgvDOAdd.Rows[i].Cells[4].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口类型选择，请检查");
                            return;
                        }
                        if (dgvDOAdd.Rows[i].Cells[5].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的端口状态选择，请检查");
                            return;
                        }
                        if (dgvDOAdd.Rows[i].Cells[4].Value.ToString() == "扩展" &&
                            dgvDOAdd.Rows[i].Cells[6].Value == null)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的扩展卡号选择，请检查");
                            return;
                        }
                        //检查是否已经存在重复数据
                        Name = dgvDOAdd.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgvDOAdd.Rows[i].Cells[2].Value.ToString());
                        IoID = int.Parse(dgvDOAdd.Rows[i].Cells[3].Value.ToString());
                        mIoType = dgvDOAdd.Rows[i].Cells[4].Value.ToString();

                        if (dgvDOAdd.Rows[i].Cells[6].Value == null)
                            ExtendNum = 0;
                        else
                            ExtendNum = int.Parse(dgvDOAdd.Rows[i].Cells[6].Value.ToString());

                        if (WDCard.SelectShowDOCheck(" Name='" + Name+"'") == 1)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称:" + Name + "；已存在，请检查");
                            return;
                        }
                        if (mIoType == "扩展")
                        {
                            IoType = WContTool.getIoType(mIoType);

                            if (WDCard.SelectShowDOCheck(
                                " CardNum=" + CardNum.ToString() +
                                " and IoID=" + IoID.ToString() +
                                " and IoType=" + IoType.ToString() +
                                " and ExtendNum=" + ExtendNum.ToString()
                                ) == 1)
                            {
                                WTool.Popup("第" + (i + 1).ToString() + "行的卡号、端口号、端口类型和扩展卡号已存在，请检查");
                                return;
                            }
                        }
                        else
                        {
                            IoType = WContTool.getIoType(mIoType);

                            if (WDCard.SelectShowDOCheck(
                               " CardNum=" + CardNum.ToString() +
                               " and IoID=" + IoID.ToString() +
                               " and IoType=" + IoType.ToString()
                               ) == 1)
                            {
                                WTool.Popup("第" + (i + 1).ToString() + "行的卡号、端口号和端口类型已存在，请检查");
                                return;
                            }
                        }

                        //增加的数据判断
                        int numRepeatName = 0;
                        int numRepeatCA = 0;
                        for (int j = 0; j < dgvDOAdd.Rows.Count - 1; j++)
                        {
                            if (i != j)
                            {
                                if (Name == dgvDOAdd.Rows[j].Cells[0].Value.ToString())
                                {
                                    numRepeatName++;
                                }
                                if (mIoType == "扩展")
                                {
                                    if (CardNum == int.Parse(dgvDOAdd.Rows[j].Cells[2].Value.ToString()) &&
                                    IoID == int.Parse(dgvDOAdd.Rows[j].Cells[3].Value.ToString()) &&
                                    IoType == int.Parse(dgvDOAdd.Rows[j].Cells[4].Value.ToString()) &&
                                    ExtendNum == int.Parse(dgvDOAdd.Rows[j].Cells[6].Value.ToString()))
                                    {
                                        numRepeatCA++;
                                    }
                                }
                                else
                                {
                                    if (CardNum == int.Parse(dgvDOAdd.Rows[j].Cells[2].Value.ToString()) &&
                                    IoID == int.Parse(dgvDOAdd.Rows[j].Cells[3].Value.ToString()) &&
                                    IoType == int.Parse(dgvDOAdd.Rows[j].Cells[4].Value.ToString()))
                                    {
                                        numRepeatCA++;
                                    }
                                }

                            }
                        }
                        if (numRepeatName > 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的轴名称有重复，请检查");
                            return;
                        }
                        if (numRepeatCA > 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的卡号、端口号和端口类型（扩展卡号）有重复，请检查");
                            return;
                        }
                    }
                    //把所有数据插入
                    for (int i = 0; i < dgvDOAdd.Rows.Count - 1; i++)
                    {
                        GroupName = dgvDOAdd.Rows[i].Cells[0].Value.ToString();
                        Name = dgvDOAdd.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgvDOAdd.Rows[i].Cells[2].Value.ToString());
                        IoID = int.Parse(dgvDOAdd.Rows[i].Cells[3].Value.ToString());
                        mIoType = dgvDOAdd.Rows[i].Cells[4].Value.ToString();
                        mIoState = dgvDOAdd.Rows[i].Cells[5].Value.ToString();
                        if (dgvDOAdd.Rows[i].Cells[6].Value == null)
                            ExtendNum = 0;
                        else
                            ExtendNum = int.Parse(dgvDOAdd.Rows[i].Cells[6].Value.ToString());

                        IoType = WContTool.getIoType(mIoType);
                        IoState = WContTool.getIoState(mIoState);

                        if (WDCard.InsertDO(GroupName, Name, CardNum, IoID, IoType, IoState, ExtendNum) != 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                    closePanelUI();
                    //刷新轴数据
                    WDCard.SelectShowDO(ref dgvDO);
                    dgvDOAdd.Rows.Clear();
                    WTool.Popup("轴数据添加成功");
                }
                else
                {
                    WTool.Popup("添加的数据为空");
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
            }
        }

        private void btnDOAddCancel_Click(object sender, EventArgs e)
        {
            closePanelUI();
        }

        private void cms_DOModify_Click(object sender, EventArgs e)
        {
            if (dgvDO.SelectedRows.Count == 1)
            {
                int mIndex = dgvDO.CurrentRow.Index;
                int nowIndex = dgvDOModify.Rows.Add();

                dgvDOModify.Rows[nowIndex].Cells[0].Value = dgvDO.Rows[mIndex].Cells[0].Value.ToString();
                dgvDOModify.Rows[nowIndex].Cells[1].Value = dgvDO.Rows[mIndex].Cells[1].Value.ToString();
                dgvDOModify.Rows[nowIndex].Cells[2].Value = dgvDO.Rows[mIndex].Cells[2].Value.ToString();
                dgvDOModify.Rows[nowIndex].Cells[3].Value = dgvDO.Rows[mIndex].Cells[3].Value.ToString();
                dgvDOModify.Rows[nowIndex].Cells[4].Value = dgvDO.Rows[mIndex].Cells[4].Value.ToString();
                dgvDOModify.Rows[nowIndex].Cells[5].Value = dgvDO.Rows[mIndex].Cells[5].Value.ToString();
                dgvDOModify.Rows[nowIndex].Cells[6].Value = dgvDO.Rows[mIndex].Cells[6].Value.ToString();
                showPanelUI("输出修改");
            }
            else
            {
                WTool.Popup("当前未选中数据");
            }
        }
        private void btnDOModifyCancel_Click(object sender, EventArgs e)
        {
            dgvDOModify.Rows.Clear();
            closePanelUI();
        }
        private void btnDOModifyOk_Click(object sender, EventArgs e)
        {
            //获取修改的数据
            String GroupName = dgvDOModify.Rows[0].Cells[0].Value.ToString();
            String Name = dgvDOModify.Rows[0].Cells[1].Value.ToString();
            Int32 CardNum = int.Parse(dgvDOModify.Rows[0].Cells[2].Value.ToString());
            Int32 IoID = int.Parse(dgvDOModify.Rows[0].Cells[3].Value.ToString());
            String mIoType = dgvDOModify.Rows[0].Cells[4].Value.ToString();
            Int32 IoType = WContTool.getIoType(dgvDOModify.Rows[0].Cells[4].Value.ToString());
            String mIoState = dgvDOModify.Rows[0].Cells[5].Value.ToString();
            Int32 IoState = WContTool.getIoState(dgvDOModify.Rows[0].Cells[5].Value.ToString());
            Int32 ExtendNum = int.Parse(dgvDOModify.Rows[0].Cells[6].Value.ToString());
            try
            {
                int isModifyNum = 0;
                int mIndex = dgvDO.CurrentRow.Index;
                String oldName = dgvDO.Rows[mIndex].Cells[1].Value.ToString();
                if (Name != oldName)
                {
                    if (WDCard.SelectShowDOCheck(" Name=" + Name) == 1)
                    {
                        WTool.Popup("端口名称已存在，请检查");
                        return;
                    }
                }
                else
                {
                    isModifyNum++;
                }

                if (IoType == 1023)
                {
                    if (CardNum == int.Parse(dgvDO.Rows[mIndex].Cells[2].Value.ToString()) &&
                        IoID == int.Parse(dgvDO.Rows[mIndex].Cells[3].Value.ToString()) &&
                        mIoType == dgvDO.Rows[mIndex].Cells[4].Value.ToString() &&
                        ExtendNum == int.Parse(dgvDO.Rows[mIndex].Cells[6].Value.ToString()))
                    {
                        isModifyNum++;
                    }
                    else
                    {
                        if (WDCard.SelectShowDOCheck(
                            " CardNum=" + CardNum.ToString() +
                            " and IoID=" + IoID.ToString() +
                            " and IoType=" + IoType.ToString() +
                            " and ExtendNum=" + ExtendNum.ToString()
                            ) == 1)
                        {
                            WTool.Popup("卡号、端口号、端口类型和扩展卡号已存在，请检查");
                            return;
                        }
                    }
                }
                else
                {
                    if (CardNum == int.Parse(dgvDO.Rows[mIndex].Cells[2].Value.ToString()) &&
                        IoID == int.Parse(dgvDO.Rows[mIndex].Cells[3].Value.ToString()) &&
                        mIoType == dgvDO.Rows[mIndex].Cells[4].Value.ToString())
                    {
                        isModifyNum++;
                    }
                    else
                    {
                        if (WDCard.SelectShowDOCheck(
                           " CardNum=" + CardNum.ToString() +
                           " and IoID=" + IoID.ToString() +
                           " and IoType=" + IoType.ToString()
                           ) == 1)
                        {
                            WTool.Popup("卡号、端口号和端口类型已存在，请检查");
                            return;
                        }
                    }
                }
                if (GroupName == dgvDO.Rows[mIndex].Cells[0].Value.ToString() &&
                    mIoState == dgvDO.Rows[mIndex].Cells[5].Value.ToString())
                {
                    isModifyNum++;
                }
                if (isModifyNum == 3)
                {
                    WTool.Popup("当前数据未有改动");
                    return;
                }
                if (WDCard.UpdateDO(oldName, GroupName, Name, CardNum, IoID, IoType, IoState, ExtendNum) != 0)
                {
                    WTool.Popup("轴数据修改失败");
                    return;
                }
                //刷新轴数据
                WDCard.SelectShowDO(ref dgvDO);
                dgvDOModify.Rows.Clear();
                closePanelUI();
                WTool.Popup("轴数据修改成功");
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
            }
        }

        private void cms_DODelete_Click(object sender, EventArgs e)
        {
            if (dgvDO.SelectedRows.Count == 1)
            {
                int mIndex = dgvDO.CurrentRow.Index;
                String mName = dgvDO.Rows[mIndex].Cells[1].Value.ToString();
                int rtn = WDCard.DeleteDO(mName);
                if (rtn == 0)
                {
                    //刷新轴数据
                    WDCard.SelectShowDO(ref dgvDO);
                    WTool.Popup("删除成功");
                }
                else
                {
                    WTool.Popup("删除失败");
                }
            }
            else
            {
                WTool.Popup("当前未选中数据");
            }
        }
        /// <summary>
        /// 判断并打开对应编辑的页面
        /// </summary>
        /// <param name="mName">打开的页面</param>
        public void showPanelUI(string mName)
        {
            if (mName == "轴添加")
                panAxisAdd.Visible = true;
            else if (mName == "轴修改")
                panAxisModify.Visible = true;
            else if (mName == "输入添加")
                panDIAdd.Visible = true;
            else if (mName == "输入修改")
                panDIModify.Visible = true;
            else if (mName == "输出添加")
                panDOAdd.Visible = true;
            else if (mName == "输出修改")
                panDOModify.Visible = true;
            else
                WTool.Popup("界面打开判断有误");

            dgvAxis.Enabled = false;
            dgvDI.Enabled = false;
            dgvDO.Enabled = false;
        }
        /// <summary>
        /// 关闭所有编辑页面
        /// </summary>
        public void closePanelUI()
        {
            panAxisAdd.Visible = false;
            panAxisModify.Visible = false;

            panDIAdd.Visible = false;
            panDIModify.Visible = false;

            panDOAdd.Visible = false;
            panDOModify.Visible = false;

            dgvAxis.Enabled = true;
            dgvDI.Enabled = true;
            dgvDO.Enabled = true;
        }

        private void Cms_AxisSaveExcel_Click(object sender, EventArgs e)
        {
            ExportExcel((DataTable)dgvAxis.DataSource, "Axis");
        }
        private void Cms_DISaveExcel_Click(object sender, EventArgs e)
        {
            ExportExcel((DataTable)dgvDI.DataSource, "DI");
        }
        private void Cms_DOSaveExcel_Click(object sender, EventArgs e)
        {
            ExportExcel((DataTable)dgvDO.DataSource, "DO");
        }
        public void ExportExcel(DataTable dt, string title)
        {
            gotoTitle:
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "另存为（文件的名称前缀必须为“"+ title + "”）";
            savedialog.Filter = "Excel表格(*.xlsx)|*.xlsx";
            savedialog.FilterIndex = 0;
            savedialog.RestoreDirectory = true;
            savedialog.CheckPathExists = true;
            savedialog.FileName = "";
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = savedialog.FileName;
                if (!Path.GetFileNameWithoutExtension(filepath).StartsWith(title))
                {
                    WTool.Popup("文件的前缀需要为“"+ title + "”");
                    goto gotoTitle;
                }
                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("standard_template");
                //创建Excel行
                IRow row = sheet.CreateRow(0);
                //将DataTable的列名显示在Excel表第一行
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }
                //遍历DataTable，给Excel赋值
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow rowItem = sheet.CreateRow(i+1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        rowItem.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
                FileStream file = new FileStream(filepath, FileMode.Create);
                book.Write(file);
                file.Close();
                book.Close();
                file.Dispose();
                WTool.Popup("保存成功");
            }

        }

        private void Cms_AxisLoadExcel_Click(object sender, EventArgs e)
        {
            ExcelToTableForXLSX(ref dgvAxis, "Axis");
        }
        private void Cms_DILoadExcel_Click(object sender, EventArgs e)
        {
            ExcelToTableForXLSX(ref dgvDI, "DI");
        }

        private void Cms_DOLoadExcel_Click(object sender, EventArgs e)
        {
            ExcelToTableForXLSX(ref dgvDO, "DO");
        }
        /// <summary>
        /// 将Excel文件中的数据读出到DataTable中(xlsx)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public void ExcelToTableForXLSX(ref DataGridView dgv,string title)
        {
            gotoTitle:
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = title;
            ofd.Filter = "Excel表格(*.xlsx)|*.xlsx";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filepath = ofd.FileName;
                if (!Path.GetFileNameWithoutExtension(filepath).StartsWith(title))
                {
                    WTool.Popup("文件的前缀需要为“" + title + "”");
                    goto gotoTitle;
                }
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook xssfworkbook = new XSSFWorkbook(fs);
                    ISheet sheet = xssfworkbook.GetSheetAt(0);

                    //表头
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));

                        }
                        else
                            dt.Columns.Add(new DataColumn(obj.ToString()));
                        columns.Add(i);
                    }
                    //数据
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        foreach (int j in columns)
                        {
                            if (sheet.GetRow(i) != null)
                            {
                                dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                                if (dr[j] != null && dr[j].ToString() != string.Empty)
                                {
                                    hasValue = true;
                                }
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
                dgv.DataSource = dt;
                WTool.Popup("读取成功");

                String GroupName = "";
                String Name = "";
                Int32 CardNum = 0;
                Int32 IoID = 0;
                String mIoType = "";
                Int32 IoType = 0;
                String mIoState = "";
                Int32 IoState = 0;
                Int32 ExtendNum = 0;


                if (title.Equals("Axis"))
                {
                    Int32 AxisNum = 0;
                    Int32 Pulse = 0;
                    Int32 Acc = 0;
                    Int32 Speed = 0;
                    Int32 ResetNum = 0;
                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        GroupName = dgv.Rows[i].Cells[0].Value.ToString();
                        Name = dgv.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                        AxisNum = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                        if (dgv.Rows[i].Cells[4].Value == null)
                            Pulse = 100;
                        else
                            Pulse = int.Parse(dgv.Rows[i].Cells[4].Value.ToString());
                        if (dgv.Rows[i].Cells[5].Value == null)
                            Acc = 100;
                        else
                            Acc = int.Parse(dgv.Rows[i].Cells[5].Value.ToString());
                        if (dgv.Rows[i].Cells[6].Value == null)
                            Speed = 10;
                        else
                            Speed = int.Parse(dgv.Rows[i].Cells[6].Value.ToString());
                        ResetNum = int.Parse(dgv.Rows[i].Cells[7].Value.ToString());
                        WDCard.DeleteAxis(Name);
                        if (WDCard.InsertAxis(GroupName, Name, CardNum, AxisNum, Pulse, Acc, Speed, ResetNum) != 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                }
                else if (title.Equals("DO"))
                {
                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        GroupName = dgv.Rows[i].Cells[0].Value.ToString();
                        Name = dgv.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                        IoID = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                        mIoType = dgv.Rows[i].Cells[4].Value.ToString();
                        mIoState = dgv.Rows[i].Cells[5].Value.ToString();
                        if (dgv.Rows[i].Cells[6].Value == null)
                            ExtendNum = 0;
                        else
                            ExtendNum = int.Parse(dgv.Rows[i].Cells[6].Value.ToString());

                        IoType = WContTool.getIoType(mIoType);
                        IoState = WContTool.getIoState(mIoState);

                        WDCard.DeleteDO(Name);
                        if (WDCard.InsertDO(GroupName, Name, CardNum, IoID, IoType, IoState, ExtendNum) != 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                }
                else  if (title.Equals("DI"))
                {
                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        GroupName = dgv.Rows[i].Cells[0].Value.ToString();
                        Name = dgv.Rows[i].Cells[1].Value.ToString();
                        CardNum = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                        IoID = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                        mIoType = dgv.Rows[i].Cells[4].Value.ToString();
                        mIoState = dgv.Rows[i].Cells[5].Value.ToString();
                        if (dgv.Rows[i].Cells[6].Value == null)
                            ExtendNum = 0;
                        else
                            ExtendNum = int.Parse(dgv.Rows[i].Cells[6].Value.ToString());

                        IoType = WContTool.getIoType(mIoType);
                        IoState = WContTool.getIoState(mIoState);

                        WDCard.DeleteDI(Name);
                        if (WDCard.InsertDI(GroupName, Name, CardNum, IoID, IoType, IoState, ExtendNum) != 0)
                        {
                            WTool.Popup("第" + (i + 1).ToString() + "行的数据添加失败");
                            return;
                        }
                    }
                }
                
            }
        }
        /// <summary>
         /// 获取单元格类型(xlsx)
         /// </summary>
         /// <param name="cell"></param>
         /// <returns></returns>
        private static object GetValueTypeForXLSX(XSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:
                    return null;
                case CellType.Boolean: //BOOLEAN:
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:
                    return cell.NumericCellValue;
                case CellType.String: //STRING:
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:
                    if (cell.CachedFormulaResultType == CellType.Numeric)
                    {
                        return cell.NumericCellValue;
                    }
                    else
                    {
                        return cell.StringCellValue;
                    }
                default:
                    return "=" + cell.CellFormula;
            }
        }

    }
}
