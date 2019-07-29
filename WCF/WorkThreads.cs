using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WCF
{
    /// 类 	  名：WorkThreads
	/// 类 描 述：工作流程类
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源码网证：https://github.com/jiliwei/WCF
	/// 版权许可：GNU通用公共许可第3版
    class WorkThreads
    {
        bool isFeeding = true;//true表示送料完成，false为正在送料
        public void SuctionThread()//飞达送料线程
        {
            while (true)
            {//主流程
                if (WCardToolClass.getDIState("飞达信号")){//```````````````````````````````````````````````````输入信号读取
                    //飞达A信号·有信号，表示接料板上有辅料
                    Thread.Sleep(20);
                }else{
                    isFeeding = false;//标识正在送料
                    WCardToolClass.setMoveJOGStart("飞达轴");//启动飞达轴送料```````````````````````````````````JOG运动启动
                    WCardToolClass.waitDIState("飞达信号",true);//等待飞达信号，有信号``````````````````````````等待输入信号
                    WCardToolClass.setMoveJOGStop("飞达轴");//停止飞达轴送料````````````````````````````````````JOG运动停止
                    WCardToolClass.setMoveRelative("飞达送料补偿");//飞达轴继续运动一段距离`````````````````````轴相对运动
                    isFeeding = true;//标识送料完成
                }
            }//主流程
        }


        //mCard.setMoveAbsolutely("A工位X轴",6.66);//A工位X轴运动到6.66位置````````````````轴绝对运动
        //mCard.setDOState("蜂鸣器",true);//打开蜂鸣器`````````````````````````````````````输出信号设置

    }
}
