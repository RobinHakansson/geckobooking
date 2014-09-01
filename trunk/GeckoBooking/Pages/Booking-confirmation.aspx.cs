using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeckoDAL;

namespace GeckoBooking
{
    public partial class Booking_confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelBooked.Text = "<b>This is your booking confirmation: </b><br/>";

            var currentBooking = Session["CurrentBooking"] as Booking;

            if (currentBooking != null)
            {
                //BookingDB.GetBookingById(currentBooking.Id);
                var sessionList = SessionDB.GetAllSessionsByBookingId(currentBooking.Id);

                LabelBooked.Text +=
                    string.Format("<br/><b>Booking Date:</b> {0}  <br/>Number of Sessions: {1} <br/>Total Cost: <b> {2} SEK</b>",
                        currentBooking.BookingDate.ToShortDateString(),
                        currentBooking.Session.Count,
                        currentBooking.TotalCost);

                foreach (Session s in sessionList)
                {
                    LabelSessions.Text += string.Format("<br/><br/>Start Time: {0} <br/>Court: {1} <br/>Session Cost: {2} SEK",
                        s.StartDateTime.ToShortTimeString(),
                        s.Court.Name + s.Court.Id,
                        s.SessionCost);
                }
            }
            else
            {
                LabelBooked.Text = "There is currently no booking to show";
            }
        }
    }
}