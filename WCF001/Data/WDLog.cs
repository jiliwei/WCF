using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace WCF
{
    /// 类 	  名：WDLog
	/// 类 描 述：日志数据类
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/14
	/// 源    码：https://github.com/jiliwei/WCF
    public class WDLog : WData
    {
        /// <summary>
        /// 检查日志表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfLog"))//如果没有参数表，则创建相应的表
            {
                Create("CREATE TABLE WcfLog (" +
                      "ID INTEGER  PRIMARY KEY AUTOINCREMENT," +
                      "Date DATETIME NOT NULL DEFAULT(datetime('now', 'localtime'))," +
                      "Type VARCHAR  NOT NULL," +
                      "Level   INTEGER NOT NULL DEFAULT(0)," +
                      "Name VARCHAR," +
                      "Details VARCHAR)");
            }
        }
        /// <summary>
        /// 日志表数据查询
        /// </summary>
        /// <returns></returns>
        public static int SelectLog(ref DataGridView dgvShow,
            int iNumber = 50,
            string startDate = "",
            string endDate = "",
            string type = "",
            int leval = -1,
            string name = "",
            string details = "")
        {
            try
            {
                string strWhere = "";
                if (startDate.Length > 0)
                {
                    strWhere += " Date >= '" + startDate + "' ";
                }
                if (endDate.Length > 0)
                {
                    if (strWhere.Length > 0)
                        strWhere += " AND ";
                    strWhere += " Date <= '" + endDate + "' ";
                }
                if (type.Length > 0)
                {
                    if (strWhere.Length > 0)
                        strWhere += " AND ";
                    strWhere += " Type GLOB '*" + type + "*' ";
                }
                if (leval > -1)
                {
                    if (strWhere.Length > 0)
                        strWhere += " AND ";
                    strWhere += " Level = " + leval + " ";
                }
                if (name.Length > 0)
                {
                    if (strWhere.Length > 0)
                        strWhere += " AND ";
                    strWhere += " Name GLOB '*" + name + "*' ";
                }
                if (details.Length > 0)
                {
                    if (strWhere.Length > 0)
                        strWhere += " AND ";
                    strWhere += " Details GLOB '*" + details + "*' ";
                }

                string sql = "SELECT  Date AS '日期',Type AS '类型',Level AS '等级',Name AS '名称',Details AS '详情'  FROM WcfLog ";
                if (strWhere.Length > 0)
                {
                    sql += " WHERE " + strWhere;
                }
                sql += " order by ID desc limit 0," + iNumber;
                DataTable dt = Select(sql);
                dgvShow.DataSource = dt;
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 日志的增加
        /// </summary>
        /// <returns></returns>
        public static int InsertLog(String Type, int Level, String Name, String Details)
        {
            try
            {
                string sql = "INSERT INTO WcfLog(Type,Level,Name,Details) " +
                "VALUES(@Type,@Level,@Name,@Details)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Type", DbType.String).Value = Type;
                cmd.Parameters.Add("Level", DbType.Int32).Value = Level;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("Details", DbType.String).Value = Details;
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
        /// 日志通过日期删除
        /// </summary>
        /// <returns></returns>
        public static int DeleteLog(string strDate, bool isSequence = false)
        {
            try
            {
                if (isSequence)
                {
                    //删除所有数据，及重置自增ID
                    string sql = "DELETE FROM WcfLog";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    sql = "UPDATE sqlite_sequence set seq=0 where name='WcfLog'";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                else
                {
                    //删除一段时间数据
                    string sql = "DELETE FROM WcfLog WHERE Date <=" + strDate;
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
    }
}
