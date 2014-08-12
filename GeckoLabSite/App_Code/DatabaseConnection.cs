using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DatabaseConnection creates the SqlConnection.
/// </summary>
public class DatabaseConnection
{
    private string strCon;

    public DatabaseConnection() { }

    public DatabaseConnection(string strCon)
    {
        Connection_string = strCon;
    }    

    public string Connection_string
    {
        set { strCon = value; }
    }

    public System.Data.SqlClient.SqlConnection GetConnection
    {
        get { return new System.Data.SqlClient.SqlConnection(strCon); }
    }


}