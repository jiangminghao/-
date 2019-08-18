using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// tjclass 的摘要说明
/// </summary>
public class tjclass
{
	public string tjtype1()
    {
        string sqlstr = "select count(*) from type_1";
        return OleDbHelper.executeScalar(sqlstr, CommandType.Text, null);
    }
    public string tjtype2()
    {
        string sqlstr = "select count(*) from type_2";
        return OleDbHelper.executeScalar(sqlstr, CommandType.Text, null);
    }
    public string tjproduct()
    {
        string sqlstr = "select count(*) from products";
        return OleDbHelper.executeScalar(sqlstr, CommandType.Text, null);
    }
    public string tjuser()
    {
        string sqlstr = "select count(*) from userinfo where power=1";
        return OleDbHelper.executeScalar(sqlstr, CommandType.Text, null);
    }
    public string tjorder()
    {
        string sqlstr = "select count(*) from orders where state=4";
        return OleDbHelper.executeScalar(sqlstr, CommandType.Text, null);
    }
    public string tjsellcount()
    {
        string sqlstr = "select sum(ordercount) from orders ";
        return OleDbHelper.executeScalar(sqlstr, CommandType.Text, null);
    }
}