using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    /// <summary>
    /// The GetUsers acts as a connector to the DatabaseContext when getting users.
    /// </summary>
    public class GetUsers
    {
        /// <summary>
        /// Gets all users in the database.
        /// </summary>
        /// <returns> all users in the database.</returns>
        public static User[] getAllUsers()
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("\n\nDB Users:");
                    foreach (User usr in db.Users.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("User id: " + usr.userId + " name: " + usr.name + " removed messages: " + usr.removedMess);
                        System.Diagnostics.Debug.WriteLine("Total messages: " + usr.totalMess + " read messages: " + usr.readMess);
                        System.Diagnostics.Debug.WriteLine("last login: " + usr.lastLogin + " total login: " + usr.totalMonthLogin + " month: " + usr.currentMonth);
                    }

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

        /// <summary>
        /// Returns the specified users name.
        /// </summary>
        /// <param name="id"> the specified users id.</param>
        /// <returns> the specified users name.</returns>
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

        /// <summary>
        /// Updates the users last login timestamp as well as increments the total amount 
        /// of logins this month. If a new month has started the total amount of logins is 
        /// reset.
        /// </summary>
        /// <param name="username"> the users username.</param>
        /// <returns> true if the update was successful. Month reset is not counted as a failure.</returns>
        public static bool updateUserInformation(string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();

                    int oldMonth = user.currentMonth;
                    int newMonth = DateTime.Now.Month;

                    if(oldMonth != newMonth)
                    {
                        user.totalMonthLogin = 1;
                        db.Users.Attach(user);
                        db.Entry(user).Property(e => e.totalMonthLogin).IsModified = true;
                        db.SaveChanges();

                        user.currentMonth = newMonth;
                        db.Users.Attach(user);
                        db.Entry(user).Property(e => e.currentMonth).IsModified = true;
                        db.SaveChanges();

                        user.lastLogin = DateTime.Now.ToString();
                        db.Users.Attach(user);
                        db.Entry(user).Property(e => e.lastLogin).IsModified = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        user.totalMonthLogin = user.totalMonthLogin + 1;
                        db.Users.Attach(user);
                        db.Entry(user).Property(e => e.totalMonthLogin).IsModified = true;
                        db.SaveChanges();

                        user.lastLogin = DateTime.Now.ToString();
                        db.Users.Attach(user);
                        db.Entry(user).Property(e => e.lastLogin).IsModified = true;
                        db.SaveChanges();
                    }

                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to update user information user!");
                    return false;
                }
            }
        }
    }
}