using System;
using System.Windows.Forms;
using WCF;
using static WCF.WCSScriptParent;
public partial class WCSScriptCS
{
	public double ������������ = 0 ;
	public string ��������ź� = "��������ź�" ;
	public string ���϶������ź� = "���϶������ź�" ;
	public string �ɴ������ź� = "�ɴ������ź�" ;
	public string ������� = "�������" ;
	public string ���϶���ˮ������ = "���϶���ˮ������" ;
	public string ���϶��赲���� = "���϶��赲����" ;
	public string ��������� = "���������" ;
	public string ����X�� = "����X��" ;
	public string ����Y�� = "����Y��" ;
	public string ����R�� = "����R��" ;
	public string ����Z�� = "����Z��" ;
	public string �ɴ������� = "�ɴ�������" ;
	public string ����λ = "����λ" ;
	public string �ɴ�ȡ��λ�Ϸ� = "�ɴ�ȡ��λ�Ϸ�" ;
	public string �ɴ�ȡ��λ�·� = "�ɴ�ȡ��λ�·�" ;
	public string ����λ�Ϸ� = "����λ�Ϸ�" ;
	public string ����λ�·� = "����λ�·�" ;
	public string �ɴ����ϲ��� = "�ɴ����ϲ���" ;
	public string ȡ���ӳ�ʱ�� = "ȡ���ӳ�ʱ��" ;
	public string �����ӳ�ʱ�� = "�����ӳ�ʱ��" ;
}
public class ������ˮ�߸�λ : WCSScriptCS
{
	private double �����ۼƼ�ʱ�� = 0 ;
	public void TaskSwitch()
	{
		string nowStep = "����׼��";
		TaskContinue:
		switch (nowStep)
		{
			case "����׼��":
				nowStep = ����׼��();
				break;
			case "��ˮ������źŸ�λ":
				nowStep = ��ˮ������źŸ�λ();
				break;
			case "����������ˮ��":
				nowStep = ����������ˮ��();
				break;
			case "�ж����޲�Ʒ":
				nowStep = �ж����޲�Ʒ();
				break;
			case "ֹͣ������ˮ��":
				nowStep = ֹͣ������ˮ��();
				break;
			case "��ʾȡ�߲�Ʒ":
				nowStep = ��ʾȡ�߲�Ʒ();
				break;
			case "������ˮ�ߴ���״̬":
				nowStep = ������ˮ�ߴ���״̬();
				break;
			case "�������":
				nowStep = �������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "������ˮ�߸�λ", "������ɻ��쳣���˳�����ѭ��");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "����׼��":
				����׼��();
				break;
			case "��ˮ������źŸ�λ":
				��ˮ������źŸ�λ();
				break;
			case "����������ˮ��":
				����������ˮ��();
				break;
			case "�ж����޲�Ʒ":
				�ж����޲�Ʒ();
				break;
			case "ֹͣ������ˮ��":
				ֹͣ������ˮ��();
				break;
			case "��ʾȡ�߲�Ʒ":
				��ʾȡ�߲�Ʒ();
				break;
			case "������ˮ�ߴ���״̬":
				������ˮ�ߴ���״̬();
				break;
			case "�������":
				�������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "������ˮ�߸�λ", "�����������쳣�������¡�������̡�");
				return;
		}
	}
	public string ����׼��()
	{
		if (stepCheckTry("������ˮ�߸�λ", "����׼��"))
			return "";
		return "��ˮ������źŸ�λ";
	}
	public string ��ˮ������źŸ�λ()
	{
		if (stepCheckTry("������ˮ�߸�λ", "��ˮ������źŸ�λ"))
			return "";
		���������λ(���϶��赲����);
		return "����������ˮ��";
	}
	public string ����������ˮ��()
	{
		if (stepCheckTry("������ˮ�߸�λ", "����������ˮ��"))
			return "";
		���������λ(���϶���ˮ������);
		�����ۼƼ�ʱ�� = 0;
		return "�ж����޲�Ʒ";
	}
	public string �ж����޲�Ʒ()
	{
		if (stepCheckTry("������ˮ�߸�λ", "�ж����޲�Ʒ"))
			return "";
		if(��ȡ������λ(���϶������ź�))
		{
		return "ֹͣ������ˮ��";
		}
		�ӳ�(1);
		�����ۼƼ�ʱ��++;
		if(�����ۼƼ�ʱ�� > 10)
		{
		return "������ˮ�ߴ���״̬";
		}
		return "�ж����޲�Ʒ";
		return "ֹͣ������ˮ��";
	}
	public string ֹͣ������ˮ��()
	{
		if (stepCheckTry("������ˮ�߸�λ", "ֹͣ������ˮ��"))
			return "";
		���������λ(���϶���ˮ������);
		return "��ʾȡ�߲�Ʒ";
	}
	public string ��ʾȡ�߲�Ʒ()
	{
		if (stepCheckTry("������ˮ�߸�λ", "��ʾȡ�߲�Ʒ"))
			return "";
		����("��ˮ�߸�λ�����У����϶������źż�⵽���źţ���ȡ����Ʒ���ٵ��ȷ��");
		if(��ȡ������λ(���϶������ź�))
		{
		return "��ʾȡ�߲�Ʒ";
		}
		else
		{
		return "�ж����޲�Ʒ";
		}
		return "������ˮ�ߴ���״̬";
	}
	public string ������ˮ�ߴ���״̬()
	{
		if (stepCheckTry("������ˮ�߸�λ", "������ˮ�ߴ���״̬"))
			return "";
		���������λ(���϶��赲����);
		return "�������";
	}
	public string �������()
	{
		if (stepCheckTry("������ˮ�߸�λ", "�������"))
			return "";
		return "";
	}
}
public class ���Ϲ�λ��λ : WCSScriptCS
{
	private string[] ����XYR�� =  new string[999] ;
	public void TaskSwitch()
	{
		string nowStep = "����׼��";
		TaskContinue:
		switch (nowStep)
		{
			case "����׼��":
				nowStep = ����׼��();
				break;
			case "Z�Ḵλ":
				nowStep = Z�Ḵλ();
				break;
			case "XYR�Ḵλ":
				nowStep = XYR�Ḵλ();
				break;
			case "�˶�������λ":
				nowStep = �˶�������λ();
				break;
			case "�������":
				nowStep = �������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "���Ϲ�λ��λ", "������ɻ��쳣���˳�����ѭ��");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "����׼��":
				����׼��();
				break;
			case "Z�Ḵλ":
				Z�Ḵλ();
				break;
			case "XYR�Ḵλ":
				XYR�Ḵλ();
				break;
			case "�˶�������λ":
				�˶�������λ();
				break;
			case "�������":
				�������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "���Ϲ�λ��λ", "�����������쳣�������¡�������̡�");
				return;
		}
	}
	public string ����׼��()
	{
		if (stepCheckTry("���Ϲ�λ��λ", "����׼��"))
			return "";
		return "Z�Ḵλ";
	}
	public string Z�Ḵλ()
	{
		if (stepCheckTry("���Ϲ�λ��λ", "Z�Ḵλ"))
			return "";
		�������(����Z��);
		return "XYR�Ḵλ";
	}
	public string XYR�Ḵλ()
	{
		if (stepCheckTry("���Ϲ�λ��λ", "XYR�Ḵλ"))
			return "";
		����XYR��=new string[]{����X��,����Y��,����R��};
		�������(����XYR��);
		return "�˶�������λ";
	}
	public string �˶�������λ()
	{
		if (stepCheckTry("���Ϲ�λ��λ", "�˶�������λ"))
			return "";
		�����˶�(����λ);
		return "�������";
	}
	public string �������()
	{
		if (stepCheckTry("���Ϲ�λ��λ", "�������"))
			return "";
		return "";
	}
}
public class �ɴ����� : WCSScriptCS
{
	public enum S
	{
		״̬���ڹ���,
		״̬�������,
		״̬ȡ�����,
	}
	private static S ״̬;
	public static bool ״̬���ڹ���
	{
		get
		{
			if (״̬ == S.״̬���ڹ���)
				return true;
			return false;
		}
	}
	public static bool ״̬�������
	{
		get
		{
			if (״̬ == S.״̬�������)
				return true;
			return false;
		}
	}
	public static bool ״̬ȡ�����
	{
		get
		{
			if (״̬ == S.״̬ȡ�����)
				return true;
			return false;
		}
	}
	public static void ����״̬���ڹ���()
	{
		״̬ = S.״̬���ڹ���;
	}
	public static void ����״̬�������()
	{
		״̬ = S.״̬�������;
	}
	public static void ����״̬ȡ�����()
	{
		״̬ = S.״̬ȡ�����;
	}
	public void TaskSwitch()
	{
		string nowStep = "����׼��";
		TaskContinue:
		switch (nowStep)
		{
			case "����׼��":
				nowStep = ����׼��();
				break;
			case "�жϷɴ��Ƿ�����":
				nowStep = �жϷɴ��Ƿ�����();
				break;
			case "�ɴ���������":
				nowStep = �ɴ���������();
				break;
			case "�жϷɴ��Ƿ����ź�":
				nowStep = �жϷɴ��Ƿ����ź�();
				break;
			case "�ɴ�ֹͣ����":
				nowStep = �ɴ�ֹͣ����();
				break;
			case "�ɴ�̶�����һ�ξ���":
				nowStep = �ɴ�̶�����һ�ξ���();
				break;
			case "���ù������":
				nowStep = ���ù������();
				break;
			case "�ȴ�ȡ��":
				nowStep = �ȴ�ȡ��();
				break;
			case "�������":
				nowStep = �������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "�ɴ�����", "������ɻ��쳣���˳�����ѭ��");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "����׼��":
				����׼��();
				break;
			case "�жϷɴ��Ƿ�����":
				�жϷɴ��Ƿ�����();
				break;
			case "�ɴ���������":
				�ɴ���������();
				break;
			case "�жϷɴ��Ƿ����ź�":
				�жϷɴ��Ƿ����ź�();
				break;
			case "�ɴ�ֹͣ����":
				�ɴ�ֹͣ����();
				break;
			case "�ɴ�̶�����һ�ξ���":
				�ɴ�̶�����һ�ξ���();
				break;
			case "���ù������":
				���ù������();
				break;
			case "�ȴ�ȡ��":
				�ȴ�ȡ��();
				break;
			case "�������":
				�������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "�ɴ�����", "�����������쳣�������¡�������̡�");
				return;
		}
	}
	public string ����׼��()
	{
		if (stepCheckTry("�ɴ�����", "����׼��"))
			return "";
		return "�жϷɴ��Ƿ�����";
	}
	public string �жϷɴ��Ƿ�����()
	{
		if (stepCheckTry("�ɴ�����", "�жϷɴ��Ƿ�����"))
			return "";
		if(��ȡ������λ(�ɴ������ź�))
		{
		return "���ù������";
		}
		else
		{
		return "�ɴ���������";
		}
		return "�ɴ���������";
	}
	public string �ɴ���������()
	{
		if (stepCheckTry("�ɴ�����", "�ɴ���������"))
			return "";
		�����˶�(�ɴ�������);
		return "�жϷɴ��Ƿ����ź�";
	}
	public string �жϷɴ��Ƿ����ź�()
	{
		if (stepCheckTry("�ɴ�����", "�жϷɴ��Ƿ����ź�"))
			return "";
		if(��ȡ���븴λ(�ɴ������ź�))
		{
		    �ӳ�(0.01);
		return "�жϷɴ��Ƿ����ź�";
		}
		else
		{
		return "�ɴ�ֹͣ����";
		}
		return "�ɴ�ֹͣ����";
	}
	public string �ɴ�ֹͣ����()
	{
		if (stepCheckTry("�ɴ�����", "�ɴ�ֹͣ����"))
			return "";
		����ֹͣ(�ɴ�������);
		return "�ɴ�̶�����һ�ξ���";
	}
	public string �ɴ�̶�����һ�ξ���()
	{
		if (stepCheckTry("�ɴ�����", "�ɴ�̶�����һ�ξ���"))
			return "";
		����˶�(�ɴ�������,�ɴ����ϲ���);
		return "���ù������";
	}
	public string ���ù������()
	{
		if (stepCheckTry("�ɴ�����", "���ù������"))
			return "";
		����״̬�������();
		return "�ȴ�ȡ��";
	}
	public string �ȴ�ȡ��()
	{
		if (stepCheckTry("�ɴ�����", "�ȴ�ȡ��"))
			return "";
		if(״̬ȡ�����)
		{
		return "�������";
		}
		else
		{
		return "�ȴ�ȡ��";
		}
		return "�������";
	}
	public string �������()
	{
		if (stepCheckTry("�ɴ�����", "�������"))
			return "";
		return "����׼��";
		return "";
	}
}
public class ���϶���ˮ�� : WCSScriptCS
{
	public enum S
	{
		״̬���϶���,
		״̬��Ʒ��λ,
		״̬�������,
		״̬��Ʒ����,
	}
	private static S ״̬;
	public static bool ״̬���϶���
	{
		get
		{
			if (״̬ == S.״̬���϶���)
				return true;
			return false;
		}
	}
	public static bool ״̬��Ʒ��λ
	{
		get
		{
			if (״̬ == S.״̬��Ʒ��λ)
				return true;
			return false;
		}
	}
	public static bool ״̬�������
	{
		get
		{
			if (״̬ == S.״̬�������)
				return true;
			return false;
		}
	}
	public static bool ״̬��Ʒ����
	{
		get
		{
			if (״̬ == S.״̬��Ʒ����)
				return true;
			return false;
		}
	}
	public static void ����״̬���϶���()
	{
		״̬ = S.״̬���϶���;
	}
	public static void ����״̬��Ʒ��λ()
	{
		״̬ = S.״̬��Ʒ��λ;
	}
	public static void ����״̬�������()
	{
		״̬ = S.״̬�������;
	}
	public static void ����״̬��Ʒ����()
	{
		״̬ = S.״̬��Ʒ����;
	}
	public void TaskSwitch()
	{
		string nowStep = "����׼��";
		TaskContinue:
		switch (nowStep)
		{
			case "����׼��":
				nowStep = ����׼��();
				break;
			case "������ˮ�߽���":
				nowStep = ������ˮ�߽���();
				break;
			case "������϶������ź�":
				nowStep = ������϶������ź�();
				break;
			case "���������ˮ��ֹͣ":
				nowStep = ���������ˮ��ֹͣ();
				break;
			case "���ò�Ʒ��λ":
				nowStep = ���ò�Ʒ��λ();
				break;
			case "�ȴ����϶������":
				nowStep = �ȴ����϶������();
				break;
			case "�赲�����½�":
				nowStep = �赲�����½�();
				break;
			case "������ˮ�߳���":
				nowStep = ������ˮ�߳���();
				break;
			case "������϶����ź�":
				nowStep = ������϶����ź�();
				break;
			case "���������ˮ��ֹͣ":
				nowStep = ���������ˮ��ֹͣ();
				break;
			case "�������":
				nowStep = �������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "���϶���ˮ��", "������ɻ��쳣���˳�����ѭ��");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "����׼��":
				����׼��();
				break;
			case "������ˮ�߽���":
				������ˮ�߽���();
				break;
			case "������϶������ź�":
				������϶������ź�();
				break;
			case "���������ˮ��ֹͣ":
				���������ˮ��ֹͣ();
				break;
			case "���ò�Ʒ��λ":
				���ò�Ʒ��λ();
				break;
			case "�ȴ����϶������":
				�ȴ����϶������();
				break;
			case "�赲�����½�":
				�赲�����½�();
				break;
			case "������ˮ�߳���":
				������ˮ�߳���();
				break;
			case "������϶����ź�":
				������϶����ź�();
				break;
			case "���������ˮ��ֹͣ":
				���������ˮ��ֹͣ();
				break;
			case "�������":
				�������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "���϶���ˮ��", "�����������쳣�������¡�������̡�");
				return;
		}
	}
	public string ����׼��()
	{
		if (stepCheckTry("���϶���ˮ��", "����׼��"))
			return "";
		���������λ(���϶��赲����);
		return "������ˮ�߽���";
	}
	public string ������ˮ�߽���()
	{
		if (stepCheckTry("���϶���ˮ��", "������ˮ�߽���"))
			return "";
		���������λ(���϶���ˮ������);
		return "������϶������ź�";
	}
	public string ������϶������ź�()
	{
		if (stepCheckTry("���϶���ˮ��", "������϶������ź�"))
			return "";
		if(��ȡ������λ(���϶������ź�))
		{
		return "���������ˮ��ֹͣ";
		}
		else
		{
		return "������϶������ź�";
		}
		return "���������ˮ��ֹͣ";
	}
	public string ���������ˮ��ֹͣ()
	{
		if (stepCheckTry("���϶���ˮ��", "���������ˮ��ֹͣ"))
			return "";
		���������λ(���϶���ˮ������);
		return "���ò�Ʒ��λ";
	}
	public string ���ò�Ʒ��λ()
	{
		if (stepCheckTry("���϶���ˮ��", "���ò�Ʒ��λ"))
			return "";
		����״̬��Ʒ��λ();
		return "�ȴ����϶������";
	}
	public string �ȴ����϶������()
	{
		if (stepCheckTry("���϶���ˮ��", "�ȴ����϶������"))
			return "";
		if(״̬�������)
		{
		return "�赲�����½�";
		}
		else
		{
		return "�ȴ����϶������";
		}
		return "�赲�����½�";
	}
	public string �赲�����½�()
	{
		if (stepCheckTry("���϶���ˮ��", "�赲�����½�"))
			return "";
		���������λ(���϶��赲����);
		return "������ˮ�߳���";
	}
	public string ������ˮ�߳���()
	{
		if (stepCheckTry("���϶���ˮ��", "������ˮ�߳���"))
			return "";
		���������λ(���϶���ˮ������);
		return "������϶����ź�";
	}
	public string ������϶����ź�()
	{
		if (stepCheckTry("���϶���ˮ��", "������϶����ź�"))
			return "";
		if(��ȡ������λ(���϶������ź�))
		{
		return "������϶����ź�";
		}
		else
		{
		return "���������ˮ��ֹͣ";
		}
		return "���������ˮ��ֹͣ";
	}
	public string ���������ˮ��ֹͣ()
	{
		if (stepCheckTry("���϶���ˮ��", "���������ˮ��ֹͣ"))
			return "";
		���������λ(���϶���ˮ������);
		return "�������";
	}
	public string �������()
	{
		if (stepCheckTry("���϶���ˮ��", "�������"))
			return "";
		return "����׼��";
		return "";
	}
}
public class �������� : WCSScriptCS
{
	public enum S
	{
		״̬�ȴ��������,
		״̬ȡ�϶���,
		״̬�ȴ���Ʒ��λ,
		״̬���϶���,
	}
	private static S ״̬;
	public static bool ״̬�ȴ��������
	{
		get
		{
			if (״̬ == S.״̬�ȴ��������)
				return true;
			return false;
		}
	}
	public static bool ״̬ȡ�϶���
	{
		get
		{
			if (״̬ == S.״̬ȡ�϶���)
				return true;
			return false;
		}
	}
	public static bool ״̬�ȴ���Ʒ��λ
	{
		get
		{
			if (״̬ == S.״̬�ȴ���Ʒ��λ)
				return true;
			return false;
		}
	}
	public static bool ״̬���϶���
	{
		get
		{
			if (״̬ == S.״̬���϶���)
				return true;
			return false;
		}
	}
	public static void ����״̬�ȴ��������()
	{
		״̬ = S.״̬�ȴ��������;
	}
	public static void ����״̬ȡ�϶���()
	{
		״̬ = S.״̬ȡ�϶���;
	}
	public static void ����״̬�ȴ���Ʒ��λ()
	{
		״̬ = S.״̬�ȴ���Ʒ��λ;
	}
	public static void ����״̬���϶���()
	{
		״̬ = S.״̬���϶���;
	}
	private double �����ۼƼ�ʱ = 0 ;
	public void TaskSwitch()
	{
		string nowStep = "����׼��";
		TaskContinue:
		switch (nowStep)
		{
			case "����׼��":
				nowStep = ����׼��();
				break;
			case "�˶����ɴ�ȡ��λ�Ϸ�":
				nowStep = �˶����ɴ�ȡ��λ�Ϸ�();
				break;
			case "�ȴ��ɴ﹩�����":
				nowStep = �ȴ��ɴ﹩�����();
				break;
			case "����ȡ�϶���":
				nowStep = ����ȡ�϶���();
				break;
			case "�ж������Ƿ�ȡ�ϳɹ�":
				nowStep = �ж������Ƿ�ȡ�ϳɹ�();
				break;
			case "���÷ɴ﹩�����":
				nowStep = ���÷ɴ﹩�����();
				break;
			case "�˶�������λ�Ϸ�":
				nowStep = �˶�������λ�Ϸ�();
				break;
			case "�ȴ���Ʒ��λ":
				nowStep = �ȴ���Ʒ��λ();
				break;
			case "�������϶���":
				nowStep = �������϶���();
				break;
			case "�����������":
				nowStep = �����������();
				break;
			case "�������":
				nowStep = �������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "��������", "������ɻ��쳣���˳�����ѭ��");
				return;
		}
		goto TaskContinue;
	}
	public void StepSwitch(string strStep)
	{
		switch (strStep)
		{
			case "����׼��":
				����׼��();
				break;
			case "�˶����ɴ�ȡ��λ�Ϸ�":
				�˶����ɴ�ȡ��λ�Ϸ�();
				break;
			case "�ȴ��ɴ﹩�����":
				�ȴ��ɴ﹩�����();
				break;
			case "����ȡ�϶���":
				����ȡ�϶���();
				break;
			case "�ж������Ƿ�ȡ�ϳɹ�":
				�ж������Ƿ�ȡ�ϳɹ�();
				break;
			case "���÷ɴ﹩�����":
				���÷ɴ﹩�����();
				break;
			case "�˶�������λ�Ϸ�":
				�˶�������λ�Ϸ�();
				break;
			case "�ȴ���Ʒ��λ":
				�ȴ���Ʒ��λ();
				break;
			case "�������϶���":
				�������϶���();
				break;
			case "�����������":
				�����������();
				break;
			case "�������":
				�������();
				break;
			default:
				WDLog.InsertLog("��������", 1, "��������", "�����������쳣�������¡�������̡�");
				return;
		}
	}
	public string ����׼��()
	{
		if (stepCheckTry("��������", "����׼��"))
			return "";
		return "�˶����ɴ�ȡ��λ�Ϸ�";
	}
	public string �˶����ɴ�ȡ��λ�Ϸ�()
	{
		if (stepCheckTry("��������", "�˶����ɴ�ȡ��λ�Ϸ�"))
			return "";
		�����˶�(�ɴ�ȡ��λ�Ϸ�);
		return "�ȴ��ɴ﹩�����";
	}
	public string �ȴ��ɴ﹩�����()
	{
		if (stepCheckTry("��������", "�ȴ��ɴ﹩�����"))
			return "";
		if(�ɴ�����.״̬�������)
		{
		return "����ȡ�϶���";
		}
		else
		{
		return "�ȴ��ɴ﹩�����";
		}
		return "����ȡ�϶���";
	}
	public string ����ȡ�϶���()
	{
		if (stepCheckTry("��������", "����ȡ�϶���"))
			return "";
		�����˶�(�ɴ�ȡ��λ�·�);
		���������λ(�������);
		�ӳ�(ȡ���ӳ�ʱ��);
		�����˶�(�ɴ�ȡ��λ�Ϸ�);
		return "�ж������Ƿ�ȡ�ϳɹ�";
	}
	public string �ж������Ƿ�ȡ�ϳɹ�()
	{
		if (stepCheckTry("��������", "�ж������Ƿ�ȡ�ϳɹ�"))
			return "";
		if(��ȡ������λ(��������ź�))
		{
		return "���÷ɴ﹩�����";
		}
		else
		{
		return "����ȡ�϶���";
		}
		return "���÷ɴ﹩�����";
	}
	public string ���÷ɴ﹩�����()
	{
		if (stepCheckTry("��������", "���÷ɴ﹩�����"))
			return "";
		�ɴ�����.����״̬ȡ�����();
		return "�˶�������λ�Ϸ�";
	}
	public string �˶�������λ�Ϸ�()
	{
		if (stepCheckTry("��������", "�˶�������λ�Ϸ�"))
			return "";
		�����˶�(����λ�Ϸ�);
		return "�ȴ���Ʒ��λ";
	}
	public string �ȴ���Ʒ��λ()
	{
		if (stepCheckTry("��������", "�ȴ���Ʒ��λ"))
			return "";
		if(���϶���ˮ��.״̬��Ʒ��λ)
		{
		return "�������϶���";
		}
		else
		{
		return "�ȴ���Ʒ��λ";
		}
		return "�������϶���";
	}
	public string �������϶���()
	{
		if (stepCheckTry("��������", "�������϶���"))
			return "";
		�����˶�(����λ�·�);
		���������λ(�������);
		���������λ(���������);
		�ӳ�(�����ӳ�ʱ��);
		�����˶�(����λ�Ϸ�);
		return "�����������";
	}
	public string �����������()
	{
		if (stepCheckTry("��������", "�����������"))
			return "";
		���϶���ˮ��.����״̬�������();
		return "�������";
	}
	public string �������()
	{
		if (stepCheckTry("��������", "�������"))
			return "";
		return "����׼��";
		return "";
	}
}
