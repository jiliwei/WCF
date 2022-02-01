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
    public partial class WCFSerial : UserControl
    {
        public WCFSerial()
        {
            InitializeComponent();
        }
        public void ConInit()
        {
            WDSerial.CheckForm();
            flpSerial.Controls.Clear();
            List<string> mNames = new List<string>();
            foreach (KeyValuePair<string, SerialData> item in WDSerial.DicSerialData)
            {
                WCFSerialSon mWCFSerialSon = new WCFSerialSon(item.Value);
                //宽减去滚动条的宽度
                mWCFSerialSon.Size = new Size(Size.Width - 23, mWCFSerialSon.Size.Height);//宽度适应实际的宽度高度暴力
                flpSerial.Controls.Add(mWCFSerialSon);
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
            cmsAddServer.Name = "cmsAddSerial";
            cmsAddServer.Size = new Size(152, 22);
            cmsAddServer.Text = "增加串口";
            cmsAddServer.Click += new EventHandler(cmsAdd_Click);
            cmsParaMenu.Items.Add(cmsAddServer);

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

            flpSerial.ContextMenuStrip = cmsParaMenu;//参数保存使用

        }
        private void cmsAdd_Click(object sender, EventArgs e)
        {
            string name = "串口" + (WDSerial.DicSerialData.Count + 1).ToString();
            WDSerial.InsertSerial(name);
            ConInit();
        }
        private void cmsDelete_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Text;
            foreach (KeyValuePair<string, SerialData> item in WDSerial.DicSerialData)
            {
                if (name.Equals("删除" + item.Key))
                {
                    WDSerial.DeleteSerial(item.Value.Id);
                    ConInit();
                    return;
                }
            }
        }
    }
}
