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
    public partial class WCFAxisShortcut : UserControl
    {
        private static AxisData mAxisData = new AxisData();
        public WCFAxisShortcut(AxisData axisData)
        {
            InitializeComponent();
            mAxisData = axisData;
            txtAxisName.Text = mAxisData.Name;
        }

        private void btnPositive_MouseDown(object sender, MouseEventArgs e)
        {
            WTool.Popup(txtAxisName.Text + "，＋");
        }
        private void btnPositive_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void btnNegative_MouseDown(object sender, MouseEventArgs e)
        {
            WTool.Popup(txtAxisName.Text+"，-");
        }

        private void btnNegative_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void timerRefersh_Tick(object sender, EventArgs e)
        {
            if (mAxisData != null && mAxisData.Name != null && WDCard.DicAxisInfor != null)
            {
                if (WDCard.DicAxisInfor.ContainsKey(mAxisData.Name))
                {
                    AxisInfor mAxisInfor = WDCard.DicAxisInfor[mAxisData.Name];
                    txtState.Text = mAxisInfor.State.ToString();
                    txtActual.Text = mAxisInfor.Actual.ToString("0.000");
                }
            }
        }
    }
}
