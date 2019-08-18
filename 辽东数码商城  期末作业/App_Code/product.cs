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
/// product 的摘要说明
/// </summary>
public class product
{
    public int createproduct(string productname, int typeid_1, int typeid_2, bool recommended, bool specials, double price,
            double userprice, double specialsprice, int pointcount, string imagepath, int count, int sellcount, string description)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into products (productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],[sellcount],[description]) values (");
        sb.Append("@productname,@typeid_1,@typeid_2,@recommended,@specials,@price,@userprice,");
        sb.Append("@specialsprice,@pointcount,@imagepath,@count,@sellcount,@description)");
        OleDbParameter[] param = 
                                    {
                                        OleDbHelper.GetParameter("@productname",OleDbType.Char,50,"productname",productname),
                                        OleDbHelper.GetParameter("@typeid_1",OleDbType.Integer,4,"typeid_1",typeid_1),
                                        OleDbHelper.GetParameter("@typeid_2",OleDbType.Integer,4,"typeid_2",typeid_2),
                                        OleDbHelper.GetParameter("@recommended",OleDbType.Boolean,1,"recommended",recommended),
                                        OleDbHelper.GetParameter("@specials",OleDbType.Boolean,1,"specials",specials),
                                        OleDbHelper.GetParameter("@price",OleDbType.Double,8,"price",price),
                                        OleDbHelper.GetParameter("@userprice",OleDbType.Double,8,"userprice",userprice),
                                        OleDbHelper.GetParameter("@specialsprice",OleDbType.Double,8,"specialsprice",specialsprice),
                                        OleDbHelper.GetParameter("@pointcount",OleDbType.Integer,4,"pointcount",pointcount),
                                        OleDbHelper.GetParameter("@imagepath",OleDbType.Char,100,"imagepath",imagepath),
                                        OleDbHelper.GetParameter("@count",OleDbType.Integer,4,"[count]",count),
                                        OleDbHelper.GetParameter("@sellcount",OleDbType.Integer,4,"sellcount",sellcount),
                                        OleDbHelper.GetParameter("@description",OleDbType.Char,description)                                       
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 删除一个商品
    /// </summary>
    /// <param name="productid"></param>
    /// <returns></returns>
    public int deleteproduct(int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("delete from products where productid=@productid");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@productid", OleDbType.Integer, 4, "productid", productid) };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 更新一个商品
    /// </summary>
    /// <param name="productid">商品编号</param>
    /// <param name="productname">商品名称</param>
    /// <param name="typeid_1">商品一级分类</param>
    /// <param name="typeid_2">商品二级分类</param>
    /// <param name="recommended">是否推荐</param>
    /// <param name="specials">是否特价</param>
    /// <param name="price">商品原价</param>
    /// <param name="userprice">会员价格</param>
    /// <param name="specialsprice">推荐价格</param>
    /// <param name="pointcount">点击数量</param>
    /// <param name="imagepath">图片路径</param>
    /// <param name="count">商品库存数量</param>
    /// <param name="count">销售数量</param>
    /// <param name="description">商品描述</param>
    /// <returns></returns>
    public int updateproduct(int productid, string productname, int typeid_1, int typeid_2, bool recommended, bool specials, Double price,
        Double userprice, Double specialsprice, int pointcount, int count, int sellcount, string description)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update products set productname=@productname,typeid_1=@typeid_1,typeid_2=@typeid_2,recommended=@recommended,");
        sb.Append("specials=@specials,price=@price,userprice=@userprice,specialsprice=@specialsprice,pointcount=@pointcount,");
        sb.Append("[count]=@count,sellcount=@sellcount,description=@description where productid=@productid");
        OleDbParameter[] param = 
                                    {
                                        OleDbHelper.GetParameter("@productname",OleDbType.Char,50,"productname",productname),
                                        OleDbHelper.GetParameter("@typeid_1",OleDbType.Integer,4,"typeid_1",typeid_1),
                                        OleDbHelper.GetParameter("@typeid_2",OleDbType.Integer,4,"typeid_2",typeid_2),
                                        OleDbHelper.GetParameter("@recommended",OleDbType.Boolean,1,"recommended",recommended),
                                        OleDbHelper.GetParameter("@specials",OleDbType.Boolean,1,"specials",specials),
                                        OleDbHelper.GetParameter("@price",OleDbType.Double,8,"price",price),
                                        OleDbHelper.GetParameter("@userprice",OleDbType.Double,8,"userprice",userprice),
                                        OleDbHelper.GetParameter("@specialsprice",OleDbType.Double,8,"specialsprice",specialsprice),
                                        OleDbHelper.GetParameter("@pointcount",OleDbType.Integer,4,"pointcount",pointcount),
                                      
                                        OleDbHelper.GetParameter("@count",OleDbType.Integer,4,"[count]",count),
                                        OleDbHelper.GetParameter("@sellcount",OleDbType.Integer,4,"sellcount",sellcount),
                                        OleDbHelper.GetParameter("@description",OleDbType.Char,description),
                                        OleDbHelper.GetParameter("@productid", OleDbType.Integer, 4, "productid", productid)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 根据参数查询商品
    /// </summary>
    /// <param name="typeid_1"></param>
    /// <param name="typeid_2"></param>
    /// <param name="productname"></param>
    /// <returns></returns>
    public DataTable productlist(int typeid_1, int typeid_2, string productname)
    {
        StringBuilder sb = new StringBuilder();
        List<OleDbParameter> list = new List<OleDbParameter>();
        sb.Append("select productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where 1=@index");
        list.Add(OleDbHelper.GetParameter("@index", OleDbType.Integer, 1));
        if (typeid_1 != 0)
        {
            sb.Append(" and typeid_1=@typeid_1 ");
            list.Add(OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "typeid_1", typeid_1));
        }
        if (typeid_2 != 0)
        {
            sb.Append(" and typeid_2=@typeid_2");
            list.Add(OleDbHelper.GetParameter("@typeid_2", OleDbType.Integer, 4, "typeid_2", typeid_2));
        }
        if (productname != "")
        {
            sb.Append(" and productname like '%' + @productname + '%'");
            list.Add(OleDbHelper.GetParameter("@productname", OleDbType.Char, 50, "productname", productname));
        }

        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, list.ToArray());
    }

    public DataTable selectproduct(int typeid_1, int typeid_2, string productname, int recommended, int specials)
    {
        StringBuilder sb = new StringBuilder();
        List<OleDbParameter> list = new List<OleDbParameter>();
        sb.Append("SELECT products.*, type_2.typename AS typename_2, type_1.typename AS typename_1 ");
        sb.Append("FROM products, type_2, type_1 ");
        sb.Append("WHERE products.typeid_2=type_2.typeid_2 and type_2.typeid_1=type_1.typeid_1");
        if (typeid_1 != 0)
        {
            sb.Append(" and type_2.typeid_1=@typeid_1 ");
            list.Add(OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "type_2.typeid_1", typeid_1));
        }
        if (typeid_2 != 0)
        {
            sb.Append(" and type_2.typeid_2=@typeid_2");
            list.Add(OleDbHelper.GetParameter("@typeid_2", OleDbType.Integer, 4, "type_2.typeid_2", typeid_2));
        }
        if (productname != "")
        {
            sb.Append(" and products.productname like '%' + @productname + '%'");
            list.Add(OleDbHelper.GetParameter("@productname", OleDbType.Char, 50, "products.productname", productname));
        }
        if (recommended == 1)
        {
            sb.Append(" and products.recommended=@recommended");
            list.Add(OleDbHelper.GetParameter("@recommended", OleDbType.Boolean, 1, "products.recommended", true));
        }
        if (recommended == 0)
        {
            sb.Append(" and products.recommended=@recommended");
            list.Add(OleDbHelper.GetParameter("@recommended", OleDbType.Boolean, 1, "products.recommended", false));
        }
        if (specials == 1)
        {
            sb.Append(" and products.specials=@specials");
            list.Add(OleDbHelper.GetParameter("@specials", OleDbType.Boolean, 1, "products.specials", true));
        }
        if (specials == 0)
        {
            sb.Append(" and products.specials=@specials");
            list.Add(OleDbHelper.GetParameter("@specials", OleDbType.Boolean, 1, "products.specials", false));
        }

        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, list.ToArray());
    }

    /// <summary>
    ///获得一条商品纪录 
    /// </summary>
    /// <param name="productid"></param>
    /// <returns></returns>
    public DataRow getoneproduct(int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products ");
        sb.Append("where productid=@productid");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@productid", OleDbType.Integer, 4, "productid", productid) };
        DataTable table = OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param);
        return table.Rows[0];
    }

    /// <summary>
    /// 获得若干数量的新商品
    /// </summary>
    /// <returns></returns>
    public DataTable getnewproductlist(int num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select top " + num + " productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text,null);
    }
    public DataTable getnewproductlist()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select  productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }
    /// <summary>
    /// 获得若干数量的特价商品
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public DataTable getspecialproductlist(int num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select top " + num + " productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where specials=true order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text,null);
    }
    public DataTable getspecialproductlist()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select  productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where specials=true order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }
    /// <summary>
    /// 获得若干数量的推荐商品
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public DataTable getrecommendedproductlist(int num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select top " + num + " productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where recommended=true order by productid desc");
        return OleDbHelper.executeDataAdapter (sb.ToString(),CommandType.Text,null);
    }
    public DataTable getrecommendedproductlist()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select  productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where recommended=true order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }

    /// <summary>
    /// 获得若干数量的热卖商品
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public DataTable gethotsellproductlist( int num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select top " + num + " productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products order by sellcount desc,productid desc");
        return OleDbHelper.executeDataAdapter (sb.ToString(),CommandType.Text,null);
    }

    /// <summary>
    /// 获得若干数量的热门商品
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public DataTable getpointproductlist( int num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select top " + num + " productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products order by pointcount desc,productid desc");
        return OleDbHelper.executeDataAdapter (sb.ToString(),CommandType.Text,null);
    }

    /// <summary>
    ///更新商品的浏览数量 
    /// </summary>
    /// <param name="productid"></param>
    public void updatepointnum(int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update products set pointcount=pointcount+1 where productid=@productid");
        OleDbParameter[] param = { OleDbHelper.GetParameter("@productid", OleDbType.Integer, 4, "productid", productid) };
        OleDbHelper.executeNonQuery (sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 获得新商品
    /// </summary>
    /// <returns></returns>
    public DataTable getnewproduct()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text,null);
    }

    /// <summary>
    /// 获得特价商品
    /// </summary>
    /// <returns></returns>
    public DataTable getspecialproduct()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where specials=true order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }

    /// <summary>
    /// 获得推荐商品
    /// </summary>
    /// <returns></returns>
    public DataTable getrecommendedproduct()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select productid,productname,typeid_1,typeid_2,recommended,specials,price,");
        sb.Append("userprice,specialsprice,pointcount,imagepath,[count],sellcount,description from products where recommended=true order by productid desc");
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }

    /// <summary>
    /// 更新图片路径
    /// </summary>
    /// <param name="path"></param>
    public int updatepic(string imagepath, int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update products set imagepath=@imagepath where productid=@productid");
        OleDbParameter[] param = 
                                    {
                                        OleDbHelper.GetParameter("@imagepath",OleDbType.Char,100,"imagepath",imagepath),
                                        OleDbHelper.GetParameter("@productid", OleDbType.Integer, 4, "productid", productid)
                                    };
        return OleDbHelper.executeNonQuery (sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 查询商品
    /// </summary>
    /// <param name="type_1"></param>
    /// <param name="type_2"></param>
    /// <param name="productname"></param>
    /// <param name="price_1"></param>
    /// <param name="price_2"></param>
    /// <returns></returns>
    public DataTable searchproductlist(int type_1, int type_2, string productname, string price_1, string price_2)
    {
        StringBuilder sb = new StringBuilder();
        List<OleDbParameter> list = new List<OleDbParameter>();
        sb.Append("SELECT products.*, type_2.typename AS typename_2, type_1.typename AS typename_1 ");
        sb.Append("FROM products, type_2, type_1 ");
        sb.Append("WHERE products.typeid_2=type_2.typeid_2 and type_2.typeid_1=type_1.typeid_1");
        if (type_1 != 0)
        {
            sb.Append(" and type_2.typeid_1=@typeid_1 ");
            list.Add(OleDbHelper.GetParameter("@typeid_1", OleDbType.Integer, 4, "type_2.typeid_1", type_1));
        }
        if (type_2 != 0)
        {
            sb.Append(" and type_2.typeid_2=@typeid_2");
            list.Add(OleDbHelper.GetParameter("@typeid_2", OleDbType.Integer, 4, "type_2.typeid_2", type_2));
        }
        if (productname != "")
        {
            sb.Append(" and products.productname like '%' + @productname + '%'");
            list.Add(OleDbHelper.GetParameter("@productname", OleDbType.Char, 50, "products.productname", productname));
        }
        if (price_1 != "" && price_2 != "")
        {
            sb.Append(" and products.price between @price_1 and @price_2");
            list.Add(OleDbHelper.GetParameter("@price_1", OleDbType.Double, 8, "products.price", double.Parse(price_1)));
            list.Add(OleDbHelper.GetParameter("@price_2", OleDbType.Double, 8, "products.price", double.Parse(price_2)));
        }

        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, list.ToArray());
    }
}
