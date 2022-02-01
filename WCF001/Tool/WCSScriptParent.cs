using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF;

namespace WCF
{
    /// 类 	  名：WCSScriptParent
	/// 类 描 述：WCSScript的部分父类，还有一部分是代码生成（主要内容是参数名称）
	/// WCF·769838889@qq.com
	/// 创建时间：2021/11/02
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCSScriptParent
    {
        #region 检查函数，每一步运行都会执行一次
        /// <summary>
        /// 步骤运行检查，正常返回false，异常返回true
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public static bool stepCheckTry(string taskName, string stepName)
        {
            WDLog.InsertLog("流程运行", 1, taskName, "执行步骤："+ stepName);
            afreshCheck:
            if (WDPublic.runState == RunState.暂停中)
            {
                WTool.Sleep(20);
                goto afreshCheck;
            }
            else if (WDPublic.runState == RunState.急停)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region 常用工具
        public static void 弹窗(string strContent)
        {
            WTool.Popup(strContent);
        }
        public static string 弹窗确定取消(string strContent)
        {
            DialogResult mDialogResult = WTool.PopupOKCancel(strContent);
            if (mDialogResult == DialogResult.OK)
                return "确定";
            else
                return "取消";
        }
        public static string 弹窗重试(string strContent)
        {
            DialogResult mDialogResult = WTool.PopupRetry(strContent);
            if (mDialogResult == DialogResult.OK)
                return "确定";
            else if (mDialogResult == DialogResult.Retry)
                return "重试";
            else
                return "取消";
        }
        public static void 延迟(double i)
        {
            WTool.Sleep((int)(i * 1000));
        }
        public static void 延迟(string paraName)
        {
            //WTool.Sleep((int)(i * 1000));
        }
        #endregion
        #region 板卡功能
        public static bool 绝对运动(string pointName)
        {
            if (CC.MoveAbsolute(pointName) == 0)
                return true;
            else
                return false;
        }
        public static bool 相对运动(string pointName, string pointMove)
        {
            if (CC.MoveRelative(pointName) == 0)
                return true;
            else
                return false;
        }
        public static bool 连续运动(string axisName)
        {
            if (CC.MoveContinuous(axisName) == 0)
                return true;
            else
                return false;
        }
        public static bool 单轴停止(string axisName)
        {
            if (CC.Stop(axisName) == 0)
                return true;
            else
                return false;
        }
        public static bool 读取输入复位(string ioName)
        {
            if (CC.ReadDIFalse(ioName) == 0)
                return true;
            else
                return false;
        }
        public static bool 读取输入置位(string ioName)
        {
            if (CC.ReadDITrue(ioName) == 0)
                return true;
            else
                return false;
        }
        public static bool 读取输出复位(string ioName)
        {
            if (CC.ReadDOFalse(ioName) == 0)
                return true;
            else
                return false;
        }
        public static bool 读取输出置位(string ioName)
        {
            if (CC.ReadDOTrue(ioName) == 0)
                return true;
            else
                return false;
        }
        public static bool 设置输出复位(string ioName)
        {
            if (CC.SetUpDOFalse(ioName) == 0)
                return true;
            else
                return false;
        }
        public static bool 设置输出置位(string ioName)
        {
            if (CC.SetUpDOTrue(ioName) == 0)
                return true;
            else
                return false;
        }
        public static bool 单轴回零(string axisName)
        {
            if (CC.SingleZero(axisName) == 0)
                return true;
            else
                return false;
        }
        public static bool 多轴回零(string[] axisNames)
        {
            if (CC.MultipleZero(axisNames) == 0)
                return true;
            else
                return false;
        }
        public static bool 流水线启动(string name)
        {
            //if (CC.MultipleZero(axisNames) == 0)
            //    return true;
            //else
            return false;
        }
        public static bool 流水线停止(string name)
        {
            //if (CC.MultipleZero(axisNames) == 0)
            //    return true;
            //else
            return false;
        }
        #endregion
    }
}