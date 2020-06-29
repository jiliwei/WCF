using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSScriptLibrary;
using System.IO;
using System.Threading;

namespace WCF.WCFControl
{
    /// 类 	  名：WCFAxis
	/// 类 描 述：流程自定义控件
	/// WCF·769838889@qq.com
	/// 创建时间：2020/6/29
	/// 源    码：https://github.com/jiliwei/WCF
    public partial class WCFAutoScript : UserControl
    {
        public WCFAutoScript()
        {
            InitializeComponent();
        }
        public void ConInit()
        {
            TabControl tabCont = new TabControl();
            string rootPath = Directory.GetCurrentDirectory();//获取应用程序的当前工作目录。
            string[] files = Directory.GetFiles(rootPath + "\\AutoScript", "*.txt");//读取指定文件夹的所有TXT文件
            foreach (string itemFile in files)
            {
                string strName = Path.GetFileNameWithoutExtension(itemFile);
                TabPage tpPage = new TabPage();//增加选项卡
                tpPage.Name = "tp" + strName;
                tpPage.Text = strName;
                tpPage.Dock = DockStyle.Fill;
                RichTextBox rtbPara = new RichTextBox();//增加编辑器
                rtbPara.Name = "rtb" + strName;
                rtbPara.Dock = DockStyle.Fill;
                StreamReader sr = new StreamReader(itemFile, Encoding.Default);
                rtbPara.Text = sr.ReadToEnd();//给编辑器添加内容
                sr.Close();
                tpPage.Controls.Add(rtbPara);
                tabCont.Controls.Add(tpPage);//子项添加到选项卡
            }
            tabCont.Name = "tcProcess";
            tabCont.Dock = DockStyle.Fill;
            panelAsProcess.Controls.Clear();
            panelAsProcess.Controls.Add(tabCont);

        }
        private void btnAsSave_Click(object sender, EventArgs e)
        {
            string rootPath = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(rootPath + "\\AutoScript", "*.txt");
            TabControl tabCont = (TabControl)panelAsProcess.Controls["tcProcess"];//获取到选项卡控件
            foreach (string itemFile in files)
            {
                string strName = Path.GetFileNameWithoutExtension(itemFile);
                TabPage tpCont = (TabPage)tabCont.Controls["tp" + strName];//获取到选项卡控件
                RichTextBox rtbCont = (RichTextBox)tpCont.Controls["rtb" + strName];//获取到选项卡控件
                rtbCont.SaveFile(itemFile, RichTextBoxStreamType.PlainText);
            }
        }

        private List<Thread> lTask = new List<Thread>();
        AsmHelper helper = null;
        private void btnAsRun_Click(object sender, EventArgs e)
        {
            if (lTask.Count <= 0)
            {
                string scriptCode = "using System;\n" +
                                    "using System.Windows.Forms;\n" +
                                    "using WCF.WCFScript;\n" +
                                    "public class AutoScript\n" +
                                    "{\n";
                string rootPath = Directory.GetCurrentDirectory();
                string[] files = Directory.GetFiles(rootPath + "\\AutoScript", "*.txt");
                TabControl tabCont = (TabControl)panelAsProcess.Controls["tcProcess"];//获取到选项卡控件
                List<string> runNames = new List<string>();
                foreach (string itemFile in files)
                {
                    string strName = Path.GetFileNameWithoutExtension(itemFile);
                    TabPage tpCont = (TabPage)tabCont.Controls["tp" + strName];//获取到选项卡控件
                    RichTextBox rtbCont = (RichTextBox)tpCont.Controls["rtb" + strName];//获取到选项卡控件
                    scriptCode += rtbCont.Text;
                    if (!strName.Contains("共用参数"))
                    {
                        runNames.Add(strName);
                    }
                }
                scriptCode += "}";
                helper = new AsmHelper(CSScript.LoadCode(scriptCode, null, false));
                foreach (string item in runNames)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(workRun));
                    thread.Start((object)item);
                    lTask.Add(thread);
                }
                btnAsRun.Text = "结束";
            }
            else
            {
                foreach (Thread item in lTask) { item.Abort(); }
                lTask.Clear();
                btnAsRun.Text = "运行";
            }
        }
        public void workRun(object runName)
        {
        //应该是cs-script的异常，设置为不出异常才能启动另一个线程才能每次都能启动成功
        //否则出现异常的概率会很大
        autoRestart:
            try
            {
                helper.Invoke("AutoScript." + runName.ToString());
            }
            catch (Exception e)
            {
                goto autoRestart;
            }
        }
        /// <summary>
        /// 结束线程
        /// </summary>
        public void Clear()
        {
            foreach (Thread item in lTask) { item.Abort(); }
            lTask.Clear();
        }
    }
}
