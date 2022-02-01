using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace WCF
{
    class WDSerial : WData
    {
        //Socket数据
        private static Dictionary<string, SerialData> dicSerialData = new Dictionary<string, SerialData>();

        internal static Dictionary<string, SerialData> DicSerialData
        { 
            get
            {
                SelectSerial();
                return dicSerialData;
            }
        }

        /// <summary>
        /// 检查Socket表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfSerial"))//如果没有参数表，则创建相应的表
            {
                //新增Socket表
                Create("CREATE TABLE WcfSerial (" +
                    "ID   INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Name VARCHAR NOT NULL," +
                    "Port   VARCHAR NOT NULL," +
                    "BaudRate   VARCHAR NOT NULL," +
                    "DataBit   VARCHAR NOT NULL," +
                    "CheckBit   VARCHAR NOT NULL," +
                    "StopBit VARCHAR NOT NULL)");
            }
        }
        public static int SelectSerial()
        {
            try
            {
                DataTable dt = Select("SELECT ID," +
                                            "Name," +
                                            "Port, " +
                                            "BaudRate, " +
                                            "DataBit, " +
                                            "CheckBit, " +
                                            "StopBit " +
                                            "FROM WcfSerial order by ID asc");
                dicSerialData.Clear();
                int id = 0;
                string name = string.Empty;//名称
                string port = "";//端口
                string baudRate = "";//波特率
                string dataBit = "";//数据位
                string checkBit = "";//校验位
                string stopBit = "";//停止位

                foreach (DataRow dr in dt.Rows)
                {
                    id = int.Parse(dr[0].ToString());
                    name = dr[1].ToString();
                    port = dr[2].ToString();
                    baudRate = dr[3].ToString();
                    dataBit = dr[4].ToString();
                    checkBit = dr[5].ToString();
                    stopBit = dr[6].ToString();

                    SerialData mSerialData = new SerialData();
                    mSerialData.Id = id;
                    mSerialData.Name = name;
                    mSerialData.Port = port;
                    mSerialData.BaudRate = baudRate;
                    mSerialData.DataBit = dataBit;
                    mSerialData.CheckBit = checkBit;
                    mSerialData.StopBit = stopBit;

                    dicSerialData.Add(name, mSerialData);
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
        /// 增加数据
        /// </summary>
        /// <param name="Name">串口名称</param>
        /// <returns></returns>
        public static int InsertSerial(string Name)
        {
            try
            {
                //增加点位名称表数据
                string sql = "INSERT INTO WcfSerial(Name,Port,BaudRate,DataBit,CheckBit,StopBit) " +
                            "VALUES(@Name,@Port,@BaudRate,@DataBit,@CheckBit,@StopBit)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("Port", DbType.String).Value = "COM1";
                cmd.Parameters.Add("BaudRate", DbType.String).Value = "194000";
                cmd.Parameters.Add("DataBit", DbType.String).Value = "5";
                cmd.Parameters.Add("CheckBit", DbType.String).Value = "NONE";
                cmd.Parameters.Add("StopBit", DbType.String).Value = "NONE";
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
        /// 删除数据
        /// </summary>
        /// <param name="ID">表ID</param>
        /// <returns></returns>
        public static int DeleteSerial(int ID)
        {
            try
            {
                Delete("WcfSerial", "ID", ID);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="ID">表ID</param>
        /// <param name="Type">Socket类型</param>
        /// <param name="Name">Socket名称</param>
        /// <param name="IP">IP</param>
        /// <param name="Port">端口</param>
        /// <returns></returns>
        public static int UpdateSerial(int ID, string Name, string Port, string BaudRate, string DataBit, string CheckBit, string StopBit)
        {
            try
            {
                string sql = "UPDATE WcfSerial SET Name = @Name,Port = @Port,BaudRate = @BaudRate,DataBit = @DataBit,"+
                    "CheckBit = @CheckBit,StopBit = @StopBit WHERE ID=@ID";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("Port", DbType.String).Value = Port;
                cmd.Parameters.Add("BaudRate", DbType.String).Value = BaudRate;
                cmd.Parameters.Add("DataBit", DbType.String).Value = DataBit;
                cmd.Parameters.Add("CheckBit", DbType.String).Value = CheckBit;
                cmd.Parameters.Add("StopBit", DbType.String).Value = StopBit;
                cmd.Parameters.Add("ID", DbType.Int32).Value = ID;
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

    }
    public class SerialData
    {
        private int id = 0;//表ID
        private string name = string.Empty;//名称
        private string port = "";//端口
        private string baudRate = "";//波特率
        private string dataBit = "";//数据位
        private string checkBit = "";//校验位
        private string stopBit = "";//停止位

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Port { get => port; set => port = value; }
        public string BaudRate { get => baudRate; set => baudRate = value; }
        public string DataBit { get => dataBit; set => dataBit = value; }
        public string CheckBit { get => checkBit; set => checkBit = value; }
        public string StopBit { get => stopBit; set => stopBit = value; }
    }
}
