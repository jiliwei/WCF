using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    class WSocket
    {
        private string name = "";//TCP的名称
        private string port = "";//端口
        private string ip = "";//IP
        private int iTimeout = 6000;//通讯的超时时间
        public SocketState state = SocketState.已关闭;

        public string Name { get => name; set => name = value; }
        public string Port { get => port; set => port = value; }
        public string Ip { get => ip; set => ip = value; }
        public int ITimeout { get => iTimeout; set => iTimeout = value; }
        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        public virtual int Open()
        {
            return -1;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        public virtual int Close()
        {
            return -1;
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendContent">发送的内容</param>
        /// <param name="strClient">指定的客户端</param>
        /// <returns></returns>
        public virtual int Send(string sendContent, string strClient = "")
        {
            return -1;
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="strClient">读取数据的客户端</param>
        /// <returns></returns>
        public virtual int Receive(string strClient = "")
        {
            return -1;
        }
        /// <summary>
        /// 发送并接收
        /// </summary>
        /// <param name="sendContent">发送的内容</param>
        /// <param name="strClient">指定的客户端</param>
        /// <returns></returns>
        public virtual int SendRec(string sendContent, string strClient = "")
        {
            return -1;
        }
    }
}
