using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace WCF
{
    /// 类 	  名：WDataTask
	/// 类 描 述：任务流程数据类
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/14
	/// 源    码：https://github.com/jiliwei/WCF
    class WDTask : WData
    {
        //任务的所有数据
        private static Dictionary<string, TaskData> dicTaskData = new Dictionary<string, TaskData>();
        internal static Dictionary<string, TaskData> DicTaskData { 
            get 
            {
                SelectTask();
                return dicTaskData; 
            } 
        }

        public static List<TaskPara> ListTaskPrivate 
        { 
            get 
            {
                SelectPrivate();
                return listTaskPrivate; 
            } 
        }
        public static Dictionary<double, string> DicTaskPublic
        {
            get
            {
                SelectPublic();
                return dicTaskPublic;
            }
        }
        public static List<TaskPara> ListTaskState
        {
            get
            {
                SelectState();
                return listTaskState;
            }
        }

        //区部变量数据
        private static List<TaskPara> listTaskPrivate = new List<TaskPara>();
        //共有变量数据
        private static Dictionary<double, string> dicTaskPublic = new Dictionary<double, string>();
        //任务状态数据
        private static List<TaskPara> listTaskState = new List<TaskPara>();
        /// <summary>
        /// 检查任务表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfTask"))//如果没有参数表，则创建相应的表
            {
                //任务主表
                Create("CREATE TABLE WcfTask(" +
                        "ID INTEGER PRIMARY KEY AUTOINCREMENT," +//任务表ID
                        "NumOrder DOUBLE  NOT NULL," +//顺序
                        "TaskName VARCHAR NOT NULL," +//任务名称
                        "TaskType VARCHAR NOT NULL" +//任务类型
                        ")");
                //任务详情表
                Create("CREATE TABLE WcfStep(" +
                        "ID INTEGER PRIMARY KEY AUTOINCREMENT," +//步骤表ID
                        "TaskID INTEGER REFERENCES WcfTask (ID)," +//任务表ID
                        "NumOrder DOUBLE  NOT NULL," +//顺序
                        "StepIDFather  INTEGER, " +//父ID（任务步骤表ID）
                        "StepName VARCHAR NOT NULL," +//步骤名称
                        "StepDetails VARCHAR" +//步骤详情
                        ")");
                //任务局部参数表
                Create("CREATE TABLE WcfTaskPrivate (" +
                        "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                        "NumOrder DOUBLE  NOT NULL," +
                        "TaskID   INTEGER REFERENCES WcfTask(ID)," +
                        "Name VARCHAR NOT NULL)");
                //任务全局参数表
                Create("CREATE TABLE WcfTaskPublic (" +
                        "ID       INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "NumOrder DOUBLE  NOT NULL, " +
                        "Name     VARCHAR NOT NULL)");
                //任务状态表
                Create("CREATE TABLE WcfTaskState (" +
                        "ID       INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "NumOrder DOUBLE  NOT NULL, " +
                        "TaskID   INTEGER REFERENCES WcfTask(ID), " +
                        "Name     VARCHAR NOT NULL)");
            }
        }
        /// <summary>
        /// 任务表数据查询
        /// </summary>
        /// <returns></returns>
        public static int SelectTask()
        {
            try
            {
                DataTable dt = Select("SELECT ID,NumOrder,TaskName,TaskType  FROM WcfTask order by NumOrder asc");
                dicTaskData.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    TaskData mTaskData = new TaskData();
                    mTaskData.ID = int.Parse(dr[0].ToString());
                    mTaskData.NumOrder = double.Parse(dr[1].ToString());
                    mTaskData.TaskName = dr[2].ToString();
                    mTaskData.TaskType = dr[3].ToString();
                    Dictionary<string, StepData> dicStepData = new Dictionary<string, StepData>();
                    SelectStep(mTaskData.ID.ToString(), out dicStepData);
                    mTaskData.DicStepData = dicStepData;
                    dicTaskData.Add(mTaskData.TaskName, mTaskData);
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 步骤表数据查询
        /// </summary>
        /// <returns></returns>
        public static int SelectStep(string TaskID, out Dictionary<string, StepData> dicStepData)
        {
            dicStepData = new Dictionary<string, StepData>();
            try
            {
                DataTable dt = Select("SELECT ID,NumOrder,StepIDFather,StepName,StepDetails FROM WcfStep WHERE TaskID = " + 
                    TaskID + " order by NumOrder asc");
                dicStepData.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    StepData mStepData = new StepData();
                    string dr0 = dr[0].ToString();
                    string dr1 = dr[1].ToString();
                    string dr2 = dr[2].ToString();
                    string dr3 = dr[3].ToString();
                    string dr4 = dr[4].ToString();
                    mStepData.ID = int.Parse(dr0);
                    mStepData.NumOrder = double.Parse(dr1);
                    if (dr2.Length > 0)
                        mStepData.StepIDFather = int.Parse(dr2);
                    mStepData.StepName = dr3;
                    if (dr4.Length > 0)
                        mStepData.StepDetails = dr4;
                    else
                        mStepData.StepDetails = "";
                    dicStepData.Add(mStepData.StepName, mStepData);
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 任务的增加
        /// </summary>
        /// <returns></returns>
        public static int InsertTask(Double NumOrder, String TaskName, String TaskType)
        {
            try
            {
                string sql = "INSERT INTO WcfTask(NumOrder,TaskName,TaskType) " +
                "VALUES(@NumOrder,@TaskName,@TaskType)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = NumOrder;
                cmd.Parameters.Add("TaskName", DbType.String).Value = TaskName;
                cmd.Parameters.Add("TaskType", DbType.String).Value = TaskType;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 任务的删除
        /// </summary>
        /// <returns></returns>
        public static int DeleteTask(String TaskName)
        {
            try
            {
                Delete("WcfTask", "TaskName", TaskName);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 步骤的增加
        /// </summary>
        /// <returns></returns>
        public static int InsertStep(int TaskID, double NumOrder, String StepName)
        {
            try
            {
                string sql = "INSERT INTO WcfStep(TaskID,NumOrder,StepName) " +
                "VALUES(@TaskID,@NumOrder,@StepName)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("TaskID", DbType.Int32).Value = TaskID;
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = NumOrder;
                //cmd.Parameters.Add("StepIDFather", DbType.Int32).Value = 0;
                cmd.Parameters.Add("StepName", DbType.String).Value = StepName;
                cmd.ExecuteNonQuery();
                cmd.Clone();

                SelectTask();//刷新数据
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 步骤通过步骤ID删除
        /// </summary>
        /// <returns></returns>
        public static int DeleteStep(int StepID)
        {
            try
            {
                Delete("WcfStep", "ID", StepID);

                SelectTask();//刷新数据
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 步骤通过任务ID删除
        /// </summary>
        /// <returns></returns>
        public static int DeleteStepTaskID(int TaskID)
        {
            try
            {
                Delete("WcfStep", "TaskID", TaskID);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 步骤表详情更新
        /// </summary>
        /// <returns></returns>
        public static int UpdateStep(int iTaskStep, string strStepDetails)
        {
            string sql = "UPDATE WcfStep SET StepDetails = @StepDetails WHERE ID=@ID";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("ID", DbType.Int32).Value = iTaskStep;
            cmd.Parameters.Add("StepDetails", DbType.String).Value = strStepDetails;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            return 0;
        }
        #region 区部参数、全局参数和任务状态  查询、增加、删除
        public static int SelectPrivate()
        {
            try
            {
                DataTable dt = Select("select NumOrder,TaskID,Name from WcfTaskPrivate ORDER BY TaskID ,NumOrder");
                listTaskPrivate.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    TaskPara taskPara = new TaskPara();
                    taskPara.NumOrder = double.Parse(dr[0].ToString());
                    taskPara.TaskID = int.Parse(dr[1].ToString());
                    taskPara.Name = dr[2].ToString();
                    listTaskPrivate.Add(taskPara);
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int InsertPrivate(double NumOrder, int TaskID, string Name)
        {
            try
            {
                string sql = "INSERT INTO WcfTaskPrivate(NumOrder,TaskID,Name) " +
                "VALUES(@NumOrder,@TaskID,@Name)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = NumOrder;
                cmd.Parameters.Add("TaskID", DbType.Int32).Value = TaskID;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int DeletePrivate(string Name)
        {
            try
            {
                Delete("WcfTaskPrivate", "Name", Name);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int SelectPublic()
        {
            try
            {
                DataTable dt = Select("select NumOrder,Name from WcfTaskPublic ORDER BY NumOrder");
                dicTaskPublic.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    dicTaskPublic.Add(double.Parse(dr[0].ToString()), dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int InsertPublic(double NumOrder, string Name)
        {
            try
            {
                string sql = "INSERT INTO WcfTaskPublic(NumOrder,Name) " +
                "VALUES(@NumOrder,@Name)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = NumOrder;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int DeletePublic(string Name)
        {
            try
            {
                Delete("WcfTaskPublic", "Name", Name);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int SelectState()
        {
            try
            {
                DataTable dt = Select("select NumOrder,TaskID,Name from WcfTaskState ORDER BY TaskID ,NumOrder");
                listTaskState.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    TaskPara taskPara = new TaskPara();
                    taskPara.NumOrder = double.Parse(dr[0].ToString());
                    taskPara.TaskID = int.Parse(dr[1].ToString());
                    taskPara.Name = dr[2].ToString();
                    listTaskState.Add(taskPara);
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int InsertState(double NumOrder,int TaskID, string Name)
        {
            try
            {
                string sql = "INSERT INTO WcfTaskState(NumOrder,TaskID,Name) " +
                "VALUES(@NumOrder,@TaskID,@Name)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = NumOrder;
                cmd.Parameters.Add("TaskID", DbType.Int32).Value = TaskID;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        public static int DeleteState(string Name)
        {
            try
            {
                Delete("WcfTaskState", "Name", Name);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        #endregion
    }
    class TaskData
    {
        private int iD;
        private double numOrder;
        private string taskName;
        private string taskType;
        private Dictionary<string, StepData> dicStepData;

        public int ID { get => iD; set => iD = value; }
        public double NumOrder { get => numOrder; set => numOrder = value; }
        public string TaskName { get => taskName; set => taskName = value; }
        public string TaskType { get => taskType; set => taskType = value; }
        public Dictionary<string, StepData> DicStepData { get => dicStepData; set => dicStepData = value; }
    }
    public class StepData
    {
        private int iD;
        private int taskID;
        private double numOrder;
        private int stepIDFather;
        private string stepName;
        private string stepDetails;

        public int ID { get => iD; set => iD = value; }
        public int TaskID { get => taskID; set => taskID = value; }
        public double NumOrder { get => numOrder; set => numOrder = value; }
        public int StepIDFather { get => stepIDFather; set => stepIDFather = value; }
        public string StepName { get => stepName; set => stepName = value; }
        public string StepDetails { get => stepDetails; set => stepDetails = value; }
    }
    public class TaskPara
    {
        private double numOrder;
        private int taskID;
        private string name;

        public double NumOrder { get => numOrder; set => numOrder = value; }
        public int TaskID { get => taskID; set => taskID = value; }
        public string Name { get => name; set => name = value; }
    }
}
