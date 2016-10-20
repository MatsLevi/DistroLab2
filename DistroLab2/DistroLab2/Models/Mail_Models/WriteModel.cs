using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model that sends/registers mails to users
    /// </summary>
    public class WriteModel
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public WriteModel()
        {

        }

        /// <summary>
        /// Registers a mail on one or multiple users
        /// </summary>
        /// <param name="users"></param> List<string> containing user usernames
        /// <param name="title"></param> string containing title of mail
        /// <param name="message"></param> string containing message
        /// <param name="userId"></param> int containing sender id 
        /// <returns></returns> MessageViewModel containing message data
        public MessageViewModel registerMail(List<String> users, string title, string message, int userId)
        {
            Message msg = AddMail.RegisterMail(users, title, message, userId);

            if (msg == null)
                return null;

            return new MessageViewModel(msg.timestamp, msg.messId, true);
        }

        /// <summary>
        /// Registers a mail to users in a group
        /// </summary>
        /// <param name="group"></param> string containing user usernames
        /// <param name="title"></param> string containing title of mail
        /// <param name="message"></param> string containing message
        /// <param name="senderId"></param> int containing sender id 
        /// <returns></returns> bool containing information wheter the registration succeeded or not
        public bool registerGroupMail(string group, string title, string message, int senderId)
        {
            Message msg = AddMail.RegisterGroupMail(group, title, message, senderId);

            if (msg == null)
                return false;

            return true;
        }
    }
}