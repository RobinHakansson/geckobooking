using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeckoDAL;

namespace GeckoBooking.Pages
{
    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateUserBookingTable();
        }

        public void CreateUserBookingTable()
        {
            UserName.Text = string.Format("UserName: {0}", UserDB.GetUserById(1).UserName);
            foreach (var booking in BookingDB.GetBookingsByUserId(1))
            {
                TableHeaderRow tbHeaderRow = new TableHeaderRow() { };

                TableHeaderCell tbHeaderCell = new TableHeaderCell() { Text = string.Format("<b>Booking id:</b> {0}", booking.Id), ColumnSpan = 6 };

                tbHeaderRow.Cells.Add(tbHeaderCell);
                MyBookingsTable.Rows.Add(tbHeaderRow);


                TableHeaderRow tbHeaderRowSession = new TableHeaderRow();
                tbHeaderRowSession.Cells.Add(new TableHeaderCell() { Text = "Selected" });
                tbHeaderRowSession.Cells.Add(new TableHeaderCell() { Text = "Session Id", CssClass = "no-spacing-right" });
                tbHeaderRowSession.Cells.Add(new TableHeaderCell() { Text = "Date" });
                tbHeaderRowSession.Cells.Add(new TableHeaderCell() { Text = "Time" });
                tbHeaderRowSession.Cells.Add(new TableHeaderCell() { Text = "Court" });
                tbHeaderRowSession.Cells.Add(new TableHeaderCell() { Text = "Session Cost" });
                MyBookingsTable.Rows.Add(tbHeaderRowSession);

                foreach (var session in SessionDB.GetAllSessionsByBookingId(booking.Id))
                {
                    TableRow trSession = new TableRow();
                    SessionItemCheckBox cb = new SessionItemCheckBox() {ID = session.Id.ToString() ,Session = session  };
                    TableCell tbCell = new TableCell();
                    ((IParserAccessor)tbCell).AddParsedSubObject(cb);

                    trSession.Cells.Add(tbCell);
                    trSession.Cells.Add(new TableCell() { Text = session.Id.ToString(), CssClass = "no-spacing-right" });
                    trSession.Cells.Add(new TableCell() { Text = session.StartDateTime.ToShortDateString() });
                    trSession.Cells.Add(new TableCell()
                    {
                        Text = session.StartDateTime.ToShortTimeString() + "-" + session.EndDateTime.ToShortTimeString()
                    });
                    trSession.Cells.Add(new TableCell() { Text = session.Court.Name + session.CourtId });
                    trSession.Cells.Add(new TableCell() { Text = session.SessionCost.ToString() });
                    MyBookingsTable.Rows.Add(trSession);

                }

                TableRow tbRow = new TableRow();
                tbRow.Cells.Add(new TableCell() { Text = "<hr>", ColumnSpan = 6 });

                MyBookingsTable.Rows.Add(tbRow);
            }
        }

        public void CancelSession_OnClick(object sender, EventArgs e)
        {
            IEnumerable<Control> cbList = GetAllControls(MyBookingsTable);

            var enumerable = cbList as IList<Control> ?? cbList.ToList();


            foreach (var ctrl in enumerable)
            {
                if (ctrl.GetType() == typeof(SessionItemCheckBox))
                {

                    var sessionItemCheckBox = (SessionItemCheckBox)ctrl;
                    if (sessionItemCheckBox.Checked == true)
                    {
                        Session session = sessionItemCheckBox.Session;
                        SessionDB.DeleteSessionById(session.Id);
                    }
                }
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
    }
    public class SessionItemCheckBox : CheckBox
    {
        public Session Session { get; set; }
    }
}