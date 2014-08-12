using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoDAL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // << CREATE >>
            //User user = new User();
            //user.UserID = 0;
            //user.FirstName = "Kalle";
            //user.LastName = "Anka";
            //user.Email = "kalle@anka.se";
            //user.Phone = "042-12345654";
            //user.IsDeleted = false;

            //UserDB.AddUser(user);
            
            // << UPDATE >>
            //User user = UserDB.GetUserById(1);

            //user.FirstName = "Pelle";
            //user.LastName = "Panna";

            //Console.WriteLine(UserDB.UpdateUser(user));

            List<User> users_1 = UserDB.GetUsersWithLetterLInLastNameNotEF();

            foreach (var item in users_1)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            List<Court> courts = CourtDB.GetAllAvailableCourtsByDateTime(new DateTime(2014,08,05,10,00,00));
            foreach (var item in courts)
            {
                Console.WriteLine("CourtID: {0}, Courtname: {1}", item.CourtID, item.Name);
            }

            // << DELETE >>
            //Console.WriteLine(UserDB.DeleteUserById(2));
 
            // << READ >>
            //List<User> users = UserDB.GetAllUsers();

            //foreach (var item in users)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}

           

            Console.ReadKey();
        }
    }
}
