using System.Windows.Forms;
using System.Threading;

namespace WCF.WCFScript
{
    public static class 工具
    {
        public static void 显示(string value)
        {
            MessageBox.Show(value);
        }
        public static void 等待(ref string value, string result)
        {
        继续等待:
            if (value.Equals(result))
            {
                return;
            }
            Thread.Sleep(50);
            goto 继续等待;
        }
        public static void 等待50毫秒()
        {
            Thread.Sleep(50);
        }
    }
}
