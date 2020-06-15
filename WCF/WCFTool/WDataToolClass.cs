using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;

namespace WCF
{
    /// 类 	  名：WDataToolClass
	/// 类 描 述：SQLite数据库工具类
	/// WCF公会·769838889@qq.com
	/// 创建时间：2019/7/26
	/// 源    码：https://github.com/jiliwei/WCF
    public class WDataToolClass
    {
        private SQLiteConnection conn;
        private string dbDataPath = Application.StartupPath + "\\WcfData.db";
        public static ConcurrentDictionary<string, string> dicAxis = new ConcurrentDictionary<string, string>();//轴数据字典
        public static ConcurrentDictionary<string, string> dicDI = new ConcurrentDictionary<string, string>();//DI数据字典
        public static ConcurrentDictionary<string, string> dicDO = new ConcurrentDictionary<string, string>();//DO数据字典
        public static ConcurrentDictionary<string, string> dicPara = new ConcurrentDictionary<string, string>();//参数数据字典

        /// <summary>
        /// 当前用的参数表的表名
        /// </summary>
        private string mParameter = "";
        /// <summary>
        /// 校验数据库文件是否存在
        /// </summary>
        /// <returns></returns>
        public int CheckAndOpenDataFile()
        {
            try
            {
                //判断数据库是否存在，不存在则创建数据库及相应表
                if (File.Exists(dbDataPath) == false)
                {
                    //创建数据库
                    SQLiteConnection.CreateFile(dbDataPath);
                    conn = new SQLiteConnection();
                    SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
                    connsb.DataSource = dbDataPath;
                    connsb.Password = "Wcf2019";
                    conn.ConnectionString = connsb.ToString();
                    conn.Open();

                    String sql = "";
                    SQLiteCommand cmd;
                    //创建机种表并增加默认数据
                    sql = "CREATE TABLE WcfModel ( ID INTEGER PRIMARY KEY, Name VARCHAR UNIQUE, Current INTEGER NOT NULL )";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    //增加默认数据
                    sql = "INSERT INTO WcfModel(Name,Current)  VALUES(@Name,@Current)";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.Add("Name", DbType.String).Value = "默认机种";
                    cmd.Parameters.Add("Current", DbType.Int32).Value = 1;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                    //创建轴数据表
                    sql = "CREATE TABLE WcfAxis ( " +
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR UNIQUE NOT NULL," +
                            "CardNum INTEGER NOT NULL," +
                            "AxisNum  INTEGER NOT NULL," +
                            "Pulse INTEGER NOT NULL DEFAULT(1000)," +
                            "Acc INTEGER NOT NULL DEFAULT(100)," +
                            "Speed INTEGER NOT NULL DEFAULT(10)," +
                            "ResetNum INTEGER NOT NULL DEFAULT(0))";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                    //创建输入表
                    sql = "CREATE TABLE WcfDI (" +
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR NOT NULL," +
                            "CardNum   INTEGER NOT NULL," +
                            "IoID INTEGER NOT NULL," +
                            "IoType    INTEGER CONSTRAINT[4] NOT NULL DEFAULT(4)," +
                            "IoState INTEGER CONSTRAINT FALSE NOT NULL DEFAULT(0)," +
                            "ExtendNum INTEGER CONSTRAINT[0] NOT NULL DEFAULT(0))";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                    //创建输出表
                    sql = "CREATE TABLE WcfDO (" +
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR NOT NULL," +
                            "CardNum   INTEGER NOT NULL," +
                            "IoID INTEGER NOT NULL," +
                            "IoType    INTEGER CONSTRAINT[4] NOT NULL DEFAULT(4)," +
                            "IoState INTEGER CONSTRAINT FALSE NOT NULL DEFAULT(0)," +
                            "ExtendNum INTEGER CONSTRAINT[0] NOT NULL DEFAULT(0))";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                    //创建参数参照表
                    sql = "CREATE TABLE WcfParameter (" +
                            "ID INTEGER PRIMARY KEY," +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR UNIQUE," +
                            "Value DOUBLE DEFAULT(0)," +
                            "CorrAxis  INTEGER," +
                            "Remarks   VARCHAR)";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    //创建矩阵参照表（一个位置只有一个吸嘴去贴，故只有一个补偿坐标）
                    sql = "CREATE TABLE WcfParameterMatrix (" +
                          "ID    INTEGER PRIMARY KEY," +
                          "NUM   INTEGER NOT NULL," +
                          "State INTEGER NOT NULL," +
                          "X     DOUBLE NOT NULL," +
                          "Y     DOUBLE  NOT NULL," +
                          "OffsetX DOUBLE DEFAULT(0)," +
                          "OffsetY DOUBLE  DEFAULT(0))," +
                          "OffsetR DOUBLE  DEFAULT(0))";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                    //查询当前机种，创建当前机种的参数表（表名=WcfParameter+当前机种对应的表ID）
                    sql = "SELECT ID FROM WcfModel WHERE Current=1";
                    cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader sdr = cmd.ExecuteReader();
                    cmd.Clone();
                    while (sdr.Read())
                    {
                        mParameter = "WcfParameter" + sdr["Id"].ToString();
                        sql = "create table " + mParameter + " as select * from WcfParameter";
                    }
                    sdr.Close();
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                }
                else
                {
                    OpenSqlite();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns></returns>
        public int OpenSqlite()
        {
            try
            {
                conn = new SQLiteConnection(dbDataPath);
                SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
                connsb.DataSource = dbDataPath;
                connsb.Password = "Wcf2019";
                conn.ConnectionString = connsb.ToString();
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /////////////////////////////////////////轴
        /// <summary>
        /// 轴数据的查询
        /// </summary>
        /// <returns></returns>
        public int getDataAxis(string Name, out int CardNum, out int AxisNum, out int Pulse, out int Acc, out int Speed, out int ResetNum)
        {
            CardNum = 0;
            AxisNum = 0;
            Pulse = 0;
            Acc = 0;
            Speed = 0;
            ResetNum = 0;
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select CardNum,AxisNum,Pulse,Acc,Speed,ResetNum from WcfAxis WHERE Name='" + Name + "'", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    CardNum = int.Parse(dt.Rows[0][0].ToString());
                    AxisNum = int.Parse(dt.Rows[0][1].ToString());
                    Pulse = int.Parse(dt.Rows[0][2].ToString());
                    Acc = int.Parse(dt.Rows[0][3].ToString());
                    Speed = int.Parse(dt.Rows[0][4].ToString());
                    ResetNum = int.Parse(dt.Rows[0][5].ToString());
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 轴数据的所有轴名称查询
        /// </summary>
        /// <returns></returns>
        public int getDataAxis(out DataTable dtCorrAxis)
        {
            dtCorrAxis = new DataTable();
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select ID,Name from WcfAxis", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                    dtCorrAxis = dt;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 轴数据的查询和显示
        /// </summary>
        /// <returns></returns>
        public int SelectShowAxis(ref DataGridView dgvShow)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select  GroupName as 组名,Name as 名称,CardNum as 卡号,AxisNum as 轴号,Pulse as 脉冲当量,Acc as 加速度,Speed as 速度,ResetNum as 复位顺序 from WcfAxis", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dicAxis.ContainsKey(dr[1].ToString()))
                        dicAxis[dr[1].ToString()] = dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString();
                    else
                        dicAxis.TryAdd(dr[1].ToString(), dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询获取轴数据表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public int SelectShowAxis(out DataTable dt, string GroupName = "")
        {
            dt = new DataTable();
            try
            {
                if (GroupName.Length > 0)
                {
                    GroupName = " WHERE GroupName = '" + GroupName + "' ";
                }
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select GroupName,Name,CardNum,AxisNum,ResetNum,Acc,Speed from WcfAxis " + GroupName + " ORDER BY GroupName", conn);
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (GroupName.Length == 0)
                        MessageBox.Show("输入数据为空");
                    else
                        MessageBox.Show(GroupName + "组的输入数据为空");
                    return 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 校验轴数据表是否已经存在
        /// </summary>
        /// <param name="mCheck">校验的数据</param>
        /// <returns>存在返回1，不存在返回0</returns>
        public int SelectShowAxisCheck(string mCheck)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select * from WcfAxis WHERE " + mCheck, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dt.Clear();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 轴数据的增加
        /// </summary>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">名称</param>
        /// <param name="CardNum">卡号</param>
        /// <param name="AxisNum">轴号</param>
        /// <param name="Pulse">脉冲当量</param>
        /// <param name="Acc">加速度</param>
        /// <param name="Speed">速度</param>
        /// <param name="ResetNum">复位顺序</param>
        /// <returns></returns>
        public int InsertAxis(String GroupName, String Name, Int32 CardNum, Int32 AxisNum, Int32 Pulse, Int32 Acc, Int32 Speed, Int32 ResetNum)
        {
            try
            {
                string sql = "INSERT INTO WcfAxis(GroupName,Name,CardNum,AxisNum,ResetNum,Acc,Speed) " +
                "VALUES(@GroupName,@Name,@CardNum,@AxisNum,@ResetNum,@Acc,@Speed)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("CardNum", DbType.Int32).Value = CardNum;
                cmd.Parameters.Add("AxisNum", DbType.Int32).Value = AxisNum;
                cmd.Parameters.Add("Pulse", DbType.Int32).Value = Pulse;
                cmd.Parameters.Add("Acc", DbType.Int32).Value = Acc;
                cmd.Parameters.Add("Speed", DbType.Int32).Value = Speed;
                cmd.Parameters.Add("ResetNum", DbType.Int32).Value = ResetNum;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过轴名称来更新轴数据
        /// </summary>
        /// <param name="oldName">将要更新的轴名称</param>
        /// <param name="Name">名称</param>
        /// <param name="CardNum">卡号</param>
        /// <param name="AxisNum">轴号</param>
        /// <param name="Pulse">脉冲当量</param>
        /// <param name="Acc">加速度</param>
        /// <param name="Speed">速度</param>
        /// <param name="ResetNum">复位顺序</param>
        /// <returns></returns>
        public int UpdateAxis(String oldName, String GroupName, String Name, Int32 CardNum, Int32 AxisNum, Int32 Pulse, Int32 Acc, Int32 Speed, Int32 ResetNum)
        {
            try
            {
                string sql = "UPDATE WcfAxis SET " +
                    "GroupName=@GroupName,Name=@Name,CardNum=@CardNum,AxisNum=@AxisNum,Pulse=@Pulse,Acc=@Acc,Speed=@Speed,ResetNum=@ResetNum  " +
                    "WHERE Name=@oldName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("CardNum", DbType.Int32).Value = CardNum;
                cmd.Parameters.Add("AxisNum", DbType.Int32).Value = AxisNum;
                cmd.Parameters.Add("Pulse", DbType.Int32).Value = Pulse;
                cmd.Parameters.Add("Acc", DbType.Int32).Value = Acc;
                cmd.Parameters.Add("Speed", DbType.Int32).Value = Speed;
                cmd.Parameters.Add("ResetNum", DbType.Int32).Value = ResetNum;
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过轴名称来删除轴数据
        /// </summary>
        /// <param name="oldName">将要删除的轴名称</param>
        /// <returns></returns>
        public int DeleteAxis(String oldName)
        {
            try
            {
                string sql = "DELETE FROM WcfAxis WHERE Name=@oldName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /////////////////////////////////输入
        /// <summary>
        /// DI数据的查询
        /// </summary>
        /// <returns></returns>
        public int getDataDI(string Name, out int CardNum, out int IoID, out int IoType, out int IoState, out int ExtendNum)
        {
            CardNum = 0;
            IoID = 0;
            IoType = 0;
            IoState = 0;
            ExtendNum = 0;
            try
            {
                string[] mValue = dicDI[Name].Split(';');
                CardNum = int.Parse(mValue[0]);
                IoID = int.Parse(mValue[1]);
                IoType = int.Parse(mValue[2]);
                IoState = int.Parse(mValue[3]);
                ExtendNum = int.Parse(mValue[4]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// DI数据的查询和显示
        /// </summary>
        /// <returns></returns>
        public int SelectShowDI(ref DataGridView dgvShow)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select GroupName as 组名,Name as 名称,CardNum as 卡号,IoID as 端口号," +
                                            "cast(IoType as VARCHAR) as 类型,cast(IoState as VARCHAR) as 状态,ExtendNum as 扩展卡号 from WcfDI ORDER BY GroupName", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dicDI.ContainsKey(dr[1].ToString()))
                        dicDI[dr[1].ToString()] = dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString();
                    else
                        dicDI.TryAdd(dr[1].ToString(), dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvShow.Rows[i].Cells[4].Value = WUseToolClass.getIoTypeName(int.Parse(dgvShow.Rows[i].Cells[4].Value.ToString()));
                    dgvShow.Rows[i].Cells[5].Value = WUseToolClass.getIoStateName(int.Parse(dgvShow.Rows[i].Cells[5].Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询获取输入表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public int SelectShowDI(out DataTable dt, string GroupName = "")
        {
            dt = new DataTable();
            try
            {
                if (GroupName.Length > 0)
                {
                    GroupName = " WHERE GroupName = '" + GroupName + "' ";
                }
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select GroupName,Name,CardNum,IoID,IoType,IoState,ExtendNum from WcfDI " + GroupName + " ORDER BY GroupName", conn);
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (GroupName.Length == 0)
                        MessageBox.Show("输入数据为空");
                    else
                        MessageBox.Show(GroupName + "组的输入数据为空");
                    return 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 校验DI数据表是否已经存在数据
        /// </summary>
        /// <param name="mCheck">校验的数据</param>
        /// <returns>存在返回1，不存在返回0</returns>
        public int SelectShowDICheck(string mCheck)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select * from WcfDI WHERE " + mCheck, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dt.Clear();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// DI数据的增加
        /// </summary>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">名称</param>
        /// <param name="CardNum">卡号</param>
        /// <param name="IoID">IO号</param>
        /// <param name="IoType">IO类型</param>
        /// <param name="IoState">是否取反</param>
        /// <param name="ExtendNum">扩展卡号</param>
        /// <returns></returns>
        public int InsertDI(String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
        {
            try
            {
                string sql = "INSERT INTO WcfDI(GroupName,Name,CardNum,IoID,IoType,IoState,ExtendNum) " +
                "VALUES(@GroupName,@Name,@CardNum,@IoID,@IoType,@IoState,@ExtendNum)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("CardNum", DbType.Int32).Value = CardNum;
                cmd.Parameters.Add("IoID", DbType.Int32).Value = IoID;
                cmd.Parameters.Add("IoType", DbType.Int32).Value = IoType;
                cmd.Parameters.Add("IoState", DbType.Int32).Value = IoState;
                cmd.Parameters.Add("ExtendNum", DbType.Int32).Value = ExtendNum;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过DI名称来更新轴数据
        /// </summary>
        /// <param name="oldName">将要删除的IO名称</param>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">名称</param>
        /// <param name="CardNum">卡号</param>
        /// <param name="IoID">IO号</param>
        /// <param name="IoType">IO类型</param>
        /// <param name="IoState">是否取反</param>
        /// <param name="ExtendNum">扩展卡号</param>
        /// <returns></returns>
        public int UpdateDI(String oldName, String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
        {
            try
            {
                string sql = "UPDATE WcfDI SET GroupName=@GroupName,Name=@Name,CardNum=@CardNum,IoID=@IoID,IoType=@IoType,IoState=@IoState,ExtendNum=@ExtendNum  " +
                "WHERE Name=@oldName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("CardNum", DbType.Int32).Value = CardNum;
                cmd.Parameters.Add("IoID", DbType.Int32).Value = IoID;
                cmd.Parameters.Add("IoType", DbType.Int32).Value = IoType;
                cmd.Parameters.Add("IoState", DbType.Int32).Value = IoState;
                cmd.Parameters.Add("ExtendNum", DbType.Int32).Value = ExtendNum;
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过DI名称来删除轴数据
        /// </summary>
        /// <param name="oldName">将要删除的DI名称</param>
        /// <returns></returns>
        public int DeleteDI(String oldName)
        {
            try
            {
                string sql = "DELETE FROM WcfDI WHERE Name=@oldName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /////////////////////////////////输出
        /// <summary>
        /// DO数据的查询
        /// </summary>
        /// <returns></returns>
        public int getDataDO(string Name, out int CardNum, out int IoID, out int IoType, out int IoState, out int ExtendNum)
        {
            CardNum = 0;
            IoID = 0;
            IoType = 0;
            IoState = 0;
            ExtendNum = 0;
            try
            {
                string[] mValue = dicDO[Name].Split(';');
                CardNum = int.Parse(mValue[0]);
                IoID = int.Parse(mValue[1]);
                IoType = int.Parse(mValue[2]);
                IoState = int.Parse(mValue[3]);
                ExtendNum = int.Parse(mValue[4]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// DO数据的查询和显示
        /// </summary>
        /// <returns></returns>
        public int SelectShowDO(ref DataGridView dgvShow)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select GroupName as 组名,Name as 名称,CardNum as 卡号,IoID as 端口号," +
                                            "cast(IoType as VARCHAR) as 类型,cast(IoState as VARCHAR) as 状态,ExtendNum as 扩展卡号 from WcfDO ORDER BY GroupName", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dicDO.ContainsKey(dr[1].ToString()))
                        dicDO[dr[1].ToString()] = dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString();
                    else
                        dicDO.TryAdd(dr[1].ToString(), dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvShow.Rows[i].Cells[4].Value = WUseToolClass.getIoTypeName(int.Parse(dgvShow.Rows[i].Cells[4].Value.ToString()));
                    dgvShow.Rows[i].Cells[5].Value = WUseToolClass.getIoStateName(int.Parse(dgvShow.Rows[i].Cells[5].Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询获取输出表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public int SelectShowDO(out DataTable dt, string GroupName = "")
        {
            dt = new DataTable();
            try
            {
                if (GroupName.Length > 0)
                {
                    GroupName = " WHERE GroupName = '" + GroupName + "' ";
                }
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select GroupName,Name,CardNum,IoID,IoType,IoState,ExtendNum from WcfDO " + GroupName + " ORDER BY GroupName", conn);
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (GroupName.Length == 0)
                        MessageBox.Show("输入数据为空");
                    else
                        MessageBox.Show(GroupName + "组的输入数据为空");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 校验DO数据表是否已经存在数据
        /// </summary>
        /// <param name="mCheck">校验的数据</param>
        /// <returns>存在返回1，不存在返回0</returns>
        public int SelectShowDOCheck(string mCheck)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select * from WcfDO WHERE " + mCheck, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dt.Clear();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// DO数据的增加
        /// </summary>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">名称</param>
        /// <param name="CardNum">卡号</param>
        /// <param name="IoID">IO号</param>
        /// <param name="IoType">IO类型</param>
        /// <param name="IoState">是否取反</param>
        /// <param name="ExtendNum">扩展卡号</param>
        /// <returns></returns>
        public int InsertDO(String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
        {
            try
            {
                string sql = "INSERT INTO WcfDO(GroupName,Name,CardNum,IoID,IoType,IoState,ExtendNum) " +
                "VALUES(@GroupName,@Name,@CardNum,@IoID,@IoType,@IoState,@ExtendNum)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("CardNum", DbType.Int32).Value = CardNum;
                cmd.Parameters.Add("IoID", DbType.Int32).Value = IoID;
                cmd.Parameters.Add("IoType", DbType.Int32).Value = IoType;
                cmd.Parameters.Add("IoState", DbType.Int32).Value = IoState;
                cmd.Parameters.Add("ExtendNum", DbType.Int32).Value = ExtendNum;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过DO名称来更新轴数据
        /// </summary>
        /// <param name="oldName">将要删除的IO名称</param>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">名称</param>
        /// <param name="CardNum">卡号</param>
        /// <param name="IoID">IO号</param>
        /// <param name="IoType">IO类型</param>
        /// <param name="IoState">是否取反</param>
        /// <param name="ExtendNum">扩展卡号</param>
        /// <returns></returns>
        public int UpdateDO(String oldName, String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
        {
            try
            {
                string sql = "UPDATE WcfDO SET GroupName=@GroupName,Name=@Name,CardNum=@CardNum,IoID=@IoID,IoType=@IoType,IoState=@IoState,ExtendNum=@ExtendNum  " +
                "WHERE Name=@oldName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("CardNum", DbType.Int32).Value = CardNum;
                cmd.Parameters.Add("IoID", DbType.Int32).Value = IoID;
                cmd.Parameters.Add("IoType", DbType.Int32).Value = IoType;
                cmd.Parameters.Add("IoState", DbType.Int32).Value = IoState;
                cmd.Parameters.Add("ExtendNum", DbType.Int32).Value = ExtendNum;
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过DI名称来删除轴数据
        /// </summary>
        /// <param name="oldName">将要删除的DI名称</param>
        /// <returns></returns>
        public int DeleteDO(String oldName)
        {
            try
            {
                string sql = "DELETE FROM WcfDO WHERE Name=@oldName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        ////////////////////////////机种
        /// <summary>
        /// 读取或切换机种数据，并设置参数表名
        /// </summary>
        /// <param name="Name">机种名字，为空则读取当前机种，若没有当前机种则读取默认机种</param>
        /// <returns></returns>
        public int SelectShowModel(string Name, ref ComboBox mComboBox)
        {
            try
            {
                if (Name.Length > 0)
                {
                    //把所有机种都设置为0
                    string sql = "UPDATE WcfModel SET Current = 0";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    //把选择的机种设置为当前机种
                    sql = "UPDATE WcfModel SET Current = 1 WHERE Name=@Name";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.Add("Name", DbType.String).Value = Name;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select Id,Name,Current,Current from WcfModel", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                //显示机种列表
                mComboBox.Items.Clear();
                int isDefault = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mComboBox.Items.Add(dt.Rows[i]["Name"].ToString());
                        if (int.Parse(dt.Rows[i]["Current"].ToString()) == 1)
                        {
                            isDefault++;
                            mParameter = "WcfParameter" + dt.Rows[i]["Id"].ToString();
                            mComboBox.Text = dt.Rows[i]["Name"].ToString();
                        }
                    }
                    //当没有当前机种时，把默认机种设置为当前机种
                    if (isDefault == 0)
                    {
                        //设置为默认参数表
                        mParameter = "WcfParameter" + dt.Rows[0]["Id"].ToString();
                        mComboBox.Text = dt.Rows[0]["Name"].ToString();
                        //把第一个机种设置为默认机种
                        string sql = "UPDATE WcfModel SET Current = 1 WHERE Id=@Id";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.Add("Id", DbType.Int32).Value = dt.Rows[0]["Id"];
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 校验是否有重复机种名称
        /// </summary>
        /// <param name="Name">机种名称</param>
        /// <returns></returns>
        public int SelectShowModelName(string Name)
        {
            try
            {
                string sql = "select * from WcfModel WHERE Name='" + Name + "'";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 增加新机种
        /// </summary>
        /// <param name="Name">机种名字</param>
        /// <returns></returns>
        public int InsertModel(string Name)
        {
            string nowParameter = "";
            try
            {
                //把所有机种都设置为0
                string sql = "UPDATE WcfModel SET Current = 0";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                //插入新机种并设置为默认机种
                sql = "INSERT INTO WcfModel(Name,Current)  VALUES(@Name,@Current)";
                cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Name", DbType.String).Value = Name;
                cmd.Parameters.Add("Current", DbType.Int32).Value = 1;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                //读取新机种对应的Id
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select ID from WcfModel WHERE Name='" + Name + "'", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    nowParameter = "WcfParameter" + dt.Rows[0]["Id"].ToString();
                    //创建和当前参数表一样结构一样数据的参数表
                    sql = "create table " + nowParameter + " as select * from " + mParameter;
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 删除机种
        /// </summary>
        /// <param name="Name">机种名字</param>
        /// <returns></returns>
        public int DeleteModel(string Name)
        {
            if (Name == "默认机种")
            {
                return 1;
            }
            string sql = "";
            SQLiteCommand cmd;
            try
            {
                //删除参数表
                sql = "DROP TABLE " + mParameter;
                cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                //删除机种表数据
                sql = "DELETE FROM WcfModel WHERE Name=@oldName";
                cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("oldName", DbType.String).Value = Name;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        ///////////////////////////////////////参数表
        /// <summary>
        /// 参数数据的查询
        /// </summary>
        /// <returns></returns>
        public int getDataParameter(string Name, out double Value)
        {
            Value = 0;
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select Value from  " + mParameter + "  WHERE Name='" + Name + "'", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Value = double.Parse(dt.Rows[0][0].ToString());
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询获取轴数据表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public int SelectShowParameter(out DataTable dt, string GroupName = "")
        {
            dt = new DataTable();
            try
            {
                if (GroupName.Length > 0)
                {
                    GroupName = " WHERE GroupName = '" + GroupName + "' ";
                }
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select GroupName,Name,Value,Remarks from  " + mParameter + GroupName + " ORDER BY GroupName", conn);
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    if (GroupName.Length == 0)
                        MessageBox.Show("输入数据为空");
                    else
                        MessageBox.Show(GroupName + "组的输入数据为空");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查找相互类似的参数（更新一组数据用,一组位置，如：贴合X、贴合Y、贴合Z，查询贴合可以把这组3个数据查询出来）
        /// </summary>
        /// <returns></returns>
        public int SelectShowParameter(string Name, ref DataGridView dgvShow)
        {
            try
            {
                string sql = "select " + mParameter + ".Name as 名称," +
                    mParameter + ".Value as 值, WcfAxis.Name as 关联轴 from " +
                    mParameter + " left join WcfAxis on WcfAxis.ID = " + mParameter + ".CorrAxis " +
                    "where " + mParameter + ".Name like '" + Name + "%' ORDER BY " + mParameter + ".GroupName";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询参数表数据
        /// </summary>
        /// <returns></returns>
        public int SelectShowParameter(ref DataGridView dgvShow)
        {
            try
            {
                string sql = "select " + mParameter + ".GroupName as 组名," + mParameter + ".Name as 名称," +
                    mParameter + ".Value as 值, WcfAxis.Name as 关联轴," + mParameter + ".Remarks as 备注 from " +
                    mParameter + " left join WcfAxis on WcfAxis.ID = " + mParameter + ".CorrAxis ORDER BY " + mParameter + ".GroupName";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dicPara.ContainsKey(dr[1].ToString()))
                    {
                        if (dr[3].ToString().Length <= 0)
                            dicPara[dr[1].ToString()] = dr[2].ToString();
                        else
                            dicPara[dr[1].ToString()] = dr[2].ToString() + ";" + dicAxis[dr[3].ToString()];
                    }
                    else
                    {
                        if (dr[3].ToString().Length <= 0)
                            dicPara.TryAdd(dr[1].ToString(), dr[2].ToString());
                        else
                            dicPara.TryAdd(dr[1].ToString(), dr[2].ToString() + ";" + dicAxis[dr[3].ToString()]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过组名查询参数表数据
        /// </summary>
        /// <param name="GroupName">参数组名</param>
        /// <returns></returns>
        public int SelectShowParameter(ref DataGridView dgvShow, string GroupName)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(
                    "select GroupName as 组名,Name as 名称,Value as 值 from " + mParameter +
                    " WHERE GroupName=" + GroupName + " ORDER BY GroupName", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询参数表是否有重复的参数名称
        /// </summary>
        /// <param name="Name">参数名称</param>
        /// <returns></returns>
        public int SelectShowParameterName(string Name)
        {
            try
            {
                string sql = "select * from " + mParameter + " WHERE Name='" + Name + "'";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 更新参数数据
        /// </summary>
        /// <param name="isUpdateName">是否更新组名，参数名称和备注(不改变就不用更新)</param>
        /// <param name="oldName">旧参数名称</param>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">参数名称</param>
        /// <param name="Value">参数对应值</param>
        /// <param name="CorrAxis">关联轴</param>
        /// <param name="Remarks">备注</param>
        /// <returns></returns>
        public int UpdateParameter(bool isUpdateName, string oldName, string GroupName, string Name, Double Value, string CorrAxis, string Remarks)
        {
            try
            {
                string sql = "";
                SQLiteCommand cmd;
                if (isUpdateName)
                {
                    if (CorrAxis.Length == 0)
                        CorrAxis = "-1";

                    SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select Id,Name,Current from WcfModel", conn);
                    DataTable dt = new DataTable();
                    mAdapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string mParaUPDATE = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            mParaUPDATE = "WcfParameter" + dt.Rows[i]["Id"].ToString();
                            sql = "UPDATE " + mParaUPDATE + " SET GroupName=@GroupName,Name=@Name,CorrAxis=@CorrAxis,Remarks=@Remarks WHERE Name=@oldName";
                            cmd = new SQLiteCommand(sql, conn);
                            cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                            cmd.Parameters.Add("Name", DbType.String).Value = Name;
                            cmd.Parameters.Add("CorrAxis", DbType.Int32).Value = CorrAxis;
                            cmd.Parameters.Add("Remarks", DbType.String).Value = Remarks;
                            cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                            cmd.ExecuteNonQuery();
                            cmd.Clone();
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
                sql = "UPDATE " + mParameter + " SET Value=@Value WHERE Name=@oldName";
                cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("Value", DbType.Double).Value = Value;
                cmd.Parameters.Add("oldName", DbType.String).Value = oldName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 参数表插入数据(插入所有的参数表)
        /// </summary>
        /// <param name="GroupName">组名</param>
        /// <param name="Name">名称</param>
        /// <param name="Value">值</param>
        /// <returns></returns>
        public int InsertParameter(string GroupName, string Name, double Value, string CorrAxis, string Remarks)
        {
            try
            {
                string sql = "";
                string mParameter = "";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select Id,Name,Current from WcfModel", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                SQLiteCommand cmd;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mParameter = "WcfParameter" + dt.Rows[i]["Id"].ToString();
                        sql = "INSERT INTO " + mParameter + " (GroupName,Name,Value,CorrAxis,Remarks) VALUES(@GroupName,@Name,@Value,@CorrAxis,@Remarks)";
                        cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                        cmd.Parameters.Add("Name", DbType.String).Value = Name;
                        cmd.Parameters.Add("Value", DbType.Double).Value = Value;
                        cmd.Parameters.Add("CorrAxis", DbType.Int32).Value = CorrAxis;
                        cmd.Parameters.Add("Remarks", DbType.String).Value = Remarks;
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 参数表删除数据
        /// </summary>
        /// <param name="Name">删除的参数名称</param>
        /// <returns></returns>
        public int DeleteParameter(string Name)
        {
            try
            {
                string sql = "";
                string mParameter = "";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select Id,Name,Current from WcfModel", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                SQLiteCommand cmd;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mParameter = "WcfParameter" + dt.Rows[i]["Id"].ToString();
                        sql = "DELETE FROM " + mParameter + " WHERE Name='" + Name + "'";
                        cmd = new SQLiteCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 矩阵表添加数据
        /// </summary>
        /// <returns></returns>
        public int InsertMatrix(String Name, ConcurrentDictionary<string, string> dicMatrix)
        {
            try
            {
                SQLiteCommand cmd;
                //查询表是否存在
                string sql = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='" + mParameter + Name + "'";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    //没有表就创建
                    sql = "create table " + mParameter + Name + " as select * from WcfParameter";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                else
                {
                    //有表就清空数据
                    //1：清空数据
                    sql = "DELETE FROEM '" + mParameter + Name + "'";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    //2：自增列改为0
                    sql = "UPDATE sqlite_sequence SET seq=0 WHRER name = '" + mParameter + Name + "'";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                //插入数据
                foreach (String item in dicMatrix.Values)
                {
                    string[] mValue = item.Split(';');
                    sql = "INSERT INTO " + mParameter + Name + "(GroupName,Name,CardNum,IoID,IoType,IoState,ExtendNum) " +
                    "VALUES(@GroupName,@Name,@CardNum,@IoID,@IoType,@IoState,@ExtendNum)";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.Add("NUM", DbType.Int32).Value = double.Parse(mValue[0]);
                    cmd.Parameters.Add("State", DbType.Int32).Value = double.Parse(mValue[1]);
                    cmd.Parameters.Add("X", DbType.Int32).Value = double.Parse(mValue[2]);
                    cmd.Parameters.Add("Y", DbType.Int32).Value = double.Parse(mValue[3]);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 矩阵表查询数据
        /// </summary>
        /// <returns></returns>
        public int SelectMatrix(string Name, ref ConcurrentDictionary<string, string> dicMatrix)
        {
            try
            {
                SQLiteCommand cmd;
                //查询表是否存在
                string sql = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='" + mParameter + Name + "'";
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    //没有表就创建
                    sql = "create table " + mParameter + Name + " as select * from WcfParameter";
                    cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                }
                mAdapter = new SQLiteDataAdapter("select NUM,State,X,Y,OffsetX,OffsetY,OffsetR  from " + mParameter + Name + "  ORDER BY NUM", conn);
                dt = new DataTable();
                mAdapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dicMatrix.ContainsKey(dr[0].ToString()))
                        dicMatrix[dr[0].ToString()] = dr[1].ToString() + ";" + dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString();
                    else
                        dicMatrix.TryAdd(dr[0].ToString(), dr[1].ToString() + ";" + dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 生成常量类
        /// </summary>
        /// <returns></returns>
        public int GeneratingClass()
        {
            TextWriter tw = new StreamWriter(new BufferedStream(new FileStream(
                Application.StartupPath + "\\WConstClass.cs", FileMode.Create, FileAccess.Write)),
                System.Text.Encoding.GetEncoding("gb2312"));
            try
            {
                tw.WriteLine("namespace WCF");
                tw.WriteLine("{");
                tw.WriteLine("\tclass WConstClass");
                tw.WriteLine("\t{");
                foreach (String mKey in dicPara.Keys)
                {
                    tw.WriteLine("\t\tpublic const string " + mKey + " = \"" + mKey + "\";");
                }
                foreach (String mKey in dicAxis.Keys)
                {
                    tw.WriteLine("\t\tpublic const string " + mKey + " = \"" + mKey + "\";");
                }
                foreach (String mKey in dicDI.Keys)
                {
                    tw.WriteLine("\t\tpublic const string " + mKey + " = \"" + mKey + "\";");
                }
                foreach (String mKey in dicDO.Keys)
                {
                    tw.WriteLine("\t\tpublic const string " + mKey + " = \"" + mKey + "\";");
                }
                tw.WriteLine("\t}");
                tw.WriteLine("}");
                tw.Flush();
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                tw.Close();
            }
            return 0;
        }
    }
}
