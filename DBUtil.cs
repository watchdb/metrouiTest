using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace MetroUITest
{
    class DBUtil
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("DBUtil");
        protected OracleConnection con;//连接对象
        public DBUtil(string constr)
        {
            con = new OracleConnection(constr);
        }
        public DBUtil(string ds,string user,string password)
        {
            con = new OracleConnection("Data Source=" + ds + ";user=" + user + ";password=" + password + ";");
        }
        #region 打开数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            //打开数据库连接
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    //打开数据库连接
                    con.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        #endregion
        #region 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            //判断连接的状态是否已经打开
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        #endregion

        public OracleConnection getConnection()
        {
            return con;
        }

        #region 执行查询语句，返回OracleDataReader ( 注意：调用该方法后，一定要对OracleDataReader进行Close )
        /// <summary>
        /// 执行查询语句，返回OracleDataReader ( 注意：调用该方法后，一定要对OracleDataReader进行Close )
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>OracleDataReader</returns>  
        public OracleDataReader ExecuteReader(string sql)
        {
            OracleDataReader myReader;
            Open();
            OracleCommand cmd = new OracleCommand(sql, con);
            myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>    
        public void ExecuteSql(string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, con);
            try
            {
                Open();
                cmd.ExecuteNonQuery();
                Close();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                Close();
                throw e;
            }
        }
        #endregion

        #region 执行带参数的SQL语句
        /// <summary>
        /// 执行不带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>    
        public void ExecuteSql(OracleConnection con,string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                log.Error("SQL执行失败" + e.Message);
                log.Error("报错的SQL语句：" + sql);
                throw e;
            }
        }
        #endregion

        #region 执行SQL语句，返回数据到DataSet中
        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>A
        /// <param name="sql">sql语句</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                Open();//打开数据连接
                OracleDataAdapter adapter = new OracleDataAdapter(sql, con);
                adapter.Fill(ds);
            }
            catch//(Exception ex)
            {
            }
            finally
            {
                Close();//关闭数据库连接
            }
            return ds;
        }
        #endregion
        #region 执行SQL语句，返回数据到自定义DataSet中
        /// <summary>
        /// 执行SQL语句，返回数据到DataSet中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="DataSetName">自定义返回的DataSet表名</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql, string DataSetName)
        {
            DataSet ds = new DataSet();
            Open();//打开数据连接
            OracleDataAdapter adapter = new OracleDataAdapter(sql, con);
            adapter.Fill(ds, DataSetName);
            Close();//关闭数据库连接
            return ds;
        }
        #endregion
        #region 执行Sql语句,返回带分页功能的自定义dataset
        /// <summary>
        /// 执行Sql语句,返回带分页功能的自定义dataset
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="CurrPageIndex">当前页</param>
        /// <param name="DataSetName">返回dataset表名</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string sql, int PageSize, int CurrPageIndex, string DataSetName)
        {
            DataSet ds = new DataSet();
            Open();//打开数据连接
            OracleDataAdapter adapter = new OracleDataAdapter(sql, con);
            adapter.Fill(ds, PageSize * (CurrPageIndex - 1), PageSize, DataSetName);
            Close();//关闭数据库连接
            return ds;
        }
        #endregion
        #region 执行SQL语句，返回记录总数
        /// <summary>
        /// 执行SQL语句，返回记录总数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回记录总条数</returns>
        public int GetRecordCount(string sql)
        {
            int recordCount = 0;
            Open();//打开数据连接
            OracleCommand command = new OracleCommand(sql, con);
            OracleDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                recordCount++;
            }
            dataReader.Close();
            Close();//关闭数据库连接
            return recordCount;
        }
        #endregion
        #region 统计某表记录总数
        /// <summary>
        /// 统计某表记录总数
        /// </summary>
        /// <param name="KeyField">主键/索引键</param>
        /// <param name="TableName">数据库.用户名.表名</param>
        /// <param name="Condition">查询条件</param>
        /// <returns>返回记录总数</returns>
        public int GetRecordCount(string keyField, string tableName, string condition)
        {
            int RecordCount = 0;
            string sql = "select count(" + keyField + ") as count from " + tableName + " " + condition;
            DataSet ds = GetDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                RecordCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            ds.Clear();
            ds.Dispose();
            return RecordCount;
        }
        /// <summary>
        /// 统计某表记录总数
        /// </summary>
        /// <param name="Field">可重复的字段</param>
        /// <param name="tableName">数据库.用户名.表名</param>
        /// <param name="condition">查询条件</param>
        /// <param name="flag">字段是否主键</param>
        /// <returns>返回记录总数</returns>
        public int GetRecordCount(string Field, string tableName, string condition, bool flag)
        {
            int RecordCount = 0;
            if (flag)
            {
                RecordCount = GetRecordCount(Field, tableName, condition);
            }
            else
            {
                string sql = "select count(distinct(" + Field + ")) as count from " + tableName + " " + condition;
                DataSet ds = GetDataSet(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    RecordCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
                ds.Clear();
                ds.Dispose();
            }
            return RecordCount;
        }
        #endregion
    }
}
