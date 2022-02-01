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
    public partial class WCFSerialSon : UserControl
    {
        private static SerialData mSerialData = new SerialData();
        public WCFSerialSon(SerialData serialData)
        {
            InitializeComponent();
            mSerialData = serialData;
            InitView();
        }
        private void InitView()
        {
            txtName.Text = mSerialData.Name;
            txtPort.Text = mSerialData.Port;
            txtBaudRate.Text = mSerialData.BaudRate;
            txtDataBit.Text = mSerialData.DataBit;
            txtCheckBit.Text = mSerialData.CheckBit;
            txtStopBit.Text = mSerialData.StopBit;
            tlpSerial.BackColor = Color.LightGray;
            txtState.BackColor = Color.Gray;
        }

        private void WCFSocketSon_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;//设置允许线程更新控件
        }
    }
}
