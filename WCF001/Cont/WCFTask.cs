using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WCF
{
    /// 类 	  名：WDataTask
	/// 类 描 述：任务流程控件
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/10
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFTask : UserControl
    {
        public WCFTask()
        {
            InitializeComponent();
            //界面初始化
            gbAddTask.Visible = false;
            gbAddStep.Visible = false;

            //initLvTask();
        }
        private Dictionary<string, List<string>> dicTips = new Dictionary<string, List<string>>();
        public void ConInit()
        {
            wcfLog.ConInit("流程运行");

            #region 设置提示树形控件的数据
            dicTips.Add("关键字", WDPublic.Keyword);
            dicTips.Add("通用函数", WDPublic.Currency);
            dicTips.Add("板卡函数", WDPublic.Card);
            dicTips.Add("通讯函数", WDPublic.Commun);
            foreach (KeyValuePair<string, List<string>> item in dicTips)
            {
                TreeNode tn = new TreeNode(item.Key);
                foreach (string itemSon in item.Value)
                {
                    tn.Nodes.Add(new TreeNode(itemSon));
                }
                tvTipsName.Nodes.Add(tn);
            }
            //添加通用参数
            TreeNode tnPara = new TreeNode("通用参数");
            List<string> mParaCurr = new List<string>();
            foreach (ParaTab itemParaTab in WDPara.GetListParaTab)
            {
                TreeNode tnParaTab = new TreeNode(itemParaTab.Name);
                foreach (ParaTable itemParaTable in itemParaTab.ListParaTable)
                {
                    TreeNode tnParaTable = new TreeNode(itemParaTable.Name);
                    foreach (ParaCurr itemParaCurr in itemParaTable.ListParaTable)
                    {
                        TreeNode tnParaCurr = new TreeNode(itemParaCurr.Name);
                        tnParaTable.Nodes.Add(tnParaCurr);
                        mParaCurr.Add(itemParaCurr.Name);
                    }
                    tnParaTab.Nodes.Add(tnParaTable);
                }
                tnPara.Nodes.Add(tnParaTab);
            }
            tvTipsName.Nodes.Add(tnPara);
            dicTips.Add("通用参数", mParaCurr);
            #endregion

            initLvTask();
            initLvPublic();//共有变量初始化

            #region 卡数据和点位数据列表的显示
            InitViewCPoint();
            InitViewCDI();
            InitViewCDO();
            InitViewCAxis();
            #endregion
            #region 代码智能感知初始化
            ConInitRTBData();
            ConInitRTB();
            #endregion
        }
        private void initLvTask()
        {

            lvTask.Columns.Add("任务名称", 100, HorizontalAlignment.Center);

            ListViewGroup mHeader = new ListViewGroup();
            ListViewItem mLvi;

            string mTaskType = "";
            List<string> mPara = new List<string>();
            foreach (KeyValuePair<string, TaskData> item in WDTask.DicTaskData)
            {
                if (!mTaskType.Equals(item.Value.TaskType))
                {
                    //创建列表组名并添加
                    mHeader = new ListViewGroup();
                    mHeader.Header = item.Value.TaskType;
                    mHeader.HeaderAlignment = HorizontalAlignment.Center;
                    lvTask.Groups.Add(mHeader);
                    lvTask.ShowGroups = true;
                    mTaskType = item.Value.TaskType;
                }
                //添加数据
                mLvi = new ListViewItem();
                mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                mLvi.Text = item.Key;
                //添加到列表
                mHeader.Items.Add(mLvi);
                lvTask.Items.Add(mLvi);
                mPara.Add(item.Key);
            }
            lvTask.HeaderStyle = ColumnHeaderStyle.None;

            if (dicTips.ContainsKey("任务名称"))
                dicTips["任务名称"] = mPara;
            else
                dicTips.Add("任务名称", mPara);

        }
        private void cmsTaskAdd_Click(object sender, EventArgs e)
        {
            if (lvTask.Items.Count > 0 && lvTask.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个任务");
                return;
            }
            if (lvTask.Items.Count > 0)
            {
                string strName = lvTask.SelectedItems[0].Text;
                cbAddTask.Text = WDTask.DicTaskData[strName].TaskType;
                //cbAddTask.Enabled = false;
            }
            //else
            //    cbAddTask.Enabled = true;

            txtAddTaskName.Text = "";
            gbAddTask.Visible = true;
        }

        private void btnAddTaskOK_Click(object sender, EventArgs e)
        {
            if (cbAddTask.Text.Length == 0)
            {
                WTool.Popup("请选择任务类型");
                return;
            }
            if (txtAddTaskName.Text.Length == 0)
            {
                WTool.Popup("请填写任务名称");
                return;
            }
            //获取排序的序号
            double numOrder = 0.001;
            if (lvTask.SelectedItems.Count == 1)
            {
                string strName = lvTask.SelectedItems[0].Text;
                double nowNumOrder = WDTask.DicTaskData[strName].NumOrder;
                List<double> listNumOrder = new List<double>();
                #region 获取下一个数据的排序值并生成新的排序值
                foreach (KeyValuePair<string, TaskData> item in WDTask.DicTaskData)
                {
                    if (item.Value.NumOrder > nowNumOrder)
                    {
                        listNumOrder.Add(item.Value.NumOrder);
                    }
                }
                if (listNumOrder.Count > 0)
                {
                    listNumOrder.Sort();
                    if (listNumOrder[0] != 0)
                    {
                        numOrder = (nowNumOrder + listNumOrder[0]) / 2;
                    }
                }
                else
                {
                    numOrder = nowNumOrder + 0.001;
                }
                #endregion
            }
            #region 任务名称重复检测
            string strTaskName = txtAddTaskName.Text.ToString();
            if (WContTool.IsTrim(ref strTaskName, "任务名称"))
                return;
            else if (IsNameRepeat(strTaskName, "任务名称"))
                return;
            #endregion
            //增加任务表数据
            WDTask.InsertTask(
                numOrder,
                strTaskName,
                cbAddTask.Text.ToString());
            //刷新本地数据
            Dictionary<string, TaskData> DicTaskData = WDTask.DicTaskData;
            //增加步骤表相应数据
            WDTask.InsertStep(
                DicTaskData[strTaskName].ID,
                0.001,
                "任务准备");
            WDTask.InsertStep(
                DicTaskData[strTaskName].ID,
                0.9,
                "任务完成");

            lvTask.Clear();
            initLvTask();
            gbAddTask.Visible = false;
        }
        private void cmsTaskDelete_Click(object sender, EventArgs e)
        {
            if (lvTask.Items.Count == 0)
            {
                WTool.Popup("当前没有任务");
                return;
            }
            if (lvTask.Items.Count > 0 && lvTask.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个任务");
                return;
            }
            string strName = lvTask.SelectedItems[0].Text;
            DialogResult mDialogResult = WTool.PopupOKCancel("是否删除任务：" + strName, "提示");
            if (mDialogResult == DialogResult.OK)
            {
                WDTask.DeleteTask(strName);//删除任务表数据
                WDTask.DeleteStepTaskID(WDTask.DicTaskData[strName].ID);//删除步骤表数据
                lvTask.Clear();
                lvStep.Clear();
                initLvTask();
            }
        }

        private void btnAddTaskCancel_Click(object sender, EventArgs e)
        {
            gbAddTask.Visible = false;
        }
        private void cmsStepAdd_Click(object sender, EventArgs e)
        {
            if (lvStep.Items.Count > 0 && lvStep.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个步骤");
                return;
            }

            txtAddStepName.Text = "";
            gbAddStep.Visible = true;
        }

        private void btnAddStepOK_Click(object sender, EventArgs e)
        {
            #region 步骤名称重复检测
            string strStepName = txtAddStepName.Text.ToString();
            if (WContTool.IsTrim(ref strStepName, "步骤名称"))
                return;
            foreach (KeyValuePair<string, StepData> itemStep in WDTask.DicTaskData[strNowTask].DicStepData)
            {
                if (itemStep.Key.Equals(strStepName))
                {
                    WTool.Popup("任务名称有重复请检查");
                    return;
                }
            }
            #endregion

            #region 获取排序的序号
            double numOrder = 0.001;
            if (lvStep.SelectedItems.Count == 1)
            {
                string strName = lvStep.SelectedItems[0].Text;
                double nowNumOrder = WDTask.DicTaskData[strNowTask].DicStepData[strName].NumOrder;
                List<double> listNumOrder = new List<double>();
                //获取下一个数据的排序值并生成新的排序值
                foreach (KeyValuePair<string, StepData> itemStep in WDTask.DicTaskData[strNowTask].DicStepData)
                {
                    if (itemStep.Value.NumOrder > nowNumOrder)
                    {
                        listNumOrder.Add(itemStep.Value.NumOrder);
                    }
                }
                if (listNumOrder.Count > 0)
                {
                    listNumOrder.Sort();
                    if (listNumOrder[0] != 0)
                    {
                        numOrder = (nowNumOrder + listNumOrder[0]) / 2;
                    }
                }
                else
                {
                    numOrder = nowNumOrder + 0.001;
                }
            }
            #endregion

            WDTask.InsertStep(
                WDTask.DicTaskData[strNowTask].ID,
                numOrder,
                strStepName);

            initLvStep();
            gbAddStep.Visible = false;
        }
        private void cmsStepDelete_Click(object sender, EventArgs e)
        {
            if (lvStep.Items.Count == 0)
            {
                WTool.Popup("当前没有步骤");
                return;
            }
            if (lvStep.Items.Count > 0 && lvStep.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个步骤");
                return;
            }
            string strName = lvStep.SelectedItems[0].Text;
            WDTask.DeleteStep(WDTask.DicTaskData[strNowTask].DicStepData[strName].ID);

            initLvStep();
        }

        private void btnAddStepCancel_Click(object sender, EventArgs e)
        {
            gbAddStep.Visible = false;
        }
        private string strNowTask = "";
        private int iNowTaskID = -1;
        private ListViewGroup mHeaderStep;
        private void lvTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTask.FocusedItem != null)
            {
                strNowTask = lvTask.FocusedItem.Text;
                iNowTaskID = WDTask.DicTaskData[strNowTask].ID;
                initLvStep();
                initLvPrivate();
                initLvState();
                txtStepDetails.Text = "";
                gbNowStep.Text = "当前未选择步骤";
                strNowStep = "";//清空当前选择的步骤
                iNowStepID = -1;
            }
        }
        private void initLvStep()
        {
            if (WDTask.DicTaskData.ContainsKey(strNowTask))
            {
                if (lvStep.Groups.Count == 0)
                {
                    lvStep.Columns.Add("步骤名称", 140, HorizontalAlignment.Center);
                    //创建列表组名并添加
                    mHeaderStep = new ListViewGroup();
                    mHeaderStep.Header = "步骤名称";
                    mHeaderStep.HeaderAlignment = HorizontalAlignment.Center;
                    lvStep.Groups.Add(mHeaderStep);
                    lvStep.ShowGroups = true;
                    lvStep.HeaderStyle = ColumnHeaderStyle.None;
                }
                lvStep.Items.Clear();

                Dictionary<string, StepData> dicStepData = WDTask.DicTaskData[strNowTask].DicStepData;
                List<string> mPara = new List<string>();
                foreach (KeyValuePair<string, StepData> item in dicStepData)
                {
                    //添加数据
                    ListViewItem mLvi = new ListViewItem();
                    mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                    mLvi.Text = item.Key;
                    //添加到列表
                    mHeaderStep.Items.Add(mLvi);
                    lvStep.Items.Add(mLvi);
                    mPara.Add(item.Key);
                }
                if (dicTips.ContainsKey("任务步骤"))
                    dicTips["任务步骤"] = mPara;
                else
                    dicTips.Add("任务步骤", mPara);
                ConInitRTBData();
            }
        }
        private int iNowStepID = -1;
        private string strNowStep = "";
        private void lvStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStep.FocusedItem != null)
            {
                iNowStepID = WDTask.DicTaskData[strNowTask].DicStepData[lvStep.FocusedItem.Text].ID;
                txtStepDetails.Text = WDTask.DicTaskData[strNowTask].DicStepData[lvStep.FocusedItem.Text].StepDetails;
                strNowStep = lvStep.FocusedItem.Text;
                gbNowStep.Text = strNowTask + " >>> " + strNowStep;
            }
        }

        private void txtStepDetails_Leave(object sender, EventArgs e)
        {
            string strStepDetails = txtStepDetails.Text;
            if (strStepDetails.Length > 0 || iNowStepID != -1)
            {
                WDTask.UpdateStep(iNowStepID, strStepDetails);
                foreach (KeyValuePair<string, StepData> item in WDTask.DicTaskData[strNowTask].DicStepData)
                {
                    if (item.Value.ID == iNowStepID)
                    {
                        item.Value.StepDetails = strStepDetails;
                        break;
                    }
                }
            }
        }

        private void btnTaskCheck_Click(object sender, EventArgs e)
        {
            WCSScript.GenerateCode();
        }

        private void btnTaskStart_Click(object sender, EventArgs e)
        {
            if (strNowTask.Length == 0)
            {
                WTool.Popup("请先选择任务再运行");
                return;
            }
            WCSScript.TaskRun(strNowTask);
        }

        private void btnTaskStep_Click(object sender, EventArgs e)
        {
            if (strNowTask.Length == 0)
            {
                WTool.Popup("请先选择任务再运行");
                return;
            }
            if (strNowStep.Length == 0)
            {
                WTool.Popup("请先选择步骤再运行");
                return;
            }
            WCSScript.TaskStepRun(strNowTask, strNowStep);
        }
        private void btnTaskRow_Click(object sender, EventArgs e)
        {
            
        }
        #region 参数和状态的操作
        private void initLvPrivate()
        {
            lvTaskPrivate.Clear();
            lvTaskPrivate.Columns.Add("局部变量", 100, HorizontalAlignment.Center);

            //创建列表组名并添加
            ListViewGroup mHeader = new ListViewGroup();
            mHeader.Header = "局部变量";
            mHeader.HeaderAlignment = HorizontalAlignment.Center;
            lvTaskPrivate.Groups.Add(mHeader);
            lvTaskPrivate.ShowGroups = true;
            ListViewItem mLvi;

            List<string> mPara = new List<string>();
            foreach (TaskPara item in WDTask.ListTaskPrivate)
            {
                if(iNowTaskID == item.TaskID)
                {
                    //添加数据
                    mLvi = new ListViewItem();
                    mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                    mLvi.Text = item.Name;
                    //添加到列表
                    mHeader.Items.Add(mLvi);
                    lvTaskPrivate.Items.Add(mLvi);
                    mPara.Add(item.Name);
                }
            }
            lvTaskPrivate.HeaderStyle = ColumnHeaderStyle.None;
            if (dicTips.ContainsKey("局部变量"))
                dicTips["局部变量"] = mPara;
            else
                dicTips.Add("局部变量", mPara);
            ConInitRTBData();
        }
        private void cmsPrivateAdd_Click(object sender, EventArgs e)
        {
            if (iNowTaskID == -1)
            {
                WTool.Popup("请先选中任务，才能增加局部变量");
                return;
            }
            else if (lvTaskPrivate.Items.Count > 0 && lvTaskPrivate.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个局部变量");
                return;
            }
            gbAddPrivate.Visible = true;
        }

        private void cmsPrivateDelete_Click(object sender, EventArgs e)
        {
            if (lvTaskPrivate.Items.Count == 0)
            {
                WTool.Popup("当前没有局部变量");
                return;
            }
            if (lvTaskPrivate.Items.Count > 0 && lvTaskPrivate.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个局部变量");
                return;
            }
            string strName = lvTaskPrivate.SelectedItems[0].Text;
            WDTask.DeletePrivate(strName);
            initLvPrivate();
        }

        private void btnAddPrivateOK_Click(object sender, EventArgs e)
        {
            #region 参数名称校验
            string strPrivateName = txtAddPrivateName.Text;
            string strPrivateType = txtAddPrivateType.Text;
            if (strPrivateName.Contains("数字"))
            {
                WTool.Popup("参数名称不能包含“数字”");
                return;
            }
            else if (strPrivateName.Contains("字符"))
            {
                WTool.Popup("参数名称不能包含“字符”");
                return;
            }
            else if (strPrivateName.Contains("集合"))
            {
                WTool.Popup("参数名称不能包含“集合”");
                return;
            }
            else if (strPrivateType.Length == 0)
            {
                WTool.Popup("参数类型不能为空");
                return;
            }
            strPrivateName = strPrivateType + strPrivateName;
            if (WContTool.IsTrim(ref strPrivateName, "局部变量"))
                return;
            else if (IsNameRepeat(strPrivateName, "局部变量"))
                return;
            #endregion

            #region 获取排序的序号
            double numOrder = 0.001;
            if (lvTaskPrivate.SelectedItems.Count == 1)
            {
                string strName = lvTaskPrivate.SelectedItems[0].Text;
                double nowNumOrder = 0;
                foreach (TaskPara item in WDTask.ListTaskPrivate)
                {
                    if (item.Name.Equals(strName))
                    {
                        nowNumOrder = item.NumOrder;
                        break;
                    }
                }
                List<double> listNumOrder = new List<double>();
                //获取下一个数据的排序值并生成新的排序值
                foreach (TaskPara item in WDTask.ListTaskPrivate)
                {
                    if (item.TaskID == iNowTaskID && item.NumOrder > nowNumOrder)
                    {
                        listNumOrder.Add(item.NumOrder);
                    }
                }
                if (listNumOrder.Count > 0)
                {
                    listNumOrder.Sort();
                    if (listNumOrder[0] != 0)
                    {
                        numOrder = (nowNumOrder + listNumOrder[0]) / 2;
                    }
                }
                else
                {
                    numOrder = nowNumOrder + 0.001;
                }
            }
            #endregion

            WDTask.InsertPrivate(
                numOrder,
                iNowTaskID,
                strPrivateName);
            initLvPrivate();
            gbAddPrivate.Visible = false;
        }

        private void btnAddPrivateCancel_Click(object sender, EventArgs e)
        {
            gbAddPrivate.Visible = false;
        }

        private void initLvPublic()
        {
            lvTaskPublic.Clear();
            lvTaskPublic.Columns.Add("共有变量", 100, HorizontalAlignment.Center);

            //创建列表组名并添加
            ListViewGroup mHeader = new ListViewGroup();
            mHeader.Header = "共有变量";
            mHeader.HeaderAlignment = HorizontalAlignment.Center;
            lvTaskPublic.Groups.Add(mHeader);
            lvTaskPublic.ShowGroups = true;
            ListViewItem mLvi;

            List<string> mPara = new List<string>();
            foreach (KeyValuePair<double,string> item in WDTask.DicTaskPublic)
            {
                //添加数据
                mLvi = new ListViewItem();
                mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                mLvi.Text = item.Value;
                //添加到列表
                mHeader.Items.Add(mLvi);
                lvTaskPublic.Items.Add(mLvi);
                mPara.Add(item.Value);
            }
            lvTaskPublic.HeaderStyle = ColumnHeaderStyle.None;
            if (dicTips.ContainsKey("共有变量"))
                dicTips["共有变量"] = mPara;
            else
                dicTips.Add("共有变量", mPara);
            ConInitRTBData();
        }
        private void cmsPublicAdd_Click(object sender, EventArgs e)
        {
            if (lvTaskPublic.Items.Count > 0 && lvTaskPublic.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个共有变量");
                return;
            }
            gbAddPublic.Visible = true;
        }

        private void cmsPublicDelete_Click(object sender, EventArgs e)
        {
            if (lvTaskPublic.Items.Count == 0)
            {
                WTool.Popup("当前没有共有变量");
                return;
            }
            if (lvTaskPublic.Items.Count > 0 && lvTaskPublic.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个共有变量");
                return;
            }
            string strName = lvTaskPublic.SelectedItems[0].Text;
            WDTask.DeletePublic(strName);
            initLvPublic();
        }
        private void btnAddPublicOK_Click(object sender, EventArgs e)
        {
            #region 参数名称校验
            string strPublicName = txtAddPublicName.Text;
            string strPublicType = txtAddPublicType.Text;
            if (strPublicName.Contains("数字"))
            {
                WTool.Popup("参数名称不能包含“数字”");
                return;
            }
            else if (strPublicName.Contains("字符"))
            {
                WTool.Popup("参数名称不能包含“字符”");
                return;
            }
            else if (strPublicName.Contains("集合"))
            {
                WTool.Popup("参数名称不能包含“集合”");
                return;
            }
            else if (strPublicType.Length == 0)
            {
                WTool.Popup("参数类型不能为空");
                return;
            }
            strPublicName = strPublicType + strPublicName;
            if (WContTool.IsTrim(ref strPublicName, "共有变量"))
                return;
            else if (IsNameRepeat(strPublicName,"共有变量"))
                return;
            #endregion

            #region 获取排序的序号
            double numOrder = 0.001;
            if (lvTaskPublic.SelectedItems.Count == 1)
            {
                string strName = lvTaskPublic.SelectedItems[0].Text;
                double nowNumOrder = 0;
                foreach (KeyValuePair<double,string> item in WDTask.DicTaskPublic)
                {
                    if (item.Value.Equals(strName))
                    {
                        nowNumOrder = item.Key;
                        break;
                    }
                }
                List<double> listNumOrder = new List<double>();
                //获取下一个数据的排序值并生成新的排序值
                foreach (KeyValuePair<double, string> item in WDTask.DicTaskPublic)
                {
                    if (item.Key > nowNumOrder)
                    {
                        listNumOrder.Add(item.Key);
                    }
                }
                if (listNumOrder.Count > 0)
                {
                    listNumOrder.Sort();
                    if (listNumOrder[0] != 0)
                    {
                        numOrder = (nowNumOrder + listNumOrder[0]) / 2;
                    }
                }
                else
                {
                    numOrder = nowNumOrder + 0.001;
                }
            }
            #endregion

            WDTask.InsertPublic(
                numOrder,
                strPublicName);
            initLvPublic();
            gbAddPublic.Visible = false;
        }

        private void btnAddPublicCancel_Click(object sender, EventArgs e)
        {
            gbAddPublic.Visible = false;
        }
        private void initLvState()
        {
            lvTaskState.Clear();
            lvTaskState.Columns.Add("任务状态", 100, HorizontalAlignment.Center);

            //创建列表组名并添加
            ListViewGroup mHeader = new ListViewGroup();
            mHeader.Header = "任务状态";
            mHeader.HeaderAlignment = HorizontalAlignment.Center;
            lvTaskState.Groups.Add(mHeader);
            lvTaskState.ShowGroups = true;
            ListViewItem mLvi;

            List<string> mPara = new List<string>();
            foreach (TaskPara item in WDTask.ListTaskState)
            {
                if (iNowTaskID == item.TaskID)
                {
                    //添加数据
                    mLvi = new ListViewItem();
                    mLvi.UseItemStyleForSubItems = false;//设置可以改变单元格背景颜色
                    mLvi.Text = item.Name;
                    //添加到列表
                    mHeader.Items.Add(mLvi);
                    lvTaskState.Items.Add(mLvi);
                    mPara.Add(item.Name);
                    mPara.Add("设置"+item.Name);
                }
            }
            lvTaskState.HeaderStyle = ColumnHeaderStyle.None;
            if (dicTips.ContainsKey(strNowTask))
                dicTips[strNowTask] = mPara;
            else
                dicTips.Add(strNowTask, mPara);
            ConInitRTBData();
        }

        private void cmsStateAdd_Click(object sender, EventArgs e)
        {
            if (iNowTaskID == -1)
            {
                WTool.Popup("请先选中任务，才能增加任务状态");
                return;
            }
            if (lvTaskState.Items.Count > 0 && lvTaskState.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个任务状态");
                return;
            }
            gbAddState.Visible = true;
        }

        private void cmsStateDelete_Click(object sender, EventArgs e)
        {
            if(lvTaskState.Items.Count == 0)
            {
                WTool.Popup("当前没有任务状态");
                return;
            }
            if (lvTaskState.Items.Count > 0 && lvTaskState.SelectedItems.Count != 1)
            {
                WTool.Popup("请先选中一个任务状态");
                return;
            }
            string strName = lvTaskState.SelectedItems[0].Text;
            WDTask.DeleteState(strName);
            initLvState();
        }
        private void btnAddStateOK_Click(object sender, EventArgs e)
        {
            #region 名称重复检测
            string strStateName = txtAddStateName.Text.ToString();
            if (strStateName.IndexOf("状态") != 0)
                strStateName = "状态" +strStateName;
            if (WContTool.IsTrim(ref strStateName, "任务状态"))
                return;
            else if (IsNameRepeat(strStateName, "任务状态"))
                return;
            #endregion

            #region 获取排序的序号
            double numOrder = 0.001;
            if (lvTaskState.SelectedItems.Count == 1)
            {
                string strName = lvTaskState.SelectedItems[0].Text;
                double nowNumOrder = 0;
                foreach (TaskPara item in WDTask.ListTaskState)
                {
                    if (item.Name.Equals(strName))
                    {
                        nowNumOrder = item.NumOrder;
                        break;
                    }
                }
                List<double> listNumOrder = new List<double>();
                //获取下一个数据的排序值并生成新的排序值
                foreach (TaskPara item in WDTask.ListTaskState)
                {
                    if (item.TaskID == iNowTaskID && item.NumOrder > nowNumOrder)
                    {
                        listNumOrder.Add(item.NumOrder);
                    }
                }
                if (listNumOrder.Count > 0)
                {
                    listNumOrder.Sort();
                    if (listNumOrder[0] != 0)
                    {
                        numOrder = (nowNumOrder + listNumOrder[0]) / 2;
                    }
                }
                else
                {
                    numOrder = nowNumOrder + 0.001;
                }
            }
            #endregion

            WDTask.InsertState(
                numOrder,
                iNowTaskID,
                strStateName);
            initLvState();
            gbAddState.Visible = false;
        }

        private void btnAddStateCancel_Click(object sender, EventArgs e)
        {
            gbAddState.Visible = false;
        }

        /// <summary>
        /// 检查名称是否重复，重复的话弹窗并返回true
        /// </summary>
        /// <param name="name">检查的名称</param>
        /// <param name="where">该名称在哪里来的</param>
        /// <returns></returns>
        private bool IsNameRepeat(string name, string where)
        {
            foreach (KeyValuePair<string, TaskData> item in WDTask.DicTaskData)
            {
                if (item.Key.Equals(name))
                {
                    WTool.Popup("该" + where + "名称已经存在任务(列表)名称里面，请重新命名");
                    return true;
                }
                foreach (KeyValuePair<string, StepData> itemStep in item.Value.DicStepData)
                {
                    if (itemStep.Key.Equals(name))
                    {
                        WTool.Popup("该" + where + "名称已经存在任务步骤(列表)名称里面，请重新命名");
                        return true;
                    }
                }
            }
            foreach (TaskPara item in WDTask.ListTaskPrivate)
            {
                if (item.Name.Equals(name))
                {
                    WTool.Popup("该" + where + "名称已经存在本任务或其他任务的局部变量里面，请重新命名");
                    return true;
                }
            }
            foreach (KeyValuePair<double, string> item in WDTask.DicTaskPublic)
            {
                if (item.Value.Equals(name))
                {
                    WTool.Popup("该" + where + "名称已经存在共有变量里面，请重新命名");
                    return true;
                }
            }
            foreach (TaskPara item in WDTask.ListTaskState)
            {
                if (item.Name.Equals(name))
                {
                    WTool.Popup("该" + where + "名称已经存在本任务或其他任务的共有变量里面，请重新命名");
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region 点位，输入，输出和轴列表的显示
        #region 点位列表的显示
        private void InitViewCPoint()
        {
            TabControl mTabControl;
            int iTabControlNum = this.Controls.Find("mTabControlCPoint", true).Length;
            if (iTabControlNum == 0)
            {
                mTabControl = new TabControl();
                mTabControl.Name = "mTabControlCPoint";
                mTabControl.SelectedIndex = 0;
                mTabControl.Dock = DockStyle.Fill;
            }
            else
            {
                mTabControl = this.Controls.Find("mTabControlCPoint", true)[0] as TabControl;
                mTabControl.Controls.Clear();
            }
            Dictionary<string, List<PointMain>> dicListAxis = WDPoint.getDicPointMain;
            List<string> mParaPoint = new List<string>();
            foreach (KeyValuePair<string, List<PointMain>> itemGroup in dicListAxis)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Name = "tp_" + itemGroup.Key + "CPoint";
                mTabPage.Padding = new Padding(3);
                mTabPage.Text = itemGroup.Key;
                mTabPage.UseVisualStyleBackColor = true;
                mTabPage.Controls.Add(CreaterDGVCPoint(itemGroup.Key + "CPoint", itemGroup.Value,ref mParaPoint));
                mTabControl.Controls.Add(mTabPage);
            }
            dicTips.Add("点位名称", mParaPoint);
            tabCPoint.Controls.Add(mTabControl);
        }
        private DataGridView CreaterDGVCPoint(string name, List<PointMain> paraPos,ref List<string> mParaPoint)
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgv_" + name;
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("名称", Type.GetType("System.String"));

            dt.Columns["名称"].ReadOnly = true;

            dgvParaConfig.AllowUserToAddRows = false;
            dgvParaConfig.AllowUserToDeleteRows = false;
            dgvParaConfig.RowHeadersVisible = false;
            dgvParaConfig.ColumnHeadersVisible = false;

            //添加显示的数据
            if (paraPos != null)
            {
                //key,序号_value_提示
                foreach (PointMain item in paraPos)
                {
                    DataRow mRow = dt.NewRow();
                    mRow[0] = item.PointName;
                    dt.Rows.Add(mRow);
                    mParaPoint.Add(item.PointName);
                }
            }
            dgvParaConfig.DataSource = dt;
            //禁止排序
            foreach (DataGridViewColumn item in dgvParaConfig.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ((ISupportInitialize)(dgvParaConfig)).EndInit();

            return dgvParaConfig;
        }
        #endregion
        #region 输入列表的显示
        private void InitViewCDI()
        {
            TabControl mTabControl;
            int iTabControlNum = this.Controls.Find("mTabControlCDI", true).Length;
            if (iTabControlNum == 0)
            {
                mTabControl = new TabControl();
                mTabControl.Name = "mTabControlCDI";
                mTabControl.SelectedIndex = 0;
                mTabControl.Dock = DockStyle.Fill;
            }
            else
            {
                mTabControl = this.Controls.Find("mTabControlCDI", true)[0] as TabControl;
                mTabControl.Controls.Clear();
            }
            Dictionary<string, List<DIData>> dicListAxis = WDCard.DicListDI;
            List<string> mParaDI = new List<string>();
            foreach (KeyValuePair<string, List<DIData>> itemGroup in dicListAxis)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Name = "tp_" + itemGroup.Key + "CDI";
                mTabPage.Padding = new Padding(3);
                mTabPage.Text = itemGroup.Key;
                mTabPage.UseVisualStyleBackColor = true;
                mTabPage.Controls.Add(CreaterDGVCDI(itemGroup.Key + "CDI", itemGroup.Value, ref mParaDI));
                mTabControl.Controls.Add(mTabPage);
            }
            dicTips.Add("输入信号", mParaDI);
            tabCDI.Controls.Add(mTabControl);
        }
        private DataGridView CreaterDGVCDI(string name, List<DIData> paraPos,ref List<string> mParaDI)
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgv_" + name;
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("名称", Type.GetType("System.String"));

            dt.Columns["名称"].ReadOnly = true;

            dgvParaConfig.AllowUserToAddRows = false;
            dgvParaConfig.AllowUserToDeleteRows = false;
            dgvParaConfig.RowHeadersVisible = false;
            dgvParaConfig.ColumnHeadersVisible = false;

            //添加显示的数据
            if (paraPos != null)
            {
                //key,序号_value_提示
                foreach (DIData item in paraPos)
                {
                    DataRow mRow = dt.NewRow();
                    mRow[0] = item.Name;
                    dt.Rows.Add(mRow);
                    mParaDI.Add(item.Name);
                }
            }
            dgvParaConfig.DataSource = dt;
            //禁止排序
            foreach (DataGridViewColumn item in dgvParaConfig.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ((ISupportInitialize)(dgvParaConfig)).EndInit();

            return dgvParaConfig;
        }
        #endregion
        #region 输出列表的显示
        private void InitViewCDO()
        {
            TabControl mTabControl;
            int iTabControlNum = this.Controls.Find("mTabControlCDO", true).Length;
            if (iTabControlNum == 0)
            {
                mTabControl = new TabControl();
                mTabControl.Name = "mTabControlCDO";
                mTabControl.SelectedIndex = 0;
                mTabControl.Dock = DockStyle.Fill;
            }
            else
            {
                mTabControl = this.Controls.Find("mTabControlCDO", true)[0] as TabControl;
                mTabControl.Controls.Clear();
            }
            Dictionary<string, List<DOData>> dicListAxis = WDCard.DicListDO;
            List<string> mParaDO = new List<string>();
            foreach (KeyValuePair<string, List<DOData>> itemGroup in dicListAxis)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Name = "tp_" + itemGroup.Key + "CDO";
                mTabPage.Padding = new Padding(3);
                mTabPage.Text = itemGroup.Key;
                mTabPage.UseVisualStyleBackColor = true;
                mTabPage.Controls.Add(CreaterDGVCDO(itemGroup.Key + "CDO", itemGroup.Value,ref mParaDO));
                mTabControl.Controls.Add(mTabPage);
            }
            dicTips.Add("输出信号", mParaDO);
            tabCDO.Controls.Add(mTabControl);
        }
        private DataGridView CreaterDGVCDO(string name, List<DOData> paraPos,ref List<string> mParaDO)
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgv_" + name;
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("名称", Type.GetType("System.String"));

            dt.Columns["名称"].ReadOnly = true;

            dgvParaConfig.AllowUserToAddRows = false;
            dgvParaConfig.AllowUserToDeleteRows = false;
            dgvParaConfig.RowHeadersVisible = false;
            dgvParaConfig.ColumnHeadersVisible = false;

            //添加显示的数据
            if (paraPos != null)
            {
                //key,序号_value_提示
                foreach (DOData item in paraPos)
                {
                    DataRow mRow = dt.NewRow();
                    mRow[0] = item.Name;
                    dt.Rows.Add(mRow);
                    mParaDO.Add(item.Name);
                }
            }
            dgvParaConfig.DataSource = dt;
            //禁止排序
            foreach (DataGridViewColumn item in dgvParaConfig.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ((ISupportInitialize)(dgvParaConfig)).EndInit();

            return dgvParaConfig;
        }
        #endregion
        #region 轴列表的显示
        private void InitViewCAxis()
        {
            TabControl mTabControl;
            int iTabControlNum = this.Controls.Find("mTabControlCAxis", true).Length;
            if (iTabControlNum == 0)
            {
                mTabControl = new TabControl();
                mTabControl.Name = "mTabControlCAxis";
                mTabControl.SelectedIndex = 0;
                mTabControl.Dock = DockStyle.Fill;
            }
            else
            {
                mTabControl = this.Controls.Find("mTabControlCAxis", true)[0] as TabControl;
                mTabControl.Controls.Clear();
            }
            Dictionary<string, List<AxisData>> dicListAxis = WDCard.DicListAxis;
            List<string> mParaAxis = new List<string>();
            foreach (KeyValuePair<string, List<AxisData>> itemGroup in dicListAxis)
            {
                TabPage mTabPage = new TabPage();
                mTabPage.Name = "tp_" + itemGroup.Key + "CAxis";
                mTabPage.Padding = new Padding(3);
                mTabPage.Text = itemGroup.Key;
                mTabPage.UseVisualStyleBackColor = true;
                mTabPage.Controls.Add(CreaterDGVCAxis(itemGroup.Key + "CAxis", itemGroup.Value,ref mParaAxis));
                mTabControl.Controls.Add(mTabPage);
            }
            dicTips.Add("轴数据", mParaAxis);
            tabCAxis.Controls.Add(mTabControl);
        }
        private DataGridView CreaterDGVCAxis(string name, List<AxisData> paraPos,ref List<string> mParaAxis)
        {
            //参数列表初始化
            DataGridView dgvParaConfig = new DataGridView();
            dgvParaConfig.AllowUserToResizeRows = false;
            dgvParaConfig.Dock = DockStyle.Fill;
            dgvParaConfig.Name = "dgv_" + name;
            dgvParaConfig.RowTemplate.Height = 23;
            dgvParaConfig.ClearSelection();//取消默认选中效果
            //参数行数据初始化
            DataTable dt = new DataTable();
            dt.Columns.Add("名称", Type.GetType("System.String"));

            dt.Columns["名称"].ReadOnly = true;

            dgvParaConfig.AllowUserToAddRows = false;
            dgvParaConfig.AllowUserToDeleteRows = false;
            dgvParaConfig.RowHeadersVisible = false;
            dgvParaConfig.ColumnHeadersVisible = false;

            //添加显示的数据
            if (paraPos != null)
            {
                //key,序号_value_提示
                foreach (AxisData item in paraPos)
                {
                    DataRow mRow = dt.NewRow();
                    mRow[0] = item.Name;
                    dt.Rows.Add(mRow);
                    mParaAxis.Add(item.Name);
                }
            }
            dgvParaConfig.DataSource = dt;
            //禁止排序
            foreach (DataGridViewColumn item in dgvParaConfig.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvParaConfig.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ((ISupportInitialize)(dgvParaConfig)).EndInit();

            return dgvParaConfig;
        }
        #endregion

        #endregion
        #region 编辑框的功能
        private ListBox lbAutoComplete ;
        private List<AutoCompleteData> mAutoCompleteData = new List<AutoCompleteData>();
        private void ConInitRTB()
        {
            lbAutoComplete = new ListBox();
            lbAutoComplete.KeyDown += (e, r) =>
            {
                if (r.KeyCode == Keys.Escape)//ESC按钮
                {
                    lbAutoComplete.Items.Clear();
                    lbAutoComplete.Hide();
                    lbAutoComplete.Focus();
                }
                else if (r.KeyCode == Keys.Enter)
                {
                    int cursorPosition = txtStepDetails.SelectionStart;
                    if (cursorPosition == 0) return;
                    string text = lbAutoComplete.SelectedItem as string;
                    txtStepDetails.SelectionStart = cursorPosition - strScreen.Length;
                    txtStepDetails.SelectionLength = strScreen.Length;
                    txtStepDetails.SelectedText = text ?? "";
                }
            };
            lbAutoComplete.Hide();
        }
        private void ConInitRTBData()
        {
            #region 整理数据
            mAutoCompleteData.Clear();
            foreach (KeyValuePair<string, List<string>> item in dicTips)
            {
                foreach (string itemSon in item.Value)
                    mAutoCompleteData.Add(new AutoCompleteData(WContTool.GetSpellCode(itemSon), itemSon));
            }
            #endregion
        }
        private void txtStepDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;//屏蔽Ctrl+ V组合按键
                txtStepDetails.Paste(DataFormats.GetFormat(DataFormats.Text));
            }
            if (lbAutoComplete.Visible)
            {
                if (e.KeyCode == Keys.Down)
                {
                    int iNow = lbAutoComplete.SelectedIndex;
                    if (iNow < lbAutoComplete.Items.Count - 1)
                        lbAutoComplete.SelectedIndex = iNow + 1;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int iNow = lbAutoComplete.SelectedIndex;
                    if (iNow > 0)
                        lbAutoComplete.SelectedIndex = iNow - 1;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    int cursorPosition = txtStepDetails.SelectionStart;
                    if (cursorPosition == 0) return;
                    string text = lbAutoComplete.SelectedItem as string;
                    txtStepDetails.SelectionStart = cursorPosition - strScreen.Length;
                    txtStepDetails.SelectionLength = strScreen.Length;
                    txtStepDetails.SelectedText = text ?? "";
                    e.Handled = true;
                }
            }
        }
        private string strScreen = string.Empty;
        private void txtStepDetails_TextChanged(object sender, EventArgs e)
        {
            Thread.Sleep(100);//当为按下删除按钮时，延迟100毫秒等待筛选字符串重新整理
            int iTotal = txtStepDetails.SelectionStart;
            if (iTotal > 0)
            {
                strScreen = string.Empty;
                for (int i = iTotal - 1 ; i >= 0; i--)
                {
                    var varLast = txtStepDetails.Text[i];
                    if (varLast.Equals('('))
                    {
                        break;
                    }
                    if (WContTool.IsLetterOrNumber(varLast.ToString()))
                        strScreen = varLast + strScreen;
                    else
                        break;
                }
                
                if (strScreen.Length == 0)
                {
                    lbAutoComplete.Hide();
                    return;
                }
                else
                    PopulateListBox(strScreen);
                
            }
        }
        [DllImport("user32")]
        private static extern int GetCaretPos(out Point p);
        private Point nowPoint;
        private void PopulateListBox(string mKey)
        {
            lbAutoComplete.Items.Clear();
            var list = mAutoCompleteData.Where(p => p.Key.StartsWith(mKey));

            GetCaretPos(out nowPoint);
            lbAutoComplete.SetBounds(nowPoint.X, nowPoint.Y + 15, 150, (list.Count() * 13) + 13);

            foreach (var item in list)
            {
                if (item.Key.StartsWith(mKey))
                    lbAutoComplete.Items.Add(item.Value);

            }

            if (lbAutoComplete.Items.Count == 0)
                lbAutoComplete.Hide();
            else
            {
                lbAutoComplete.SelectedIndex = -1;
                lbAutoComplete.Show();
                lbAutoComplete.Parent = txtStepDetails;
            }
        }
        #endregion

    }
    class AutoCompleteData
    {
        public AutoCompleteData(string key,string value)
        {
            this.key = key;
            this.value = value;
        }
        private string key = string.Empty;
        private string value = string.Empty;
        public string Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
