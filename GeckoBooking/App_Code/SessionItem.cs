using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeckoDAL;

namespace GeckoBooking
{
    public class SessionItem
    {
        public SessionItem(DateTime date)
        {
            CourtVacancy = CourtDB.CourtVacancyByDatetime(date);

            SessionTime = date.TimeOfDay.ToString();
        }

        public string SessionTime { get; set; }
        public bool[] CourtVacancy { get; set; }

    }
}
