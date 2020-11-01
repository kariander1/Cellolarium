using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RemoveUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] == null || (bool)Session["IsAdmin"] != true)
            Response.Redirect("notLogged.aspx");
        string query = "DELETE FROM users WHERE ID=" + Request.QueryString["idNum"];
        DalBll.DoQuery(DalBll.GetConnection(), query);
        Response.Redirect("AdminManage.aspx");
    }
}