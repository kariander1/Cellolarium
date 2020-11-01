using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class notLogged : System.Web.UI.Page
{
    public string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] == null)
            msg = " שלום אורח, \n אין לך הרשאה לצפות בדף זה";
       
        else
            msg = " על מנת לצפות בתוכן המבוקש, הינך מתבקש להתחבר לאתר";
    }
}