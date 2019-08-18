using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_usermng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Userinfo us = new Userinfo();
            string username = Session["username"].ToString();
            DataRow dr = us.getUser(username).Rows[0];
            Label2.Text = username;
            TextBox1.Text = dr["password"].ToString();
            TextBox4.Text = dr["email"].ToString();
            TextBox2.Text = dr["question"].ToString();
            TextBox3.Text = dr["answer"].ToString();
        }
    }
    public string setpower(string power)
    {
        if (power == "1")
            return "普通用户";
       
        return "管理员";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = Session["username"].ToString();
        string password = TextBox1.Text;
        string email = TextBox4.Text;
        string question = TextBox2.Text;
        string answer = TextBox3.Text;
        Userinfo us = new Userinfo();
        int i = us.updateUser(username, password, email, question, answer);
        if(i>0)
            Response.Write("<script>alert('修改成功');</script>");
        
    }
}