using System;
using System.Data;
using System.Text.RegularExpressions;

namespace WCF
{
    /// 类 	  名：WContTool
	/// 类 描 述：控件（内部）工具类
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/27
	/// 源    码：https://github.com/jiliwei/WCF
    class WContTool
    {
        /// <summary>
        /// 通过IO类型名称获取IO类型值
        /// </summary>
        /// <param name="mName">IO名称</param>
        /// <returns></returns>
        public static int getIoType(string mName)
        {
            int IoType;
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
                WTool.Popup("端口类型错误***，请检查");
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
                WTool.Popup("端口类型错误***，请检查");
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
                WTool.Popup("端口状态错误***，请检查");
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
                WTool.Popup("端口状态错误***，请检查");
            }
            return mName;
        }
        /// <summary>
        /// 判断object对象是否为空并提示
        /// </summary>
        /// <param name="mValue"></param>
        /// <param name="mName"></param>
        /// <returns></returns>
        public static bool isObjectNull(object mValue, string mName)
        {
            if (mValue == null)
            {
                WTool.Popup(mName + "不能为空，请检查");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 通过关联轴名字返回关联轴ID
        /// </summary>
        /// <returns></returns>
        public static string getCorrAxisID(DataTable dtCorrAxis, string Name)
        {
            string ID = "-1";
            if (Name.Length == 0) ID = "";
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
        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        /// <param name="value">需要判断的字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        /// <summary>
        /// 检测字符串是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTrim(ref string value,string strTips = "")
        {
            if (value.Length == 0)
            {
                WTool.Popup(strTips + "输入为空");
                return true;
            }
            value = value.Trim();
            if (value.Length == 0)
            {
                WTool.Popup(strTips + "输入为空");
                return true;
            }
            return false;
        }

        #region 获取汉字首字母
        /// <summary>
        /// 获取汉字首字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSpellCodeToUpper(string str)
        {
            string strTemp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)//第一个字母大写
                    strTemp += GetCharSpellCode(str.Substring(i, 1)).ToUpper();
                else
                    strTemp += GetCharSpellCode(str.Substring(i, 1));
                if (strTemp.Length >= 6)
                    return strTemp;
            }
            return strTemp;
        }
        public static string GetSpellCode(string str)
        {
            string strTemp = "";
            for (int i = 0; i < str.Length; i++)
            {
                    strTemp += GetCharSpellCode(str.Substring(i, 1));
                if (strTemp.Length >= 6)
                    return strTemp;
            }
            return strTemp;
        }
        /// <summary>
        /// 获取1个汉字的首字母
        /// </summary>
        /// <param name="strChar">一个字符</param>
        /// <returns></returns>
        public static string GetCharSpellCode(string strChar)
        {
            long iChar;
            byte[] ZW = System.Text.Encoding.Default.GetBytes(strChar);
            if (ZW.Length == 1)
                return strChar.ToLower();
            else
                iChar = ((short)ZW[0]) * 256 + (short)ZW[1];

            if (iChar >= 45217 && iChar <= 45252)
                return "a";
            else if (iChar >= 45253 && iChar <= 45760)
                return "b";
            else if (iChar >= 45761 && iChar <= 46317)
                return "c";
            else if (iChar >= 46318 && iChar <= 46825)
                return "d";
            else if (iChar >= 46826 && iChar <= 47009)
                return "e";
            else if (iChar >= 47010 && iChar <= 47296)
                return "f";
            else if (iChar >= 47297 && iChar <= 47613)
                return "g";
            else if (iChar >= 47614 && iChar <= 48118)
                return "h";
            else if (iChar >= 48119 && iChar <= 49061)
                return "j";
            else if (iChar >= 49062 && iChar <= 49323)
                return "k";
            else if (iChar >= 49324 && iChar <= 49895)
                return "l";
            else if (iChar >= 49896 && iChar <= 50370)
                return "m";
            else if (iChar >= 50371 && iChar <= 50613)
                return "n";
            else if (iChar >= 50614 && iChar <= 50621)
                return "o";
            else if (iChar >= 50622 && iChar <= 50905)
                return "p";
            else if (iChar >= 50906 && iChar <= 51386)
                return "q";
            else if (iChar >= 51387 && iChar <= 51445)
                return "r";
            else if (iChar >= 51446 && iChar <= 52217)
                return "s";
            else if (iChar >= 52218 && iChar <= 52697)
                return "t";
            else if (iChar >= 52698 && iChar <= 52979)
                return "w";
            else if (iChar >= 52980 && iChar <= 53688)
                return "x";
            else if (iChar >= 53689 && iChar <= 54480)
                return "y";
            else if (iChar >= 54481 && iChar <= 55289)
                return "z";
            return strChar;
        }
        public static bool IsLetterOrNumber(string str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z]"))
                return true;
            else if (Regex.IsMatch(str, @"^\d"))
                return true;
            else if (str.Equals("["))
                return true;
            return false;
        }
        #endregion
    }
}
