using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace GeckoDAL
{
    public partial class User
    {
        public override string ToString()
        {
            string result = string.Format("UserID: {0}", Id);
            result += string.Format("\r\nFirstName: {0}", FirstName);
            result += string.Format("\r\nLastName: {0}", LastName);
            result += string.Format("\r\nEmail: {0}", Email);
            result += string.Format("\r\nPhone: {0}", Phone);
            return result;
        }
    }

    public class UserDB
    {
        private static readonly GeckoContainer Context = DB.Context;


        private static IEnumerable<User> GetAllNotDeletedUsers()
        {
            return Context.Users.Where(u => !u.IsDeleted);
        }

        public static List<User> GetAllUsers() //only non-deleted users
        {
            //IEnumerable<User> query = Context.Users.Where(u => !u.IsDeleted);
            
            //IEnumerable<User> query = from u in Context.Users
            //                          where !u.IsDeleted
            //                          select u;

            //List<User> result = query.ToList();  
          
            return GetAllNotDeletedUsers().ToList();
        }

        public static List<User> GetUsersWithLetterLInLastName()
        {
            List<User> result = GetAllNotDeletedUsers().Where(u => u.LastName.ToUpper().Contains("L")).ToList();
            return result;
        }
        
        //Find connectionString in App.config (without EF)
        //private static readonly string geckoConnectionString = ConfigurationManager.ConnectionStrings["GeckoDB"].ToString();

        //public static List<User> GetUsersWithLetterLInLastNameNotEF()
        //{
        //    //when using closes then the connection will close too
        //    using (SqlConnection connection = new SqlConnection(geckoConnectionString))
        //    {
        //        connection.Open();

        //        StringBuilder sqlquery = new StringBuilder("SELECT [Id],[FirstName],[LastName],[Email],[Phone],[IsDeleted]");
        //        sqlquery.Append("FROM [dbo].[Users]");
        //        sqlquery.Append("WHERE [LastName] LIKE '%L%' OR [LastName] LIKE '%l%'");

        //        using (SqlCommand command = new SqlCommand(sqlquery.ToString(), connection))
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            DataSet dataset = new DataSet();

        //            adapter.Fill(dataset);

        //            List<User> result = new List<User>();
        //            if (dataset.Tables[0].Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
        //                {
        //                    DataRow row = dataset.Tables[0].Rows[i];
        //                    User user = new User() { 
        //                        Id = int.Parse(row["Id"].ToString().Trim()), //Trim removes blanks before and after
        //                        FirstName = row["FirstName"].ToString().Trim(),
        //                        LastName = row["LastName"].ToString().Trim(),
        //                        Email = row["Email"].ToString().Trim(),
        //                        Phone = row["Phone"].ToString().Trim(),
        //                        IsDeleted = (row["IsDeleted"].ToString().Trim() == "1")
        //                    };
        //                    result.Add(user);
        //                }
        //            }
        //            return result;
        //        }
        //    }
        //}

        public static User GetUserById(int id)
        {
            var result = GetAllNotDeletedUsers().Where(u => u.Id == id).SingleOrDefault();
            return result;
        }

        public static User AddUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return user;
        }

        public static int UpdateUser(User user)
        {
            User userToUpdate = GetUserById(user.Id);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Phone = user.Phone;

            int affectedRows = Context.SaveChanges();
            return affectedRows;            
        }

        public static int DeleteUserById(int id)
        {
            User userToDelete = GetUserById(id);

            if (userToDelete != null)
            {
                userToDelete.IsDeleted = true;
            }

            int affectedRows = Context.SaveChanges();
            return affectedRows;  
        }
    }
}
