using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeckoDAL;

namespace GeckoBooking
{
    class SessionItem
    {
        public SessionItem(DateTime date)
        {
            var courtVacancy = CourtDB.CourtVacancyByDatetime(date);

            SessionTime = date.TimeOfDay.ToString();
            Court1 = courtVacancy[0];
            Court2 = courtVacancy[1];
            Court3 = courtVacancy[2];
            Court4 = courtVacancy[3];

        }

        public string SessionTime { get; set; }
        public bool Court1 { get; set; }
        public bool Court2 { get; set; }
        public bool Court3 { get; set; }
        public bool Court4 { get; set; }

    }
}
