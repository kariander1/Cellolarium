using System;
using System.Collections.Generic;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Data;



public class DalBll
{

    //התחברות לבסיס נתונים
    public static SqlConnection GetConnection()
    {
        string path = HttpContext.Current.Server.MapPath("~/app_data/DataBase.mdf");
        string connStr = string.Format(@"Data Source=.\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;User Instance=True", path);
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();

        return conn;
    }




    public static bool IsExist(SqlConnection conn, string sql)
    {

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader data = cmd.ExecuteReader();
        if (data.Read())
        {
            data.Close();
            conn.Close();
            return true;
        }
        data.Close();
        conn.Close();
        return false;

    }

    public static void DoQuery(SqlConnection conn, string sql)
    {

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }


    public static SqlDataReader DataReadSQL(SqlConnection conn, string sql)
    {
        //מחזיר רשומות ממסד הנתונים

        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader data1 = cmd.ExecuteReader();
        return data1;
    }


}

