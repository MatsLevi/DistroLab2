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

        public static Message RegisterMail(List<String> users, string MessageTitle, string msg, int userId)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    String time = DateTime.Now.ToString();
                    Message dbMsg = new Message { senderId = userId, timestamp = time, message = msg, title = MessageTitle };
                    db.Messages.Add(dbMsg);
                    db.SaveChanges();

                    for (int i = 0; i < users.ToArray().Length; i++)
                    {
                        dbMsg = (from Message in db.Messages where Message.senderId == userId && Message.timestamp == time && Message.message == msg && Message.title == MessageTitle select Message).First();
                        string uName = users.ToArray()[i];
                        User user = (from User in db.Users where User.name == uName select User).First();
                        ReceivedMessage receivedMessage = new ReceivedMessage { messId = dbMsg.messId, userId = user.userId, read = false};
                        db.ReceivedMessages.Add(receivedMessage);
                    }

                    db.SaveChanges();

                    System.Diagnostics.Debug.WriteLine("DB Messages:");
                    foreach (Message message in db.Messages.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Message id: " + message.messId + " sender id: " + message.senderId + " timestamp: " + message.timestamp);
                        System.Diagnostics.Debug.WriteLine("message: " + message.message + " title: " + message.title);
                    }

                    System.Diagnostics.Debug.WriteLine("\n\nDB ReceivedMessages:");
                    foreach (ReceivedMessage rm in db.ReceivedMessages.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Message id: " + rm.messId + " receiver id: " + rm.userId + " read: " + rm.read);
                    }

                    return dbMsg;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to register mail!");
                    return null;
                }
            }
        }

        public static Message RegisterGroupMail(string groupName, string MessageTitle, string msg, int userId)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    String time = DateTime.Now.ToString();
                    Group mailGroup = (from Group in db.Groups where Group.name == groupName select Group).First();

                    System.Diagnostics.Debug.WriteLine("Passed get group from database in AddMail");

                    GroupUser[] groupUsers = (from GroupUser in db.GroupUsers where GroupUser.groupId == mailGroup.groupId select GroupUser).ToArray();

                    System.Diagnostics.Debug.WriteLine("Passed get group users from database in AddMail");

                    User[] users = new User[groupUsers.Length];

                    System.Diagnostics.Debug.WriteLine("Just before for loop in AddMail");

                    for (int i = 0; i < groupUsers.Length; i++)
                    {
                       users[i] = (from User in db.Users where User.userId == groupUsers[i].userId select User).First();
                    }

                    System.Diagnostics.Debug.WriteLine("Passed get user loop from database in AddMail");

                    Message dbMsg = new Message { senderId = userId, timestamp = time, message = msg, title = MessageTitle };
                    db.Messages.Add(dbMsg);
                    db.SaveChanges();

                    System.Diagnostics.Debug.WriteLine("Passed add message in database in AddMail");

                    dbMsg = (from Message in db.Messages where Message.senderId == userId && Message.timestamp == time && Message.message == msg && Message.title == MessageTitle select Message).First();

                    System.Diagnostics.Debug.WriteLine("Passed finding message in db");

                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i].userId != userId)
                        {
                            ReceivedMessage receivedMessage = new ReceivedMessage { messId = dbMsg.messId, userId = users[i].userId, read = false };
                            db.ReceivedMessages.Add(receivedMessage);
                        }
                    }

                    db.SaveChanges();

                    System.Diagnostics.Debug.WriteLine("Passed storing messages in db");

                    return dbMsg;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to register group mail!");
                    return null;
                } 
            }
        }
    }
}