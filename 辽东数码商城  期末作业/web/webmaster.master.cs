using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_webmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Userinfo user = new Userinfo();
        if (user.IsLogin() == true)
        {
            this.loginpanel.Visible = true;
            this.logoutpanel.Visible =false;
            this.usernamelabel.Text = "欢迎 :" +  user.getUserName() + "进入辽东数码商城";
        }
        else
        {
            this.logoutpanel.Visible = true;
            this.loginpanel.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Userinfo user = new Userinfo();
        user.Logout();
        Response.Redirect("default.aspx");
    }
}
