using DistroLab2.Models.Mail_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    public class AddMail
    {
        public AddMail()
        {

        }

        public static bool RegisterMail(List<String> users, string MessageTitle, string msg, int userId)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    Message dbMsg = new Message { senderId = userId, timestamp = DateTime.Now.ToString(), message = msg, title = MessageTitle };
                    db.Messages.Add(dbMsg);
                    int[] receiveUserIds = new int[users.ToArray().Length];

                    for (int i = 0; i < users.ToArray().Length; i++)
                    {
                        string uName = users.ToArray()[i];
                        User user = (from User in db.Users where User.name == uName select User).First();
                        // dbMsg.messId ger prob fel id...
                        ReceivedMessage receivedMessage = new ReceivedMessage { messId = dbMsg.messId, userId = user.userId, read = false};
                        db.ReceivedMessages.Add(receivedMessage);
                    }

                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to register mail!");
                    return false;
                }
            }
        }
    }
}