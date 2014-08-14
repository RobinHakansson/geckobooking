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
        public List<SessionItem> sessions = new List<SessionItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataSource = CourtDB.GetAllCourts();
            //GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            

            for (int i = 8; i <= 18; i++)
            {
                DateTime date = DateTime.Parse(TextBox2.Text + " " + i + ":00");
                sessions.Add(new SessionItem(date));   
            }
                        
            GridView1.DataSource = sessions;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                CheckBox checkB = (CheckBox)e.Row.FindControl("CheckBox1");

                int index = e.Row.RowIndex;

                if (sessions[index].CourtVacancy[0])
                {
                    checkB.Checked = true;
                }
                else {
                    checkB.Checked = false;
                }

            }
            else { 
            }
        }
    }
}