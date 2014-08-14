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

            SessionTime = date;
        }

        public DateTime SessionTime { get; set; }
        public bool[] CourtVacancy { get; set; }

        public static DateTime DaySessionStartTime = DateTime.Parse("08:00");
        public static DateTime DaySessionEndTime = DateTime.Parse("22:00");

        public static TimeSpan OpenTimeSpan
        {
            get { return DaySessionEndTime - DaySessionStartTime; }
        }
    }
}
