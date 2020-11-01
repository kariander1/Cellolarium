using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class AdminManage : System.Web.UI.Page
{
    public string showUsers="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["IsAdmin"]==null||(bool)Session["IsAdmin"]!=true)
            Response.Redirect("notLogged.aspx");
        string selectQuery = "select * from Users ";
        if (Request.Form["do"] != null)
        {
    
            
        
           
            if (Request.Form["Fn"].ToString() != null && Request.Form["Fn"].ToString() != "")
            {
                selectQuery += "WHERE Fname like N'" + Request.Form["Fn"].ToString() + "%' ";
                if(Request.Form["Ln"].ToString() != null && Request.Form["Ln"].ToString() != "")
                    selectQuery+="AND Lname like N'"+Request.Form["Ln"].ToString() +"%'";
            }
            else if (Request.Form["Ln"].ToString() != null && Request.Form["Ln"].ToString() != "")
                   selectQuery += "WHERE Lname like N'" + Request.Form["Ln"].ToString() + "%'";
            switch (Request.Form["sort"].ToString())
            {
                case "name": selectQuery += "ORDER BY Fname ";
                    break;
                case "last": selectQuery += "ORDER BY Lname ";
                    break;
                case "date": selectQuery += "ORDER BY DateCreated ";
                    break;
            }
            if (Request.Form["sort"].ToString() != "none")
                if (Request.Form["ord"].ToString() == "up")
                    selectQuery += "ASC ";
                else
                    selectQuery += "DESC ";
            
        }
        
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(selectQuery, DalBll.GetConnection());

        da.Fill(ds,"Users");
        DataTable dt = ds.Tables["Users"];
        showUsers+="<table cellspacing=5 cellpadding=5 border=1 id=ustable>";
        showUsers+="<tr>";
        showUsers += "<th width=100%> שם פרטי </th>";
        showUsers += "<th width=100%> שם משפחה </th>";
        showUsers += "<th width=100%> סיסמא </th>";
        showUsers += "<th width=100%> תעודת זהות </th>";
        showUsers += "<th width=100%> אימייל </th>";
        showUsers += "<th width=100%> מין </th>";
        showUsers += "<th width=100%> תכניות אהובות </th>";
        showUsers += "<th width=100%> בקשות</th>";
        showUsers += "<th width=100%> הרשאת מנהל</th>";
        showUsers += "<th width=100%> תאריך הצטרפות</th>";
        showUsers += "</tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            showUsers += "<tr>";
            showUsers += "<td width=100%>" + dt.Rows[i]["Fname"] + "</td>";
            showUsers += "<td width=100%>" + dt.Rows[i]["Lname"] + "</td>";
            showUsers += "<td width=100%>" + dt.Rows[i]["Password"] + "</td>";
            showUsers+="<td width=100%>" + dt.Rows[i]["ID"] + "</td>";
            showUsers += "<td width=100%>" + dt.Rows[i]["Email"] + "</td>";            
            if(dt.Rows[i]["Gender"].ToString().ToLower()=="true")
                showUsers += "<td width=100%>" +"זכר" + "</td>";
            else if(dt.Rows[i]["Gender"].ToString().ToLower()=="false")
                showUsers += "<td width=100%>" + "נקבה" + "</td>";
            else
                showUsers += "<td width=100%></td>";
            showUsers += "<td width=100%>" + dt.Rows[i]["Favourites"] + "</td>";
            showUsers += "<td width=100%>" + dt.Rows[i]["Requests"] + "</td>";
            if (dt.Rows[i]["IsAdmin"].ToString().ToLower() == "true")
                showUsers += "<td width=100%>" + "יש" + "</td>";
            else
                showUsers += "<td width=100%>" + "אין" + "</td>";
            showUsers += "<td width=100%>" + dt.Rows[i]["DateCreated"] + "</td>";
            if (dt.Rows[i]["IsAdmin"].ToString().ToLower() == "true")
                showUsers += "<td>מחק";
            else
                showUsers += "<td><a href='RemoveUser.aspx?idNum=" + dt.Rows[i]["ID"] + "'>מחק</a>";
            showUsers += "&nbsp<a href='EditUser.aspx?idNum=" + dt.Rows[i]["ID"] + "'>ערוך</a></td>";
        }
        showUsers += "</table>";
    }
}