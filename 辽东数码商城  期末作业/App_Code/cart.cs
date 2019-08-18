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
/// cart 的摘要说明
/// </summary>
public class cart
{
    public String GetShoppingCartId()
    {
       
        HttpContext context = System.Web.HttpContext.Current;

        if (context.User.Identity.Name != "")
        {
            return context.User.Identity.Name;
        }
        else
        {
            if (context.Request.Cookies["eshop_CartId"] != null)
            {
                return context.Request.Cookies["eshop_CartId"].Value;
            }
            else
            {
                Guid tempCartId = Guid.NewGuid();

                context.Response.Cookies["eshop_CartId"].Value = tempCartId.ToString();

                return tempCartId.ToString();
            }
        }


    } 
    public int addtocart(int productid, int userid, int count, bool checkout)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into cart (cartid,productid,[userid],[count],checkout) ");
        sb.Append("values (@cartid,@productid,@userid,@count,@checkout)");
        OleDbParameter[] param =
                                   {new OleDbParameter ("@cartid",GetShoppingCartId()),
                                       new OleDbParameter ("@productid",productid),
                                       new OleDbParameter("@userid",userid),
                                       new OleDbParameter("@count",count),
                                       new OleDbParameter("@checkout",checkout)
                                   };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 删除一件商品
    /// </summary>
    /// <param name="cartid"></param>
    /// <returns></returns>
    public int deletecart(string cartid )
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("delete from cart where cartid=@cartid");
        OleDbParameter[] param = { new OleDbParameter("@cartid", cartid) };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }
    public int deletecartbyproductid(int  productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("delete from cart where cartid=@cartid and productid=@productid");
        OleDbParameter[] param = { new OleDbParameter("@cartid", this.GetShoppingCartId()),
            new OleDbParameter("@productid",productid)   };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }
    /// <summary>
    /// 批量删除商品
    /// </summary>
    /// <param name="cartids"></param>
    /// <returns></returns>
    public int deltecartlist(int[] ids)
    {

        List<OleDbParameter[]> paramlist = new List<OleDbParameter[]>();
        List<string> sqls = new List<string>();
        for (int i = 0; i < ids.Length; i++)
        {
            sqls.Add("delete from cart where id=@id" + i.ToString());
            OleDbParameter[] param = { new OleDbParameter ("@id" + i.ToString(), ids[i]) };
            paramlist.Add(param);
        }
        return OleDbHelper.executeNonQuery(sqls.ToArray(), paramlist);
    }

    /// <summary>
    /// 获得购物列表
    /// </summary>
    /// <returns></returns>
    public DataTable selectcartlist()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT cart.id,cart.cartid, cart.[count], cart.checkout,cart.[userid], ");
        sb.Append("cart.productid, products.productname, products.recommended, products.specials, products.price, ");
        sb.Append("products.userprice, products.specialsprice ");
        sb.Append("FROM cart INNER JOIN products ON cart.productid = products.productid where cart.checkout=false");
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text,null);
    }

    /// <summary>
    /// 获得某个用户的购物列表
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public DataTable getcartlist(string cartid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT cart.id,cart.cartid, cart.[count], cart.checkout, cart.productid, cart.[userid],");
        sb.Append("products.productname, products.recommended, products.specials, products.price,");
        sb.Append("products.userprice, products.specialsprice ");
        sb.Append("FROM cart INNER JOIN products ON cart.productid=products.productid ");
        sb.Append("WHERE cart.checkout=false and cart.[cartid]=@cartid");
        OleDbParameter[] param = { new OleDbParameter("@cartid", cartid) };
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 修改购物列表的购买数量
    /// </summary>
    /// <param name="cartids"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public int updatecartlist(int[] ids, int[] count)
    {
        List<OleDbParameter[]> paramlist = new List<OleDbParameter[]>();
        List<string> sqls = new List<string>();
        for (int i = 0; i < ids.Length; i++)
        {
            sqls.Add("update cart set [count]=@count " + i.ToString() + "where id=@id" + i.ToString());
            OleDbParameter[] param = 
                                        {
                                            new OleDbParameter("@count" + i.ToString(),count[i]),
                                            new OleDbParameter("@id" + i.ToString(),ids[i])
                                        };
            paramlist.Add(param);
        }

        return OleDbHelper.executeNonQuery(sqls.ToArray(), paramlist);
    }

    public int updatecartbyid(int productid, int count)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update cart set [count]=@count where productid=@productid and cartid=@cartid");
        OleDbParameter[] param = 
                                    {
                                       new OleDbParameter("@count",count),
                                       new OleDbParameter("@productid",productid),
                                        new OleDbParameter("@cartid",this.GetShoppingCartId())
                                       
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }
    public int updatecartstate()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update cart set checkout=true where  cartid=@cartid");
        OleDbParameter[] param =  {
            new OleDbParameter("@cartid",this.GetShoppingCartId())
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }
    public int updatecartbyid(int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update cart set [count]=[count]+1 where productid=@productid and cartid=@cartid");
        OleDbParameter[] param = 
                                    {
                                       new OleDbParameter("@productid",productid),
                                        new OleDbParameter("@cartid",this.GetShoppingCartId())
                                       
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }
    public int migratecart(string oldcartid, string newcartid)
    {
        int userid = int.Parse(newcartid);
        StringBuilder sb = new StringBuilder();
        sb.Append("update cart set [cartid]=@newcartid,userid=@userid where cartid=@oldcartid");
        OleDbParameter[] param = 
                                    {
                                       new OleDbParameter("@newcartid",newcartid),
                                       new OleDbParameter("@userid",userid),
                                       new OleDbParameter("@oldcartid",oldcartid)
                                       
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(), CommandType.Text, param);
    }

    /// <summary>
    /// 商品是否存在购物车里
    /// </summary>
    /// <param name="productid"></param>
    /// <returns></returns>
    public bool isexitproduct(int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select productid from cart where checkout=false and productid=@productid and [cartid]=@cartid");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@productid",productid),
                                        new OleDbParameter("@cartid",this.GetShoppingCartId())
                                    };
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param).Rows.Count > 0 ? true : false;
    }

    /// <summary>
    /// 根据某一购物商品的数量
    /// </summary>
    /// <param name="cartid"></param>
    /// <returns></returns>
    public int updatecartbyproductid(int productid, string  cartid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update cart set [count]=[count]+1 where productid=@productid and [cartid]=@cartid");
        OleDbParameter[] param = 
                                    {
                                       new OleDbParameter("@productid",productid),
                                       new OleDbParameter("@cartid",cartid)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 修改商品的购物状态
    /// </summary>
    /// <param name="cartid"></param>
    /// <returns></returns>
    public int updatestate(string cartid, bool checkout)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update cart set checkout=@checkout where [cartid]=@cartid");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@checkout",checkout),
                                        new OleDbParameter("@cartid",cartid)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 购物成功后商品数量减
    /// </summary>
    /// <param name="productid"></param>
    public void updateproduct(int productid, int num)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update products set [count]=[count]-" + num + ",sellcount=sellcount +" + num + " where productid=@productid");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@productid",productid),
                                        //OleDbHelper.GetParameter("@num",OleDbType.Integer,num)
                                    };
        OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 获得一条购物纪录
    /// </summary>
    /// <param name="productid"></param>
    /// <returns></returns>
    public DataRow getonecartbyproductid(int productid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT cart.count ,products.productname, products.recommended, products.specials, products.price, products.userprice, products.specialsprice");
        sb.Append(" FROM cart INNER JOIN products ON cart.productid = products.productid");
        sb.Append(" WHERE products.productid=@productid");
        OleDbParameter[] param = 
                                    {
                                       new OleDbParameter("@productid",productid)
                                    };
        return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param).Rows[0];
    }

    /// <summary>
    /// 根据商品ID获得一条购物纪录的数量
    /// </summary>
    /// <param name="productid"></param>
    /// <returns></returns>
    public int getcartnum(string cartid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select [count] from cart where cartid=@cartid");
        OleDbParameter[] param = 
                                    {
                                        new OleDbParameter("@cartid",cartid)
                                    };
        return int.Parse(OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param).Rows[0]["count"].ToString());
    }
}
