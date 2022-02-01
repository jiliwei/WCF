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
    /// 类 	  名：WData
	/// 类 描 述：数据父类
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/14
	/// 源    码：https://github.com/jiliwei/WCF
    public class WData
    {
        public static SQLiteConnection conn;
        private static string dbDataPath = Application.StartupPath + "\\WcfData.db";
        public static int iPriLevel = 0;//权限等级

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns></returns>
        public static int OpenSqlite()
        {
            try
            {
                //判断数据库是否存在
                if (File.Exists(dbDataPath) == false)
                    SQLiteConnection.CreateFile(dbDataPath);//创建数据库

                conn = new SQLiteConnection();//打开数据库
                SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
                connsb.DataSource = dbDataPath;
                connsb.Password = "Wcf2019";
                conn.ConnectionString = connsb.ToString();
                conn.Open();
                //检查表格没有则创建
                WDCard.CheckForm();
                WDLog.CheckForm();
                WDPara.CheckForm();
                WDPoint.CheckForm();
                WDSysPara.CheckForm();
                WDTask.CheckForm();
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 检查表是否存在
        /// </summary>
        /// <param name="name">表名称</param>
        /// <returns></returns>
        public static bool CheckFormExists(string name)
        {
            SQLiteCommand mDbCmd = conn.CreateCommand();
            mDbCmd.CommandText = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='" + name + "';";
            if (0 == Convert.ToInt32(mDbCmd.ExecuteScalar()))
                return false;
            else
                return true;
        }
        public static void Create(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Clone();
        }
        public static DataTable Select(string sql)
        {
            SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            mAdapter.Fill(dt);
            return dt;
        }
        public static void Delete(string strName,string strField,int iValue)
        {
            string sql = "DELETE FROM " + strName + " WHERE " + strField + " =" + iValue;
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Clone();
        }
        public static void Delete(string strName, string strField, string strValue)
        {
            string sql = "DELETE FROM " + strName + " WHERE " + strField + " ='" + strValue + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Clone();
        }
    }
}
