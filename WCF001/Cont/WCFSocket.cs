using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF.Cont
{
    public partial class WCFSocket : UserControl
    {
        public WCFSocket()
        {
            InitializeComponent();
        }
        public void ConInit()
        {
            WDSocket.CheckForm();
            flpSecket.Controls.Clear();
            List<string> mNames = new List<string>();
            foreach (KeyValuePair<string, SocketData> item in WDSocket.DicSocketData)
            {
                WCFSocketSon mWCFSocketSon = new WCFSocketSon(item.Value);
                //宽减去滚动条的宽度
                mWCFSocketSon.Size = new Size(Size.Width - 23, mWCFSocketSon.Size.Height);//宽度适应实际的宽度高度暴力
                flpSecket.Controls.Add(mWCFSocketSon);
                mNames.Add(item.Key);
            }

            //添加右键菜单
            components = new Container();
            ContextMenuStrip cmsParaMenu ;
            int iTabControlNum = Controls.Find("cmsScoketMenu", true).Length;
            if (iTabControlNum == 0)
            {
                cmsParaMenu = new ContextMenuStrip(components);
            }
            else
            {
                cmsParaMenu = Controls.Find("cmsScoketMenu", true)[0] as ContextMenuStrip;
                cmsParaMenu.Controls.Clear();
            }
            cmsParaMenu.SuspendLayout();

            ToolStripMenuItem cmsAddServer = new ToolStripMenuItem();
            cmsAddServer.Name = "cmsAddServer";
            cmsAddServer.Size = new Size(152, 22);
            cmsAddServer.Text = "增加服务器";
            cmsAddServer.Click += new EventHandler(cmsAdd_Click);
            cmsParaMenu.Items.Add(cmsAddServer);

            ToolStripMenuItem cmsAddClient = new ToolStripMenuItem();
            cmsAddClient.Name = "cmsAddClient";
            cmsAddClient.Size = new Size(152, 22);
            cmsAddClient.Text = "增加客户端";
            cmsAddClient.Click += new EventHandler(cmsAdd_Click);
            cmsParaMenu.Items.Add(cmsAddClient);

            foreach (string item in mNames)
            {
                ToolStripMenuItem cmsDelete = new ToolStripMenuItem();
                cmsDelete.Name = "cmsDelete"+ item;
                cmsDelete.Size = new Size(152, 22);
                cmsDelete.Text = "删除"+ item;
                cmsDelete.Click += new EventHandler(cmsDelete_Click);
                cmsParaMenu.Items.Add(cmsDelete);
            }
            cmsParaMenu.Size = new Size(153, 48);
            cmsParaMenu.ResumeLayout(false);

            flpSecket.ContextMenuStrip = cmsParaMenu;//参数保存使用

        }
        private void cmsAdd_Click(object sender, EventArgs e)
        {
            int type;//TCP的类型，0服务器，1客户端
            string name = ((ToolStripMenuItem)sender).Text;
            string ip = "127.0.0.1";//IP
            string port = "8000";//端口
            if (name.Equals("增加服务器"))
            {
                type = 0;
                name = "服务器" + (WDSocket.DicSocketData.Count + 1).ToString();
            }
            else
            {
                type = 1;
                name = "客户端" + (WDSocket.DicSocketData.Count + 1).ToString();
            }
            WDSocket.InsertSocket(type, name,ip, port);
            ConInit();
        }
        private void cmsDelete_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Text;
            foreach (KeyValuePair<string, SocketData> item in WDSocket.DicSocketData)
            {
                if (name.Equals("删除" + item.Key))
                {
                    WDSocket.DeleteSocket(item.Value.Id);
                    ConInit();
                    return;
                }
            }
        }
    }
}
