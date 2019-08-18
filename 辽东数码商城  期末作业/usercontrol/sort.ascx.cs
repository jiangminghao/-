using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class usercontrol_sort : System.Web.UI.UserControl
{
    type_1 t_1 = new type_1();
    type_2 t_2 = new type_2();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.Bind();
        }
    }
    protected void parent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
            DataList list = e.Item.FindControl("child") as DataList;
            DataRowView drv = e.Item.DataItem as DataRowView;
            DataTable table = t_2.type_2list(int.Parse(drv["typeid_1"].ToString()), "");
            list.DataSource = table.DefaultView;
            list.DataBind();
      

    }
    private void Bind()
    {
        DataTable t_1table = t_1.type_1list("");
        this.parent.DataSource = t_1table.DefaultView;
        this.parent.DataBind();
    }
}
