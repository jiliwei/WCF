using System;
using System.Windows.Forms;
using WCF;
using static WCF.WCSScriptParent;
public partial class WCSScriptCS
{
	public double 数字总生产量 = 0 ;
	public string 吸嘴真空信号 = "吸嘴真空信号" ;
	public string 贴合段有料信号 = "贴合段有料信号" ;
	public string 飞达有无信号 = "飞达有无信号" ;
	public string 吸嘴真空 = "吸嘴真空" ;
	public string 贴合段流水线启动 = "贴合段流水线启动" ;
	public string 贴合段阻挡气缸 = "贴合段阻挡气缸" ;
	public string 吸嘴破真空 = "吸嘴破真空" ;
	public string 贴合X轴 = "贴合X轴" ;
	public string 贴合Y轴 = "贴合Y轴" ;
	public string 贴合R轴 = "贴合R轴" ;
	public string 贴合Z轴 = "贴合Z轴" ;
	public string 飞达送料轴 = "飞达送料轴" ;
	public string 待机位 = "待机位" ;
	public string 飞达取料位上方 = "飞达取料位上方" ;
	public string 飞达取料位下方 = "飞达取料位下方" ;
	public string 贴合位上方 = "贴合位上方" ;
	public string 贴合位下方 = "贴合位下方" ;
	public string 飞达送料补偿 = "飞达送料补偿" ;
	public string 取料延迟时间 = "取料延迟时间" ;
	public string 贴合延迟时间 = "贴合延迟时间" ;
}
public class 贴合流水线复位 : WCSScriptCS
{
	private double 数字累计计时秒 = 0 ;
	public void TaskSwitch()
	{
		string nowStep = "任务准备";
		TaskContinue:
		switch (nowStep)
		{
			case "任务准备":
				nowStep = 任务准备();
				break;
			case "流水线输出信号复位":
				nowStep = 流水线输出信号复位();
				break;
			case "启动所有流水线":
				nowStep = 启动所有流水线();
				break;
			case "判断有无产品":
				nowStep = 判断有无产品();
				break;
			case "停止所有流水线":
				nowStep = 停止所有流水线();
				break;
			case "提示取走产品":
				nowStep = 提示取走产品();
				break;
			case "设置流水线待机状态":
				nowStep = 设置流水线待机状态();
				break;
			case "任务完成":
				nowStep = 任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合流水线复位", "工作完成或异常，退出工作循环");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "任务准备":
				任务准备();
				break;
			case "流水线输出信号复位":
				流水线输出信号复位();
				break;
			case "启动所有流水线":
				启动所有流水线();
				break;
			case "判断有无产品":
				判断有无产品();
				break;
			case "停止所有流水线":
				停止所有流水线();
				break;
			case "提示取走产品":
				提示取走产品();
				break;
			case "设置流水线待机状态":
				设置流水线待机状态();
				break;
			case "任务完成":
				任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合流水线复位", "单步骤运行异常，请重新“检查流程”");
				return;
		}
	}
	public string 任务准备()
	{
		if (stepCheckTry("贴合流水线复位", "任务准备"))
			return "";
		return "流水线输出信号复位";
	}
	public string 流水线输出信号复位()
	{
		if (stepCheckTry("贴合流水线复位", "流水线输出信号复位"))
			return "";
		设置输出复位(贴合段阻挡气缸);
		return "启动所有流水线";
	}
	public string 启动所有流水线()
	{
		if (stepCheckTry("贴合流水线复位", "启动所有流水线"))
			return "";
		设置输出置位(贴合段流水线启动);
		数字累计计时秒 = 0;
		return "判断有无产品";
	}
	public string 判断有无产品()
	{
		if (stepCheckTry("贴合流水线复位", "判断有无产品"))
			return "";
		if(读取输入置位(贴合段有料信号))
		{
		return "停止所有流水线";
		}
		延迟(1);
		数字累计计时秒++;
		if(数字累计计时秒 > 10)
		{
		return "设置流水线待机状态";
		}
		return "判断有无产品";
		return "停止所有流水线";
	}
	public string 停止所有流水线()
	{
		if (stepCheckTry("贴合流水线复位", "停止所有流水线"))
			return "";
		设置输出复位(贴合段流水线启动);
		return "提示取走产品";
	}
	public string 提示取走产品()
	{
		if (stepCheckTry("贴合流水线复位", "提示取走产品"))
			return "";
		弹窗("流水线复位过程中，贴合段有料信号检测到有信号，请取出产品后再点击确认");
		if(读取输入置位(贴合段有料信号))
		{
		return "提示取走产品";
		}
		else
		{
		return "判断有无产品";
		}
		return "设置流水线待机状态";
	}
	public string 设置流水线待机状态()
	{
		if (stepCheckTry("贴合流水线复位", "设置流水线待机状态"))
			return "";
		设置输出置位(贴合段阻挡气缸);
		return "任务完成";
	}
	public string 任务完成()
	{
		if (stepCheckTry("贴合流水线复位", "任务完成"))
			return "";
		return "";
	}
}
public class 贴合工位复位 : WCSScriptCS
{
	private string[] 集合XYR轴 =  new string[999] ;
	public void TaskSwitch()
	{
		string nowStep = "任务准备";
		TaskContinue:
		switch (nowStep)
		{
			case "任务准备":
				nowStep = 任务准备();
				break;
			case "Z轴复位":
				nowStep = Z轴复位();
				break;
			case "XYR轴复位":
				nowStep = XYR轴复位();
				break;
			case "运动到待机位":
				nowStep = 运动到待机位();
				break;
			case "任务完成":
				nowStep = 任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合工位复位", "工作完成或异常，退出工作循环");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "任务准备":
				任务准备();
				break;
			case "Z轴复位":
				Z轴复位();
				break;
			case "XYR轴复位":
				XYR轴复位();
				break;
			case "运动到待机位":
				运动到待机位();
				break;
			case "任务完成":
				任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合工位复位", "单步骤运行异常，请重新“检查流程”");
				return;
		}
	}
	public string 任务准备()
	{
		if (stepCheckTry("贴合工位复位", "任务准备"))
			return "";
		return "Z轴复位";
	}
	public string Z轴复位()
	{
		if (stepCheckTry("贴合工位复位", "Z轴复位"))
			return "";
		单轴回零(贴合Z轴);
		return "XYR轴复位";
	}
	public string XYR轴复位()
	{
		if (stepCheckTry("贴合工位复位", "XYR轴复位"))
			return "";
		集合XYR轴=new string[]{贴合X轴,贴合Y轴,贴合R轴};
		多轴回零(集合XYR轴);
		return "运动到待机位";
	}
	public string 运动到待机位()
	{
		if (stepCheckTry("贴合工位复位", "运动到待机位"))
			return "";
		绝对运动(待机位);
		return "任务完成";
	}
	public string 任务完成()
	{
		if (stepCheckTry("贴合工位复位", "任务完成"))
			return "";
		return "";
	}
}
public class 飞达送料 : WCSScriptCS
{
	public enum S
	{
		状态正在供料,
		状态供料完成,
		状态取料完成,
	}
	private static S 状态;
	public static bool 状态正在供料
	{
		get
		{
			if (状态 == S.状态正在供料)
				return true;
			return false;
		}
	}
	public static bool 状态供料完成
	{
		get
		{
			if (状态 == S.状态供料完成)
				return true;
			return false;
		}
	}
	public static bool 状态取料完成
	{
		get
		{
			if (状态 == S.状态取料完成)
				return true;
			return false;
		}
	}
	public static void 设置状态正在供料()
	{
		状态 = S.状态正在供料;
	}
	public static void 设置状态供料完成()
	{
		状态 = S.状态供料完成;
	}
	public static void 设置状态取料完成()
	{
		状态 = S.状态取料完成;
	}
	public void TaskSwitch()
	{
		string nowStep = "任务准备";
		TaskContinue:
		switch (nowStep)
		{
			case "任务准备":
				nowStep = 任务准备();
				break;
			case "判断飞达是否有料":
				nowStep = 判断飞达是否有料();
				break;
			case "飞达连续送料":
				nowStep = 飞达连续送料();
				break;
			case "判断飞达是否有信号":
				nowStep = 判断飞达是否有信号();
				break;
			case "飞达停止送料":
				nowStep = 飞达停止送料();
				break;
			case "飞达固定送料一段距离":
				nowStep = 飞达固定送料一段距离();
				break;
			case "设置供料完成":
				nowStep = 设置供料完成();
				break;
			case "等待取料":
				nowStep = 等待取料();
				break;
			case "任务完成":
				nowStep = 任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "飞达送料", "工作完成或异常，退出工作循环");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "任务准备":
				任务准备();
				break;
			case "判断飞达是否有料":
				判断飞达是否有料();
				break;
			case "飞达连续送料":
				飞达连续送料();
				break;
			case "判断飞达是否有信号":
				判断飞达是否有信号();
				break;
			case "飞达停止送料":
				飞达停止送料();
				break;
			case "飞达固定送料一段距离":
				飞达固定送料一段距离();
				break;
			case "设置供料完成":
				设置供料完成();
				break;
			case "等待取料":
				等待取料();
				break;
			case "任务完成":
				任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "飞达送料", "单步骤运行异常，请重新“检查流程”");
				return;
		}
	}
	public string 任务准备()
	{
		if (stepCheckTry("飞达送料", "任务准备"))
			return "";
		return "判断飞达是否有料";
	}
	public string 判断飞达是否有料()
	{
		if (stepCheckTry("飞达送料", "判断飞达是否有料"))
			return "";
		if(读取输入置位(飞达有无信号))
		{
		return "设置供料完成";
		}
		else
		{
		return "飞达连续送料";
		}
		return "飞达连续送料";
	}
	public string 飞达连续送料()
	{
		if (stepCheckTry("飞达送料", "飞达连续送料"))
			return "";
		连续运动(飞达送料轴);
		return "判断飞达是否有信号";
	}
	public string 判断飞达是否有信号()
	{
		if (stepCheckTry("飞达送料", "判断飞达是否有信号"))
			return "";
		if(读取输入复位(飞达有无信号))
		{
		    延迟(0.01);
		return "判断飞达是否有信号";
		}
		else
		{
		return "飞达停止送料";
		}
		return "飞达停止送料";
	}
	public string 飞达停止送料()
	{
		if (stepCheckTry("飞达送料", "飞达停止送料"))
			return "";
		单轴停止(飞达送料轴);
		return "飞达固定送料一段距离";
	}
	public string 飞达固定送料一段距离()
	{
		if (stepCheckTry("飞达送料", "飞达固定送料一段距离"))
			return "";
		相对运动(飞达送料轴,飞达送料补偿);
		return "设置供料完成";
	}
	public string 设置供料完成()
	{
		if (stepCheckTry("飞达送料", "设置供料完成"))
			return "";
		设置状态供料完成();
		return "等待取料";
	}
	public string 等待取料()
	{
		if (stepCheckTry("飞达送料", "等待取料"))
			return "";
		if(状态取料完成)
		{
		return "任务完成";
		}
		else
		{
		return "等待取料";
		}
		return "任务完成";
	}
	public string 任务完成()
	{
		if (stepCheckTry("飞达送料", "任务完成"))
			return "";
		return "任务准备";
		return "";
	}
}
public class 贴合段流水线 : WCSScriptCS
{
	public enum S
	{
		状态进料动作,
		状态产品到位,
		状态贴合完成,
		状态产品流出,
	}
	private static S 状态;
	public static bool 状态进料动作
	{
		get
		{
			if (状态 == S.状态进料动作)
				return true;
			return false;
		}
	}
	public static bool 状态产品到位
	{
		get
		{
			if (状态 == S.状态产品到位)
				return true;
			return false;
		}
	}
	public static bool 状态贴合完成
	{
		get
		{
			if (状态 == S.状态贴合完成)
				return true;
			return false;
		}
	}
	public static bool 状态产品流出
	{
		get
		{
			if (状态 == S.状态产品流出)
				return true;
			return false;
		}
	}
	public static void 设置状态进料动作()
	{
		状态 = S.状态进料动作;
	}
	public static void 设置状态产品到位()
	{
		状态 = S.状态产品到位;
	}
	public static void 设置状态贴合完成()
	{
		状态 = S.状态贴合完成;
	}
	public static void 设置状态产品流出()
	{
		状态 = S.状态产品流出;
	}
	public void TaskSwitch()
	{
		string nowStep = "任务准备";
		TaskContinue:
		switch (nowStep)
		{
			case "任务准备":
				nowStep = 任务准备();
				break;
			case "启动流水线进料":
				nowStep = 启动流水线进料();
				break;
			case "检测贴合段有料信号":
				nowStep = 检测贴合段有料信号();
				break;
			case "进料完成流水线停止":
				nowStep = 进料完成流水线停止();
				break;
			case "设置产品到位":
				nowStep = 设置产品到位();
				break;
			case "等待贴合动作完成":
				nowStep = 等待贴合动作完成();
				break;
			case "阻挡气缸下降":
				nowStep = 阻挡气缸下降();
				break;
			case "启动流水线出料":
				nowStep = 启动流水线出料();
				break;
			case "检测贴合段无信号":
				nowStep = 检测贴合段无信号();
				break;
			case "出料完成流水线停止":
				nowStep = 出料完成流水线停止();
				break;
			case "任务完成":
				nowStep = 任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合段流水线", "工作完成或异常，退出工作循环");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "任务准备":
				任务准备();
				break;
			case "启动流水线进料":
				启动流水线进料();
				break;
			case "检测贴合段有料信号":
				检测贴合段有料信号();
				break;
			case "进料完成流水线停止":
				进料完成流水线停止();
				break;
			case "设置产品到位":
				设置产品到位();
				break;
			case "等待贴合动作完成":
				等待贴合动作完成();
				break;
			case "阻挡气缸下降":
				阻挡气缸下降();
				break;
			case "启动流水线出料":
				启动流水线出料();
				break;
			case "检测贴合段无信号":
				检测贴合段无信号();
				break;
			case "出料完成流水线停止":
				出料完成流水线停止();
				break;
			case "任务完成":
				任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合段流水线", "单步骤运行异常，请重新“检查流程”");
				return;
		}
	}
	public string 任务准备()
	{
		if (stepCheckTry("贴合段流水线", "任务准备"))
			return "";
		设置输出置位(贴合段阻挡气缸);
		return "启动流水线进料";
	}
	public string 启动流水线进料()
	{
		if (stepCheckTry("贴合段流水线", "启动流水线进料"))
			return "";
		设置输出置位(贴合段流水线启动);
		return "检测贴合段有料信号";
	}
	public string 检测贴合段有料信号()
	{
		if (stepCheckTry("贴合段流水线", "检测贴合段有料信号"))
			return "";
		if(读取输入置位(贴合段有料信号))
		{
		return "进料完成流水线停止";
		}
		else
		{
		return "检测贴合段有料信号";
		}
		return "进料完成流水线停止";
	}
	public string 进料完成流水线停止()
	{
		if (stepCheckTry("贴合段流水线", "进料完成流水线停止"))
			return "";
		设置输出复位(贴合段流水线启动);
		return "设置产品到位";
	}
	public string 设置产品到位()
	{
		if (stepCheckTry("贴合段流水线", "设置产品到位"))
			return "";
		设置状态产品到位();
		return "等待贴合动作完成";
	}
	public string 等待贴合动作完成()
	{
		if (stepCheckTry("贴合段流水线", "等待贴合动作完成"))
			return "";
		if(状态贴合完成)
		{
		return "阻挡气缸下降";
		}
		else
		{
		return "等待贴合动作完成";
		}
		return "阻挡气缸下降";
	}
	public string 阻挡气缸下降()
	{
		if (stepCheckTry("贴合段流水线", "阻挡气缸下降"))
			return "";
		设置输出复位(贴合段阻挡气缸);
		return "启动流水线出料";
	}
	public string 启动流水线出料()
	{
		if (stepCheckTry("贴合段流水线", "启动流水线出料"))
			return "";
		设置输出置位(贴合段流水线启动);
		return "检测贴合段无信号";
	}
	public string 检测贴合段无信号()
	{
		if (stepCheckTry("贴合段流水线", "检测贴合段无信号"))
			return "";
		if(读取输入置位(贴合段有料信号))
		{
		return "检测贴合段无信号";
		}
		else
		{
		return "出料完成流水线停止";
		}
		return "出料完成流水线停止";
	}
	public string 出料完成流水线停止()
	{
		if (stepCheckTry("贴合段流水线", "出料完成流水线停止"))
			return "";
		设置输出复位(贴合段流水线启动);
		return "任务完成";
	}
	public string 任务完成()
	{
		if (stepCheckTry("贴合段流水线", "任务完成"))
			return "";
		return "任务准备";
		return "";
	}
}
public class 贴合任务 : WCSScriptCS
{
	public enum S
	{
		状态等待供料完成,
		状态取料动作,
		状态等待产品到位,
		状态贴合动作,
	}
	private static S 状态;
	public static bool 状态等待供料完成
	{
		get
		{
			if (状态 == S.状态等待供料完成)
				return true;
			return false;
		}
	}
	public static bool 状态取料动作
	{
		get
		{
			if (状态 == S.状态取料动作)
				return true;
			return false;
		}
	}
	public static bool 状态等待产品到位
	{
		get
		{
			if (状态 == S.状态等待产品到位)
				return true;
			return false;
		}
	}
	public static bool 状态贴合动作
	{
		get
		{
			if (状态 == S.状态贴合动作)
				return true;
			return false;
		}
	}
	public static void 设置状态等待供料完成()
	{
		状态 = S.状态等待供料完成;
	}
	public static void 设置状态取料动作()
	{
		状态 = S.状态取料动作;
	}
	public static void 设置状态等待产品到位()
	{
		状态 = S.状态等待产品到位;
	}
	public static void 设置状态贴合动作()
	{
		状态 = S.状态贴合动作;
	}
	private double 数字累计计时 = 0 ;
	public void TaskSwitch()
	{
		string nowStep = "任务准备";
		TaskContinue:
		switch (nowStep)
		{
			case "任务准备":
				nowStep = 任务准备();
				break;
			case "运动到飞达取料位上方":
				nowStep = 运动到飞达取料位上方();
				break;
			case "等待飞达供料完成":
				nowStep = 等待飞达供料完成();
				break;
			case "吸嘴取料动作":
				nowStep = 吸嘴取料动作();
				break;
			case "判断吸嘴是否取料成功":
				nowStep = 判断吸嘴是否取料成功();
				break;
			case "设置飞达供料完成":
				nowStep = 设置飞达供料完成();
				break;
			case "运动到贴合位上方":
				nowStep = 运动到贴合位上方();
				break;
			case "等待产品到位":
				nowStep = 等待产品到位();
				break;
			case "吸嘴贴合动作":
				nowStep = 吸嘴贴合动作();
				break;
			case "设置贴合完成":
				nowStep = 设置贴合完成();
				break;
			case "任务完成":
				nowStep = 任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合任务", "工作完成或异常，退出工作循环");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "任务准备":
				任务准备();
				break;
			case "运动到飞达取料位上方":
				运动到飞达取料位上方();
				break;
			case "等待飞达供料完成":
				等待飞达供料完成();
				break;
			case "吸嘴取料动作":
				吸嘴取料动作();
				break;
			case "判断吸嘴是否取料成功":
				判断吸嘴是否取料成功();
				break;
			case "设置飞达供料完成":
				设置飞达供料完成();
				break;
			case "运动到贴合位上方":
				运动到贴合位上方();
				break;
			case "等待产品到位":
				等待产品到位();
				break;
			case "吸嘴贴合动作":
				吸嘴贴合动作();
				break;
			case "设置贴合完成":
				设置贴合完成();
				break;
			case "任务完成":
				任务完成();
				break;
			default:
				WDLog.InsertLog("流程运行", 1, "贴合任务", "单步骤运行异常，请重新“检查流程”");
				return;
		}
	}
	public string 任务准备()
	{
		if (stepCheckTry("贴合任务", "任务准备"))
			return "";
		return "运动到飞达取料位上方";
	}
	public string 运动到飞达取料位上方()
	{
		if (stepCheckTry("贴合任务", "运动到飞达取料位上方"))
			return "";
		绝对运动(飞达取料位上方);
		return "等待飞达供料完成";
	}
	public string 等待飞达供料完成()
	{
		if (stepCheckTry("贴合任务", "等待飞达供料完成"))
			return "";
		if(飞达送料.状态供料完成)
		{
		return "吸嘴取料动作";
		}
		else
		{
		return "等待飞达供料完成";
		}
		return "吸嘴取料动作";
	}
	public string 吸嘴取料动作()
	{
		if (stepCheckTry("贴合任务", "吸嘴取料动作"))
			return "";
		绝对运动(飞达取料位下方);
		设置输出置位(吸嘴真空);
		延迟(取料延迟时间);
		绝对运动(飞达取料位上方);
		return "判断吸嘴是否取料成功";
	}
	public string 判断吸嘴是否取料成功()
	{
		if (stepCheckTry("贴合任务", "判断吸嘴是否取料成功"))
			return "";
		if(读取输入置位(吸嘴真空信号))
		{
		return "设置飞达供料完成";
		}
		else
		{
		return "吸嘴取料动作";
		}
		return "设置飞达供料完成";
	}
	public string 设置飞达供料完成()
	{
		if (stepCheckTry("贴合任务", "设置飞达供料完成"))
			return "";
		飞达送料.设置状态取料完成();
		return "运动到贴合位上方";
	}
	public string 运动到贴合位上方()
	{
		if (stepCheckTry("贴合任务", "运动到贴合位上方"))
			return "";
		绝对运动(贴合位上方);
		return "等待产品到位";
	}
	public string 等待产品到位()
	{
		if (stepCheckTry("贴合任务", "等待产品到位"))
			return "";
		if(贴合段流水线.状态产品到位)
		{
		return "吸嘴贴合动作";
		}
		else
		{
		return "等待产品到位";
		}
		return "吸嘴贴合动作";
	}
	public string 吸嘴贴合动作()
	{
		if (stepCheckTry("贴合任务", "吸嘴贴合动作"))
			return "";
		绝对运动(贴合位下方);
		设置输出复位(吸嘴真空);
		设置输出置位(吸嘴破真空);
		延迟(贴合延迟时间);
		绝对运动(贴合位上方);
		return "设置贴合完成";
	}
	public string 设置贴合完成()
	{
		if (stepCheckTry("贴合任务", "设置贴合完成"))
			return "";
		贴合段流水线.设置状态贴合完成();
		return "任务完成";
	}
	public string 任务完成()
	{
		if (stepCheckTry("贴合任务", "任务完成"))
			return "";
		return "任务准备";
		return "";
	}
}
