using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            tjclass tj = new tjclass();
            Label1.Text = tj.tjtype1();
            Label2.Text = tj.tjtype2();
            Label3.Text = tj.tjproduct();
            Label4.Text = tj.tjorder();
            Label5.Text = tj.tjuser();
            Label6.Text = tj.tjsellcount();
        }
    }
}