using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace WCF
{
    /// 类 	  名：WDPara
	/// 类 描 述：参数控件数据类
	/// WCF·769838889@qq.com
	/// 创建时间：2021/10/14
	/// 源    码：https://github.com/jiliwei/WCF
    class WDPara : WData
    {
        //列表显示的数据
        private static List<ParaTab> listParaTab = new List<ParaTab>();
        internal static List<ParaTab> ListParaTab { 
            get
            {
                SelectPara();
                return listParaTab; 
            }
        }
        internal static List<ParaTab> GetListParaTab
        {
            get
            {
                return listParaTab;
            }
        }
        //流程读取的数据
        private static Dictionary<string, double> readPara = new Dictionary<string, double>();
        private static Dictionary<string, string> readParaStr = new Dictionary<string, string>();
        //当前机种ID
        public static int iNowModel = 1;


        /// <summary>
        /// 检查参数表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfParaTab"))//如果没有参数表，则创建相应的表
            {
                //新增机种表
                Create("CREATE TABLE WcfParaModel (" +
                      "ID INTEGER PRIMARY KEY," +
                      "Name    VARCHAR UNIQUE," +
                      "Current INTEGER)");
                //新增选项卡表
                Create("CREATE TABLE WcfParaTab (" +
                      "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                      "NumOrder DOUBLE ," +
                      "Name VARCHAR UNIQUE)");
                //新增选项卡对应列表表
                Create("CREATE TABLE WcfParaTable (" +
                      "ID INTEGER PRIMARY KEY AUTOINCREMENT,"+
                      "TabID INTEGER REFERENCES WcfParaTab(ID)," +
                      "NumOrder DOUBLE ," +
                      "Name VARCHAR UNIQUE)");
                //新增参数通用表
                Create("CREATE TABLE WcfParaCurr (" +
                      "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                      "TableID INTEGER REFERENCES WcfParaTable(ID)," +
                      "NumOrder DOUBLE ," +
                      "Name VARCHAR UNIQUE," +
                      "Level INTEGER CONSTRAINT [0] NOT NULL," +
                      "Tips     VARCHAR)");
                //新增参数值表
                Create("CREATE TABLE WcfParaValue (" +
                      "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                      "ParaID INTEGER REFERENCES WcfParaCurr(ID)," +
                      "ModelID INTEGER REFERENCES WcfParaModel(Id)," +
                      "ParaValue VARCHAR NOT NULL," +
                      "Relation  VARCHAR)");
                //增加默认机种
                try
                {
                    string sql = "INSERT INTO WcfParaModel(Name,Current) VALUES(\"默认机种\",1)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                catch (Exception ex)
                {
                    WTool.Popup(ex.ToString());
                }
            }
        }
        /// <summary>
        /// 增加选项卡
        /// </summary>
        /// <returns></returns>
        public static int InsertTab(string Name)
        {
            try
            {
                string sql = "INSERT INTO WcfParaTab(NumOrder,Name) VALUES(@NumOrder,@Name)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                double dNumOrder = (double)(listParaTab.Count + 1) / 1000;
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = dNumOrder;
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
        /// <summary>
        /// 更新选项卡
        /// </summary>
        /// <returns></returns>
        public static int UpdateTab(int ID, string Name)
        {
            string sql = "UPDATE WcfParaTab SET Name = @Name WHERE ID=@ID";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("ID", DbType.Int32).Value = ID;
            cmd.Parameters.Add("Name", DbType.String).Value = Name;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            return 0;
        }
        /// <summary>
        /// 删除选项卡
        /// </summary>
        /// <returns></returns>
        public static int DeleteTab(int TabID)
        {
            try
            {
                //通过列表表ID查询出参数表ID
                DataTable dt = Select("SELECT WcfParaCurr.ID FROM WcfParaCurr " +
                      "LEFT JOIN WcfParaTable " +
                      "ON  WcfParaCurr.TableID = WcfParaTable.ID " +
                      "WHERE WcfParaTable.TabID = " + TabID.ToString()) ;
                //通过参数表ID删除参数通用表数据和参数值表数据
                foreach (DataRow dr in dt.Rows)
                {
                    Delete("WcfParaCurr", "ID", int.Parse(dr[0].ToString()));
                    Delete("WcfParaValue", "ParaID", int.Parse(dr[0].ToString()));
                }
                //通过选项卡ID删除对应列表表数据和选项卡表数据
                Delete("WcfParaTable", "TabID", TabID);
                Delete("WcfParaTab", "ID", TabID);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 增加列表
        /// </summary>
        /// <returns></returns>
        public static int InsertTable(int TabID, double NumOrder, string Name)
        {
            try
            {
                string sql = "INSERT INTO WcfParaTable(TabID,NumOrder,Name) VALUES(@TabID,@NumOrder,@Name)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("TabID", DbType.Int32).Value = TabID;
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
        /// <summary>
        /// 更新列表
        /// </summary>
        /// <returns></returns>
        public static int UpdateTable(int ID, string Name)
        {
            string sql = "UPDATE WcfParaTable SET Name = @Name WHERE ID=@ID";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("ID", DbType.Int32).Value = ID;
            cmd.Parameters.Add("Name", DbType.String).Value = Name;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            return 0;
        }
        /// <summary>
        /// 删除列表
        /// </summary>
        /// <returns></returns>
        public static int DeleteTable(int TableID)
        {
            try
            {
                //通过列表表ID查询出参数表ID
                DataTable dt = Select("SELECT ID FROM WcfParaCurr " +
                      "WHERE TableID = " + TableID.ToString());
                //通过参数表ID删除参数通用表数据和参数值表数据
                foreach (DataRow dr in dt.Rows)
                {
                    Delete("WcfParaCurr", "ID", int.Parse(dr[0].ToString()));
                    Delete("WcfParaValue", "ParaID", int.Parse(dr[0].ToString()));
                }
                //通过选项卡ID删除对应列表表数据和选项卡表数据
                Delete("WcfParaTable", "ID", TableID);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 参数等级修改
        /// </summary>
        /// <returns></returns>
        public static int UpdateCurr(int Level, string Name)
        {
            string sql = "UPDATE WcfParaCurr SET Level = @Level WHERE Name=@Name";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("Level", DbType.Int32).Value = Level;
            cmd.Parameters.Add("Name", DbType.String).Value = Name;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            return 0;
        }
        /// <summary>
        /// 查询参数
        /// </summary>
        /// <returns></returns>
        public static int SelectPara()
        {
            try
            {
                listParaTab.Clear();
                //查询选项卡表
                DataTable dtTab = Select("SELECT ID,NumOrder,Name FROM WcfParaTab order by NumOrder asc");
                foreach (DataRow drTab in dtTab.Rows)
                {
                    ParaTab mParaTab = new ParaTab();
                    mParaTab.ID = int.Parse(drTab[0].ToString());
                    mParaTab.NumOrder = double.Parse(drTab[1].ToString());
                    mParaTab.Name = drTab[2].ToString();
                    //查询列表表数据
                    DataTable dtTable = Select("SELECT ID,TabID,NumOrder,Name FROM WcfParaTable "+
                        "WHERE TabID=" + mParaTab.ID + " order by NumOrder asc");
                    foreach (DataRow drTable in dtTable.Rows)
                    {
                        ParaTable mParaTable = new ParaTable();
                        mParaTable.ID = int.Parse(drTable[0].ToString());
                        mParaTable.TabID = int.Parse(drTable[1].ToString());
                        mParaTable.NumOrder = double.Parse(drTable[2].ToString());
                        mParaTable.Name = drTable[3].ToString();
                        //查询参数相关数据
                        DataTable dtCurr = Select(
                        "SELECT " +
                        "WcfParaCurr.ID," +
                        "WcfParaCurr.TableID," +
                        "WcfParaCurr.NumOrder," +
                        "WcfParaCurr.Name," +
                        "WcfParaCurr.Level," +
                        "WcfParaCurr.Tips," +
                        "WcfParaValue.ParaValue," +
                        "WcfParaValue.Relation " +
                        "FROM WcfParaCurr " +
                        "LEFT JOIN WcfParaValue ON WcfParaValue.ParaID = WcfParaCurr.ID " +
                        "LEFT JOIN WcfParaModel ON WcfParaModel.ID = WcfParaValue.ModelID " +
                        "WHERE WcfParaModel.Current = 1 AND WcfParaCurr.TableID =" + mParaTable.ID +
                        " order by NumOrder asc");
                        foreach (DataRow drCurr in dtCurr.Rows)
                        {
                            ParaCurr mParaCurr = new ParaCurr();
                            mParaCurr.ID = int.Parse(drCurr[0].ToString());
                            mParaCurr.TableID = int.Parse(drCurr[1].ToString());
                            mParaCurr.NumOrder = double.Parse(drCurr[2].ToString());
                            mParaCurr.Name = drCurr[3].ToString();
                            mParaCurr.Level = int.Parse(drCurr[4].ToString());
                            mParaCurr.Tips = drCurr[5].ToString();
                            mParaCurr.ParaValue = drCurr[6].ToString();
                            mParaCurr.Relation = drCurr[7].ToString();
                            mParaTable.ListParaTable.Add(mParaCurr);
                            //增加数据到流程读取字典
                            if (mParaCurr.Tips.Contains("(字符串)"))
                            {
                                if (readParaStr.ContainsKey(mParaCurr.Name))
                                    readParaStr[mParaCurr.Name] = mParaCurr.ParaValue;
                                else
                                    readParaStr.Add(mParaCurr.Name, mParaCurr.ParaValue);

                            } 
                            else
                            {
                                if (readPara.ContainsKey(mParaCurr.Name))
                                    readPara[mParaCurr.Name] = double.Parse(mParaCurr.ParaValue);
                                else
                                    readPara.Add(mParaCurr.Name, double.Parse(mParaCurr.ParaValue));
                            }
                        }
                        mParaTab.ListParaTable.Add(mParaTable);
                    }
                    listParaTab.Add(mParaTab);
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
        /// 增加参数
        /// </summary>
        /// <returns></returns>
        public static int InsertPara(ParaCurr mParaCurr)
        {
            try
            {
                //参数通用表数据增加
                string sql =
                    "INSERT INTO WcfParaCurr(TableID,NumOrder,Name,Level,Tips) " +
                    "VALUES(@TableID,@NumOrder,@Name,@Level,@Tips)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                //cmd.Parameters.Add("ID", DbType.Int32).Value = mParaCurr.ID;
                cmd.Parameters.Add("TableID", DbType.Int32).Value = mParaCurr.TableID;
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = mParaCurr.NumOrder;
                cmd.Parameters.Add("Name", DbType.String).Value = mParaCurr.Name;
                cmd.Parameters.Add("Level", DbType.Int32).Value = mParaCurr.Level;
                cmd.Parameters.Add("Tips", DbType.String).Value = mParaCurr.Tips;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                //参数通用表ID查询
                DataTable dtCurr = Select("SELECT ID FROM WcfParaCurr WHERE Name = '" + mParaCurr.Name +"'");
                if (dtCurr.Rows.Count!= 1)
                {
                    WTool.Popup("参数名称："+ mParaCurr.Name+",查询没有或有多个请检查");
                    return -1;
                }
                //机种表数据查询
                DataTable dtModel = Select("SELECT ID FROM WcfParaModel order by ID asc");
                foreach (DataRow drModel in dtModel.Rows)
                {
                    //参数值数据增加
                    sql =
                   "INSERT INTO WcfParaValue(ParaID,ModelID,ParaValue,Relation) " +
                   "VALUES(@ParaID,@ModelID,@ParaValue,@Relation)";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.Add("ParaID", DbType.Int32).Value = int.Parse(dtCurr.Rows[0][0].ToString());
                    cmd.Parameters.Add("ModelID", DbType.Int32).Value = int.Parse(drModel[0].ToString());
                    cmd.Parameters.Add("ParaValue", DbType.String).Value = mParaCurr.ParaValue;
                    cmd.Parameters.Add("Relation", DbType.String).Value = mParaCurr.Relation;
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
        /// <summary>
        /// 删除参数
        /// </summary>
        /// <returns></returns>
        public static int DeletePara(ParaCurr mParaCurr)
        {
            try
            {
                Delete("WcfParaValue", "ParaID", mParaCurr.ID);
                Delete("WcfParaCurr", "ID", mParaCurr.ID);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 更新参数
        /// </summary>
        /// <returns></returns>
        public static int UpdatePara(ParaCurr mParaCurr)
        {
            try
            {
                //参数通用表数据增加
                string sql = "UPDATE WcfParaCurr SET Name = @Name , Level = @Level , Tips = @Tips WHERE ID=@ID";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("ID", DbType.Int32).Value = mParaCurr.ID;
                cmd.Parameters.Add("Name", DbType.String).Value = mParaCurr.Name;
                cmd.Parameters.Add("Level", DbType.Int32).Value = mParaCurr.Level;
                cmd.Parameters.Add("Tips", DbType.String).Value = mParaCurr.Tips;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                //sql = "UPDATE WcfParaValue SET ParaValue = '1' ,Relation = '' WHERE ID=1 AND ModelID=1";
                sql = "UPDATE WcfParaValue SET ParaValue = @ParaValue , Relation = @Relation WHERE ID=@ID AND ModelID=@ModelID";
                cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("ParaValue", DbType.String).Value = mParaCurr.ParaValue;
                cmd.Parameters.Add("Relation", DbType.String).Value = mParaCurr.Relation;
                cmd.Parameters.Add("ID", DbType.Int32).Value = mParaCurr.ID;
                cmd.Parameters.Add("ModelID", DbType.Int32).Value = iNowModel;
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
    class ParaTab
    {
        private int iD;//表ID
        private double numOrder;//排列序号
        private string name;//表名称
        private List<ParaTable> listParaTable = new List<ParaTable>();//列表数据

        public int ID { get => iD; set => iD = value; }
        public double NumOrder { get => numOrder; set => numOrder = value; }
        public string Name { get => name; set => name = value; }
        internal List<ParaTable> ListParaTable { get => listParaTable; set => listParaTable = value; }
    }
    class ParaTable
    {
        private int iD;//表ID
        private int tabID;//选项卡ID
        private double numOrder;//排列序号
        private string name;//表名称
        private List<ParaCurr> listParaTable = new List<ParaCurr>();//参数数据

        public int ID { get => iD; set => iD = value; }
        public int TabID { get => tabID; set => tabID = value; }
        public double NumOrder { get => numOrder; set => numOrder = value; }
        public string Name { get => name; set => name = value; }
        internal List<ParaCurr> ListParaTable { get => listParaTable; set => listParaTable = value; }
    }
    class ParaCurr
    {
        private int iD;//表ID
        private int tableID;//列表表ID
        private double numOrder;//排列序号
        private string name;//表名称
        private int level = 0;//参数等级
        private string tips = "";//参数提示
        private string paraValue = "";//参数提示
        private string relation = "";//参数提示

        public int ID { get => iD; set => iD = value; }
        public int TableID { get => tableID; set => tableID = value; }
        public double NumOrder { get => numOrder; set => numOrder = value; }
        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public string Tips { get => tips; set => tips = value; }
        public string ParaValue { get => paraValue; set => paraValue = value; }
        public string Relation { get => relation; set => relation = value; }
    }

}
