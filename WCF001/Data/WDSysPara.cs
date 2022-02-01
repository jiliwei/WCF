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
    class WDSysPara : WData
    {
        public static List<SysPara> listSysPara = new List<SysPara>();

        /// <summary>
        /// 检查系统参数表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfSysPara"))//如果没有系统参数表，则创建相应的表
            {
                Create("CREATE TABLE WcfSysPara(" +
                        "ID INTEGER PRIMARY KEY AUTOINCREMENT," +//表ID
                        "Name  VARCHAR NOT NULL UNIQUE," +//参数名称
                        "Value VARCHAR NOT NULL," +//参数对应值
                        "Tips VARCHAR " +//参数提示
                        ")");
            }
        }
        /// <summary>
        /// 新增系统参数数据
        /// </summary>
        /// <returns></returns>
        public static int InsertSysPara(SysPara mSysPara)
        {
            try
            {
                string sql = "INSERT INTO WcfSysPara(ID,Name,Value,Tips) VALUES(@ID,@Name,@Value,@Tips)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("ID", DbType.Int32).Value = mSysPara.Id;
                cmd.Parameters.Add("Name", DbType.String).Value = mSysPara.Name;
                cmd.Parameters.Add("Value", DbType.String).Value = mSysPara.Value;
                cmd.Parameters.Add("Tips", DbType.String).Value = mSysPara.Tips;
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
        /// 删除系统参数数据
        /// </summary>
        /// <returns></returns>
        public static int DeleteSysPara()
        {
            try
            {
                //删除所有数据，及重置自增ID
                string sql = "DELETE FROM WcfSysPara";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                sql = "UPDATE sqlite_sequence set seq=0 where name='WcfSysPara'";
                cmd = new SQLiteCommand(sql, conn);
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
        /// 查询系统参数数据
        /// </summary>
        /// <returns></returns>
        public static int SelectSysPara()
        {
            //通过列表表ID查询出参数表ID
            DataTable dt = Select("SELECT ID,Name,Value,Tips FROM WcfSysPara ");
            List<SysPara> listSysParaMid = new List<SysPara>();
            //通过参数表ID删除参数通用表数据和参数值表数据
            foreach (DataRow dr in dt.Rows)
            {
                SysPara mSysPara = new SysPara();
                mSysPara.Id = int.Parse(dr[0].ToString());
                mSysPara.Name = dr[1].ToString();
                mSysPara.Value = dr[2].ToString();
                mSysPara.Tips = dr[3].ToString();
                listSysParaMid.Add(mSysPara);
            }
            listSysPara.Clear();
            listSysPara = listSysParaMid;
            return 0;
        }
    }
    class SysPara
    {
        private int id;
        private string name;
        private string value;
        private string tips;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public string Tips { get => tips; set => tips = value; }
    }
}
