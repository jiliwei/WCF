using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace WCF
{
    /// 类 	  名：WTool
	/// 类 描 述：常用工具类
	/// WCF·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public class WTool
    {
        /// <summary>
        /// 弹窗确认按钮弹窗
        /// </summary>
        /// <param name="strContent">内容</param>
        /// <param name="strTitle">标题</param>
        /// <param name="iLevel">日志等级</param>
        public static void Popup(string strContent, string strTitle = "提    示",int iLevel = 0)
        {
            ShowPopup mShowPopup = new ShowPopup(strContent, strTitle, iLevel,  1);
            mShowPopup.ShowDialog();
        }
        /// <summary>
        /// 弹窗确认按钮弹窗(不卡线程)
        /// </summary>
        /// <param name="strContent">内容</param>
        /// <param name="strTitle">标题</param>
        /// <param name="iLevel">日志等级</param>
        public static void PopupShow(string strContent, string strTitle = "提    示", int iLevel = 0)
        {
            ShowPopup mShowPopup = new ShowPopup(strContent, strTitle, iLevel, 1);
            mShowPopup.Show();
        }
        /// <summary>
        /// 弹窗确认和取消按钮弹窗
        /// </summary>
        /// <param name="strContent">内容</param>
        /// <param name="strTitle">标题</param>
        /// <param name="iLevel">日志等级</param>
        public static DialogResult PopupOKCancel(string strContent, string strTitle = "提    示", int iLevel = 0)
        {
            ShowPopup mShowPopup = new ShowPopup(strContent, strTitle, iLevel, 2);
            return mShowPopup.ShowDialog();
        }
        /// <summary>
        /// 弹窗确认、重试和取消按钮弹窗
        /// </summary>
        /// <param name="strContent">内容</param>
        /// <param name="strTitle">标题</param>
        /// <param name="iLevel">日志等级</param>
        public static DialogResult PopupRetry(string strContent, string strTitle = "提    示", int iLevel = 0)
        {
            ShowPopup mShowPopup = new ShowPopup(strContent, strTitle, iLevel, 3);
            return mShowPopup.ShowDialog();
        }
        /// <summary>
        /// 延迟
        /// </summary>
        /// <param name="i"></param>
        public static void Sleep(int i)
        {
            Thread.Sleep(i);
            Application.DoEvents();
        }

    }
}
