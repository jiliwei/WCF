using System.Threading;
using static WCF.WCardToolClass;
using static WCF.WConstClass;

namespace WCF
{
    /// 类 	  名：WorkThreads
	/// 类 描 述：工作流程类
	/// 创 建 者：WCF公会·韦季李
	/// 创建时间：2019/7/26
	/// 修改时间：2020/2/26
	/// 源    码：https://github.com/jiliwei/WCF
    class WorkThreads
    {
        public void SuctionThread()//飞达送料线程
        {
            while (true)
            {//主流程
                if (getDIState(飞达信号))
                {//```````````````````````````````````````````````````输入信号读取
                    //飞达A信号·有信号，表示接料板上有辅料
                    Thread.Sleep(20);
                }
                else
                {
                    setMoveJOGStart(飞达轴);//启动飞达轴送料```````````````````````````````````JOG运动启动
                    waitDIState(飞达信号, true);//等待飞达信号，有信号``````````````````````````等待输入信号
                    setMoveJOGStop(飞达轴);//停止飞达轴送料````````````````````````````````````JOG运动停止
                    setMoveRelative(飞达送料补偿);//飞达轴继续运动一段距离`````````````````````轴相对运动
                }
            }//主流程
        }
        //其他实例：
        //setMoveAbsolutely(A工位X轴,6.66);//A工位X轴运动到6.66位置````````````````轴绝对运动
        //setDOState(蜂鸣器,true);//打开蜂鸣器```
    }
}
