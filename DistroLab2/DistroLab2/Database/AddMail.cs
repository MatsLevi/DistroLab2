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
                Message dbMsg = new Message { senderId = userId, timestamp = DateTime.Now.ToString(), message = msg, title = MessageTitle };
                ReceivedMessage[] receivedMessages = new ReceivedMessage[users.ToArray().Length];
                int[] receiveUserIds = new int[users.ToArray().Length];

                for (int i = 0; i < users.ToArray().Length; i++)
                {
                    // dbMsg.messId ger prob fel id...
                    receivedMessages[i] = new ReceivedMessage { messId = dbMsg.messId  }
                }

                try
                {
                    db.Messages.Add(dbMsg);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to register user!");
                    return false;
                }
            }
        }
    }
}