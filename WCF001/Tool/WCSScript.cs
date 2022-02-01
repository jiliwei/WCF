using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSScripting;
using CSScriptLib;

namespace WCF
{
    /// 类 	  名：WCSScript
	/// 类 描 述：任务流程生成代码
	/// WCF·769838889@qq.com
	/// 创建时间：2021/11/02
	/// 源    码：https://github.com/jiliwei/WCF
    class WCSScript
    {
        public static Func<IEvaluator> GetEvaluator = () => CSScript.RoslynEvaluator;
        public static IEvaluator newEvaluator => GetEvaluator();
        public static Assembly asm ;
        private static List<Task> mTask = new List<Task>();
        /// <summary>
        /// 运行一个任务
        /// </summary>
        /// <param name="taskName">任务名称</param>
        public static void TaskRun(string taskName)
        {
            mTask.Add(
            Task.Run(() =>
            {
                if (asm != null)
                {
                    ((dynamic)asm.CreateObject(taskName)).TaskSwitch();
                }
                else
                {
                    WTool.Popup("请先“检查流程”");
                }
            })
            );
        }
        public static void TaskDispose()
        {
            Thread.Sleep(1000);//延迟等待，任务都结束完，再释放资源
            foreach (Task item in mTask)
            {
                if(item.Status == TaskStatus.RanToCompletion)
                    item.Dispose();
            }
            mTask = new List<Task>();
        }
        public static int TaskState()
        {
            foreach (Task item in mTask)
            {
                if (item.Status == TaskStatus.Running)
                    return 1;
            }
            return 0;
        }
        /// <summary>
        /// 单步骤运行
        /// </summary>
        /// <param name="taskName">任务名称</param>
        /// <param name="stepName">步骤名称</param>
        public static void TaskStepRun(string taskName,string stepName)
        {
            if (asm != null)
            {
                ((dynamic)asm.CreateObject(taskName)).StepSwitch(stepName);
            }
            else
            {
                WTool.Popup("请先“检查流程”");
            }
        }

