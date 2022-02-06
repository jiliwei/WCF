﻿
using System.Drawing;
using System.Windows.Forms;

namespace WCF
{
    public partial class ProcessDevePage : Form
    {
        public ProcessDevePage()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.ProcessDevePage.GetHicon());
            wcfTask.ConInit();
        }
        private static ProcessDevePage instance = null;
        public static void ShowPage()
        {
            if (instance == null || instance.IsDisposed)//未打开或已经被释放则重新打开窗口
            {
                instance = new ProcessDevePage();
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