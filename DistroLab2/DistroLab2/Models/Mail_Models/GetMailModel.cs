using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model used to retrive mails from database
    /// </summary>
    public class GetMailModel
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public GetMailModel()
        {

        }

        /// <summary>
        /// Function that retrives all mails from a chosen sender from the database
        /// </summary>
        /// <param name="user"></param> string string containg user username
        /// <param name="sender"></param> string containing sender username
        /// <returns></returns> InboxViewModel array containing mail information
        public InboxViewModel[] getAllUserMailsFromSender(string user, string sender)
        {
            Message[] messages = GetMessages.getMessages(user);
            User[] users = GetUsers.getAllUsers();

            List<Message> listOfMessages = new List<Message>();

            int userId = -1;
            for(int i = 0; i < users.Length; i++)
            {
                if(users[i].name == sender)
                {
                    userId = users[i].userId;
                }
            }

            for(int i = 0; i < messages.Length; i++)
            {
                if(messages[i].senderId == userId)
                {
                    listOfMessages.Add(messages[i]);
                }
            }

            InboxViewModel[] IVMs = new InboxViewModel[listOfMessages.ToArray().Length];
            messages = listOfMessages.ToArray();

            for(int i = 0; i < listOfMessages.ToArray().Length; i++)
            {
                IVMs[i] = new InboxViewModel(messages[i].title, messages[i].timestamp, messages[i].messId);
            }

            return IVMs;
        }

        /// <summary>
        /// Function that retrives all users from the database apart from the user
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> MailUserViewModel array containing information regarding the users
        public MailUserViewModel[] getAllUsers(string username)
        {
            User[] dbUsers = GetUsers.getAllUsers();

            if (dbUsers == null)
            {
                return null;
            }

            List<User> userList = new List<User>();
            foreach(User s in dbUsers)
            {
                if (s.name != username)
                    userList.Add(s);
            }
            dbUsers = userList.ToArray();

            MailUserViewModel[] usrs = new MailUserViewModel[dbUsers.Length];
            for (int i = 0; i < usrs.Length; i++)
            {
                usrs[i] = new MailUserViewModel(dbUsers[i].userId, dbUsers[i].name, dbUsers[i].removedMess, dbUsers[i].totalMess, dbUsers[i].readMess);
            }

            return usrs;
        }

        /// <summary>
        /// Function that retrives all users from the database
        /// </summary>
        /// <returns></returns> MailUserViewModel array containing information regarding the users
        public MailUserViewModel[] getAllUsers()
        {
            User[] dbUsers = GetUsers.getAllUsers();

            if (dbUsers == null)
            {
                return null;
            }

            MailUserViewModel[] usrs = new MailUserViewModel[dbUsers.Length];
            for (int i = 0; i < usrs.Length; i++)
            {
                usrs[i] = new MailUserViewModel(dbUsers[i].userId, dbUsers[i].name, dbUsers[i].removedMess, dbUsers[i].totalMess, dbUsers[i].readMess);
            }

            return usrs;
        }

        /// <summary>
        /// Function that retrives all mails a user have been sent
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> InboxViewModel array containing message information
        public InboxViewModel[] getAllUserMails(string username)
        {
            Message[] messages = GetMessages.getMessages(username);

            if (messages == null)
            {
                return null;
            }

            InboxViewModel[] msgs = new InboxViewModel[messages.Length];
            for (int i = 0; i < msgs.Length; i++)
            {
                msgs[i] = new InboxViewModel(messages[i].title, messages[i].timestamp, messages[i].messId);
            }

            return msgs;
        }

        /// <summary>
        /// Function that retrives names of all users that have sent the user mails
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> List<string> containing sender usernames
        public List<string> getAllMailSenders(string username)
        {
            Message[] messages = GetMessages.getMessages(username);
            User[] dbUsers = GetUsers.getAllUsers();

            if (messages == null)
            {
                return null;
            }

            int[] sedersID = new int [messages.Length];
            List<string> senders = new List<string>();

            for (int i = 0; i < messages.Length; i++)
            {
                sedersID[i] = messages[i].senderId;
            }

            for (int i = 0; i < dbUsers.Length; i++)
            {
                for (int y = 0; y < messages.Length; y++)
                {
                    if (dbUsers[i].userId == sedersID[y])
                    {
                        senders.Add(dbUsers[i].name);
                        break;
                    }
                }
            }

            return senders;
        }

        /// <summary>
        /// Function that retrives a choosen mail from the database
        /// </summary>
        /// <param name="mailId"></param> int containing id of desiered mail
        /// <param name="username"></param> string containing username of user who recieved mail
        /// <returns></returns> SpecificMailViewModel containing mail
        public SpecificMailViewModel getSpecificMail(int mailId, string username)
        {
            Message message = GetMessages.getMessage(mailId, username);
            string senderName = GetUsers.getUser(message.senderId);

            return new SpecificMailViewModel(senderName, message.message, message.title);
        }
    }
}