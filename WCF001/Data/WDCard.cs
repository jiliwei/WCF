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
    /// 类 	  名：WDCard
    /// 类 描 述：板卡数据类
    /// WCF·769838889@qq.com
    /// 创建时间：2021/10/14
    /// 源    码：https://github.com/jiliwei/WCF
    class WDCard : WData
    {
        private static ConcurrentDictionary<string, AxisData> dicAxis = new ConcurrentDictionary<string, AxisData>();//轴数据字典
        private static ConcurrentDictionary<string, DIData> dicDI = new ConcurrentDictionary<string, DIData>();//DI数据字典
        private static ConcurrentDictionary<string, DOData> dicDO = new ConcurrentDictionary<string, DOData>();//DO数据字典
        public static ConcurrentDictionary<string, AxisData> DicAxis { get => dicAxis; set => dicAxis = value; }
        public static ConcurrentDictionary<string, DIData> DicDI { get => dicDI; set => dicDI = value; }
        public static ConcurrentDictionary<string, DOData> DicDO { get => dicDO; set => dicDO = value; }

        private static ConcurrentDictionary<string, AxisInfor> dicAxisInfor = new ConcurrentDictionary<string, AxisInfor>();//轴状态信息
        private static ConcurrentDictionary<string, DiInfor> dicDiInfor = new ConcurrentDictionary<string, DiInfor>();//DI状态信息
        public static ConcurrentDictionary<string, AxisInfor> DicAxisInfor { get => dicAxisInfor; set => dicAxisInfor = value; }
        public static ConcurrentDictionary<string, DiInfor> DicDiInfor { get => dicDiInfor; set => dicDiInfor = value; }


        public static Dictionary<string, List<AxisData>> DicListAxis { 
            get 
            {
                Dictionary<string, List<AxisData>> dicListAxis = new Dictionary<string, List<AxisData>>();
                string groupNameOld = "";
                string groupName;
                List<AxisData> listAxisData = new List<AxisData>();
                foreach (KeyValuePair<string,AxisData> itemAxis in dicAxis)
                {
                    groupName = itemAxis.Value.GroupName;
                    if (!groupNameOld.Equals(groupName) && !groupNameOld.Equals(""))
                    {
                        if (dicListAxis.ContainsKey(groupNameOld))
                        {
                            foreach (AxisData itemList in listAxisData)
                            {
                                dicListAxis[groupNameOld].Add(itemList);
                            }
                        }
                        else
                            dicListAxis.Add(groupNameOld, listAxisData);
                        listAxisData = new List<AxisData>();
                    }
                    listAxisData.Add(itemAxis.Value);
                    groupNameOld = groupName;
                }
                if (listAxisData.Count > 0)
                {
                    if (dicListAxis.ContainsKey(groupNameOld))
                    {
                        foreach (AxisData itemList in listAxisData)
                        {
                            dicListAxis[groupNameOld].Add(itemList);
                        }
                    }
                    else
                        dicListAxis.Add(groupNameOld, listAxisData);
                }

                return dicListAxis;
            }
        }
        public static Dictionary<string, List<DIData>> DicListDI
        {
            get
            {
                Dictionary<string, List<DIData>> dicListDI = new Dictionary<string, List<DIData>>();
                string groupNameOld = "";
                string groupName;
                List<DIData> listDIData = new List<DIData>();
                foreach (KeyValuePair<string, DIData> itemAxis in dicDI)
                {
                    groupName = itemAxis.Value.GroupName;
                    if (!groupNameOld.Equals(groupName) && !groupNameOld.Equals(""))
                    {
                        if (dicListDI.ContainsKey(groupNameOld))
                        {
                            foreach (DIData itemList in listDIData)
                            {
                                dicListDI[groupNameOld].Add(itemList);
                            }
                        }
                        else
                            dicListDI.Add(groupNameOld, listDIData);
                        listDIData = new List<DIData>();
                    }
                    listDIData.Add(itemAxis.Value);
                    groupNameOld = groupName;
                }
                if (listDIData.Count > 0)
                {
                    if (dicListDI.ContainsKey(groupNameOld))
                    {
                        foreach (DIData itemList in listDIData)
                        {
                            dicListDI[groupNameOld].Add(itemList);
                        }
                    }
                    else
                        dicListDI.Add(groupNameOld, listDIData);
                }
                return dicListDI;
            }
        }
        public static Dictionary<string, List<DOData>> DicListDO
        {
            get
            {
                Dictionary<string, List<DOData>> dicListDO = new Dictionary<string, List<DOData>>();
                string groupNameOld = "";
                string groupName;
                List<DOData> listDOData = new List<DOData>();
                foreach (KeyValuePair<string, DOData> itemAxis in dicDO)
                {
                    groupName = itemAxis.Value.GroupName;
                    if (!groupNameOld.Equals(groupName) && !groupNameOld.Equals(""))
                    {
                        if (dicListDO.ContainsKey(groupNameOld))
                        {
                            foreach (DOData itemList in listDOData)
                            {
                                dicListDO[groupNameOld].Add(itemList);
                            }
                        }
                        else
                            dicListDO.Add(groupNameOld, listDOData);
                        listDOData = new List<DOData>();
                    }
                    listDOData.Add(itemAxis.Value);
                    groupNameOld = groupName;
                }
                if (listDOData.Count > 0)
                {
                    if (dicListDO.ContainsKey(groupNameOld))
                    {
                        foreach (DOData itemList in listDOData)
                        {
                            dicListDO[groupNameOld].Add(itemList);
                        }
                    }
                    else
                        dicListDO.Add(groupNameOld, listDOData);
                }
                return dicListDO;
            }
        }


        /// <summary>
        /// 校验数据库文件是否存在
        /// </summary>
        /// <returns></returns>
        public static int CheckForm()
        {
            try
            {
                //判断数据库是否存在，不存在则创建数据库及相应表
                if (!CheckFormExists("WcfAxis"))
                {
                    //创建轴数据表
                    Create("CREATE TABLE WcfAxis ( " +
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR UNIQUE NOT NULL," +
                            "CardNum INTEGER NOT NULL," +
                            "AxisNum  INTEGER NOT NULL," +
                            "Pulse INTEGER NOT NULL DEFAULT(1000)," +
                            "Acc INTEGER NOT NULL DEFAULT(100)," +
                            "Speed INTEGER NOT NULL DEFAULT(10)," +
                            "ResetNum INTEGER NOT NULL DEFAULT(0))");
                    //创建输入表
                    Create("CREATE TABLE WcfDI (" +
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR NOT NULL," +
                            "CardNum   INTEGER NOT NULL," +
                            "IoID INTEGER NOT NULL," +
                            "IoType    INTEGER CONSTRAINT[4] NOT NULL DEFAULT(4)," +
                            "IoState INTEGER CONSTRAINT FALSE NOT NULL DEFAULT(0)," +
                            "ExtendNum INTEGER CONSTRAINT[0] NOT NULL DEFAULT(0))");
                    //创建输出表
                    Create("CREATE TABLE WcfDO (" +
                            "ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                            "GroupName VARCHAR NOT NULL," +
                            "Name VARCHAR NOT NULL," +
                            "CardNum   INTEGER NOT NULL," +
                            "IoID INTEGER NOT NULL," +
                            "IoType    INTEGER CONSTRAINT[4] NOT NULL DEFAULT(4)," +
                            "IoState INTEGER CONSTRAINT FALSE NOT NULL DEFAULT(0)," +
                            "ExtendNum INTEGER CONSTRAINT[0] NOT NULL DEFAULT(0))");
                }
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /////////////////////////////////////////轴
        /// <summary>
        /// 轴数据的查询
        /// </summary>
        /// <returns></returns>
        public static int getDataAxis(string Name, out int CardNum, out int AxisNum, out int Pulse, out int Acc, out int Speed, out int ResetNum)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 轴数据的所有轴名称查询
        /// </summary>
        /// <returns></returns>
        public static int getDataAxis(out DataTable dtCorrAxis)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 轴数据的查询和显示
        /// </summary>
        /// <returns></returns>
        public static int SelectShowAxis(ref DataGridView dgvShow)
        {
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select  GroupName as 组名,Name as 名称,CardNum as 卡号,AxisNum as 轴号,Pulse as 脉冲当量,Acc as 加速度,Speed as 速度,ResetNum as 复位顺序 from WcfAxis", conn);
                DataTable dt = new DataTable();
                mAdapter.Fill(dt);
                dgvShow.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    AxisData mAxisData = new AxisData();
                    mAxisData.GroupName = dr[0].ToString();
                    mAxisData.Name = dr[1].ToString();
                    mAxisData.CardNum = dr[2].ToString();
                    mAxisData.AxisNum = dr[3].ToString();
                    mAxisData.Pulse = dr[4].ToString();
                    mAxisData.Acc = dr[5].ToString();
                    mAxisData.Speed = dr[6].ToString();
                    mAxisData.ResetNum = dr[7].ToString();
                    if (dicAxis.ContainsKey(dr[1].ToString()))
                        dicAxis[dr[1].ToString()] = mAxisData;
                    else
                        dicAxis.TryAdd(dr[1].ToString(), mAxisData);

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
        /// 查询获取轴数据表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public static int SelectShowAxis(out DataTable dt, string GroupName = "")
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
                        WTool.Popup("输入数据为空");
                    else
                        WTool.Popup(GroupName + "组的输入数据为空");
                    return 1;
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
        /// 查询获取轴数据表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public static int SelectShowAxisName(out DataTable dt)
        {
            dt = new DataTable();
            try
            {
                SQLiteDataAdapter mAdapter = new SQLiteDataAdapter("select ID,GroupName,Name from WcfAxis ORDER BY GroupName", conn);
                mAdapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return 1;
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
        /// 校验轴数据表是否已经存在
        /// </summary>
        /// <param name="mCheck">校验的数据</param>
        /// <returns>存在返回1，不存在返回0</returns>
        public static int SelectShowAxisCheck(string mCheck)
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
                WTool.Popup(ex.ToString());
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
        public static int InsertAxis(String GroupName, String Name, Int32 CardNum, Int32 AxisNum, Int32 Pulse, Int32 Acc, Int32 Speed, Int32 ResetNum)
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
                WTool.Popup(ex.ToString());
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
        public static int UpdateAxis(String oldName, String GroupName, String Name, Int32 CardNum, Int32 AxisNum, Int32 Pulse, Int32 Acc, Int32 Speed, Int32 ResetNum)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过轴名称来删除轴数据
        /// </summary>
        /// <param name="oldName">将要删除的轴名称</param>
        /// <returns></returns>
        public static int DeleteAxis(String oldName)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /////////////////////////////////输入
        /// <summary>
        /// DI数据的查询
        /// </summary>
        /// <returns></returns>
        public static int getDataDI(string Name, out int CardNum, out int IoID, out int IoType, out int IoState, out int ExtendNum)
        {
            CardNum = 0;
            IoID = 0;
            IoType = 0;
            IoState = 0;
            ExtendNum = 0;
            try
            {
                CardNum = int.Parse(dicDI[Name].CardNum);
                IoID = int.Parse(dicDI[Name].IoID);
                IoType = int.Parse(dicDI[Name].IoType);
                IoState = int.Parse(dicDI[Name].IoState);
                ExtendNum = int.Parse(dicDI[Name].ExtendNum);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// DI数据的查询和显示
        /// </summary>
        /// <returns></returns>
        public static int SelectShowDI(ref DataGridView dgvShow)
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
                    DIData mDIData = new DIData();
                    mDIData.GroupName = dr[0].ToString();
                    mDIData.Name = dr[1].ToString();
                    mDIData.CardNum = dr[2].ToString();
                    mDIData.IoID = dr[3].ToString();
                    mDIData.IoType = dr[4].ToString();
                    mDIData.IoState = dr[5].ToString();
                    mDIData.ExtendNum = dr[6].ToString();
                    if (dicDI.ContainsKey(dr[1].ToString()))
                        dicDI[dr[1].ToString()] = mDIData;
                    else
                        dicDI.TryAdd(dr[1].ToString(), mDIData);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvShow.Rows[i].Cells[4].Value = WContTool.getIoTypeName(int.Parse(dgvShow.Rows[i].Cells[4].Value.ToString()));
                    dgvShow.Rows[i].Cells[5].Value = WContTool.getIoStateName(int.Parse(dgvShow.Rows[i].Cells[5].Value.ToString()));
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
        /// 查询获取输入表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public static int SelectShowDI(out DataTable dt, string GroupName = "")
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
                    return 1;
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
        /// 校验DI数据表是否已经存在数据
        /// </summary>
        /// <param name="mCheck">校验的数据</param>
        /// <returns>存在返回1，不存在返回0</returns>
        public static int SelectShowDICheck(string mCheck)
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
                WTool.Popup(ex.ToString());
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
        public static int InsertDI(String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
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
                WTool.Popup(ex.ToString());
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
        public static int UpdateDI(String oldName, String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过DI名称来删除轴数据
        /// </summary>
        /// <param name="oldName">将要删除的DI名称</param>
        /// <returns></returns>
        public static int DeleteDI(String oldName)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /////////////////////////////////输出
        /// <summary>
        /// DO数据的查询
        /// </summary>
        /// <returns></returns>
        public static int getDataDO(string Name, out int CardNum, out int IoID, out int IoType, out int IoState, out int ExtendNum)
        {
            CardNum = 0;
            IoID = 0;
            IoType = 0;
            IoState = 0;
            ExtendNum = 0;
            try
            {
                CardNum = int.Parse(dicDO[Name].CardNum);
                IoID = int.Parse(dicDO[Name].IoID);
                IoType = int.Parse(dicDO[Name].IoType);
                IoState = int.Parse(dicDO[Name].IoState);
                ExtendNum = int.Parse(dicDO[Name].ExtendNum);
            }
            catch (Exception ex)
            {
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// DO数据的查询和显示
        /// </summary>
        /// <returns></returns>
        public static int SelectShowDO(ref DataGridView dgvShow)
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
                    DOData mDOData = new DOData();
                    mDOData.GroupName = dr[0].ToString();
                    mDOData.Name = dr[1].ToString();
                    mDOData.CardNum = dr[2].ToString();
                    mDOData.IoID = dr[3].ToString();
                    mDOData.IoType = dr[4].ToString();
                    mDOData.IoState = dr[5].ToString();
                    mDOData.ExtendNum = dr[6].ToString();
                    if (dicDO.ContainsKey(dr[1].ToString()))
                        dicDO[dr[1].ToString()] = mDOData;
                    else
                        dicDO.TryAdd(dr[1].ToString(), mDOData);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvShow.Rows[i].Cells[4].Value = WContTool.getIoTypeName(int.Parse(dgvShow.Rows[i].Cells[4].Value.ToString()));
                    dgvShow.Rows[i].Cells[5].Value = WContTool.getIoStateName(int.Parse(dgvShow.Rows[i].Cells[5].Value.ToString()));
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
        /// 查询获取输出表所有数据
        /// </summary>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        public static int SelectShowDO(out DataTable dt, string GroupName = "")
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
                    return 1;
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
        /// 校验DO数据表是否已经存在数据
        /// </summary>
        /// <param name="mCheck">校验的数据</param>
        /// <returns>存在返回1，不存在返回0</returns>
        public static int SelectShowDOCheck(string mCheck)
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
                WTool.Popup(ex.ToString());
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
        public static int InsertDO(String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
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
                WTool.Popup(ex.ToString());
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
        public static int UpdateDO(String oldName, String GroupName, String Name, Int32 CardNum, Int32 IoID, Int32 IoType, Int32 IoState, Int32 ExtendNum)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 通过DI名称来删除轴数据
        /// </summary>
        /// <param name="oldName">将要删除的DI名称</param>
        /// <returns></returns>
        public static int DeleteDO(String oldName)
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
                WTool.Popup(ex.ToString());
                return -1;
            }
            return 0;
        }
    }
    #region 数据实体类
    public class CardData
    {
        private string type = string.Empty;//卡类型，固高八轴卡、固高四轴卡、固高16入16出扩展卡、固高16入扩展卡
        private string name = string.Empty;//卡名称
        private int cardNum;//卡号
        private int extendNum;//扩展卡号
        private Dictionary<string, AxisData> dicAxis = new Dictionary<string, AxisData>();//轴数据字典
        private Dictionary<string, DIData> dicDI = new Dictionary<string, DIData>();//DI数据字典
        private Dictionary<string, DOData> dicDO = new Dictionary<string, DOData>();//DO数据字典
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public int CardNum { get => cardNum; set => cardNum = value; }
        public int ExtendNum { get => extendNum; set => extendNum = value; }
        public Dictionary<string, AxisData> DicAxis { get => dicAxis; set => dicAxis = value; }
        public Dictionary<string, DIData> DicDI { get => dicDI; set => dicDI = value; }
        public Dictionary<string, DOData> DicDO { get => dicDO; set => dicDO = value; }
    }
    public class AxisData
    {
        private string groupName = string.Empty;//组名
        private string name = string.Empty;//名称
        private string cardNum;//卡号
        private string axisNum;//轴号
        private string pulse;//脉冲当量
        private string acc;//加速度
        private string speed;//速度
        private string resetNum;//复位顺序

        public string GroupName { get => groupName; set => groupName = value; }
        public string Name { get => name; set => name = value; }
        public string CardNum { get => cardNum; set => cardNum = value; }
        public string AxisNum { get => axisNum; set => axisNum = value; }
        public string Pulse { get => pulse; set => pulse = value; }
        public string Acc { get => acc; set => acc = value; }
        public string Speed { get => speed; set => speed = value; }
        public string ResetNum { get => resetNum; set => resetNum = value; }
    }
    public class DIData
    {
        private string groupName;//组名
        private string name;//名称
        private string cardNum;//卡号
        private string ioID;//端口号
        private string ioType;//类型
        private string ioState;//状态
        private string extendNum;//扩展卡号

        public string GroupName { get => groupName; set => groupName = value; }
        public string Name { get => name; set => name = value; }
        public string CardNum { get => cardNum; set => cardNum = value; }
        public string IoID { get => ioID; set => ioID = value; }
        public string IoType { get => ioType; set => ioType = value; }
        public string IoState { get => ioState; set => ioState = value; }
        public string ExtendNum { get => extendNum; set => extendNum = value; }
    }
    public class DOData
    {
        private string groupName;//组名
        private string name;//名称
        private string cardNum;//卡号
        private string ioID;//端口号
        private string ioType;//类型
        private string ioState;//状态
        private string extendNum;//扩展卡号

        public string GroupName { get => groupName; set => groupName = value; }
        public string Name { get => name; set => name = value; }
        public string CardNum { get => cardNum; set => cardNum = value; }
        public string IoID { get => ioID; set => ioID = value; }
        public string IoType { get => ioType; set => ioType = value; }
        public string IoState { get => ioState; set => ioState = value; }
        public string ExtendNum { get => extendNum; set => extendNum = value; }
    }
    public class AxisInfor
    {
        private string name;
        private bool negative;
        private bool origin;
        private bool positive;
        private bool enable;
        private bool alarm;
        private double actual;
        private AxisState state;

        public string Name { get => name; set => name = value; }
        public bool Negative { get => negative; set => negative = value; }
        public bool Origin { get => origin; set => origin = value; }
        public bool Positive { get => positive; set => positive = value; }
        public bool Enable { get => enable; set => enable = value; }
        public bool Alarm { get => alarm; set => alarm = value; }
        public double Actual { get => actual; set => actual = value; }
        public AxisState State { get => state; set => state = value; }
    }
    public class DiInfor
    {
        private string name;
        private bool state;

        public string Name { get => name; set => name = value; }
        public bool State { get => state; set => state = value; }
    }
    #endregion
}
