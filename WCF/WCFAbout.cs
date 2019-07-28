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
