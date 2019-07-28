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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WDataToolClass mWDataToolClass;
        WAutoUIClass mAutoUI = new WAutoUIClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            mAutoUI.controllInitializeSize(this);
            mWDataToolClass = new WDataToolClass();
            int rtn = 0;
            rtn = mWDataToolClass.CheckAndOpenDataFile();
            if (rtn != 0)
            {
                MessageBox.Show("mWDataToolClass.CheckAndOpenDataFile()");
            }
            //初始化设备参数编辑控件（并给赋值当前参数表mParameter）
            wcfDataPata.ConInit(mWDataToolClass);
            //卡工具类数据库操作参数设置(必须在wcfDataPata.ConInit之后，)
            WCardToolClass.mWDataToolClass = mWDataToolClass;
            WCardToolClass.InitOpenCard();
            //初始化设备参数控件
            wcfDataGroup.ConInit(mWDataToolClass);
            //初始化卡参数编辑控件
            wcfCardEdit.ConInit(mWDataToolClass);
            //初始化轴界面
            lvWcfAxis.ConInit(mWDataToolClass);
            //初始化输入界面
            lvWcfDI.ConInit(mWDataToolClass);
            //初始化输出界面
            lvWcfDO.ConInit(mWDataToolClass);
            //初始化机种选择
            wcfDataType.ConInit(mWDataToolClass,false);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            mAutoUI.controlAutoSize(this);
        }

        private void wcfDataType_DataUpdateClick(object sender, EventArgs e)
        {
            //初始化设备参数控件
            wcfDataGroup.ConInit(mWDataToolClass);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WCFAbout mainForm = new WCFAbout();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }
    }
}
