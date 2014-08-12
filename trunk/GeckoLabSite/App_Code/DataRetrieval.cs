using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DataRetrieval
/// </summary>
public class DataRetrieval
{
    DatabaseOperations operation = new DatabaseOperations();

    private string sql_string;

    private System.Data.SqlClient.SqlDataAdapter da_1;

    public DataRetrieval() { }

	public DataRetrieval(string sql)
	{
        switch (sql)
        {
            case "All Users":
                Sql = operation.GetAllUsers();
                break;

            default:
                Sql = string.Empty;
                break;                
        }

        //Sql = sql;
	}

    public string Sql
    {
        set { sql_string = value; }
    }



    public System.Data.DataSet DataSet()
    {        
        System.Data.SqlClient.SqlConnection con = new DatabaseConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString).GetConnection;
        System.Data.DataSet dat_set;

        con.Open();

        da_1 = new System.Data.SqlClient.SqlDataAdapter(sql_string, con);

        dat_set = new System.Data.DataSet();

        da_1.Fill(dat_set, "Table_Data_1");

        con.Close();


        return dat_set;
    }

}