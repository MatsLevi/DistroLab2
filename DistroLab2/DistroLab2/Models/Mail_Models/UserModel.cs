using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class UserModel
    {
        public UserModel()
        {

        }

        public bool updateLoginInformation(string username)
        {
            return GetUsers.updateUserInformation(username);
        }

        public IndexInfoViewModel getIndexViewModel(string username)
        {
            User[] users = GetUsers.getAllUsers();

            if(users == null)
            {
                return null;
            }

            User user = null;
            foreach (User s in users)
            {
                if (s.name == username)
                {
                    user = s;
                    break;
                }
            }

            ReceivedMessage[] receivedMessages = GetMessages.getReceivedMessages(user.userId);
            int unreadMessages = 0;

            foreach(ReceivedMessage rm in receivedMessages)
            {
                if (!rm.read)
                    unreadMessages++;
            }

            return new IndexInfoViewModel(username, user.lastLogin, user.totalMonthLogin, unreadMessages);
        }
    }
}