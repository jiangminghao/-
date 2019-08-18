using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_feedbackshenhe : System.Web.UI.Page
{
    FeedBack feedback = new FeedBack();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ImageButton db = (ImageButton)e.Item.FindControl("ibtDelete");
            ImageButton ub = (ImageButton)e.Item.FindControl("ibtAllow");
            ImageButton cb = (ImageButton)e.Item.FindControl("ibtDeny");
            Label lb = (Label)e.Item.FindControl("fb_dateid");
            Boolean f = feedback.getisview(lb.Text);
            db.Attributes.Add("onclick", "return confirm('确认要删除这条留言吗?')");
            if (f)
            {
                ub.Visible = false;
                cb.Visible = true;
            }
            else
            {
                ub.Visible = true;
                cb.Visible = false;
            }
        }
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            Label lb = (Label)e.Item.FindControl("fb_dateid");
            feedback.deletefeed(lb.Text);
            ListView1.DataBind();
        }
        else if (e.CommandName == "deny")
        {
            Label lb = (Label)e.Item.FindControl("fb_dateid");
            feedback.changeview(int.Parse(lb.Text), true);
            ImageButton ub = (ImageButton)e.Item.FindControl("ibtAllow");
            ImageButton cb = (ImageButton)e.Item.FindControl("ibtDeny");
            ub.Visible = false;
            cb.Visible = true;
        }
        else if (e.CommandName == "allow")
        {
            Label lb = (Label)e.Item.FindControl("fb_dateid");
            feedback.changeview(int.Parse(lb.Text), false);
            ImageButton ub = (ImageButton)e.Item.FindControl("ibtAllow");
            ImageButton cb = (ImageButton)e.Item.FindControl("ibtDeny");
            ub.Visible = true;
            cb.Visible = false;
        }
    }
}