using System;
using System.Windows.Forms;

namespace WCF
{
    public partial class WCFMain : Form
    {
        public WCFMain()
        {
            InitializeComponent();
        }
        WDataToolClass mWDataToolClass;
        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void WCFMain_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
            mWDataToolClass = new WDataToolClass();
            int rtn = 0;
            rtn = mWDataToolClass.CheckAndOpenDataFile();
            if (rtn != 0)
            {
                MessageBox.Show("mWDataToolClass.CheckAndOpenDataFile()");
            }
            //初始化卡参数编辑控件
            wcfCardEdit.ConInit(mWDataToolClass);
            //初始化轴界面
            lvWcfAxis.ConInit(mWDataToolClass);//先参数轴数据才能初始化参数
            //初始化输入界面
            lvWcfDI.ConInit(mWDataToolClass);
            //初始化输出界面
            lvWcfDO.ConInit(mWDataToolClass);
            //初始化设备参数编辑控件（并给赋值当前参数表mParameter，）
            wcfDataPata.ConInit(mWDataToolClass);
            //卡工具类数据库操作参数设置(必须在wcfDataPata.ConInit之后，)
            WCardToolClass.mWDataToolClass = mWDataToolClass;
            WCardToolClass.InitOpenCard();
            //初始化设备参数控件
            wcfDataGroup.ConInit(mWDataToolClass);
            //初始化机种选择
            wcfDataType.ConInit(mWDataToolClass, false);
            //初始化流程控件
            wcfAutoScript.ConInit();
        }

        private void WCFMain_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }

        private void wcfDataType_DataUpdateClick(object sender, EventArgs e)
        {
            //初始化设备参数控件
            wcfDataGroup.ConInit(mWDataToolClass);
        }

        public static WCFAbout mWCFAbout = null;
        private void btnWCFAbout_Click(object sender, EventArgs e)
        {
            if (mWCFAbout == null)
            {
                mWCFAbout = new WCFAbout();
                mWCFAbout.StartPosition = FormStartPosition.CenterScreen;
                mWCFAbout.Show();
            }
            else
            {
                mWCFAbout.Activate();
                mWCFAbout.WindowState = FormWindowState.Normal;
            }
        }

        private void WCFMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            wcfAutoScript.Clear();//关闭已经开启的线程
            //创建常量类，开发期间使用。
            //打开软件增加好参数后，退出软件，就把常量类复制过来覆盖旧文件就进行开发程序；
            //避免了常量类增加参数名字后又去软件增加参数，从而提高效率
            mWDataToolClass.GeneratingClass();

            System.Environment.Exit(0);
            this.Dispose();
            this.Close();
        }
    }
}
