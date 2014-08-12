using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using GeckoDAL;

public partial class Pages_Lab : System.Web.UI.Page
{
    
        
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = string.Empty;
        Label2.Text = string.Empty;
        Label3.Text = string.Empty;


        GridView1.DataSource = CourtDB.GetAllCourts();
        GridView1.DataBind();

        //Label1.Text = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;

        //PBKDF2 bytes = new PBKDF2();
        //string crvt = Convert.ToBase64String(bytes.GetBytes("123456", System.Text.Encoding.UTF8.GetBytes("Salt"), 2000, 64));
        //foreach(byte i in bytes.GetBytes("123456", System.Text.Encoding.UTF8.GetBytes("Salt"), 2000, 64))
        //{

        //Label2.Text += i.ToString()+" " ;
        //}
        //Label3.Text += crvt;



//        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
//        string selectSQL = @"
//SELECT		*
//			
//FROM        Users";
//        SqlCommand com = new SqlCommand(selectSQL, conn);

//        List<string> names;

//        try
//        {
//            conn.Open();
//            names = new List<string>();
//            using (SqlDataReader read = com.ExecuteReader())
//            {
//                while (read.Read())
//                {
//                    string s = read.IsDBNull(1) ? "" : read.GetString(1);                    
//                    names.Add(s);
//                }
//            }
//        }
//        finally
//        {
//            conn.Close();
//        }

//        foreach(string i in names)
//        {
//            Label1.Text += i + " ";
//        }


        
    }

    DataSet dSet;
    DataRow dRow;

    int MaxRows;

    //Set the ColumnNr to take data from
    int inc = 6;

    protected void Button1_Click(object sender, EventArgs e)
    {        

        try
        {
            dSet = new DataRetrieval("All Users").DataSet();

            MaxRows = dSet.Tables[0].Rows.Count;

            Label1.Text = dSet.Tables[0].Columns[inc].ColumnName+": ";

            for (int i = 0; i < MaxRows; i++)
            {
                dRow = dSet.Tables[0].Rows[i];
                Label1.Text += dRow.ItemArray.GetValue(inc).ToString() + " ";
            }
            string usn = dSet.Tables[0].Rows[0].ItemArray.GetValue(1).ToString();
            string pw = dSet.Tables[0].Rows[0].ItemArray.GetValue(6).ToString();
            string pwsalt = dSet.Tables[0].Rows[0].ItemArray.GetValue(7).ToString();

            Label1.Text = "Username: " + usn + "<br />" + "pw: " + pw + "<br />" + "pwsalt: " + pwsalt;

            string enc = Convert.ToBase64String(new PBKDF2().GetBytes(TextBox1.Text, pwsalt, 200000, 64));

            Label3.Text = "Encoded: " + enc;

            if (pw == enc)
            {
                Label4.Text = "Access Granted";
                Label4.Attributes.CssStyle.Add("color", "green");
                Label4.Attributes.CssStyle.Add("font-size", "25px");
            }
            else
            {
                Label4.Text = "Access Denied";
                Label4.Attributes.CssStyle.Add("color", "red");
                Label4.Attributes.CssStyle.Add("font-size", "25px");
            }


            //Label2.Text = "Clear Password: " + TextBox1.Text;

            //Label3.Text = "Encoded: " + Convert.ToBase64String(new PBKDF2().GetBytes(TextBox1.Text, System.Text.Encoding.UTF8.GetBytes("Salt"), 2000, 64));


        }
        catch (Exception err)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "CatchMsg", "$(document).ready(function(){ console.error('Error ', '"+err.Message+"'); });", true);
        }
    }
}