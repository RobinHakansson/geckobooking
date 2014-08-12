using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoDAL
{
    public class CourtDB
    {
        private static readonly GeckoContainer Context = DB.Context;

        private static IEnumerable<Court> GetAllNotDeletedCourts()
        {
            return Context.Courts.Where(c => !c.IsDeleted);
            //return Context.Courts.Where(Hej);
        }

        //Illustrating lambda-expression
        //private static bool Hej(Court c)
        //{
        //    return !c.IsDeleted;
        //}

        public static List<Court> GetAllCourts()
        {
            return GetAllNotDeletedCourts().ToList();
        }

        public static Court GetCourtById(int id)
        {
            Court result = GetAllNotDeletedCourts().Where(c => c.Id == id).SingleOrDefault();
            return result;
        }

        public static List<Court> GetAllOccupiedCourtsByDateTime(DateTime dt)
        {
            List<Session> listSession = SessionDB.GetAllSessionsByDateTime(dt);
            IEnumerable<int> occupiedCourtID = listSession.Select(s => s.CourtId);

            List<Court> result = GetAllNotDeletedCourts().Where(c => occupiedCourtID.Contains(c.Id)).ToList();
            return result;
        }

        public static List<Court> GetAllAvailableCourtsByDateTime(DateTime dt)
        {
            List<Session> listSession = SessionDB.GetAllSessionsByDateTime(dt);
            IEnumerable<int> occupiedCourtID = listSession.Select(s => s.CourtId);

            List<Court> result = GetAllNotDeletedCourts().Where(c => !occupiedCourtID.Contains(c.Id)).ToList();
            return result;
        }

        public static bool[] CourtVacancyByDatetime(DateTime date)
        {
            List<Session> listSession = SessionDB.GetAllSessionsByDateTime(date);
            IEnumerable<int> occupiedCourtID = listSession.Select(s => s.CourtId);

            var result = GetAllNotDeletedCourts().Select(c => !occupiedCourtID.Contains(c.Id)).ToArray();
            return result;
        }
    }
}
