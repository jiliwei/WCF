using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace WCF
{
    class WDSocket : WData
    {
        //Socket数据
        private static Dictionary<string, SocketData> dicSocketData = new Dictionary<string, SocketData>();

        internal static Dictionary<string, SocketData> DicSocketData { 
            get
            {
                SelectSocket();
                return dicSocketData;
            }
        }

        /// <summary>
        /// 检查Socket表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfSocket"))//如果没有参数表，则创建相应的表
            {
                //新增Socket表
                Create("CREATE TABLE WcfSocket ("+
                    "ID   INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Type INTEGER CONSTRAINT[0] NOT NULL," +
                    "Name VARCHAR NOT NULL," +
                    "IP   VARCHAR NOT NULL," +
                    "Port VARCHAR NOT NULL)");
            }
        }
        public static int SelectSocket()
        {
            try
            {
                DataTable dt = Select("SELECT ID," +
                                            "Type," +
                                            "Name, " +
                                            "IP, " +
                                            "Port " +
                                            "FROM WcfSocket order by Type asc");
                dicSocketData.Clear();
                int id = 0;
                int type = 0;//TCP的类型，0服务器，1客户端
                string name = "";//TCP的名称
                string ip = "";//IP
                string port = "";//端口

                foreach (DataRow dr in dt.Rows)
                {
                    id = int.Parse(dr[0].ToString());
                    type = int.Parse(dr[1].ToString());
                    name = dr[2].ToString();
                    ip = dr[3].ToString();
                    port = dr[4].ToString();

                    SocketData mSocketData = new SocketData();
                    mSocketData.Id = id;
                    mSocketData.Type = type;
                    mSocketData.Name = name;
                    mSocketData.Ip = ip;
                    mSocketData.Port = port;

                    dicSocketData.Add(name, mSocketData);
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
        /// <param name="Type">Socket类型</param>
        /// <param name="Name">Socket名称</param>
        /// <param name="IP">IP</param>
        /// <param name="Port">端口</param>
        /// <returns></returns>
        public static int InsertSocket(int Type, string Name, string IP, string Port)
        {
            try
            {
                //增加点位名称表数据
                string sql = "INSERT INTO WcfSocket(Type,Name,IP,Port) " +
                                "VALUES(@Type,@Name,@IP,@Port)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Type", DbType.Int32).Value = Type;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("IP", DbType.String).Value = IP;
                cmd.Parameters.Add("Port", DbType.String).Value = Port;
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
        public static int DeleteSocket(int ID)
        {
            try
            {
                Delete("WcfSocket", "ID", ID);
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
        public static int UpdateSocket(int ID, int Type, string Name, string IP, string Port)
        {
            try
            {
                string sql = "UPDATE WcfSocket SET Type = @Type,Name = @Name,IP = @IP,Port = @Port WHERE ID=@ID";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Type", DbType.Int32).Value = Type;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("IP", DbType.String).Value = IP;
                cmd.Parameters.Add("Port", DbType.String).Value = Port;
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
    public class SocketData
    {
        private int id = 0;//表ID
        private int type = 0;//TCP的类型，0服务器，1客户端
        private string name = "";//TCP的名称
        private string port = "";//端口
        private string ip = "";//IP
        public int Id { get => id; set => id = value; }
        public int Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string Port { get => port; set => port = value; }
        public string Ip { get => ip; set => ip = value; }
    }
}
