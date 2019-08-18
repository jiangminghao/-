using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class newproductlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "buy")
        {
            Label productidlabel = e.Item.FindControl("productid") as Label;
            Userinfo user = new Userinfo();
            {
                product pro = new product();
                DataRow dr = pro.getoneproduct(int.Parse(productidlabel.Text));
                if ((int.Parse(dr["count"].ToString()) > int.Parse(dr["sellcount"].ToString())))
                {
                    cart ocart = new cart();
                    if (ocart.isexitproduct(int.Parse(productidlabel.Text)) == false)
                    {
                        if (ocart.addtocart(int.Parse(productidlabel.Text), user.getUserID(), 1, false) == 1)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物成功')</script>", false);
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物失败')</script>", false);
                        }
                    }
                    else
                    {
                        if (ocart.updatecartbyid(int.Parse(productidlabel.Text)) == 1)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物成功')</script>", false);
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物失败')</script>", false);
                        }
                    }

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('该商品缺货中')</script>", false);
                }


            }
        }
    }
}