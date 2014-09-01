﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoDAL
{
    public partial class Session
    {
        public Session()
        {
            
        }

        public Session(Court court, DateTime startDateTime)
        {
            Court = court;
            StartDateTime = startDateTime;
            EndDateTime = startDateTime.AddHours(1);

            int hours = (EndDateTime - startDateTime).Hours;
            if (hours >= 0)
            {
                SessionCost = court.HourlyFee * hours;
            }
            
        }
    }

    public class SessionDB
    {
        private static readonly GeckoContainer Context = DB.Context;

        private static IEnumerable<Session> GetAllNotDeletedSessions()
        {
            return Context.Sessions.Where(s => !s.IsDeleted);           
        }

        public static List<Session> GetAllSessionsByDateTime(DateTime dt)
        {
            var result = GetAllNotDeletedSessions().Where(s => s.StartDateTime <= dt && s.EndDateTime >= dt).ToList();
            return result;
        }

        public static List<Session> GetAllOccupiedSessionsByCourtAndDate(int cid, DateTime date)
        {
            var result = GetAllNotDeletedSessions()
                .Where(s => s.CourtId == cid && s.StartDateTime <= date && s.EndDateTime >= date)
                .OrderBy(s => s.StartDateTime).ToList();
            return result;
        }

        public static List<Session> GetAllSessionsByBookingId(int bid)
        {
            var result = GetAllNotDeletedSessions()
                .Where(s => s.BookingId == bid)
                .OrderBy(s => s.StartDateTime).ToList();
            return result;
        }
    }
}
