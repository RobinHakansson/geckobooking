using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeckoDAL;
using GeckoBooking;


namespace GeckoBooking
{
    public partial class Lab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataSource = CourtDB.GetAllCourts();
            //GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            List<SessionItem> sessions = new List<SessionItem>();

            for (int i = 8; i <= 18; i++)
            {
                DateTime date = DateTime.Parse(TextBox2.Text + " " + i + ":00:00");
                sessions.Add(new SessionItem(date));   
            }
            
            
            GridView1.DataSource = sessions;
            GridView1.DataBind();
        }
    }
}