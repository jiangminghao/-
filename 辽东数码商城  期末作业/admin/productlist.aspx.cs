using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_productlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            product pro = new product();
            type_1 ty1 = new type_1();
            type_2 ty2 = new type_2();
            int id = int.Parse(Request.QueryString["pid"]);
            DataRow dr = pro.getoneproduct(id);
            TextBox1.Text = dr["productname"].ToString();
            DropDownList1.Items.Add(new ListItem(ty1.gettypename((int)dr["typeid_1"]), dr["typeid_1"].ToString()));
            DataTable table = ty1.type_1list("");
            foreach (DataRow row in table.Rows)
            {
                DropDownList1.Items.Add(new ListItem(row["typename"].ToString(), row["typeid_1"].ToString()));
            }

            drop2.Items.Add(new ListItem(ty2.gettypename((int)dr["typeid_2"]), dr["typeid_2"].ToString()));
            CheckBox1.Checked = (bool)dr["recommended"];
            CheckBox2.Checked = (bool)dr["specials"];
            TextBox2.Text = dr["price"].ToString();
            TextBox3.Text = dr["userprice"].ToString();
            TextBox4.Text = dr["specialsprice"].ToString();
            TextBox5.Text = dr["pointcount"].ToString();
            Image1.ImageUrl = "../pic/" + dr["imagepath"].ToString();
            TextBox6.Text = dr["count"].ToString();
            TextBox7.Text = dr["sellcount"].ToString();
            TextBox8.Text = dr["description"].ToString();

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
        product pro = new product();
        int id = int.Parse(Request.QueryString["pid"]);
        int i = pro.updateproduct(id, TextBox1.Text, int.Parse(DropDownList1.SelectedValue), int.Parse(drop2.SelectedValue), CheckBox1.Checked, CheckBox2.Checked, Double.Parse(TextBox2.Text),
                        Double.Parse(TextBox3.Text), Double.Parse(TextBox4.Text), int.Parse(TextBox5.Text), int.Parse(TextBox6.Text), int.Parse(TextBox7.Text), TextBox8.Text);
        if (i > 0)
        {
            if (FileUpload1.HasFile)
            {
                string exName = System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper();
                if (exName == ".JPG" || exName == ".BMP" || exName == ".GIF")
                {
                    if (FileUpload1.PostedFile.ContentLength > 204800000)//判断图片是否大于200k（根据自己的需要判断大小）
                    {
                        Response.Write("<script>alert('对不起，图片大小不能大于200K');window.location.href='productlist.aspx'</script>");
                        return;
                    }
                    else
                    {
                        string ImageName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + exName;//图片名称设置为保存的时间
                        pro.updatepic(ImageName, id);

                        FileUpload1.SaveAs(Server.MapPath("../pic") + "\\" + ImageName);
                        Response.Write("<script>alert('数据修改成功');window.location.href='productmng.aspx'</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('不支持的商品图片类型！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('数据修改成功');window.location.href='productmng.aspx'</script>");
            }
        }
    }
}