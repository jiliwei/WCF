using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            #region 选项卡名称高度设置
            tcMainPage.ItemSize = new Size(new Point(40, 1));
            #endregion
            #region 隐藏相应的按钮
            panelLogin.Visible = false;
            btnData.Visible = false;
            btnDebug.Visible = false;
            btnHome.Visible = false;
            #endregion
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {
            #region 选项卡名称隐藏
            tcMainPage.Region = new Region(new RectangleF(
                tcMainPageHome.Left,
                tcMainPageHome.Top,
                tcMainPageHome.Width,
                tcMainPageHome.Height));
            #endregion
            #region 数据库初始化
            if (WData.OpenSqlite() != 0)
            {
                WTool.Popup("数据库文件异常");
            }
            #endregion
            #region 相关控件初始化
            //初始化卡参数编辑控件
            wcfCard.ConInit();
            wcfLog.ConInit();
            wcfPara.ConInit();
            wcfPoint.ConInit();
            wcfHome.ConInit();
            wcfSocket.ConInit();
            wcfSerial.ConInit();
            #endregion
            #region 调试功能有关初始化
            initLvTask();
            wcfDebug.ConInit();
            #endregion
            UpdatePriLevel("管理员");//调试时先默认管理员权限
        }
        #region 按钮事件
        #region 程序顶部功能区按钮事件
        #region 窗口拖动
        Point mPoint;
        private void btnMoveWin_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void btnMoveWin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion
        private void btnCloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            cbPermissions.Text = "";
            txtLoginPassword.Text = "";
            panelLogin.Visible = true;
        }

        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
        }
        private void cbPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbPermissions.Text;
            if (name.Equals("操作员"))
                UpdatePriLevel(name);
        }

        private void btnLoginOK_Click(object sender, EventArgs e)
        {
            string name = cbPermissions.Text;
            if (tsslPermissions.Text.Length == 0)
            {
                WTool.Popup("请先选择账号类型，再登入");
                return;
            }
            WDSysPara.SelectSysPara();
            foreach (SysPara item in WDSysPara.listSysPara)
            {
                if (item.Name.Equals(name))
                {
                    if (item.Value.Equals(txtLoginPassword.Text))
                    {
                        UpdatePriLevel(name);
                        return;
                    }
                }
            }

            WTool.Popup("密码错误");
            return;
        }
        private void UpdatePriLevel(string name)
        {
            if (name.Equals("操作员"))
            {
                panelLogin.Visible = false;
                btnData.Visible = false;
                btnDebug.Visible = false;
                btnHome.Visible = false;

                tsslPermissions.Text = "操作员";
                WData.iPriLevel = 0;
                tcMainPage.SelectedIndex = 0;
                //关闭相应的窗口
                MonitorAxisPage.ClosePage();
                MonitorDIPage.ClosePage();
                MonitorDOPage.ClosePage();
                ProcessDevePage.ClosePage();
                SystemSetPage.ClosePage();
            }
            if (name.Equals("技术员"))
            {
                panelLogin.Visible = false;
                btnData.Visible = true;
                btnDebug.Visible = true;
                btnHome.Visible = true;

                tsslPermissions.Text = "技术员";
                WData.iPriLevel = 1;
            }
            if (name.Equals("管理员"))
            {
                panelLogin.Visible = false;
                btnData.Visible = true;
                btnDebug.Visible = true;
                btnHome.Visible = true;

                tsslPermissions.Text = "管理员";
                WData.iPriLevel = 2;
            }
            wcfPara.ConInit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            tcMainPage.SelectedIndex = 0;
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            tcMainPage.SelectedIndex = 1;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            tcMainPage.SelectedIndex = 2;
        }
        #endregion
        #region 调试功能区按钮事件
        private void btnMonitorAxis_Click(object sender, EventArgs e)
        {
            MonitorAxisPage.ShowPage();
        }

        private void btnMonitorIn_Click(object sender, EventArgs e)
        {
            MonitorDIPage.ShowPage();
        }

        private void btnMonitorOn_Click(object sender, EventArgs e)
        {
            MonitorDOPage.ShowPage();
        }

        private void btnProcessDeve_Click(object sender, EventArgs e)
        {
            ProcessDevePage.ShowPage();
        }

        private void btnSystemSet_Click(object sender, EventArgs e)
        {
            SystemSetPage.ShowPage();
        }
        #endregion
        #endregion
        private int iPopupNum = 0;
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            #region 弹窗个数提示
            iPopupNum = 0;
            FormCollection mFormCollection = Application.OpenForms;
            foreach (Form item in mFormCollection)
            {
                if (item.Name.Equals("ShowPopup"))
                {
                    iPopupNum++;
                }
            }
            if (iPopupNum != 0)
                tsslPopupNum.Text = "弹窗个数：" + iPopupNum.ToString();
            else
                tsslPopupNum.Text = "";
            #endregion
            #region 运行状态刷新
            txtRunMode.Text = WDPublic.runState.ToString();
            if (txtRunMode.Text.Equals(RunState.急停.ToString()))
                txtRunMode.BackColor = Color.Red;
            else if (txtRunMode.Text.Equals(RunState.正在工作.ToString()))
                txtRunMode.BackColor = Color.GreenYellow;
            else if (txtRunMode.Text.Equals(RunState.正在复位.ToString()))
                txtRunMode.BackColor = Color.GreenYellow;
            else if (txtRunMode.Text.Equals(RunState.暂停中.ToString()))
                txtRunMode.BackColor = Color.Yellow;
            else
                txtRunMode.BackColor = SystemColors.Info;
            #endregion
        }
        #region 调试功能有关

        private void initLvTask()
        {

            lvTask.Columns.Add("任务名称", 100, HorizontalAlignment.Center);

            ListViewGroup mHeader = new ListViewGroup();
            ListViewItem mLvi;

            string mTaskType = "";
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
            }
            lvTask.HeaderStyle = ColumnHeaderStyle.None;

        }
        #endregion

        private void lvTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTask.FocusedItem != null)
            {
                wcfDebug.ConInit(lvTask.FocusedItem.Text);
            }
        }
        #region 首页操作按钮（复位，启动，暂停，急停）
        private void btnSuspend_Click(object sender, EventArgs e)
        {
            WDLog.InsertLog("按钮点击", 0, "操作记录", "首页点击急停");
            WDPublic.runState = RunState.急停;
            WCSScript.TaskDispose();//释放资源
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            WDLog.InsertLog("按钮点击", 0, "操作记录", "首页点击暂停");
            if (WDPublic.runState != RunState.正在工作)
            {
                WTool.PopupShow("当设备为“正在工作”才能暂停设备");
                return;
            }
            WDPublic.runState = RunState.暂停中;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            WDLog.InsertLog("按钮点击", 0, "操作记录", "首页点击开始启动");
            if (WDPublic.runState != RunState.复位完成 && WDPublic.runState != RunState.暂停中)
            {
                WTool.PopupShow("当设备为“复位完成”或“暂停中”才能启动设备");
                return;
            }
            if (WDPublic.runState == RunState.复位完成)
            {
                foreach (KeyValuePair<string, TaskData> item in WDTask.DicTaskData)
                {
                    if (item.Value.TaskType.Equals("生产任务"))
                        WCSScript.TaskRun(item.Value.TaskName);
                }
            }
            WDPublic.runState = RunState.正在工作;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            WDLog.InsertLog("按钮点击", 0, "操作记录", "首页点击复位");
            if (WDPublic.runState != RunState.未复位 && WDPublic.runState != RunState.急停)
            {
                WTool.PopupShow("当设备为“未复位”或“急停”才能复位设备");
                return;
            }
            //等待急停(正常工作时，在进行急停，需要延迟1秒等待任务都结束才能释放资源，这里怎么做是防止点了急停就立马点复位)
            if (WCSScript.TaskState() == 1)
                Thread.Sleep(1000);//延迟等待，等待急停，资源释放
            foreach (KeyValuePair<string, TaskData> item in WDTask.DicTaskData)
            {
                if (item.Value.TaskType.Equals("复位任务"))
                    WCSScript.TaskRun(item.Value.TaskName);
            }
            WDPublic.runState = RunState.正在复位;
            Task.Run(() =>
            {
                while (true)
                {
                    if (WCSScript.TaskState() == 0)
                    {
                        WCSScript.TaskDispose();//复位完成，释放资源
                        WDPublic.runState = RunState.复位完成;
                        WDLog.InsertLog("流程运行", 0, "设备复位", "复位完成");
                        return;
                    }
                    Task.Delay(100);
                }
            });
        }
        #endregion
    }
}
