using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF
{
    class WCardToolClass
    {
        public static WDataToolClass mWDataToolClass;
        public static WCardClass mWCardClass;
        /// <summary>
        /// 卡初始化并打开
        /// </summary>
        /// <returns></returns>
        public static int InitOpenCard()
        {
            double mCardType = 0;//卡的类型，
            mWDataToolClass.getDataParameter("运动控制卡类型",out mCardType);

            if (mCardType == 0)
                mWCardClass = new WCardGTSClass();

            //卡初始化并打开
            mWCardClass.InitOpenCard();
            return 0;
        }
        /// <summary>
        /// DI读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool  getDIState(string Name)
        {
            //读取参数
            int CardNum = 0;
            int IoID = 0;
            int IoType = 0;
            int IoState = 0;
            int ExtendNum = 0;
            mWDataToolClass.getDataDI(Name, out CardNum, out IoID, out IoType, out IoState, out ExtendNum);
            int mState = mWCardClass.getDIState(CardNum,  IoID,  IoType,  IoState,  ExtendNum);
            if (mState == 0)
                return false;
            else if (mState == 1)
                return true;
            else if (mState == -1)
            {
                if (MessageBox.Show("“"+Name+"”读取失败，“是”设置为有信号，“否”设置为无信号", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 等待DI信号
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="mState">等待的信号</param>
        /// <returns></returns>
        public static bool waitDIState(string Name, bool mState)
        {
            return true;
        }
        /// <summary>
        /// DO读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool getDOState(string Name)
        {
            //读取参数
            int CardNum = 0;
            int IoID = 0;
            int IoType = 0;
            int IoState = 0;
            int ExtendNum = 0;
            mWDataToolClass.getDataDO(Name, out CardNum, out IoID, out IoType, out IoState, out ExtendNum);
            int mState = mWCardClass.getDOState(CardNum, IoID, IoType, IoState, ExtendNum);
            if (mState == 0)
                return false;
            else if (mState == 1)
                return true;
            else if (mState == -1)
            {
                if (MessageBox.Show("“" + Name + "”读取失败，“是”设置为有信号，“否”设置为无信号", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// DO操作
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setDOState(string Name, bool mState)
        {

            return 0;
        }
        /// <summary>
        /// 正限位读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int getPositiveState(string Name)
        {

            return 0;
        }
        /// <summary>
        /// 负限位读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int getNegativeState(string Name)
        {

            return 0;
        }
        /// <summary>
        /// 轴报警读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int getPoliceState(string Name)
        {

            return 0;
        }
        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setMoveRelative(string Name)
        {

            return 0;
        }
        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setMoveAbsolutely(string Name,double Value)
        {

            return 0;
        }
        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setMoveAbsolutely(string Name)
        {

            return 0;
        }
        /// <summary>
        /// JOG运动启动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setMoveJOGStart(string Name)
        {

            return 0;
        }
        /// <summary>
        /// JOG运动停止
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setMoveJOGStop(string Name)
        {

            return 0;
        }
        /// <summary>
        /// 轴复位
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static int setAxisReset(string Name)
        {

            return 0;
        }
        /// <summary>
        /// 读取轴当前位置
        /// </summary>
        /// <param name="Name">轴名称</param>
        /// <returns></returns>
        public static int getAxisCurrentLocation(string Name, out double mCurrentLocation)
        {
            mCurrentLocation = 0;
            int CardNum = 0;
            int AxisNum = 0;
            int Pulse = 0;
            int Acc = 0;
            int Speed = 0;
            int ResetNum = 0;
            mWDataToolClass.getDataAxis( Name, out CardNum, out AxisNum, out Pulse, out Acc, out Speed, out ResetNum);
            mWCardClass.getAxisCurrentLocation( CardNum,  AxisNum,  Pulse, out mCurrentLocation);
            return 0;
        }
    }
}
