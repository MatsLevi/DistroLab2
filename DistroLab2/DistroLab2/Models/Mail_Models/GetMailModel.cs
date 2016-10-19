using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class GetMailModel
    {
        public GetMailModel()
        {

        }

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
                System.Diagnostics.Debug.WriteLine("msgs length: " + msgs.Length + " title: " + messages[i].title);
                msgs[i] = new InboxViewModel(messages[i].title, messages[i].timestamp, messages[i].messId);
            }

            return msgs;
        }

        public List<string> getAllMailSenders(string username)
        {
            System.Diagnostics.Debug.WriteLine("Getting serders of recieved mails");
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

        public SpecificMailViewModel getSpecificMail(int mailId, string username)
        {
            Message message = GetMessages.getMessage(mailId, username);
            string senderName = GetUsers.getUser(message.senderId);

            System.Diagnostics.Debug.WriteLine("senderName: " + senderName + " message: " + message.message + " title: " + message.title);

            return new SpecificMailViewModel(senderName, message.message, message.title);
        }
    }
}