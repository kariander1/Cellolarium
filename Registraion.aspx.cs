using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registraion : System.Web.UI.Page
{
    public string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["sub"] != null)
        {
            string query;
            query = "SELECT * FROM Users WHERE ID = " + Request.Form["id"];
            if (DalBll.IsExist(DalBll.GetConnection(), query))
            {
                msg = "תעודת זהות קיימת כבר, אנא נסה שוב";

            }
            else 
            {

                DateTime dt = DateTime.Now;
                query = "INSERT INTO Users (ID,Fname,Lname,Password,Email,Gender,Favourites,Requests,IsAdmin,DateCreated) VALUES(";
                query += "'" + Request.Form["id"] + "'";
                query += ",N'" + Request.Form["first"] + "'";
                query += ",N'" + Request.Form["last"] + "'";
                query += ",N'" + Request.Form["pass"] + "'";
                query += ",'" + Request.Form["mail"] + "'";

                string g;

                g = Request.Form["gender"].ToString();
                if (g.Equals("זכר"))
                    query += ",N'" + "true" + "'";
                else
                    query += ",N'" + "false" + "'";


                query += ",N'" + Request.Form["sel"] + "'";
                query += ",N'" + Request.Form["req"] + "'";
                query += ",N'" + "false" + "'";
                query += ",N'" + dt.ToString() + "')";

                DalBll.DoQuery(DalBll.GetConnection(), query);

                msg = "הרשמה בוצעה בהצלחה";
            }
           
        }
    }
}