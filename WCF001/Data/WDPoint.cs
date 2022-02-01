using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace WCF
{
    /// 类 	  名：WDPoint
	/// 类 描 述：点位控件数据类
	/// WCF·769838889@qq.com
	/// 创建时间：2021/11/03
	/// 源    码：https://github.com/jiliwei/WCF
    class WDPoint : WData
    {
        //点位的所有数据
        private static Dictionary<string, List<PointMain>> dicPointMain = new Dictionary<string, List<PointMain>>();
        internal static Dictionary<string, List<PointMain>> DicPointMain
        {
            get
            {
                SelectPoint();
                return dicPointMain;
            }
        }
        internal static Dictionary<string, List<PointMain>> getDicPointMain
        {
            get
            {
                return dicPointMain;
            }
        }
        /// <summary>
        /// 检查点位表是否存在，不存在就创建相应的表
        /// </summary>
        public static void CheckForm()
        {
            if (!CheckFormExists("WcfPointName"))//如果没有参数表，则创建相应的表
            {
                //新增点位名称表
                Create("CREATE TABLE WcfPointName (" +
                        "ID        INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "NumOrder  DOUBLE  NOT NULL, " +
                        "GroupName VARCHAR NOT NULL, " +
                        "PointName VARCHAR NOT NULL)");
                //新增点位对应轴表
                Create("CREATE TABLE WcfPointAxis (" +
                        "ID          INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "PointNameID INTEGER REFERENCES WcfPointName(ID), " +
                        "AxisID      INTEGER REFERENCES WcfAxis(ID))");
                //新增点位对应值表
                Create("CREATE TABLE WcfPointValue( " +
                        "ID          INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "PointAxisID INTEGER REFERENCES WcfPointAxis(ID), " +
                        "ModelID     INTEGER REFERENCES WcfParaModel(ID), " +
                        "Pos       DOUBLE  CONSTRAINT[0] NOT NULL, " +
                        "Speed      DOUBLE  CONSTRAINT[100] NOT NULL DEFAULT(100), " +
                        "Acc         DOUBLE  CONSTRAINT[100] NOT NULL DEFAULT(100), " +
                        "Dec         DOUBLE  CONSTRAINT[100] NOT NULL DEFAULT(100), " +
                        "Smooth       DOUBLE  CONSTRAINT[50] NOT NULL DEFAULT(50) )");
            }
        }
        /// <summary>
        /// 点位数据查询
        /// </summary>
        /// <returns></returns>
        public static int SelectPoint()
        {
            try
            {
                DataTable dt = Select("select "+
                                        "WcfPointName.ID, "+
                                        "WcfPointName.NumOrder, "+
                                        "WcfPointName.GroupName, "+
                                        "WcfPointName.PointName, "+
                                        "WcfAxis.Name, "+
                                        "WcfPointValue.Pos, " +
                                        "WcfPointValue.Speed, " +
                                        "WcfPointValue.Acc, " +
                                        "WcfPointValue.Dec, " +
                                        "WcfPointValue.Smooth " +
                                        "from WcfPointName " +
                                        "LEFT JOIN WcfPointAxis ON WcfPointAxis.PointNameID = WcfPointName.ID "+
                                        "LEFT JOIN WcfAxis ON WcfAxis.ID = WcfPointAxis.AxisID "+
                                        "LEFT JOIN WcfPointValue ON WcfPointValue.PointAxisID = WcfPointAxis.ID "+
                                        "WHERE WcfPointValue.ModelID = 1 "+
                                        "order by WcfPointName.NumOrder asc");
                dicPointMain.Clear();
                string iD = "";
                string numOrder = "";
                string groupName = "";
                string pointName = "";
                string axisName = "";
                string pos = "";
                string speed = "";
                string acc = "";
                string dec = "";
                string smooth = "";

                List<PointMain> mPointMains = new List<PointMain>();
                PointMain mPointMain = new PointMain();
                string groupNameOld = "";
                string pointNameOld = "";
                foreach (DataRow dr in dt.Rows)
                {
                    iD = dr[0].ToString();
                    numOrder = dr[1].ToString();
                    groupName = dr[2].ToString();
                    pointName = dr[3].ToString();
                    axisName = dr[4].ToString();
                    pos = dr[5].ToString();
                    speed = dr[6].ToString();
                    acc = dr[7].ToString();
                    dec = dr[8].ToString();
                    smooth = dr[9].ToString();

                    PointValue mPointValue = new PointValue();
                    mPointValue.Pos = double.Parse(pos);
                    mPointValue.Speed = double.Parse(speed);
                    mPointValue.Acc = double.Parse(acc);
                    mPointValue.Dec = double.Parse(dec);
                    mPointValue.Smooth = double.Parse(smooth);

                    if (!pointName.Equals(pointNameOld))
                    {
                        if (!pointNameOld.Equals(""))//当不是第一个时才添加
                            mPointMains.Add(mPointMain);

                        mPointMain = new PointMain();
                        mPointMain.ID = int.Parse(iD);
                        mPointMain.NumOrder = double.Parse(numOrder);
                        mPointMain.GroupName = groupName;
                        mPointMain.PointName = pointName;

                    }
                    mPointMain.DicPos.Add(axisName, mPointValue);

                    if (!groupNameOld.Equals(groupName) && !groupNameOld.Equals(""))
                    {
                        dicPointMain.Add(groupNameOld, mPointMains);
                        mPointMains = new List<PointMain>();
                    }

                    pointNameOld = pointName;
                    groupNameOld = groupName;
                }
                if (mPointMain.DicPos.Count > 0)
                {
                    mPointMains.Add(mPointMain);
                    dicPointMain.Add(groupName, mPointMains);
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
        /// 点位的增加
        /// </summary>int PointAxisID, double Pos
        /// <returns></returns>
        public static int InsertPoint(double NumOrder, string GroupName, string PointName, Dictionary<int,double> Pos)
        {
            try
            {
                //增加点位名称表数据
                string sql = "INSERT INTO WcfPointName(NumOrder,GroupName,PointName) " +
                                "VALUES(@NumOrder,@GroupName,@PointName)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("NumOrder", DbType.Double).Value = NumOrder;
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("PointName", DbType.String).Value = PointName;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                //查询点位名称表数据的ID
                DataTable dtPointName = Select("select ID from WcfPointName WHERE PointName = \""+ PointName + "\"");
                if (dtPointName.Rows.Count == 1)
                {
                    int PointNameID = int.Parse(dtPointName.Rows[0][0].ToString());
                    foreach (KeyValuePair<int, double> item in Pos)
                    {
                        //增加点位轴ID表数据
                        sql = "INSERT INTO WcfPointAxis(PointNameID,AxisID) " +
                                "VALUES(@PointNameID,@AxisID)";
                        cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.Add("PointNameID", DbType.Int32).Value = PointNameID;
                        cmd.Parameters.Add("AxisID", DbType.Int32).Value = item.Key;
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                        //机种表数据查询
                        DataTable dtModel = Select("SELECT ID FROM WcfParaModel order by ID asc");
                        DataTable dtPointAxis = Select("select ID from WcfPointAxis WHERE AxisID = " + item.Key.ToString() +
                            " and PointNameID = " + PointNameID.ToString());
                        if (dtPointAxis.Rows.Count == 1)
                        {
                            int PointAxisID = int.Parse(dtPointAxis.Rows[0][0].ToString());
                            foreach (DataRow drModel in dtModel.Rows)
                            {
                                //增加参数点位值数据
                                sql = "INSERT INTO WcfPointValue(PointAxisID,ModelID,Pos) " +
                                        "VALUES(@PointAxisID,@ModelID,@Pos)";
                                cmd = new SQLiteCommand(sql, conn);
                                cmd.Parameters.Add("PointAxisID", DbType.Int32).Value = int.Parse(dtPointAxis.Rows[0][0].ToString());
                                cmd.Parameters.Add("ModelID", DbType.Int32).Value = int.Parse(drModel[0].ToString());
                                cmd.Parameters.Add("Pos", DbType.Double).Value = item.Value;
                                cmd.ExecuteNonQuery();
                                cmd.Clone();
                            }
                        }
                        else
                        {
                            WTool.Popup("InsertPoint数据异常，WcfPointAxis查询到数据个数是：" + dtPointAxis.Rows.Count);
                            return -1;
                        }
                    }
                }
                else
                {
                    WTool.Popup("InsertPoint数据异常，WcfPointName查询到数据个数是：" + dtPointName.Rows.Count);
                    return -1;
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
        /// 点位的删除
        /// </summary>
        /// <returns></returns>
        public static int DeletePoint(string PointName)
        {
            try
            {
                //查询点位名称表数据的ID
                DataTable dtPointName = Select("select ID from WcfPointName WHERE PointName = \"" + PointName + "\"");
                if (dtPointName.Rows.Count == 1)
                {
                    int PointNameID = int.Parse(dtPointName.Rows[0][0].ToString());
                    DataTable dtPointAxis = Select("select ID from WcfPointAxis WHERE PointNameID = " + PointNameID.ToString());
                    foreach (DataRow drModel in dtPointAxis.Rows)
                    {
                        int iPointAxisID = int.Parse(drModel[0].ToString());
                        Delete("WcfPointAxis", "ID", iPointAxisID);
                        Delete("WcfPointValue", "PointAxisID", iPointAxisID);
                    }
                    Delete("WcfPointName", "ID", PointNameID);
                }
                else
                {
                    WTool.Popup("DeletePoint数据异常，WcfPointName查询到数据个数是：" + dtPointName.Rows.Count);
                    return -1;
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
        /// 更改点位组名和点位名称
        /// </summary>
        /// <param name="PointName">点位名称</param>
        /// <param name="GroupName">点位组名</param>
        /// <param name="oldPointName">点位名称旧值</param>
        /// <returns></returns>
        public static int UpdatePointName(string PointName, string GroupName, string oldPointName)
        {
            try
            {
                string sql = "UPDATE WcfPointName SET PointName = @PointName,GroupName = @GroupName WHERE PointName=@oldPointName";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.Add("PointName", DbType.String).Value = PointName;
                cmd.Parameters.Add("GroupName", DbType.String).Value = GroupName;
                cmd.Parameters.Add("oldPointName", DbType.String).Value = oldPointName;
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
        public static int UpdatePointValue(int PointNameID, Dictionary<int, double> Pos)
        {
            try
            {
                foreach (KeyValuePair<int, double> item in Pos)
                {
                    DataTable dtPointAxis = Select("select ID from WcfPointAxis WHERE PointNameID = " + PointNameID.ToString() +
                        " and AxisID = " + item.Key.ToString());
                    if (dtPointAxis.Rows.Count == 1)
                    {
                        string sql = "UPDATE WcfPointValue SET Pos = @Pos WHERE PointAxisID=@PointAxisID";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.Add("Pos", DbType.Double).Value = item.Value;
                        cmd.Parameters.Add("PointAxisID", DbType.Int32).Value = int.Parse(dtPointAxis.Rows[0][0].ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Clone();
                    }
                    else
                    {
                        WTool.Popup("UpdatePos数据异常，WcfPointAxis查询到数据个数是：" + dtPointAxis.Rows.Count);
                        return -1;
                    }
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
    class PointMain
    {
        private int iD = 0;
        private double numOrder = 0;
        private string groupName;
        private string pointName;
        private Dictionary<string, PointValue> dicPos = new Dictionary<string, PointValue>();//轴名称，值

        public int ID { get => iD; set => iD = value; }
        public double NumOrder { get => numOrder; set => numOrder = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string PointName { get => pointName; set => pointName = value; }
        internal Dictionary<string, PointValue> DicPos { get => dicPos; set => dicPos = value; }
    }
    class PointValue
    {
        private double pos;//位置
        private double speed;//速度
        private double acc;//加速度
        private double dec;//减速度
        private double smooth;//平滑时间

        public double Pos { get => pos; set => pos = value; }
        public double Speed { get => speed; set => speed = value; }
        public double Acc { get => acc; set => acc = value; }
        public double Dec { get => dec; set => dec = value; }
        public double Smooth { get => smooth; set => smooth = value; }
    }
}
