using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseOperations
/// </summary>
public class DatabaseOperations
{
    private string sql_command;

    public DatabaseOperations() { }

    //public DatabaseOperations(string custom_sql_command)
    //{
    //    SQL_Command = custom_sql_command;
    //}

    public string SQL_Command { set { sql_command = value; } }

    public string GetAllUsers()
    {
        return "SELECT * FROM Users";
    }



}