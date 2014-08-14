using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeckoDAL;


namespace GeckoBooking
{

    public partial class Lab : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SessionItem.OpenTimeSpan.Hours; i++)
            {
                DateTime dateTime = DateTime.Parse(TextBox2.Text+" "+(SessionItem.DaySessionStartTime.Hour+i)+":00:00");
                SessionItem sessionItem = new SessionItem(dateTime);
                TableRow trRow = new TableRow();
                TableCell timeCell = new TableCell();
                timeCell.Text = sessionItem.SessionTime;
                trRow.Cells.Add(timeCell);
                for (int j = 0; j < CourtDB.GetAllCourts().Count; j++)
                {
                    TableCell tableCell = new TableCell();
                    trRow.Cells.Add(tableCell);

                    var checkBox = new CheckBox(){Checked = sessionItem.CourtVacancy[j]};

                    
                    ((IParserAccessor)tableCell).AddParsedSubObject(checkBox);
                }

                Table1.Rows.Add(trRow);
            }

        }

        //for (int i = 0; i < CourtDB.GetAllCourts().Count + 1; i++)
        //{
        //    var checkBoxField = new TemplateField();
        //    checkBoxField.ItemTemplate = new BookableCourtColumn();
        //    GridView1.Columns.Add(checkBoxField);
        //}

        //for (int i = 8; i <= 18; i++)
        //{
        //    DateTime date = DateTime.Parse(TextBox2.Text + " " + i + ":00");
        //    sessions.Add(new SessionItem(date));
        //    for (int j = 1; j < CourtDB.GetAllCourts().Count + 1; j++)
        //    {
        //        GridView1.Rows[i]
        //    }
        //}



        //GridView1.DataSource = sessions;
        //GridView1.DataBind();
    }

    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //if (e.Row.DataItem != null)
    //    //{
    //    //    CheckBox checkB = (CheckBox)e.Row.FindControl("CheckBox1");

    //    //    int index = e.Row.RowIndex;

    //    //    if (sessions[index].CourtVacancy[0])
    //    //    {
    //    //        checkB.Checked = true;
    //    //    }
    //    //    else {
    //    //        checkB.Checked = false;
    //    //    }

    //    //}
    //    //else { 
    //    //}
    //}
}
