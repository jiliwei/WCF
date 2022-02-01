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
    public partial class WCFHome : UserControl
    {
        public WCFHome()
        {
            InitializeComponent();
        }
        public void ConInit()
        {
            wcfLog.ConInit("流程运行");
        }
    }
}
