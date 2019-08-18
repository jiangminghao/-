using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class productinfo : System.Web.UI.Page
{
    product pro = new product();
    type_1 t_1 = new type_1();
    type_2 t_2 = new type_2();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.Bind();
            pro.updatepointnum(int.Parse(this.Request.QueryString["pid"].ToString()));
        }
    }
    private void Bind()
    {
        int pid = int.Parse(this.Request.QueryString["pid"].ToString());
        DataRow row = pro.getoneproduct(pid);
        this.productnameliteral.Text = row["productname"].ToString();
        this.IMG1.Src = "pic/" + row["imagepath"].ToString();
        this.type_1nameliteral.Text = t_1.gettypename(int.Parse(row["typeid_1"].ToString()));
        this.type_2nameliteral.Text = t_2.gettypename(int.Parse(row["typeid_2"].ToString()));
        this.pointcountliteral.Text = row["pointcount"].ToString();
        this.countliteral.Text = (int.Parse(row["count"].ToString()) > int.Parse(row["sellcount"].ToString())) ? row["count"].ToString() : "缺货";
        this.sellcountliteral.Text = row["sellcount"].ToString();
        this.priceliteral.Text = row["price"].ToString();
        this.userpriceliteral.Text = row["userprice"].ToString();
        this.specialsliteral.Text = row["specialsprice"].ToString();
        this.descriptionliteral.Text = row["description"].ToString();
    }
    protected void addcart_Click(object sender, ImageClickEventArgs e)
    {
       Userinfo user=new Userinfo();
        if (this.countliteral.Text.Trim() != "缺货")
        {
            cart ocart = new cart();
            if (ocart.isexitproduct(int.Parse(this.Request.QueryString["pid"].ToString())) == false)
            {
                if (ocart.addtocart(int.Parse(this.Request.QueryString["pid"].ToString()), user.getUserID(), 1, false) == 1)
                {

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物成功')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物失败')</script>", false);
                }
            }
            else
            {
                if (ocart.updatecartbyid(int.Parse(this.Request.QueryString["pid"].ToString())) == 1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物成功')</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('购物失败')</script>", false);
                }
            }
        }
        else
        {
            this.addcart.Enabled = false;
        }
        
    }
}