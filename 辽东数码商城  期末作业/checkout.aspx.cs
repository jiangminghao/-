using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout : System.Web.UI.Page
{
    Userinfo user = new Userinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (user.IsLogin() == false)
        {
            this.Response.Redirect("login.aspx");
        }
    }
    protected void addorderbt_Click(object sender, EventArgs e)
    {
        DateTime ordertime = DateTime.Now;
        string orderid = ordertime.ToString("yyyyMMddhhmmss");
        double orderprice = double.Parse(Session["price"].ToString());
        int ordercount = int.Parse(Session["count"].ToString());
        order ord = new order();

        if (ord.createorder(orderid, user.getUserID(), this.acceptnametb.Text.Trim(),
            this.addresstb.Text.Trim(), this.postalcodetb.Text.Trim(), this.phonetb.Text.Trim(),
            this.deliverylist.SelectedItem.Text, this.paymentlist.SelectedItem.Text, 1, ordertime, orderprice, ordercount) == 1)
        {
            cart mycart = new cart();
            mycart.updatecartstate();
            this.Response.Redirect("success.aspx");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('订单出错!')</script>", false);
        }

    }
}