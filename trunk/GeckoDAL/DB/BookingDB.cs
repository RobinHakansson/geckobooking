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
    }
}
