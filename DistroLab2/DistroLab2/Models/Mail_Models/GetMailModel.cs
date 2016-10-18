﻿using DistroLab2.Database;
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
                msgs[i] = new InboxViewModel(messages[i].title, messages[i].timestamp);
            }

            return msgs;
        }
    }
}