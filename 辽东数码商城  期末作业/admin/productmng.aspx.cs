using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_productmng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        product pt = new product();
        foreach (GridViewRow gl in GridView1.Rows)
        {
            Label lb = gl.Cells[4].FindControl("Label1") as Label;
            int pid = int.Parse(lb.Text);
            CheckBox ck = gl.Cells[0].FindControl("CheckBox1") as CheckBox;
            if (ck.Checked)
            {
                pt.deleteproduct(pid);
            }
        }
        GridView1.DataBind();
    }
}