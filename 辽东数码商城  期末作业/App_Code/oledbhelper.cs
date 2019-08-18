using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections.Generic;
/// <summary>
/// OleDbHelper 的摘要说明
/// </summary>
public class OleDbHelper
{
    private static readonly string OleDbcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    //建立连接方法
    public OleDbConnection createCon()
    {
        OleDbConnection con = new OleDbConnection(OleDbcon);
        if (con.State != ConnectionState.Open)
            con.Open();
        return con;
    }
    public static OleDbParameter GetParameter(String paramName, OleDbType paramType, Int32 paramSize, String ColName, Object paramValue)
    {
        OleDbParameter param = new OleDbParameter(paramName, paramType, paramSize, ColName);
        param.Value = paramValue;
        return param;
    }

    /// <summary>
    /// 获得参数对象
    /// </summary>
    /// <param name="paramName">参数名称</param>
    /// <param name="paramType">数据类型</param>
    /// <param name="paramSize">长度</param>
    /// <param name="ColName">源列名称</param>
    /// <returns></returns>
    public static OleDbParameter GetParameter(String paramName, OleDbType paramType, Int32 paramSize, String ColName)
    {
        OleDbParameter param = new OleDbParameter(paramName, paramType, paramSize, ColName);
        return param;
    }

    /// <summary>
    /// 获得参数对象
    /// </summary>
    /// <param name="paramName">参数名称</param>
    /// <param name="paramType">数据类型</param>
    /// <param name="paramSize">长度</param>
    /// <param name="ColName">源列名称</param>
    /// <returns></returns>
    public static OleDbParameter GetParameter(String paramName, OleDbType paramType, Object paramValue)
    {
        OleDbParameter param = new OleDbParameter(paramName, paramType);
        param.Value = paramValue;
        return param;
    }

    //准备command命令
    public static void prepareCommand(OleDbConnection con, OleDbCommand cmd, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] para)
    {
        //如果数据库连接没有打开  则打开连接
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
        cmd.Connection = con;
        cmd.CommandText = cmdText;
        if (trans != null)//如果trans存在的话 执行以下命令
        {
            cmd.Transaction = trans;
        }
        cmd.CommandText = cmdText;
        if (para != null)//如果para不为空 遍历一遍para
        {
            foreach (OleDbParameter pa in para)
            {
                cmd.Parameters.Add(pa);
            }
        }
    }

    //从数据库中读取数据源 返回一个OleDbDataReader对象
    public static OleDbDataReader executeReader(string cmdText, CommandType cmdType, OleDbParameter[] para)
    {
        //定义连接
        OleDbConnection con = new OleDbConnection(OleDbcon);
        //捕获可能发生的异常
        try
        {
            OleDbCommand cmd = new OleDbCommand();
            prepareCommand(con, cmd, null, cmdType, cmdText, para);

            OleDbDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return sdr;
        }
        catch (Exception)
        {
            throw;
        }
    }

    //更新数据库方法（增加，删除）
    public static int executeNonQuery(string cmdText, CommandType cmdType, OleDbParameter[] para)
    {
        using (OleDbConnection con = new OleDbConnection(OleDbcon))
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                prepareCommand(con, cmd, null, cmdType, cmdText, para);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public static int executeNonQuery(String[] Sqlstr, List<OleDbParameter[]> param)
    {
        using (OleDbConnection conn = new OleDbConnection(OleDbcon))
        {

            OleDbCommand cmd = new OleDbCommand();
            OleDbTransaction tran = null;
            
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                Int32 count = Sqlstr.Length;
                for (Int32 i = 0; i < count; i++)
                {
                    cmd.CommandText = Sqlstr[i];
                    cmd.Parameters.Clear();
                   cmd.Parameters.AddRange(param[i]);
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return 1;
            }
            catch(Exception e)
            {
                tran.Rollback();
                
                return 0;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
    }

    //取得数据库中一行的值
    public static string executeScalar(string cmdText, CommandType cmdType, OleDbParameter[] para)
    {
        using (OleDbConnection con = new OleDbConnection(OleDbcon))
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                prepareCommand(con, cmd, null, cmdType, cmdText, para);
                string result = Convert.ToString(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    //DataSet
    public static DataTable  executeDataAdapter(string cmdText, CommandType cmdType, OleDbParameter[] para)
    {
        using (OleDbConnection con = new OleDbConnection(OleDbcon))
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                prepareCommand(con, cmd, null, cmdType, cmdText, para);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Parameters.Clear();
                return ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public static string FunStr(string str)
    {
        str = str.Replace("&", "&amp;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt");
        str = str.Replace("'", "''");
        str = str.Replace("*", "");
        str = str.Replace("\n", "<br/>");
        str = str.Replace("\r\n", "<br/>");
        //str   =   str.Replace("?","");   
        str = str.Replace("select", "");
        str = str.Replace("insert", "");
        str = str.Replace("update", "");
        str = str.Replace("delete", "");
        str = str.Replace("create", "");
        str = str.Replace("drop", "");
        str = str.Replace("delcare", "");
        str = str.Replace("   ", "&nbsp;");

        str = str.Trim();
        if (str.Trim().ToString() == "")
            str = "无";
        return str;
    } 
}
