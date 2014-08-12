using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoDAL
{
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

        public static List<Session> GetAllSessionsByCourtAndDate(int cid, DateTime date)
        {
            var result = GetAllNotDeletedSessions()
                .Where(s => s.CourtCourtID == cid && s.StartDateTime <= date && s.EndDateTime >= date)
                .OrderBy(s => s.StartDateTime).ToList();
            return result;
        }
    }
}
