using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCF
{
    class WSocketClient: WSocket
    {
        private string receive = "";//读取的内容
        private Socket socketClient;
        public string Receive1 { get => receive; set => receive = value; }
        public override int Open()
        {
            try
            {
                if (Ip.Length == 0)
                    return -1;
                if (Port.Length == 0)
                    return -2;
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress mIPAddress = IPAddress.Parse(Ip);
                IPEndPoint mIPEndPoint = new IPEndPoint(mIPAddress, Convert.ToInt32(Port));
                socketClient.Connect(mIPEndPoint);
                state = SocketState.已打开;
            }
            catch (Exception)
            {
                return -3;
            }
            return 0;
        }
        public override int Send(string sendContent, string strClient = "")
        {
            byte[] buffer = Encoding.UTF8.GetBytes(sendContent);
            socketClient.Send(buffer);
            return 0;
        }
        public override int Receive(string strClient = "")
        {
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 10];
                int r = socketClient.Receive(buffer);
                if (r == 0)
                {
                    return -1;
                }
                receive = Encoding.UTF8.GetString(buffer, 1, r - 1);
            }
            catch (Exception)
            {
                return -2;
            }
            return 0;
        }
        public override int Close()
        {
            state = SocketState.已关闭;
            socketClient.Close();
            return 0;
        }
        public override int SendRec(string sendContent, string strClient = "")
        {
            int ret = Send(sendContent);//发送
            if (ret != 0) return -1;
            ret = Receive();//读取
            if (ret != 0) return -2;
            return 0;
        }
    }
}
