using static WCF.WCardToolClass;
using static WCF.WConstClass;

namespace WCF
{
    /// 类 	  名：WorkThreads
	/// 类 描 述：工作流程类
	/// WCF公会·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 修改时间：2020/2/26
	/// 源    码：https://github.com/jiliwei/WCF
    class WorkThreads
    {
        public void SuctionThread()//飞达送料线程
        {
            if (读取输入信号(飞达信号))//`````````````````````````````输入信号读取
            {
                等待X毫秒(20);//飞达信号·有信号，表示接料板上有辅料
            }
            else
            {
                JOG运动启动(飞达轴);//启动飞达轴送料``````````````````JOG运动启动
                等待输入信号(飞达信号, true);//等待飞达信号，有信号```等待输入信号
                JOG运动停止(飞达轴);//停止飞达轴送料``````````````````JOG运动停止
                相对运动(飞达送料补偿);//飞达轴继续运动一段距离```````轴相对运动
            }
        }
    }
}
