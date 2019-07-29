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
    /// 类 	  名：WCFAbout
	/// 类 描 述：关于窗口
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源码网证：https://github.com/jiliwei/WCF
	/// 版权许可：GNU通用公共许可第3版
    public partial class WCFAbout : Form
    {
        public WCFAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbWCF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llbWCF.Links[0].LinkData = "https://github.com/jiliwei/WCF";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
