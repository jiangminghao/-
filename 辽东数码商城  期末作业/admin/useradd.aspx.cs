using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_useradd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Userinfo us = new Userinfo();
        if(us.checkname(TextBox1.Text))
        {
            Response.Write("<script>alert('该用户已存在，无法添加');</script>");
        }
        else
        { 
        us.createUser(TextBox1.Text);
        Response.Redirect("usermng.aspx");
        }
    }
}