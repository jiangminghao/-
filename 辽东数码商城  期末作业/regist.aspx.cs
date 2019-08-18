using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regist : System.Web.UI.Page
{
    Userinfo user = new Userinfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string name = usrernameTb.Text;
        if (name != "")
       {
        bool result = user.IsExtie(name);
       Label1.Text=(result == true) ? "用户已存在,请换个用户名" : "用户不存在,你可以使用该用户名";
       }
        else
        {
           Label1.Text="请输入用户名";
       }
    }
    protected void registBt_Click(object sender, EventArgs e)
    {
        if (user.IsExtie(usrernameTb.Text.Trim()) == false)
        {
            int result = user.createUser(this.usrernameTb.Text.Trim(), this.passwordTb.Text.Trim(), 1,
                  this.emailTb.Text.Trim(), this.questionTb.Text, this.answerTb.Text.Trim());
            if (result == 1)
            {
                this.Response.Redirect("login.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('新用户注册失败!请填好资料在尝试')</script>", false);
            }
        }
        else
        {
            
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('用户已存在,请换个用户名')</script>", false);
        }
    }
}