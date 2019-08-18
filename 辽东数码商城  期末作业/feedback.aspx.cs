using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class feedback : System.Web.UI.Page
{
    Userinfo user = new Userinfo();
    int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!user.IsLogin())
            {

                Response.Redirect("login.aspx?ReturnUrl=feedback.aspx");

            }
            else
            {
                userid = user.getUserID();
                DataTable db = user.getUser(userid);
                TextBox4.Text = db.Rows[0][1].ToString();
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text.Trim() == "" || TextBox4.Text.Trim() == "" || TextBox5.Text.Trim() == "")
        {

            Response.Write("<script>alert('留言失败');</script>");

        }
        else
        {
            FeedBack ra = new FeedBack();
            ra.addfeedback(TextBox3.Text, TextBox4.Text, TextBox5.Text);
            CommTools.alert(this, "提交成功，感谢您的反馈！~");
        }
    }
}