using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF
{
    class WSocketServer: WSocket
    {
        private Socket wSocket;
        private Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();//客户端字典
        private Dictionary<string, string> dicReceive = new Dictionary<string, string>();//接收内容字典
        public string Receive1 
        { 
            get
            {
                if (DicReceive.Count > 0)//如果指定目标客户端，则默认第一个客户端
                {
                    string strClient = (new List<string>(DicReceive.Keys))[0];
                    return DicReceive[strClient];
                }
                return "无客户端链接无法读取";
            }
        }
        public Dictionary<string, string> DicReceive { get => dicReceive; set => dicReceive = value; }

        public override int Open()
        {
            try
            {
                if (Ip.Length == 0)
                    return -1;
                if (Port.Length == 0)
                    return -2;
                wSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress mIPAddress = IPAddress.Parse(Ip);
                IPEndPoint mIPEndPoint = new IPEndPoint(mIPAddress, Convert.ToInt32(Port));
                wSocket.Bind(mIPEndPoint);
                wSocket.Listen(10);//开始监听
                state = SocketState.已打开;
                Task.Run(() =>
                {
                    Listen(wSocket);
                });
            }
            catch (Exception)
            {
                return -3;
            }
            return 0;
        }

        void Listen(Socket wSocket)//实时监听客户端的链接
        {
            try
            {
                while (state == SocketState.已打开)
                {
                    Socket socketSend = wSocket.Accept();
                    //有客户端链接，则记录下来
                    string strRemotePoint = socketSend.RemoteEndPoint.ToString();
                    if (dicSocket.ContainsKey(strRemotePoint))
                        dicSocket[strRemotePoint] = socketSend;
                    else
                        dicSocket.Add(strRemotePoint, socketSend);

                    //不使用实时读取功能
                    //Task.Run(() =>
                    //{
                    //    Receive(strRemotePoint);
                    //});
                }
            }
            catch (Exception)
            {
                //不做处理，当关闭后自动退出线程
            }
        }
        public override int Close()
        {
            state = SocketState.已关闭;
            Thread.Sleep(100);//做个小延迟等待相应线程退出
            wSocket.Close();
            return 0;
        }
        //void Receive(string strRemotePoint)//实时接收返回值
        //{
        //    try
        //    {
        //        while (state == SocketState.已打开)
        //        {
        //            byte[] buffer = new byte[1024 * 1024 * 10];
        //            dicSocket[strRemotePoint].ReceiveTimeout = 6000;//超时时间设置为6秒
        //            int iRtn = dicSocket[strRemotePoint].Receive(buffer);
        //            if (iRtn == 0)
        //                break;

        //            string strReceive = Encoding.UTF8.GetString(buffer, 0, iRtn);
        //            if (dicReceive.ContainsKey(strRemotePoint))
        //                dicReceive[strRemotePoint] = strReceive;
        //            else
        //                dicReceive.Add(strRemotePoint, strReceive);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //不做处理，当关闭后自动退出线程
        //    }
        //}
        public override int Send(string sendContent,string strClient = "")
        {
            try
            {
                if (dicSocket.Count == 0)
                {
                    return -2;//没有客户端链接，无法发送消息
                }

                if (strClient.Length == 0)//如果指定目标客户端，则默认第一个客户端
                    strClient = (new List<string>(dicSocket.Keys))[0];
                if (dicSocket[strClient].Connected == false)
                    return -3;//与客户端的链接已经断开

                byte[] buffer = Encoding.UTF8.GetBytes(sendContent);
                dicSocket[strClient].Send(buffer);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public override int Receive(string strClient = "")//实时接收返回值
        {
            try
            {
                if (strClient.Length == 0)//如果指定目标客户端，则默认第一个客户端
                    strClient = (new List<string>(dicSocket.Keys))[0];
                if (dicSocket[strClient].Connected == false)
                    return -3;//与客户端的链接已经断开

                byte[] buffer = new byte[1024 * 1024 * 10];
                dicSocket[strClient].ReceiveTimeout = ITimeout;//超时时间设置为6秒
                int iRtn = dicSocket[strClient].Receive(buffer);
                if (iRtn == 0)
                    return -2;

                string strReceive = Encoding.UTF8.GetString(buffer, 0, iRtn);
                if (DicReceive.ContainsKey(strClient))
                    DicReceive[strClient] = strReceive;
                else
                    DicReceive.Add(strClient, strReceive);
            }
            catch (Exception)
            {
                return -1;
                //不做处理，当关闭后自动退出线程
            }
            return 0;
        }
        public override int SendRec(string sendContent, string strClient = "")
        {
            int ret = Send(sendContent, strClient);//发送
            if (ret != 0) return -1;
            ret = Receive(strClient);//读取
            if (ret != 0) return -2;
            return 0;
        }
    }
}
