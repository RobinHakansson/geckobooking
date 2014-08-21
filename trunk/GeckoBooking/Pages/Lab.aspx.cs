using System;
using System.Collections.Generic;
using System.Drawing;
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
            CurrentDateLabel.Text = TextBox2.Text;

            var courts = CourtDB.GetAllCourts();

            TableHeaderRow tbHeaderRow = new TableHeaderRow();

            TableHeaderCell tbHeaderTimeCell = new TableHeaderCell();
            tbHeaderRow.Cells.Add(tbHeaderTimeCell);

            for (int i = 0; i < courts.Count; i++)
            {
                TableHeaderCell tbHeaderCell = new TableHeaderCell();
                tbHeaderCell.Text = courts[i].Name + " " + courts[i].Id;
                tbHeaderRow.Cells.Add(tbHeaderCell);
            }

            Table1.Rows.Add(tbHeaderRow);

            for (int i = 0; i < SessionItem.OpenTimeSpan.Hours; i++)
            {
                DateTime dateTime =
                    DateTime.Parse(TextBox2.Text + " " + (SessionItem.DaySessionStartTime.Hour + i) + ":00:00");
                SessionItem sessionItem = new SessionItem(dateTime);
                TableRow trRow = new TableRow();
                TableCell timeCell = new TableCell();
                timeCell.Text = sessionItem.SessionTime.ToShortTimeString().TrimEnd(':');
                trRow.Cells.Add(timeCell);
                for (int j = 0; j < courts.Count; j++)
                {

                    TableCell tableCell = new TableCell();
                    if (!sessionItem.CourtVacancy[j])
                    {
                        tableCell.BackColor = Color.FromArgb(1, 200, 50, 50);
                    }
                    else
                    {
                        tableCell.BackColor = Color.FromArgb(1, 0, 250, 0);
                    }
                    trRow.Cells.Add(tableCell);


                    var checkBox = new CheckBox()
                    {
                        Visible = sessionItem.CourtVacancy[j],
                        ID = courts[j].Id + "-" + sessionItem.SessionTime.ToShortTimeString().TrimEnd(':')
                    };

                    ((IParserAccessor) tableCell).AddParsedSubObject(checkBox);
                }
                Table1.Rows.Add(trRow);
            }
        }


        public static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control descendant in GetAllControls(control))
                {
                    yield return descendant;
                }
            }
        }

        protected void Button2_OnClick(object sender, EventArgs e)
        {
            Label5.Text = "Test: ";
            IEnumerable<Control> cbList = GetAllControls(Page);


            var enumerable = cbList as IList<Control> ?? cbList.ToList();



            foreach (var ctrl in enumerable)
            {
                if (ctrl.GetType() == typeof (CheckBox))
                {
                    Label5.Text += ctrl.ID + " ";
                }
            }


        }
    }
}
