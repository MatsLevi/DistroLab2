using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistroLab2.Models.Mail_Models;

namespace DistroLab2.Database
{
    public class AddUser
    {
        public static bool registerUser(MailUser user)
        {
            using (var db = new DatabaseContext())
            {
                User usr = new Database.User {
                    name = user.Username, removedMess = 0, totalMess = 0,
                    readMess = 0, lastLogin = DateTime.Now.ToString(), totalMonthLogin = 1,
                    currentMonth = DateTime.Now.Month
                };

                try
                {
                    db.Users.Add(usr);
                    db.SaveChanges();
                    return true;
                } catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to register user!");
                    return false;
                }
            }
        }
    }
}