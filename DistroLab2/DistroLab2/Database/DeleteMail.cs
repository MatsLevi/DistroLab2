using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    /// <summary>
    /// The DeleteMail acts as a connector to the DatabaseContext when deleting mails.
    /// </summary>
    public class DeleteMail
    {
        /// <summary>
        /// Deletes the specified mail from the specified user. The function also takes 
        /// care of updating the users removed message amount.
        /// </summary>
        /// <param name="mailId"> the mail id.</param>
        /// <param name="username"> the specified users username.</param>
        /// <returns> true if the mail was successfully deleted.</returns>
        public static bool deleteMail(int mailId, string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();
                    ReceivedMessage rm = (from ReceivedMessage in db.ReceivedMessages where ReceivedMessage.messId == mailId && ReceivedMessage.userId == user.userId select ReceivedMessage).First();

                    db.ReceivedMessages.Remove(rm);

                    user.removedMess = user.removedMess + 1;
                    db.Users.Attach(user);
                    db.Entry(user).Property(e => e.removedMess).IsModified = true;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to delete mail!");
                    return false;
                }
            }
        }
    }
}