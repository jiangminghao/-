using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    Userinfo user = new Userinfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void loginsubmit_ServerClick(object sender, ImageClickEventArgs e)
    {
        if (this.checkCokdeTb.Text.Trim() == Session["CheckCode"].ToString())
        {
            if (user.validUser(this.username.Value.Trim(), this.password.Value.Trim(), 1))
            {
                user.SetCookie(this.username.Value.Trim());
                if (Request.QueryString["ReturnUrl"] != null)
                    this.Response.Redirect(Request.QueryString["ReturnUrl"]);
                else
                    this.Response.Redirect("default.aspx");
            }
            else
            {
                //Page.RegisterStartupScript("alert", "<script>alert('用户名和密码不一致')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('用户名和密码不一致');", true);
            }
        }
        else
        {

           
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('验证码错误');", true);
        }
    }
}