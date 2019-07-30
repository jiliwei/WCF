using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    /// 类 	  名：WCardClass
	/// 类 描 述：固高运动控制卡类
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源码网证：https://github.com/jiliwei/WCF
    class WCardGTSClass : WCardClass
    {
        public override int getDIState(int CardNum, int IoID, int IoType, int IoState, int ExtendNum)
        {

            return 0;
        }

        public override int getDOState(int CardNum, int IoID, int IoType, int IoState, int ExtendNum)
        {
            return 0;
        }

        public override int getNegativeState(string Name)
        {
            return 0;
        }

        public override int getPoliceState(string Name)
        {
            return 0;
        }

        public override int getPositiveState(string Name)
        {
            return 0;
        }

        public override int InitOpenCard()
        {
            return 0;
        }

        public override int setAxisReset(string Name)
        {
            return 0;
        }

        public override int setDOState(string Name)
        {
            return 0;
        }

        public override int setMoveAbsolutely(string Name)
        {
            return 0;
        }

        public override int setMoveJOGStart(string Name)
        {
            return 0;
        }

        public override int setMoveJOGStop(string Name)
        {
            return 0;
        }

        public override int setMoveRelative(string Name)
        {
            return 0;
        }
        public override int getAxisCurrentLocation(int CardNum, int AxisNum, int Pulse, out double mCurrentLocation)
        {
            mCurrentLocation = 0;
            return 0;
        }
    }
}
