using System.Windows.Forms;

namespace WCF
{
    /// 来自网络，解决ListView复选框选择会闪烁
    public partial class WCFListView : ListView
    {
        public WCFListView()
        {
            SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
