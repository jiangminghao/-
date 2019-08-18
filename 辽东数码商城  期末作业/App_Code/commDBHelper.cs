using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;

/// <summary>
///DbHelper 的摘要说明
/// </summary>
public class commDBHelper
{
    private static string connStr =WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();

	public commDBHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
     /// 用于执行普通查询，并以DataReader方式返回所查询的结果集
    /// </summary>
    /// <param name="cmdText">查询的SQL语句或存储过程名称</param>
    /// <param name="cmdType">Command的操作类型</param>
    /// <param name="cmdParameters">操作所使用到的参数集合</param>
    public static OleDbDataReader ExecuteDataReader(string cmdText, CommandType cmdType, List<OleDbParameter> cmdParameters)
    {
        //创建连接对象
        OleDbConnection conn = new OleDbConnection();
        //设置连接字符串
        conn.ConnectionString = connStr;
        //打开连接
        conn.Open();
        //创建命令对象
        OleDbCommand comm = new OleDbCommand();
        //设置命令对象的数据源连接对象，
        //进行的操作（Sql语句，表明，存储过程）
        //以及操作的类型
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        //添加操作所用的参数
        if (cmdParameters != null)
        {
            foreach (OleDbParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        OleDbDataReader dr = comm.ExecuteReader();
        //返回结果集
        return dr;
    }
    /// <summary>
     
     
    /// 用于执行普通查询，并以DataTable离线的方式返回所查询的结果集
    /// </summary>
    /// <param name="cmdText">查询的SQL语句或存储过程名称</param>
    /// <param name="cmdType">Command的操作类型</param>
    /// <param name="cmdParameters">操作所使用到的参数集合</param>
    /// <returns></returns>
    public static DataTable ExecuteReader(string cmdText, CommandType cmdType, List<OleDbParameter> cmdParameters)
    {
        //创建连接对象
        OleDbConnection conn = new OleDbConnection();
        //设置连接字符串
        conn.ConnectionString = connStr;
        //打开连接
        conn.Open();
        //创建命令对象
        OleDbCommand comm = new OleDbCommand();
        //设置命令对象的数据源连接对象，
        //进行的操作（Sql语句，表明，存储过程）
        //以及操作的类型
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        //添加操作所用的参数
        if (cmdParameters != null)
        {
            foreach (OleDbParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //创建离线内存表
        DataTable dataTable = new DataTable();
        //创建Adapter对象，并利用查询命令的返回结果填充离线内存表
        OleDbDataAdapter ad = new OleDbDataAdapter();
        ad.SelectCommand = comm;
        ad.Fill(dataTable);
        //释放相关资源
        comm.Parameters.Clear();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
        //返回结果集
        return dataTable;
    }
    /// <summary>
    /// 用于执行按照主键进行的查询，并以DataRow离线的方式返回所查询的单条记录
    /// 主要用于根据主键获取单条记录和判断对应的主键是否已经被占用等。
    /// </summary>
    /// <param name="cmdText"></param>
    /// <param name="cmdType"></param>
    /// <param name="isExist">用于判断是否有结果</param>
    /// <param name="cmdParameters"></param>
    /// <returns></returns>
   
    /// <summary>
    /// 用于执行要求单条编辑操作
    /// </summary>
    /// <param name="cmdText"></param>
    /// <param name="cmdType"></param>
    /// <param name="cmdParameters"></param>
    /// <returns></returns>
    public static Boolean ExecuteNonQuery(string cmdText, CommandType cmdType, List<OleDbParameter> cmdParameters)
    {
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = connStr;
        conn.Open();
        OleDbCommand comm = new OleDbCommand();
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        if (cmdParameters != null)
        {
            foreach (OleDbParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //执行数据编辑操作
        try
        {
          int i=comm.ExecuteNonQuery();
          if (i > 0)
              return true;
          else
              return false;
         
        }
        catch 
        {
            
           return false;
        }
        finally
        {
            comm.Parameters.Clear();
            comm.Dispose();
            conn.Close();
            conn.Dispose();
        }
        
    }
   /// 用于执行获得单个值查询操作
    /// <param name="cmdText">操作语句</param>
    /// <param name="cmdType">操作类型</param>
    /// <param name="cmdParameters">操作参数</param>
    /// <returns></returns>
    public static object ExecuteScalar(string cmdText, CommandType cmdType, List<OleDbParameter> cmdParameters)
    {
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = connStr;
        conn.Open();
        OleDbCommand comm = new OleDbCommand();
        comm.Connection = conn;
        comm.CommandText = cmdText;
        comm.CommandType = cmdType;
        if (cmdParameters != null)
        {
            foreach (OleDbParameter para in cmdParameters)
                comm.Parameters.Add(para);
        }
        //执行ExecuteScalar方法
        object val = comm.ExecuteScalar();
        comm.Dispose();
        conn.Close();
        conn.Dispose();
        return val;
    }
    /// <summary>
    /// 创建参数对象
    /// </summary>
    /// <param name="paraName">参数名称</param>
    /// <param name="paraType">参数类型</param>
    /// <param name="paraValue">参数的值</param>
    /// <returns></returns>
    /// 


    public static OleDbParameter CreateParameters(string paraName, OleDbType paraType, object paraValue)
    {
        OleDbParameter para = new OleDbParameter();
        para.ParameterName = paraName;
        para.OleDbType = paraType;
        para.Value = paraValue;
        return para;
    }

}
