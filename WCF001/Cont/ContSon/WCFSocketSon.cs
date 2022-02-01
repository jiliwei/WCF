using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF
{
    public partial class WCFSocketSon : UserControl
    {
        private static SocketData mSocketData = new SocketData();
        public WCFSocketSon(SocketData socketData)
        {
            InitializeComponent();
            mSocketData = socketData;

            InitView();
        }
        private void InitView()
        {
            txtName.Text = mSocketData.Name;
            if (mSocketData.Type == 0)
            {
                tlpSocketType.BackColor = Color.PaleTurquoise;
                txtType.Text = "服务器";
                txtState.Text = "未打开";
                txtState.BackColor = Color.Gray;
                cbClient.Visible = true;
                btnConnect.Visible = true;
            }
            else
            {
                tlpSocketType.BackColor = Color.LightGray;
                txtType.Text = "客户端";
                txtState.Text = "未连接";
                txtState.BackColor = Color.Gray;
                cbClient.Visible = false;
                btnConnect.Visible = false;
            }
            txtIP.Text = mSocketData.Ip;
            txtPort.Text = mSocketData.Port;
        }

        private void WCFSocketSon_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;//设置允许线程更新控件
        }
    }
}
