using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class userinfo : System.Web.UI.Page
{
    Userinfo us = new Userinfo();
    order Oorder = new order();
    int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!us.IsLogin())
            {

                Response.Redirect("login.aspx?ReturnUrl=userinfo.aspx");
            }
            else
            {
                userid = us.getUserID();
                DataTable db = us.getUser(userid);
                Label1.Text = db.Rows[0][1].ToString();
                TextBox1.Text = db.Rows[0][4].ToString();
                TextBox2.Text = db.Rows[0][5].ToString();
                TextBox3.Text = db.Rows[0][6].ToString();
                ObjectDataSource1.SelectParameters.Clear();
                ObjectDataSource1.SelectParameters.Add("userid", userid.ToString());
                //DataTable orderdb = Oorder.getordersbyuserid(userid);
                //ListView1.DataSource = orderdb;
                ListView1.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        userid = us.getUserID();
        if (us.updateUserinfo(userid, TextBox1.Text, TextBox2.Text, TextBox3.Text) > 0)
        {
            Response.Write("<script>alert('资料修改成功');window.location.href='userinfo.aspx';</script>");

        }
        else
        {
            Response.Write("<script>alert('资料修改不成功');window.location.href='userinfo.aspx';</script>");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        userid = us.getUserID();
        DataTable db = us.getUser(userid);
        string password = db.Rows[0][2].ToString();
        if (password == TextBox4.Text)
        {
            if (us.updateUserPassword(userid, TextBox5.Text) > 0)
            {
                Response.Write("<script>alert('密码修改成功，请记住新密码');window.location.href='userinfo.aspx';</script>");
                Panel1.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('密码修改不成功');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('旧密码输入不正确');</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListView list = e.Item.FindControl("ListView2") as ListView;
            Label lablepid = e.Item.FindControl("Label2") as Label;
            Label labelstate = e.Item.FindControl("Label3") as Label;
            Button b1 = e.Item.FindControl("qxdd") as Button;
            Button b2 = e.Item.FindControl("ddfh") as Button;
            Button b3 = e.Item.FindControl("qrsh") as Button;
            Button b4 = e.Item.FindControl("wcjy") as Button;
            Button b5 = e.Item.FindControl("hfdd") as Button;
            string state=labelstate.Text;
            if(state=="0")
            {
                b1.Visible = false;
                b2.Visible = false;

                b3.Visible = false;
                b4.Visible = false;
                b5.Visible = true;
            }
            else if(state=="1")
            {
                b1.Visible = true;
                b2.Visible = true;
             
                b3.Visible = false;
                b4.Visible = false;
                b5.Visible = false;
            }
            else if(state=="2")
            {
                b1.Visible = false;
                b2.Visible = false;

                b3.Visible = true;
                b4.Visible = false;
                b5.Visible = false;
            }
            
            else if(state=="3"||state=="4")
            {
                b1.Visible = false;
                b2.Visible = false;
                b3.Visible = false;
                b4.Visible = true;
                b5.Visible = false;
            }

            DataTable table = Oorder.getoneorder(lablepid.Text);
            list.DataSource = table;
            list.DataBind();


        }
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if(e.CommandName=="qrsh")
        {
            string orderid = e.CommandArgument.ToString();
            Oorder.updatestate(orderid, 3);
            this.DataBind();
        }
        else if(e.CommandName=="qxdd")
        {
            string orderid = e.CommandArgument.ToString();
            Oorder.updatestate(orderid, 0);
            this.DataBind();
        }else if(e.CommandName=="hfdd")
        {
            string orderid = e.CommandArgument.ToString();
            Oorder.updatestate(orderid, 1);
            this.DataBind();
        }
    }
}