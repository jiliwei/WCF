using System;
using System.Data;
using System.Windows.Forms;

namespace WCF
{
    /// 类 	  名：WUseToolClass
	/// 类 描 述：常用工具类
	/// 创 建 者：韦季李
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public class WUseToolClass
    {
        /// <summary>
        /// 通过IO类型名称获取IO类型值
        /// </summary>
        /// <param name="mName">IO名称</param>
        /// <returns></returns>
        public static int getIoType(string mName)
        {
            int IoType = 0;
            if (mName == "正限位")
                IoType = 0;
            else if (mName == "负限位")
                IoType = 1;
            else if (mName == "原点")
                IoType = 3;
            else if (mName == "通用")
                IoType = 4;
            else if (mName == "扩展")
                IoType = 1023;
            else
            {
                MessageBox.Show("端口类型错误***，请检查");
                return -1;
            }
            return IoType;
        }
        /// <summary>
        /// 通过IO类型值获取IO类型名称
        /// </summary>
        /// <param name="mNum">IO值</param>
        /// <returns></returns>
        public static string getIoTypeName(Int32 mNum)
        {
            string mName = "异常";
            if (mNum == 0)
                mName = "正限位";
            else if (mNum == 1)
                mName = "负限位";
            else if (mNum == 3)
                mName = "原点";
            else if (mNum == 4)
                mName = "通用";
            else if (mNum == 1023)
                mName = "扩展";
            else
            {
                MessageBox.Show("端口类型错误***，请检查");
            }
            return mName;
        }
        /// <summary>
        /// 通过IO状态名称获取IO状态值
        /// </summary>
        /// <param name="mName">IO状态名称</param>
        /// <returns></returns>
        public static int getIoState(string mName)
        {
            int IoState = 0;
            if (mName == "正常")
                IoState = 0;
            else if (mName == "取反")
                IoState = 1;
            else
            {
                MessageBox.Show("端口状态错误***，请检查");
            }
            return IoState;
        }
        /// <summary>
        /// 通过IO状态值获取IO状态名称
        /// </summary>
        /// <param name="mNum">IO状态值</param>
        /// <returns></returns>
        public static string getIoStateName(Int32 mNum)
        {
            string mName = "异常";
            if (mNum == 0)
                mName = "正常";
            else if (mNum == 1)
                mName = "取反";
            else
            {
                MessageBox.Show("端口状态错误***，请检查");
            }
            return mName;
        }
        /// <summary>
        /// 判断object对象是否为空并提示
        /// </summary>
        /// <param name="mValue"></param>
        /// <param name="mName"></param>
        /// <returns></returns>
        public static bool isObjectNull(object mValue,string mName)
        {
            if(mValue == null)
            {
                MessageBox.Show(mName+"不能为空，请检查");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 通过关联轴名字返回关联轴ID
        /// </summary>
        /// <returns></returns>
        public static string getCorrAxisID(DataTable dtCorrAxis,string Name)
        {
            string ID = "-1";
            if(Name.Length == 0) ID = "";
            else if (dtCorrAxis.Rows.Count > 0)
            {
                for (int i = 0; i < dtCorrAxis.Rows.Count; i++)
                {
                    if (dtCorrAxis.Rows[i]["Name"].ToString() == Name)
                    {
                        return dtCorrAxis.Rows[i]["ID"].ToString();
                    }
                }
            }
            else if (Name == "无") ID = "null";
            else ID = "";

            return ID;
        }
    }
}
