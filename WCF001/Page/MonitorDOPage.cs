
using System.Drawing;
using System.Windows.Forms;

namespace WCF
{
    public partial class MonitorDOPage : Form
    {
        public MonitorDOPage()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.MonitorDOPage.GetHicon());
            wcfDO.ConInit();
        }
        private static MonitorDOPage instance = null;
        public static void ShowPage()
        {
            if (instance == null || instance.IsDisposed)//未打开或已经被释放则重新打开窗口
            {
                instance = new MonitorDOPage();
                instance.Show();
            }
            else if (instance.WindowState == FormWindowState.Minimized)//窗口最小化时重新显示窗口
                instance.WindowState = FormWindowState.Normal;
            else//窗口被主界面遮挡时，重新显示窗口
                instance.BringToFront();
        }
        public static void ClosePage()
        {
            if (instance != null)
                instance.Close();
        }
    }
}
