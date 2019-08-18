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
/// type_2 的摘要说明
/// </summary>
public class type_2
{
    public DataTable getall()
    {
        string sqlstr = "select * from type12";
        return OleDbHelper.executeDataAdapter(sqlstr, CommandType.Text, null);
    }
    public DataRow getrow(string typeid_2)
    {
        string sqlstr = "select * from type_2 where typeid_2="+typeid_2;
        DataTable db = OleDbHelper.executeDataAdapter(sqlstr, CommandType.Text, null);
        return db.Rows[0];
    }
    public int getpro(string typeid_2)
    {
        string sqlstr = "select count(*) from products where typeid_2=" + typeid_2;
        return Convert.ToInt32(OleDbHelper.executeScalar(sqlstr, CommandType.Text, null));
    }

    public int createtype_2(int typeid_1, string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into type_2 (typeid_1,typename) values (@typeid_1,@typename)");
        OleDbParameter[] param = 
                                    {
                                        OleDbHelper.GetParameter("@typeid_1",OleDbType.Integer,4,"typeid_1",typeid_1),
                                        OleDbHelper.GetParameter("@typename",OleDbType.Char,50,"typename",typename)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 删除一个商品二级分类
    /// </summary>
    /// <param name="typeid_2"></param>
    /// <returns></returns>
    public int deletetype_2(int typeid_2)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("delete from type_2 where typeid_2=@typeid_2");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@typeid_2", OleDbType.Integer, 4, "typeid_2", typeid_2) };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 修改一个商品二级分类
    /// </summary>
    /// <param name="typeid_1"></param>
    /// <param name="typename"></param>
    /// <returns></returns>
    public int updatetype_2(int typeid_2, int typeid_1, string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update type_2 set typeid_1=@typeid_1,typename=@typename where typeid_2=@typeid_2");
        OleDbParameter[] param = 
                                   { 
                                        OleDbHelper.GetParameter("@typeid_1",OleDbType.Integer,4,"typeid_1",typeid_1),
                                        OleDbHelper.GetParameter("@typename",OleDbType.Char,50,"typename",typename),
                                       OleDbHelper.GetParameter("@typeid_2",OleDbType.Integer,4,"typeid_2",typeid_2)
                                   };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 查询商品二级分类
    /// </summary>
    /// <param name="typeid_1"></param>
    /// <param name="typename"></param>
    /// <returns></returns>
    public DataTable type_2list(int typeid_1, string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT type_1.typename as type_1name, type_2.typeid_1, type_2.typeid_2, type_2.typename as type_2name ");
        sb.Append("FROM type_1 INNER JOIN type_2 ON type_1.typeid_1 = type_2.typeid_1 where 1 = @index");
        List<OleDbParameter> list = new List<OleDbParameter>();
        list.Add(OleDbHelper.GetParameter("@index", OleDbType.Integer, 1));
        if (typeid_1 != 0)
        {
            list.Add(OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "typeid_1", typeid_1));
            sb.Append(" and type_2.typeid_1=@typeid_1");
        }
        if (typename != "")
        {
            list.Add(OleDbHelper.GetParameter("@typename", OleDbType.Char, 50, "typename", typename));
            sb.Append(" and type_2.typename like '%' + typename + '%'");
        }
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, list.ToArray());
    }

    /// <summary>
    /// 分类是否存在
    /// </summary>
    /// <param name="typename"></param>
    /// <returns></returns>
    public bool IsExite(string typename)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select typename from type_2 where typename=@typename");
        OleDbParameter[] param = 
                                   { OleDbHelper.GetParameter("@typename", OleDbType.Char, 50, "typename", typename) };
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
        sb.Append("select typename from type_2 where typeid_2=@typeid_1");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "typeid_1", typeid) };
        DataTable table = OleDbHelper.executeDataAdapter (sb.ToString(),CommandType.Text, param);
        return table.Rows.Count > 0 ? table.Rows[0]["typename"].ToString() : "";
    }
}
