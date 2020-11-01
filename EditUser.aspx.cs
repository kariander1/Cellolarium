using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class EditUser : System.Web.UI.Page
{
    public string table,msgstatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "";
        string idNum="";
        


        if (Session["isAdmin"] == null || Session["user"] == null)
        {
            Response.Redirect("notLogged.aspx");
        }
        if (Request.Form["sub"] != null)
        {
            if (Request.QueryString["idNum"] != null)
            {
                idNum = Request.QueryString["idNum"];
            }
            else
            {
                idNum = Session["id"].ToString();
            }

            query += "UPDATE Users SET ";
            query += "Fname = N'" + Request.Form["first"] + "'";
            query += ",Lname = N'" + Request.Form["last"] + "'";
            query += ",Password = N'" + Request.Form["pass"] + "'";
            query += ",Email = N'" + Request.Form["mail"] + "'";

            string g;

            g = Request.Form["gender"].ToString();
            if (g.Equals("זכר"))
                query += ",Gender = N'" + "true" + "'";
            else
                query += ",Gender = N'" + "false" + "'";

            string s = Request.Form["sel"];
            query += ",Favourites = N'" + Request.Form["sel"] + "'";
            
            query += ",Requests = N'" + Request.Form["req"] + "'";
            if ((bool)Session["IsAdmin"] == true)
            {
                if(Request.Form["isAdmin"]!=null)
                    query += ",IsAdmin = N'" + Request.Form["isAdmin"].ToString().Equals("יש") +"' ";
            
            }
            query += "WHERE ID = '" + idNum + "'";
            DalBll.DoQuery(DalBll.GetConnection(), query);
            msgstatus = "<center><font style='font-size:25px;'>פרטיו של " + Request.Form["first"] + " " + Request.Form["last"] + " עודכנו בהצלחה</font>";
            if ((bool)Session["isAdmin"] == true)
                msgstatus += "<br/><a href='AdminManage.aspx'>חזור לעריכת משתמשים </a>";
            msgstatus += "<br/><a href='EditUser.aspx'>חזור לעריכת פרטים אישיים </a></center>";
     
        }
        else
        {
            if (Request.QueryString["idNum"] != null)
            {
                idNum = Request.QueryString["idNum"];
            }
            else
            {
                idNum = Session["id"].ToString();
            }
            query += "SELECT * FROM Users WHERE ID = '" + idNum+"'";
            SqlDataReader data = DalBll.DataReadSQL(DalBll.GetConnection(), query);
            if (data.Read())
            {
                table = @"<table cellpadding=5 cellspacing=5>
                <tr>
            <td>תעודת זהות:</td>
            <td><input type=text name=id disabled=disabled value="+idNum+ @" /></td>
           
        </tr>
        <tr>
            <td>שם:</td>
            <td><input type=text name=first value=" +data["Fname"] + @" /></td>
           
        </tr>
        <tr>
            <td>שם משפחה:</td>
            <td><input type=text name=last value=" + data["Lname"] + @" /></td>
            
        </tr>
        <tr>
            <td>סיסמא:</td>
            <td><input type=password name=pass value=" + data["Password"] + @"  /></td>
        </tr>
        <tr>
            <td>אימות סיסמא:</td>
            <td><input type=password name=checkpass  /></td>
        </tr>
        <tr>
            <td>אימייל:</td>
            <td><input type=text name=mail value=" + data["Email"] + @" /></td>
        </tr>";
                if ((bool)Session["isAdmin"] == true)
                {
                    table += @"
        <tr>
            <td>הרשאת מנהל</td>";
                    if ((bool)data["IsAdmin"])
                        table += @"<td><select name=IsAdmin disabled='disabled'><option value ='יש'>יש</option><option value='אין'    >אין</option></select></td></tr>";
                    else
                        table += @"<td><select name=IsAdmin ><option>אין</option><option>יש</option></select></td></tr>";
                }
                table+=@"
        <tr>
            <td>מין:</td>";
                
                    bool flag = (bool)data["Gender"];
                    if ((bool)data["Gender"])
                        table += @"<td><input type=radio name=gender value=זכר  checked=checked/>זכר<input type=radio name=gender value=נקבה/>נקבה</td>";
                    else
                        table += @"<td><input type=radio name=gender value=זכר  />זכר<input type=radio name=gender checked=checked value=נקבה/>נקבה</td>";
              

        table+=@"<td>בקשות מיוחדות:</td>
        </tr>    
                                 <tr>
            <td>תוכניות אהובות:</td>";

        if (data["Favourites"].ToString().Split(',').Contains("פוקימון"))
            table += @"<td><input type=checkbox checked=checked name=sel value=פוקימון>פוקימון</td>";
        else
            table += @"<td><input type=checkbox name=sel value=פוקימון>פוקימון</td>";
                table+=@"
            
            <td rowspan=4>
                <textarea name=req cols=25 rows=7 @>"+data["Requests"]+@"</textarea>
                </td>
        </tr>
        <tr>
            <td></td>";
                if(data["Favourites"].ToString().Split(',').Contains("דרגון בול זי"))
                
                    table+=@"<td><input type=checkbox name=sel checked=checked value='דרגון בול זי'>דרגון בול זי</td>";
                
                else
                    table += @"<td><input type=checkbox name=sel  value='דרגון בול זי'>דרגון בול זי</td>";
            table+=@"
        </tr>
        <tr>
            <td></td>";
            if (data["Favourites"].ToString().Split(',').Contains("איך פגשתי את אימא"))

                table += @"<td><input type=checkbox name=sel checked=checked value='איך פגשתי את אימא'>איך פגשתי את אימא</td>";

            else
                table += @"<td><input type=checkbox name=sel  value='איך פגשתי את אימא'>איך פגשתי את אימא</td>";
    
                table+=@"
        </tr>
        <tr>
            <td></td>";
                if (data["Favourites"].ToString().Split(',').Contains("שנות ה-70"))

                    table += @"<td><input type=checkbox checked=checked name=sel value='שנות ה-70'>שנות ה-70 </td>";

                else
                    table += @"<td><input type=checkbox  name=sel value='שנות ה-70'>שנות ה-70 </td>";
                table+=@"

            
        </tr>
        <tr align=center>
            <td colspan=3><input type=submit name=sub value=עדכן /></td>
        </tr>
    </table>";
            }
        }

    }
}