namespace WCF
{
    /// 类 	  名：WCardClass
	/// 类 描 述：运动控制卡父类
	/// WCF公会·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public abstract class WCardClass
    {
        /// <summary>
        /// 卡初始化并打开
        /// </summary>
        /// <returns></returns>
        public abstract int InitOpenCard();
        /// <summary>
        /// DI读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int getDIState(int CardNum, int IoID,  int IoType,  int IoState,  int ExtendNum);
        /// <summary>
        /// DO读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int getDOState(int CardNum, int IoID, int IoType, int IoState, int ExtendNum);
        /// <summary>
        /// DO操作
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int setDOState(string Name);
        /// <summary>
        /// 正限位读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int getPositiveState(string Name);
        /// <summary>
        /// 负限位读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int getNegativeState(string Name);
        /// <summary>
        /// 轴报警读取
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int getPoliceState(string Name);
        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int setMoveRelative(string Name);
        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int setMoveAbsolutely(string Name);
        /// <summary>
        /// JOG运动启动
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int setMoveJOGStart(string Name);
        /// <summary>
        /// JOG运动停止
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int setMoveJOGStop(string Name);
        /// <summary>
        /// 轴复位
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public abstract int setAxisReset(string Name);
        /// <summary>
        /// 读取轴当前位置
        /// </summary>
        public abstract int getAxisCurrentLocation(int CardNum, int AxisNum, int Pulse, out double mCurrentLocation);
    }
}
