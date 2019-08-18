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

public partial class usercontrol_special : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.Bind();
        }
    }

    private void Bind()
    {
        product pro = new product();
        DataTable table = pro.getspecialproductlist(12);
        this.specialproductlist.DataSource = table.DefaultView;
        this.specialproductlist.DataBind();
    }
}
