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
	/// 类 描 述：关于
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFAbout : Form
    {
        public WCFAbout()
        {
            InitializeComponent();

            lbl_Version.Text = "版本： "+ Application.ProductVersion.ToString() + "（鉴赏版）";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbWCF_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llb_WCF.Links[0].LinkData = "https://github.com/jiliwei/WCF";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
