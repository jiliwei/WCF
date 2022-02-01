using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    /// 类 	  名：CC(全名：CardContext)
	/// 类 描 述：运动控制的操作类（做成静态类然后CardContext缩写成CC）
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/26
	/// 源    码：https://github.com/jiliwei/WCF
    class CC
    {
        private static Card mCard;
        public static int Open()
        {
            int iRtn = 0;
            if (mCard == null)
            {
                mCard = new CardGTS();
                iRtn = mCard.Open();
                if (iRtn == 0)
                {
                    AddLog("板卡打开", "板卡打开成功");
                }
                else
                    AddLog("板卡打开", "板卡打开异常，异常代码：" + iRtn.ToString());
            }
            else
                AddLog("板卡打开", "板卡已经打开，重复操作，请检查");

            return iRtn;
        }
        public static int Close()  
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.Close();
            if (iRtn == 0)
                AddLog("板卡关闭", "板卡关闭成功");
            else
                AddLog("板卡关闭", "板卡关闭异常，异常代码：" + iRtn.ToString());

            mCard = null;//清空
            return iRtn;
        }
        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="pointName">点位名称</param>
        /// <returns></returns>
        public static int MoveAbsolute(string pointName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.MoveAbsolute(pointName);
            if (iRtn == 0)
                AddLog("绝对运动", "绝对运动运动到点位：");
            else
                AddLog("绝对运动", "绝对运动异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="pointName">点位名称</param>
        /// <returns></returns>
        public static int MoveRelative(string pointName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.MoveRelative(pointName);
            if (iRtn == 0)
                AddLog("相对运动", "相对运动运动到点位：");
            else
                AddLog("相对运动", "相对运动异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <returns></returns>
        public static int MoveContinuous(string axisName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.MoveContinuous(axisName);
            if (iRtn == 0)
                AddLog("连续运动", "连续运动，启动成功；轴名称：");
            else
                AddLog("连续运动", "连续运动异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 轴停止
        /// </summary>
        /// <param name="axisName">轴名称</param>
        /// <returns></returns>
        public static int Stop(string axisName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.MoveContinuous(axisName);
            if (iRtn == 0)
                AddLog("连续运动", "连续运动，启动成功；轴名称：");
            else
                AddLog("连续运动", "连续运动异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 读取输入复位
        /// </summary>
        /// <param name="ioName"></param>
        /// <returns></returns>
        public static int ReadDIFalse(string ioName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.ReadDIFalse();
            if (iRtn == 0)
                AddLog("读取输入原位", "读取输入原位成功，IO点位名称："+ ioName);
            else
                AddLog("读取输入原位", "读取输入原位异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 读取输入置位
        /// </summary>
        /// <param name="ioName">输入点位名称</param>
        /// <returns>0表示正常（即读取的输入点位为置位），默认99为读取的输入点位为置位为false</returns>
        public static int ReadDITrue(string ioName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.ReadDITrue();
            if (iRtn == 0)
                AddLog("读取输入置位", "读取输入置位成功，IO点位名称：");
            else
                AddLog("读取输入置位", "读取输入置位异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 读取输出复位
        /// </summary>
        /// <param name="ioName"></param>
        /// <returns></returns>
        public static int ReadDOFalse(string ioName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.ReadDOFalse();
            if (iRtn == 0)
                AddLog("读取输出原位", "读取输出原位成功，IO点位名称：");
            else
                AddLog("读取输出原位", "读取输出原位异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 读取输出置位
        /// </summary>
        /// <param name="ioName"></param>
        /// <returns></returns>
        public static int ReadDOTrue(string ioName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.ReadDOTrue();
            if (iRtn == 0)
                AddLog("读取输出置位", "读取输出置位成功，IO点位名称：");
            else
                AddLog("读取输出置位", "读取输出置位异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 设置输出复位
        /// </summary>
        /// <param name="ioName"></param>
        /// <returns></returns>
        public static int SetUpDOFalse(string ioName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.SetUpDOFalse();
            if (iRtn == 0)
                AddLog("设置输出原位", "设置输出原位成功，IO点位名称：");
            else
                AddLog("设置输出原位", "设置输出原位异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 设置输出置位
        /// </summary>
        /// <param name="ioName"></param>
        /// <returns></returns>
        public static int SetUpDOTrue(string ioName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.SetUpDOTrue();
            if (iRtn == 0)
                AddLog("设置输出置位", "设置输出置位成功，IO点位名称：");
            else
                AddLog("设置输出置位", "设置输出置位异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 单轴回零
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        public static int SingleZero(string axisName)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.SingleZero();
            if (iRtn == 0)
                AddLog("单轴回零", "单轴回零成功,回零的轴名称：");
            else
                AddLog("单轴回零", "单轴回零异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 多轴回零
        /// </summary>
        /// <param name="axisNames"></param>
        /// <returns></returns>
        public static int MultipleZero(string[] axisNames)
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.MultipleZero();
            if (iRtn == 0)
                AddLog("多轴回零", "多轴回零成功，回零的轴有：");
            else
                AddLog("多轴回零", "多轴回零异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 暂停
        /// </summary>
        /// <returns></returns>
        public static int Pause()
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.Pause();
            if (iRtn == 0)
                AddLog("板卡暂停", "板卡暂停成功");
            else
                AddLog("板卡暂停", "板卡暂停异常，异常代码：" + iRtn.ToString());
            return iRtn;
        }
        /// <summary>
        /// 急停（所有轴停止）
        /// </summary>
        /// <returns></returns>
        public static int Stop()
        {
            if (mCard == null)
                return AddLogExce();

            int iRtn = mCard.Stop();
            if (iRtn == 0)
                AddLog("板卡急停", "板卡急停成功",1);
            else
                AddLog("板卡急停", "板卡急停异常，异常代码：" + iRtn.ToString(), 1);
            return iRtn;
        }
        /// <summary>
        /// 流水线启动
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int LineStart(string name)
        {

            return 0;
        }
        /// <summary>
        /// 流水线停止
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int LineStop(string name)
        {

            return 0;
        }
        #region 本类用到的工具
        private static void AddLog(String Name, String Details, int Level = 0)
        {
            if (WDPublic.isCardLog)//判断是否启用板卡Log
                WDLog.InsertLog("运动板卡", Level, Name, Details);
        }
        private static int AddLogExce()
        {
            //WDLog.InsertLog("运动板卡", 0, "板卡异常", "板卡未打开，请检查");
            return -55;//为了不和板卡的异常有冲突，故设置-55
        }
        #endregion
    }
}
