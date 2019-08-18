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
/// order 的摘要说明
/// </summary>
public class order
{
    public int createorder(string orderid,int userid, string acceptname,
           string address, string postalcode, string phone, string delivery, string payment, int state, DateTime ordertime, double orderprice,int ordercount)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("insert into orders (orderid,[userid],acceptname,address,postalcode,phone,delivery,payment,state,ordertime,orderprice,ordercount) values ");
        sb.Append("(@orderid,@userid,@acceptname,@address,@postalcode,@phone,@delivery,@payment,@state,@ordertime,@orderprice,@ordercount)");
        OleDbParameter[] param1 = 
                                    {
                                        OleDbHelper.GetParameter("@orderid",OleDbType.Char,50,"orderid",orderid),
                                        OleDbHelper.GetParameter("@userid",OleDbType.Integer,4,"[userid]",userid),
                                        OleDbHelper.GetParameter("@acceptname",OleDbType.Char,50,"acceptname",acceptname),
                                        OleDbHelper.GetParameter("@address",OleDbType.Char,200,"address",address),
                                        OleDbHelper.GetParameter("@postalcode",OleDbType.Char,50,"postalcode",postalcode),
                                        OleDbHelper.GetParameter("@phone",OleDbType.Char,50,"phone",phone),
                                        OleDbHelper.GetParameter("@delivery",OleDbType.Char,50,"delivery",delivery),
                                        OleDbHelper.GetParameter("@payment",OleDbType.Char,50,"payment",payment),
                                        OleDbHelper.GetParameter("@state",OleDbType.Integer,4,"state",state),
                                        OleDbHelper.GetParameter("@ordertime",OleDbType.Date,8,"ordertime",ordertime),
                                        OleDbHelper.GetParameter("@orderprice",OleDbType.Double,8,"orderprice",orderprice),
                                        OleDbHelper.GetParameter("@ordercount",OleDbType.Integer,4,"ordercount",ordercount)
                                    };
        List<OleDbParameter[]> paramlist = new List<OleDbParameter[]>();
        List<string> sqls = new List<string>();
        sqls.Add(sb.ToString());
        paramlist.Add(param1);
        cart mycart = new cart();
        DataTable carttable = mycart.getcartlist(mycart.GetShoppingCartId());
        for (int i = 0; i < carttable.Rows.Count; i++)
        {
            sqls.Add("insert into orderdetails (productid,[count],orderid) values (@productid,@count,@orderid)");
            OleDbParameter[] param = 
                                        {new OleDbParameter("@productid",Int64.Parse(carttable.Rows[i]["productid"].ToString())),
                                            new OleDbParameter("@count" ,int.Parse(carttable.Rows[i]["count"].ToString())),
                                            new OleDbParameter("@orderid" ,orderid)
                                        };
            //OleDbParameter[] param = 
            //                            {OleDbHelper.GetParameter("@productid",OleDbType.Integer,4,"productid",Int64.Parse(carttable.Rows[i]["productid"].ToString())),
            //                               OleDbHelper.GetParameter("@count",OleDbType.Integer,4,"count",int.Parse(carttable.Rows[i]["count"].ToString())),
            //                              OleDbHelper.GetParameter("@orderid",OleDbType.Char,50,"orderid",orderid)
            //                            };
            paramlist.Add(param);
        }
        
