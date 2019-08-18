using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_type2mng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            type_1 tp1 = new type_1();
            DropDownList1.DataSource = tp1.getall();
            DropDownList1.DataTextField = "typename";
            DropDownList1.DataValueField = "typeid_1";
            DropDownList1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        weihu.Visible = true;
        ViewState["op"] = "add";
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edi")
        {
            weihu.Visible = true;
            ViewState["op"] = "edit";
            type_2 tp2 = new type_2();
            string typeid_2 = e.CommandArgument.ToString();
            DataRow dr = tp2.getrow(typeid_2);
            DropDownList1.SelectedValue = dr["typeid_1"].ToString();
            TextBox1.Text = dr["typename"].ToString();
            ViewState["type2id"] = typeid_2;
        }
        else if (e.CommandName == "del")
        {
            string typeid_2 = e.CommandArgument.ToString();
            type_2 tp2 = new type_2();
            int count = tp2.getpro(typeid_2);
            if (count > 0)
            {
                Response.Write("<script>alert('此分类下还有商品，不允许删除');</script>");
            }
            else
            {
                int i = tp2.deletetype_2(Convert.ToInt16(typeid_2));
                if (i > 0)
                {
                    GridView1.DataBind();
                    Response.Write("<script>alert('删除成功');</script>");
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        type_2 tp2 = new type_2();
        if (TextBox1.Text == "")
        {
            Response.Write("<script>alert('请输入二级分类名称');</script>");
            return;
        }
        else
        {
            if (tp2.IsExite(TextBox1.Text))
            {
                Response.Write("<script>alert('二级分类名称重复');</script>");
                return;
            }
            else
            {
                string typeid_1 = DropDownList1.SelectedValue;
                string typename = TextBox1.Text;

                if (ViewState["op"].ToString() == "add")
                {
                    tp2.createtype_2(Convert.ToInt32(typeid_1), typename);
                    GridView1.DataBind();
                    weihu.Visible = false;
                }
                else if (ViewState["op"].ToString() == "edit")
                {
                    tp2.updatetype_2(Convert.ToInt32(ViewState["type2id"].ToString()), Convert.ToInt32(typeid_1), typename);
                    GridView1.DataBind();
                    weihu.Visible = false;
                }
            }
        }

    }
}