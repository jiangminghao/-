using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class mycart : System.Web.UI.Page
{
    private cart ocart = new cart();
    Userinfo user = new Userinfo();
    int num = 0;
    double price = 0.0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.Bind();
        }

    }
    private void Bind()
    {
        DataTable table = ocart.getcartlist(ocart.GetShoppingCartId());
        this.cartrepeater.DataSource = table.DefaultView;
        this.cartrepeater.DataBind();

        this.counttypelieteral.Text = this.cartrepeater.Items.Count.ToString();

        this.countnumlieteral.Text = num.ToString();
        this.countpricelieral.Text = price.ToString();
    }
    protected void clearcount_Click(object sender, EventArgs e)
    {
        ocart.deletecart(ocart.GetShoppingCartId());

        this.Bind();
    }
    protected void orderbt_Click(object sender, EventArgs e)
    {
        if (this.cartrepeater.Items.Count > 0)
        {
            if (user.IsLogin())
            {
                Session["count"] = counttypelieteral.Text.Trim();
                Session["price"] = countpricelieral.Text.Trim();
                this.Response.Redirect("checkout.aspx");
            }
            else
                Response.Redirect("login.aspx?ReturnUrl=mycart.aspx");

        }
        else
        {//Page.RegisterClientScriptBlock("alert",@"<script>alert('购物车内是空的！');</script>");
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyScript", @"alert('购物车内是空的！');", true);


        }
    }
    protected void cartrepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label pricelabel = e.Item.FindControl("pricelabel") as Label;
            Label countpricelabel = e.Item.FindControl("countpricelabel") as Label;
            TextBox counttb = e.Item.FindControl("counttb") as TextBox;
            DataRowView drv = e.Item.DataItem as DataRowView;
            if (drv["specials"].ToString().ToLower() == "true")
            {
                pricelabel.Text = drv["specialsprice"].ToString();
            }
            else
            {
                pricelabel.Text = drv["userprice"].ToString();
            }
            counttb.Text = drv["count"].ToString();
            countpricelabel.Text = (double.Parse(pricelabel.Text) * int.Parse(counttb.Text.Trim())).ToString();

            num += int.Parse(counttb.Text.Trim());
            price += double.Parse(countpricelabel.Text.Trim());
        }
    }
    protected void updatecount_Click(object sender, EventArgs e)
    {
        List<int> ids = new List<int>();
        List<int> counts = new List<int>();
        foreach (RepeaterItem item in this.cartrepeater.Items)
        {
            Label label = item.FindControl("productidlabel") as Label;
            TextBox textbox = item.FindControl("counttb") as TextBox;
            ids.Add(int.Parse(label.Text.Trim()));
            counts.Add(int.Parse(textbox.Text.Trim()));
        }
        for (int i = 0; i < ids.Count; i++)
        {
            ocart.updatecartbyid(ids[i], counts[i]);
        }
        this.Bind();
    }
    protected void cartrepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deletecart")
        {
            Label label = e.Item.FindControl("productidlabel") as Label;
            int id = int.Parse(label.Text);
            ocart.deletecartbyproductid(id);
            this.Bind();
        }
    }
}