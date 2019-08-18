using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = TextBox1.Text;
        string password = TextBox2.Text;
        Userinfo us = new Userinfo();
        bool isexit = us.checklogin(username, password);
        if(isexit)
        {
            Session["username"] = username;
            Response.Redirect("default.aspx");
        }
        else
        {
            Response.Write("<script>alert('信息错误');</script>");
        }
    }
}