        public static void GenerateCode()
        {
            try
            {
                #region 类的 using
                string classCode = "using System;\n" +
                                    "using System.Windows.Forms;\n" +
                                    "using WCF;\n" +
                                    "using static WCF.WCSScriptParent;\n";
                #endregion
                #region 增加共有变量
                classCode += "public partial class WCSScriptCS\n";
                classCode += "{\n";
                //增加共有变量
                foreach (KeyValuePair<double, string> item in WDTask.DicTaskPublic)
                {
                    string strValue = item.Value;
                    if (strValue.Contains("数字"))
                        classCode += "\tpublic double " + strValue + " = 0 ;\n";
                    else if (strValue.Contains("字符"))
                        classCode += "\tpublic string " + strValue + " =  string.Empty ;\n";
                    else if (strValue.Contains("集合"))
                        classCode += "\tpublic string[] " + strValue + " =  new string[999] ;\n";
                }
                //增加输入IO名称
                foreach (KeyValuePair<string, DIData> item in WDCard.DicDI)
                    classCode += "\tpublic string " + item.Key + " = \"" + item.Key + "\" ;\n";
                //添加输出IO名称
                foreach (KeyValuePair<string, DOData> item in WDCard.DicDO)
                    classCode += "\tpublic string " + item.Key + " = \"" + item.Key + "\" ;\n";
                //添加轴名称
                foreach (KeyValuePair<string, AxisData> item in WDCard.DicAxis)
                    classCode += "\tpublic string " + item.Key + " = \"" + item.Key + "\" ;\n";
                //添加点位名称
                foreach (KeyValuePair<string, List<PointMain>> itemGroup in WDPoint.getDicPointMain)
                {
                    foreach (PointMain item in itemGroup.Value)
                    {
                        classCode += "\tpublic string " + item.PointName + " = \"" + item.PointName + "\" ;\n";
                    }
                }
                //添加通用参数
                foreach (ParaTab itemParaTab in WDPara.GetListParaTab)
                {
                    foreach (ParaTable itemParaTable in itemParaTab.ListParaTable)
                    {
                        foreach (ParaCurr itemParaCurr in itemParaTable.ListParaTable)
                        {
                            classCode += "\tpublic string " + itemParaCurr.Name + " = \"" + itemParaCurr.Name + "\" ;\n";
                        }
                    }
                }
                classCode += "}\n";
                #endregion
                Dictionary<string, TaskData> dicTaskData = WDTask.DicTaskData;
                List<string> itemTask = new List<string>(dicTaskData.Keys);
                for (int i = 0; i < itemTask.Count; i++)
                {
                    string keyTask = itemTask[i];
                    TaskData valueTask = dicTaskData[keyTask];
                    if (valueTask.DicStepData.Count == 0)
                        break;
                    classCode += "public class " + keyTask + " : WCSScriptCS\n";
                    classCode += "{\n";
                    #region 增加任务状态
                    List<string> listTask = new List<string>();
                    foreach (TaskPara item in WDTask.ListTaskState)
                    {
                        if (item.TaskID == valueTask.ID)
                            listTask.Add(item.Name);
                    }
                    if (listTask.Count > 0)
                    {
                        //枚举
                        classCode += "\tpublic enum S\n";
                        classCode += "\t{\n";
                        foreach (string item in listTask)
                            classCode += "\t\t" + item + ",\n";
                        classCode += "\t}\n";
                        //其他
                        classCode += "\tprivate static S 状态;\n";
                        //读取
                        foreach (string item in listTask)
                        {
                            classCode += "\tpublic static bool " + item + "\n";
                            classCode += "\t{\n";
                            classCode += "\t\tget\n";
                            classCode += "\t\t{\n";
                            classCode += "\t\t\tif (状态 == S." + item + ")\n";
                            classCode += "\t\t\t\treturn true;\n";
                            classCode += "\t\t\treturn false;\n";
                            classCode += "\t\t}\n";
                            classCode += "\t}\n";
                        }
                        //设置
                        foreach (string item in listTask)
                        {
                            classCode += "\tpublic static void 设置" + item + "()\n";
                            classCode += "\t{\n";
                            classCode += "\t\t状态 = S." + item + ";\n";
                            classCode += "\t}\n";
                        }
                    }
                    #endregion
                    #region 增加局部变量
                    foreach (TaskPara item in WDTask.ListTaskPrivate)
                    {
                        if (item.TaskID != valueTask.ID)
                            continue;
                        string strValue = item.Name;
                        if (strValue.Contains("数字"))
                            classCode += "\tprivate double " + strValue + " = 0 ;\n";
                        else if (strValue.Contains("字符"))
                            classCode += "\tprivate string " + strValue + " =  string.Empty ;\n";
                        else if (strValue.Contains("集合"))
                            classCode += "\tprivate string[] " + strValue + " =  new string[999] ;\n";
                    }
                    #endregion
                    string strTaskSwitch = "";//整个任务运行
                    string strStepSwitch = "";//单步骤运行
                    string strTask = "";

                    List<string> itemStep = new List<string>(valueTask.DicStepData.Keys);
                    string strFirstStep = string.Empty;
                    for (int j = 0; j < itemStep.Count; j++)
                    {
                        string keyStep = itemStep[j];//本步骤名称
                        string keyStepNext = "";//下一步的名称
                        if (j + 1 < valueTask.DicStepData.Count)//判断是否有下一步
                            keyStepNext = itemStep[j + 1];

                        StepData valueStep = valueTask.DicStepData[keyStep];
                        #region 增加任务步骤循环
                        if (strTaskSwitch.Length == 0)
                        {
                            strFirstStep = keyStep;
                            strTaskSwitch = "\tpublic void TaskSwitch()\n";
                            strTaskSwitch += "\t{\n";
                            strTaskSwitch += "\t\tstring nowStep = \"" + strFirstStep + "\";\n";
                            strTaskSwitch += "\t\tTaskContinue:\n";
                            strTaskSwitch += "\t\tswitch (nowStep)\n";
                            strTaskSwitch += "\t\t{\n";

                            strStepSwitch = "\tpublic void StepSwitch(string strStep)\n";
                            strStepSwitch += "\t{\n";
                            strStepSwitch += "\t\tswitch (strStep)\n";
                            strStepSwitch += "\t\t{\n";

                        }
                        strTaskSwitch += "\t\t\tcase \"" + keyStep + "\":\n";
                        strTaskSwitch += "\t\t\t\tnowStep = " + keyStep + "();\n";
                        strTaskSwitch += "\t\t\t\tbreak;\n";

                        strStepSwitch += "\t\t\tcase \"" + keyStep + "\":\n";
                        strStepSwitch += "\t\t\t\t" + keyStep + "();\n";
                        strStepSwitch += "\t\t\t\tbreak;\n";

                        #endregion
                        #region 增加任务步骤详情
                        strTask += "\tpublic string " + keyStep + "()\n";
                        strTask += "\t{\n";
                        strTask += "\t\tif (stepCheckTry(\"" + keyTask + "\", \"" + keyStep + "\"))\n";
                        strTask += "\t\t\treturn \"\";\n";
                        string[] strStepDetails = valueStep.StepDetails.Split('\n');
                        foreach (string itemDetails in strStepDetails)
                        {
                            switch (itemDetails.Trim())
                            {
                                case "无动作":
                                    break;
                                case "运行到下一步":
                                    strTask += "\t\treturn \"" + keyStepNext.Trim() + "\";\n";
                                    break;
                                case "重新运行本步骤":
                                    strTask += "\t\treturn \"" + keyStep.Trim() + "\";\n";
                                    break;
                                case "退出流程":
                                    //strTask += "\t\treturn \"\";\n";
                                    break;
                                case "暂停":
                                    strTask += "\t\tCC.Pause();\n";
                                    break;
                                case "急停":
                                    strTask += "\t\tCC.Stop();\n";
                                    break;
                                case "从头再来":
                                    strTask += "\t\treturn \"" + strFirstStep + "\";\n";
                                    break;
                                case "{":
                                    strTask += "\t\t{\n";
                                    break;
                                case "}":
                                    strTask += "\t\t}\n";
                                    break;
                                default:
                                    strTask += "\t\t" + ParsingTool(itemDetails) + "\n";
                                    break;
                            }
                        }
                        strTask += "\t\treturn \"" + keyStepNext.Trim() + "\";\n";
                        strTask += "\t}\n";
                        #endregion
                    }
                    #region 补充任务步骤循环结尾
                    strTaskSwitch += "\t\t\tdefault:\n";
                    strTaskSwitch += "\t\t\t\tWDLog.InsertLog(\"流程运行\", 1, \"" + keyTask + "\", \"工作完成或异常，退出工作循环\");\n";
                    strTaskSwitch += "\t\t\t\treturn;\n";
                    strTaskSwitch += "\t\t}\n";
                    strTaskSwitch += "\t\tgoto TaskContinue;\n";
                    strTaskSwitch += "\t}\n";

                    strStepSwitch += "\t\t\tdefault:\n";
                    strStepSwitch += "\t\t\t\tWDLog.InsertLog(\"流程运行\", 1, \"" + keyTask + "\", \"单步骤运行异常，请重新“检查流程”\");\n";
                    strStepSwitch += "\t\t\t\treturn;\n";
                    strStepSwitch += "\t\t}\n";
                    strStepSwitch += "\t}\n";
                    #endregion
                    classCode += strTaskSwitch;
                    classCode += strStepSwitch;
                    classCode += strTask;
                    classCode += "}\n";
                }
                //导出记录
                TextWriter tw = new StreamWriter(new BufferedStream(new FileStream(
                    Application.StartupPath + "\\TaskSwitch"+DateTime.Now.ToString("yyyyMMddhhmmss")+".cs", FileMode.Create, FileAccess.Write)),
                    System.Text.Encoding.GetEncoding("gb2312")); ;
                tw.Write(classCode);
                tw.Flush();
                tw.Close();

                asm = newEvaluator.CompileCode(classCode);
            }
            catch (Exception e)
            {
                WTool.Popup("代码检查失败，异常是：\n" + e.ToString());
            }
        }
        private static string ParsingTool(string value)
        {
            string rtn = "";
            string strParsingValue;
            if (value.Contains("跳转到("))
            {
                strParsingValue = value.Replace("跳转到(", "");
                strParsingValue = strParsingValue.Replace(")", "");
                rtn = "return \"" + strParsingValue.Trim() + "\";";
            }
            else if (value.Contains("否则当("))
            {
                rtn = value.Replace("否则当(", "else if(");
            }
            else if (value.Contains("当("))
            {
                rtn = value.Replace("当(", "if(");
            }
            else if (value.Contains("否则"))
            {
                rtn = value.Replace("否则", "else");
            }
            else if (value.Contains("弹窗("))
            {
                strParsingValue = value.Replace("弹窗(", "弹窗(\"");
                int iPos = strParsingValue.LastIndexOf(")");
                strParsingValue = strParsingValue.Insert(iPos, "\"") + ";";
                rtn = strParsingValue;
            }
            else if (value.Contains("弹窗重试("))
            {
                strParsingValue = value.Replace("弹窗重试(", "弹窗重试(\"");
                int iPos = strParsingValue.LastIndexOf(")");
                strParsingValue = strParsingValue.Insert(iPos, "\"") + ";";
                rtn = strParsingValue;
            }
            else if (value.Contains("弹窗确定取消("))
            {
                strParsingValue = value.Replace("弹窗确定取消(", "弹窗确定取消(\"");
                int iPos = strParsingValue.LastIndexOf(")");
                strParsingValue = strParsingValue.Insert(iPos, "\"") + ";";
                rtn = strParsingValue;
            }
            else if (value.Contains("弹窗确定取消("))
            {
                strParsingValue = value.Replace("弹窗确定取消(", "弹窗确定取消(\"");
                int iPos = strParsingValue.LastIndexOf(")");
                strParsingValue = strParsingValue.Insert(iPos, "\"") + ";";
                rtn = strParsingValue;
            }
            else if (CodeComplement(ref value))
            {
                rtn = value;
            }
            if (rtn.IndexOf("[并且]") > 0)
            {
                rtn = rtn.Replace("[并且]", " && ");
            }
            if (rtn.IndexOf("[或者]") > 0)
            {
                rtn = rtn.Replace("[或者]", " || ");
            }
            if (rtn.Length == 0)
                return value + ";";
            return rtn;
        }
        /// <summary>
        /// 判断是否查找到“设置状态”
        /// </summary>
        /// <param name="strValue">判断的字符串</param>
        /// <returns></returns>
        private static bool CodeComplement(ref string strValue)
        {
            foreach (TaskPara itemTaskState in WDTask.ListTaskState)
            {
                if (strValue.Contains("设置" + itemTaskState.Name))
                {
                    strValue = strValue.Replace("设置" + itemTaskState.Name, "设置" + itemTaskState.Name + "();");
                    return true;
                }
            }
            if (strValue.Contains("集合"))
            {
                foreach (TaskPara itemTaskState in WDTask.ListTaskPrivate)
                {
                    if (strValue.Contains(itemTaskState.Name))
                    {
                        int iPos = strValue.IndexOf("=");
                        if (iPos == -1)//不是赋值时不需要增加 "new string[]"
                            return false;
                        strValue = strValue.Insert(iPos + 1, "new string[]") + ";";
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
