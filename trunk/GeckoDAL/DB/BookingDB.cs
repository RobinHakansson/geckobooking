using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoDAL
{
    public class BookingDB
    {
        private static readonly GeckoContainer Context = DB.Context;

        private static IEnumerable<Booking> GetAllNotDeletedBookings()
        {
            return Context.Bookings.Where(b => !b.IsDeleted);
        }

        public static Booking GetBookingById(int id)
        {
            Booking result = GetAllNotDeletedBookings().SingleOrDefault(b => b.Id == id);
            return result;
        }

        public static int AddBooking(Booking booking)
        {
            booking.BookingDate = DateTime.Now.ToString();
            Context.Bookings.Add(booking);
            int affectedRows = Context.SaveChanges();
            return affectedRows;
        }

    }
}