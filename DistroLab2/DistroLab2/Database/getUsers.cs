using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    public class GetUsers
    {
        public static User[] getAllUsers()
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User[] users = db.Users.ToArray();
                    return users;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get all users!");
                    return null;
                }
            }
        }

        public static string getUser(int id)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.userId == id select User).First();
                    return user.name;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get user!");
                    return null;
                }
            }
        }
    }
}