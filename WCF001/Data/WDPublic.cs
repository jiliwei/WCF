using System.Collections.Generic;

namespace WCF
{
    /// <summary>
    /// 全局参数类
    /// </summary>
    class WDPublic
    {
        public static RunState runState = RunState.未复位;
        public static bool isCardLog = true;
        public static Dictionary<string, WSocket> wSocket = new Dictionary<string, WSocket>();

        private static List<string> keyword = new List<string>();
        public static List<string> Keyword 
        { 
            get 
            {
                if(keyword.Count == 0)
                {
                    keyword.Add("当");
                    keyword.Add("否则当");
                    keyword.Add("否则");
                    keyword.Add("拆分");
                    keyword.Add("跳转到");
                    keyword.Add("运行到下一步");
                    keyword.Add("重新运行本步骤");
                    keyword.Add("从头再来");
                    keyword.Add("退出流程");
                    keyword.Add("无动作");
                    keyword.Add("[并且]");
                    keyword.Add("[或者]");
                }
                return keyword;
            }
        }
        private static List<string> currency = new List<string>();
        public static List<string> Currency
        {
            get
            {
                if (currency.Count == 0)
                {
                    currency.Add("弹窗");
                    currency.Add("弹窗确定取消");
                    currency.Add("弹窗重试");
                    currency.Add("延迟");
                }
                return currency;
            }
        }
        private static List<string> card = new List<string>();
        public static List<string> Card
        {
            get
            {
                if (card.Count == 0)
                {
                    card.Add("绝对运动");
                    card.Add("相对运动");
                    card.Add("连续运动");
                    card.Add("单轴停止");
                    card.Add("读取输入复位");
                    card.Add("读取输入置位");
                    card.Add("读取输出复位");
                    card.Add("读取输出置位");
                    card.Add("设置输出复位");
                    card.Add("设置输出置位");
                    card.Add("单轴回零");
                    card.Add("多轴回零");
                    card.Add("流水线启动");
                    card.Add("流水线停止");
                }
                return card;
            }
        }
        private static List<string> commun = new List<string>();
        public static List<string> Commun
        {
            get
            {
                if (commun.Count == 0)
                {
                    commun.Add("服务器发送");
                    commun.Add("服务器接收");
                    commun.Add("客户端发送");
                    commun.Add("客户端接收");
                    commun.Add("串口发送");
                    commun.Add("串口接收");
                }
                return commun;
            }
        }

    }
    /// <summary>
    /// 弹窗的按钮
    /// </summary>
    public enum PopupBtn
    {
        确定 = 0,
        重试 = 1,
        取消 = 2,
    }
    /// <summary>
    /// 设备运行状态
    /// </summary>
    public enum RunState
    {
        未复位 = 0,
        正在复位 = 1,
        复位完成 = 2,
        正在工作 = 3,
        暂停中 = 4, 
        急停 = 5
    }
    /// <summary>
    /// 轴状态
    /// </summary>
    public enum AxisState
    {
        正常 = 0,
        正限位 = 1,
        负限位 = 2,
        原点 = 3,
        未使能 = 4,
        轴报警 = 5,
        轴异常 = 6
    }
    /// <summary>
    /// TCP状态状态
    /// </summary>
    public enum SocketState
    {
        已关闭 = 0,
        已打开 = 1
    }

}
