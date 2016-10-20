using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    /// <summary>
    /// The GetMessages acts as a connector to the DatabaseContext when getting mails.
    /// </summary>
    public class GetMessages
    {
        /// <summary>
        /// Gets all mails belonging to the specified user.
        /// </summary>
        /// <param name="username"> the specified users username.</param>
        /// <returns> all mails belonging to the specified user.</returns>
        public static Message[] getMessages(string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("\n\nDB Message:");
                    foreach (Message msg in db.Messages.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Message id: " + msg.messId + " sender id: " + msg.senderId + " timestamp: " + msg.timestamp );
                        System.Diagnostics.Debug.WriteLine("Message: " + msg.message + " title: " + msg.title);
                    }

                    System.Diagnostics.Debug.WriteLine("\n\nDB ReceivedMessage:");
                    foreach (ReceivedMessage rmsg in db.ReceivedMessages.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Message id: " + rmsg.messId + " user id: " + rmsg.userId + " read: " + rmsg.read);
                    }

                    User user = (from User in db.Users where User.name == username select User).First();
                    System.Diagnostics.Debug.WriteLine("User id: " + user.userId + " name: " + user.name);
                    ReceivedMessage[] receivedMessages = (from ReceivedMessage in db.ReceivedMessages where ReceivedMessage.userId == user.userId select ReceivedMessage).ToArray();
                    System.Diagnostics.Debug.WriteLine("receivedMessages length: " + receivedMessages.Length);

                    Message[] messages = new Message[receivedMessages.Length];

                    for (int i = 0; i < receivedMessages.Length; i++)
                    {
                        foreach (Message msg in db.Messages.ToArray())
                        {
                            if (msg.messId == receivedMessages[i].messId)
                            {
                                messages[i] = msg;
                                System.Diagnostics.Debug.WriteLine("Message " + i + ": " + messages[i].message);
                            }
                        }
                    }

                    return messages;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get all messages!");
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the specified mail and updates the specified users total read messages 
        /// as well as sets the message as read. 
        /// </summary>
        /// <param name="mailId"> the mail id.</param>
        /// <param name="username"> the specified users username.</param>
        /// <returns> the specified mail.</returns>
        public static Message getMessage(int mailId, string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    Message message = (from Message in db.Messages where Message.messId == mailId select Message).First();

                    User user = (from User in db.Users where User.name == username select User).First();
                    ReceivedMessage receivedMessage = (from ReceivedMessage in db.ReceivedMessages where ReceivedMessage.messId == mailId && ReceivedMessage.userId == user.userId select ReceivedMessage).First();

                    if (!receivedMessage.read)
                    {
                        user.readMess = user.readMess + 1;
                        db.Users.Attach(user);
                        db.Entry(user).Property(e => e.readMess).IsModified = true;
                        db.SaveChanges();

                        receivedMessage.read = true;
                        db.ReceivedMessages.Attach(receivedMessage);
                        db.Entry(receivedMessage).Property(e => e.read).IsModified = true;
                        db.SaveChanges();
                    }

                    return message;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get message!");
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets all rows in the ReceivedMessage table belonging to the specified user.
        /// </summary>
        /// <param name="userId"> the user id.</param>
        /// <returns> all rows in the ReceivedMessage table belonging to the specified user.</returns>
        public static ReceivedMessage[] getReceivedMessages(int userId)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    ReceivedMessage[] receivedMessage = (from ReceivedMessage in db.ReceivedMessages where ReceivedMessage.userId == userId select ReceivedMessage).ToArray();

                    return receivedMessage;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get received messages!");
                    return null;
                }
            }
        }
    }
}