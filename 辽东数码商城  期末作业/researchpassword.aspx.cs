using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class researchpassword : System.Web.UI.Page
{
    Userinfo user = new Userinfo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
            
            string password = user.researchPassword(TextBox1.Text, Label1.Text, TextBox2.Text);
            if (password != "")
            {
                Response.Write("<script>alert('密码为" + password + ",请记住！');window.location.href='login.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('答案错误！');</script>");
            }
        }

    protected void Button2_Click(object sender, EventArgs e)
    {

        DataTable db = user.getUser(TextBox1.Text);
        if (db.Rows.Count > 0)
        {
            Label1.Text = db.Rows[0][5].ToString();
        }
        else
        {
            Response.Write("<script>alert('该用户不存在');</script>");
        }
    }
    
}