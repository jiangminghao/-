using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_addproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            type_1 ty1 = new type_1();
            DropDownList1.DataSource = ty1.type_1list("").DefaultView;
            DropDownList1.DataTextField = "typename";
            DropDownList1.DataValueField = "typeid_1";
            DropDownList1.DataBind();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        type_2 ty2 = new type_2();
        int id1 = int.Parse(DropDownList1.SelectedValue);
        drop2.DataSource = ty2.type_2list(id1, "").DefaultView;
        drop2.DataTextField = "type_2name";
        drop2.DataValueField = "typeid_2";
        drop2.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        if (FileUpload1.HasFile)
        {
            string exName = System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper();
            if (exName == ".JPG" || exName == ".BMP" || exName == ".GIF")
            {
                if (FileUpload1.PostedFile.ContentLength > 204800000)//判断图片是否大于200k（根据自己的需要判断大小）
                {
                    Response.Write("<script>alert('对不起，图片大小不能大于200K');window.location.href='addproduct.aspx'</script>");
                    return;
                }
                else
                {
                    string ImageName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + exName;//图片名称设置为保存的时间
                    product pro = new product();
                    int i = pro.createproduct(TextBox1.Text, int.Parse(DropDownList1.SelectedValue), int.Parse(drop2.SelectedValue), CheckBox1.Checked, CheckBox2.Checked, Double.Parse(TextBox2.Text),
                        Double.Parse(TextBox3.Text), Double.Parse(TextBox4.Text), int.Parse(TextBox5.Text), ImageName, int.Parse(TextBox6.Text), int.Parse(TextBox7.Text), TextBox8.Text);
                    if (i > 0)
                    {
                        FileUpload1.SaveAs(Server.MapPath("../pic") + "\\" + ImageName);
                        Response.Write("<script>alert('数据添加成功');window.location.href='productmng.aspx'</script>");
                    }
                    else
                        Response.Write("<script>alert('数据添加失败,重新输入');window.location.href='addproduct.aspx'</script>");
                }
            }
            else
                Response.Write("<script>alert('不支持的商品图片类型！');</script>");
        }
        else
        {

            Response.Write("<script>alert('必需选择商品图片');</script>");

        }
    }
}