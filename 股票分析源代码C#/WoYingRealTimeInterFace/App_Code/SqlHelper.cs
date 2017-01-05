using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
/// SqlHelper类是专门提供给广大用户用于高性能、可升级和最佳练习的sql数据操作
/// </summary>
public abstract class SqlHelper
{
    /// <summary>
    /// 数据库连接字符串(钱龙)
    /// </summary>
    public static string SqlConnStringZX = "server=(local);database=iwinddatabase;uid=sa;pwd=1;";



    /// <summary>
    /// 输出逻辑报文的路径
    /// </summary>
    public static string MessageFilePath = AppDomain.CurrentDomain.BaseDirectory;
    // 用于缓存参数的HASH表
    // public static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
    /// <summary>
    /// 返回一个数据表(Fill)1
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">类型</param>
    /// <param name="cmdText">命令</param>
    /// <param name="TableName">DataTable表名</param>
    /// <returns>DataTable</returns>
    public static DataTable SelectTable(string connectionString, CommandType cmdType, string cmdText, string TableName)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dpt = new SqlDataAdapter();
        using (SqlConnection Conn = new SqlConnection(connectionString))
        {
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            dpt.SelectCommand = cmd;
            DataSet DsResoult = new DataSet();
            dpt.Fill(DsResoult, TableName);
            dpt.Dispose();
            Conn.Close();
            return DsResoult.Tables[TableName];
        }
    }
    /// <summary>
    /// 返回一个数据表(Fill)2
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">类型</param>
    /// <param name="cmdText">命令</param>
    /// <returns>DataTable</returns>
    public static DataTable SelectTable(string connectionString, CommandType cmdType, string cmdText)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dpt = new SqlDataAdapter();
        using (SqlConnection Conn = new SqlConnection(connectionString))
        {
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            dpt.SelectCommand = cmd;
            cmd.Connection = Conn;
            DataSet DsResoult = new DataSet();
            dpt.Fill(DsResoult, "TempTable");
            dpt.Dispose();
            Conn.Close();
            return DsResoult.Tables["TempTable"];
        }
    }
    /// <summary>
    /// 返回一个数据表(Fill)3
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">类型</param>
    /// <param name="cmdText">命令</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>DataTable</returns>
    public static DataTable SelectTable(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dpt = new SqlDataAdapter();
        using (SqlConnection Conn = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, Conn, null, cmdType, cmdText, commandParameters);
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            dpt.SelectCommand = cmd;
            DataSet DsResoult = new DataSet();
            dpt.Fill(DsResoult, "TableName");
            cmd.Parameters.Clear();
            dpt.Dispose();
            Conn.Close();
            return DsResoult.Tables["TableName"];
        }
    }
    /// <summary>
    /// 返回一个数据表(Fill)4
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">类型</param>
    /// <param name="cmdText">命令</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>DataTable</returns>
    public static DataTable SelectTable(string connectionString, CommandType cmdType, string cmdText, string TableName, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dpt = new SqlDataAdapter();
        using (SqlConnection Conn = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, Conn, null, cmdType, cmdText, commandParameters);
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            dpt.SelectCommand = cmd;
            DataSet DsResoult = new DataSet();
            dpt.Fill(DsResoult, TableName);
            cmd.Parameters.Clear();
            dpt.Dispose();
            Conn.Close();
            return DsResoult.Tables[TableName];
        }
    }
    /// <summary>
    /// 返回一个数据表(Fill)4
    /// </summary>
    /// <param name="connectionString">连接字符串</param>
    /// <param name="cmdType">类型</param>
    /// <param name="cmdText">命令</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>DataTable</returns>
    public static DataSet SelectSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter dpt = new SqlDataAdapter();
        using (SqlConnection Conn = new SqlConnection(connectionString))
        {


            PrepareCommand(cmd, Conn, null, cmdType, cmdText, commandParameters);
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            dpt.SelectCommand = cmd;
            DataSet DsResoult = new DataSet();
            dpt.Fill(DsResoult, "TableName");
            cmd.Parameters.Clear();
            dpt.Dispose();
            Conn.Close();
            return DsResoult;
        }
    }
    /// <summary>
    ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
    /// </summary>
    /// <param name="connectionString">一个有效的连接字符串</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>执行命令所影响的行数</returns>
    public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 用现有的数据库连接执行一个sql命令（不返回数据集）
    /// </summary>
    /// <param name="conn">一个现有的数据库连接</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>执行命令所影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    ///使用现有的SQL事务执行一个sql命令（不返回数据集）
    /// </summary>
    /// <remarks>
    ///举例:  
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="trans">一个现有的事务</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>执行命令所影响的行数</returns>
    public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 用执行的数据库连接执行一个返回数据集的sql命令
    /// </summary>
    /// <remarks>
    /// 举例:  
    ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的连接字符串</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>包含结果的读取器</returns>
    public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        //创建一个SqlCommand对象
        SqlCommand cmd = new SqlCommand();
        //创建一个SqlConnection对象
        SqlConnection conn = new SqlConnection(connectionString);

        //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
        //因此commandBehaviour.CloseConnection 就不会执行
        try
        {
            //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            //调用 SqlCommand  的 ExecuteReader 方法
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //清除参数
            cmd.Parameters.Clear();
            return reader;
        }
        catch
        {
            //关闭连接，抛出异常
            conn.Close();
            throw;
        }
    }
    /// <summary>
    /// 用执行的数据库连接执行一个返回数据集的sql命令
    /// </summary>
    /// <remarks>
    /// 举例:  
    ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="conn">一个有效的连接</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>包含结果的读取器</returns>
    public static SqlDataReader ExecuteReader(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        //创建一个SqlCommand对象
        SqlCommand cmd = new SqlCommand();
        //创建一个SqlConnection对象


        //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
        //因此commandBehaviour.CloseConnection 就不会执行
        try
        {
            //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            //调用 SqlCommand  的 ExecuteReader 方法
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //清除参数
            cmd.Parameters.Clear();
            return reader;
        }
        catch
        {
            //关闭连接，抛出异常
            conn.Close();
            throw;
        }


    }
    /// <summary>
    /// 用执行的数据库连接执行一个返回数据集的sql命令
    /// </summary>
    /// <remarks>
    /// 举例:  
    ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的连接字符串</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>包含结果的读取器</returns>
    public static SqlDataReader ExecuteReader(SqlTransaction Tran, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        //创建一个SqlCommand对象
        SqlCommand cmd = new SqlCommand();
        //创建一个SqlConnection对象
        SqlConnection conn = Tran.Connection;

        //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
        //因此commandBehaviour.CloseConnection 就不会执行
        try
        {
            //调用 PrepareCommand 方法，对 SqlCommand 对象设置参数
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            //调用 SqlCommand  的 ExecuteReader 方法
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //清除参数
            cmd.Parameters.Clear();
            return reader;
        }
        catch
        {
            //关闭连接，抛出异常
            conn.Close();
            throw;
        }
    }
    /// <summary>
    /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
    /// </summary>
    /// <remarks>
    ///例如:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    ///<param name="connectionString">一个有效的连接字符串</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
    public static object ExecuteScalar(SqlTransaction Tran, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection connection = Tran.Connection)
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }
    /// <summary>
    /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
    /// </summary>
    /// <remarks>
    ///例如:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    ///<param name="connectionString">一个有效的连接字符串</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
    public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
    /// </summary>
    /// <remarks>
    /// 例如:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="conn">一个存在的数据库连接</param>
    /// <param name="commandType">命令类型(存储过程, 文本, 等等)</param>
    /// <param name="commandText">存储过程名称或者sql命令语句</param>
    /// <param name="commandParameters">执行命令所用参数的集合</param>
    /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
    public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }


    /// <summary>
    /// 准备执行一个命令
    /// </summary>
    /// <param name="cmd">sql命令</param>
    /// <param name="conn">Sql连接</param>
    /// <param name="trans">Sql事务</param>
    /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
    /// <param name="cmdText">命令文本,例如：Select * from Products</param>
    /// <param name="cmdParms">执行命令的参数</param>
    public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {

        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;

        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }
}