        return OleDbHelper.executeNonQuery(sqls.ToArray(), paramlist);
        
    }

    /// <summary>
    /// 更新订单状态
    /// </summary>
    /// <param name="orderid">订单号</param>
    /// <param name="state">订单状态</param>
    /// <returns></returns>
    public int updatestate(string orderid, int state)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("update orders set state=@state where orderid=@orderid");
        OleDbParameter[] param = 
                                    { OleDbHelper.GetParameter("@state", OleDbType.Integer, 4, "state", state), 
                                      OleDbHelper.GetParameter("@orderid", OleDbType.Char, 50, "orderid", orderid)
                                    };
        return OleDbHelper.executeNonQuery(sb.ToString(),CommandType.Text, param);
    }

    /// <summary>
    /// 根据条件查询订单纪录
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="ordertime">下单时间</param>
    /// <param name="state">订单状态</param>
    /// <returns></returns>
    public DataTable selectorderlist(string username, string ordertime, int state)
    {
        StringBuilder sb = new StringBuilder();
       sb.Append("SELECT userinfo.userid, userinfo.username,orders.orderid, orders.acceptname, orders.address,");
        sb.Append("orders.postalcode, orders.phone, orders.delivery, orders.payment, orders.state,");
        sb.Append("orders.ordertime, orders.orderprice ");
        sb.Append("FROM orders INNER JOIN userinfo ON orders.userid = userinfo.userid");
       sb.Append(" where 1=1");
      if (username != "")
        {
           sb.Append(" and userinfo.username like '%" + username + "%'");
     }
    if (ordertime != "")
    {
     sb.Append(" and orders.ordertime = #" + ordertime +"#");
   }
     if (state == 0 || state == 1 || state == 2 || state == 3 || state == 4 || state == 5)
      {
          sb.Append(" and orders.state="+state);
    }
       return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }

    ///// <summary>
    ///// 根据用户ID获得订单列表
    ///// </summary>
    ///// <param name="userid"></param>
    ///// <returns></returns>
   public DataTable getordersbyuserid(int userid)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT orderid,[userid],");
        sb.Append("acceptname,address,postalcode,phone,");
        sb.Append("delivery,payment,state,ordertime,orderprice ");
        sb.Append("from orders where [userid]=@userid  order by state ");
        OleDbParameter[] param = 
                                    {
                                       OleDbHelper.GetParameter("@userid",OleDbType.Integer,4,"userid",userid)
                                    };
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text,param);
   }

    ///// <summary>
    ///// 根据条件查询订单纪录
    ///// </summary>
    ///// <param name="state">订单状态</param>
    ///// <returns></returns>
    public DataTable selectorderlist(int state)
   {
     StringBuilder sb = new StringBuilder();
      sb.Append("SELECT userinfo.userid, userinfo.username,orders.orderid, orders.acceptname, orders.address,");
        sb.Append("orders.postalcode, orders.phone, orders.delivery, orders.payment, orders.state,");
        sb.Append("orders.ordertime, orders.orderprice ");
       sb.Append("FROM orders INNER JOIN userinfo ON orders.userid = userinfo.userid");
        sb.Append(" where 1=1");
        if (state == 0 || state == 1 || state == 2 || state == 3 || state == 4)
       {
            sb.Append(" and state="+state);
        }
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text, null);
    }

    public DataTable selectorderlist(string username, int state)
    {
     StringBuilder sb = new StringBuilder();
        sb.Append("SELECT userinfo.userid, userinfo.username,orders.orderid, orders.acceptname, orders.address,");
        sb.Append("orders.postalcode, orders.phone, orders.delivery, orders.payment, orders.state,");
        sb.Append("orders.ordertime, orders.orderprice ");
      sb.Append("FROM orders INNER JOIN userinfo ON orders.userid = userinfo.userid");
       sb.Append(" where 1=1");
       
        if (username != "")
        {
            sb.Append(" and userinfo.username like '%"+ username + "%'");
           
       }
       if (state == 0 || state == 1 || state == 2 || state == 3 || state == 4)
        {
            sb.Append(" and orders.state="+state);
          
        }
        return OleDbHelper.executeDataAdapter(sb.ToString(), CommandType.Text,null);
   }

    ///// <summary>
    ///// 获得一条订单信息
    ///// </summary>
    ///// <param name="orderid"></param>
    ///// <returns></returns>
   public DataTable getoneorder(string orderid)
   {
       StringBuilder sb = new StringBuilder();
       sb.Append("SELECT orderid,orderdetails.productid as pid,productname,");
       sb.Append("userprice,imagepath,orderdetails.count  as cnt  ");
       sb.Append("from orderdetails INNER JOIN products ON orderdetails.productid = products.productid  where orderid=@orderid");
       OleDbParameter[] param = 
                                   {
                                       OleDbHelper.GetParameter("@orderid",OleDbType.Char,50,"orderid",orderid)
                                   };
       return OleDbHelper.executeDataAdapter(sb.ToString(),CommandType.Text, param);
   }
  

}
