using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// type_1 的摘要说明
/// </summary>
public class type_1
{
   public DataTable getall()
    {
        string sqlstr = "select * from type_1";
        return OleDbHelper.executeDataAdapter(sqlstr, CommandType.Text, null);
    }
 public int createtype_1(string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into type_1 (typename) values (@typename)");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@typename", OleDbType.Char, 50, "typename", typename) };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 删除一级分类
    /// </summary>
    /// <param name="type_1">一级分类编号</param>
    /// <returns></returns>
    public int deletetype_1(int typeid_1)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("delete from type_1 where typeid_1=@typeid_1");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "typeid_1", typeid_1) };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 更新一级分类
    /// </summary>
    /// <param name="type_1">一级分类编号</param>
    /// <param name="typename">一级分类名称</param>
    /// <returns></returns>
    public int updatetype_1(int typeid_1, string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update type_1 set typename=@typename where typeid_1=@typeid_1");
        OleDbParameter[] param = 
                                   { 
                                       OleDbHelper.GetParameter("@typename", OleDbType.Char, 50, "typename", typename),
                                       OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "typeid_1", typeid_1)
                                     
                                   };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 根据类型名称查询商品一级分类
    /// </summary>
    /// <param name="typename"></param>
    /// <returns></returns>
    public DataTable type_1list(string typename)
    {
        List<OleDbParameter> list = new List<OleDbParameter>();
        StringBuilder sb = new StringBuilder();
        sb.Append("select typeid_1,typename from type_1 where 1 = @index");

        list.Add(OleDbHelper.GetParameter("@index", OleDbType.Integer, 1));
        if (typename != "")
        {
            sb.Append(" and typename like '%' + @typename + '%'");
            list.Add(OleDbHelper.GetParameter("@typename", OleDbType.Char, 50, "typename", typename));
        }

        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, list.ToArray());
    }

    /// <summary>
    /// 是否已经存在该分类
    /// </summary>
    /// <param name="typename"></param>
    /// <returns></returns>
    public bool IsExite(string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select typename from type_1 where typename=@typename");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@typename", OleDbType.Char, 50, "typename", typename) };
        DataTable table = OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param);
        return table.Rows.Count > 0 ? true : false;
    }

    /// <summary>
    /// 根据类型ID获得类型名称
    /// </summary>
    /// <param name="typeid"></param>
    /// <returns></returns>
    public string gettypename(int typeid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select typename from type_1 where typeid_1=@typeid_1");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "typeid_1", typeid) };
        DataTable table = OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param);
        return table.Rows.Count > 0 ? table.Rows[0]["typename"].ToString() : " ";
    }
 
}
