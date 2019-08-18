using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_type1mng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text!="")
        {
            type_1 tp1 = new type_1();
            string typename = TextBox1.Text;
            if(tp1.IsExite(typename))
            {
                Response.Write("<script>alert('该一级分类名称已存在');</script>");
                return;
            }
            else
            { 
            int i = tp1.createtype_1(typename);
            if(i>0)
            {
                GridView1.DataBind();
                Response.Write("<script>alert('创建一级分类成功');</script>");
            }
          }
        }
        else
        {
            Response.Write("<script>alert('请输入一级分类名称');</script>");
        }
        }
    
}