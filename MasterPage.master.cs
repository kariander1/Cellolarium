using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class MasterPage : System.Web.UI.MasterPage
{
 
    public string time;
    public string topPanel;
    public string logIn;
    public string hello;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now.Date;    

        time = "<div id=time>"+ now.Date.ToShortDateString() +"</div>";
        string user = Convert.ToString(Session["user"]);


        if ((Session["user"] == null) || (user == " "))
        {
            logIn = "<table width='150px' cellpadding=2 cellspacing=5 border=0 dir=rtl>";
            logIn += "<tr>";
            logIn += "<td colspan=2>שלום אורח! אנא התחבר על מנת להנות ממלוא האתר!</td>";
            logIn += "</tr>";
            logIn += "<tr>";
            logIn += " <td > תעודת זהות</td>";
            logIn += " <td align='left'> <input type=text style=width:80px id=idNum name=idNum1 />  </td></tr>";
            logIn += "<tr><td >סיסמא</td><td align='left'><input type=password style=width:80px id=password1 name=pss /></td>";
            logIn += "</tr><tr><td colspan=2 style='padding-right:42px;padding-top:15px;'><input type=submit id=submit name=submit  value='התחבר'/></td></tr>";
            logIn += "<tr><ul id=error></ul></tr></table>";



            if (Request.Form["submit"] != null)
            {
                string query;
              
                
                query = "SELECT * FROM Users WHERE ID = N'" + Request.Form["idNum1"]+"' AND Password= N'"+Request.Form["pss"]+"'";
                SqlDataReader data = DalBll.DataReadSQL(DalBll.GetConnection(), query);
                if (data.Read())
                {
                    Session["user"] = data["Fname"] + " " + data["Lname"];
                    Session["id"] = data["ID"];
                    if (Convert.ToBoolean(data["IsAdmin"]))
                        Session["isAdmin"] = true;
                    else
                        Session["isAdmin"] = false;
                }
                else
                {
                    Session["warn"]="<div id=warn> תעודת זהות או שם משתמש שגויים </div>";
                   
                }
                   
                
              
              
                
                    
                /*

                    if (Request.Form["idNum1"].Equals("admin"))
                        Session["isAdmin"] = true;
                    else
                        Session["isAdmin"] = false;
                */
                Response.Redirect("Home.aspx");
            }
        }
        
            if (Session["user"] != null)
            {

                hello = "<font id=name>שלום " + Session["user"].ToString() + "</font>";
                topPanel += "<br/><br/><br/><a  href='EditUser.aspx'><b>פרטים אישיים</b></a>";
                topPanel += "&nbsp;&nbsp;|&nbsp;<a  href='logOut.aspx'><b>התנתק</b></a>";


                if ((bool)(Session["isAdmin"]))
                {
                    hello = "<font> שלום " + Session["user"].ToString() + "<br><b> מנהל האתר</b></font>";
                    topPanel += "&nbsp;&nbsp;|<a  href='AdminManage.aspx'><b><br/>ניהול משתמשים</a> |</b>&nbsp;<a  href='DeleteNews.aspx'><b>ערוך הודעות</a></b>|<br/>";
                }

            }
        


    }
}
