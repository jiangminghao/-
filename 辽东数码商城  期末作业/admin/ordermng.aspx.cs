using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_ordermng : System.Web.UI.Page
{
    order Oorder = new order();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListView list = e.Item.FindControl("ListView2") as ListView;
            Label lablepid = e.Item.FindControl("Label1") as Label;
            
            DataTable table = Oorder.getoneorder(lablepid.Text);
            list.DataSource = table;
            list.DataBind();


        }
    }
    protected void ListView3_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if(e.CommandName=="fahuo")
        {
            string orderid = e.CommandArgument.ToString();
            Oorder.updatestate(orderid, 2);
            ListView3.DataBind();
            ListView4.DataBind();
        }
    }
    protected void ListView5_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "ok")
        {
            string orderid = e.CommandArgument.ToString();
            Oorder.updatestate(orderid, 4);
            ListView5.DataBind();
            ListView1.DataBind();
        }
    }
    protected void ListView3_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListView list = e.Item.FindControl("ListView2") as ListView;
            Label lablepid = e.Item.FindControl("Label1") as Label;

            DataTable table = Oorder.getoneorder(lablepid.Text);
            list.DataSource = table;
            list.DataBind();


        }
    }
}