using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model used to update user information in database
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public UserModel()
        {

        }

        /// <summary>
        /// Updates last login timestamp in the database
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> bool containing information wheter the update succeeded or not
        public bool updateLoginInformation(string username)
        {
            return GetUsers.updateUserInformation(username);
        }

        /// <summary>
        /// Function that retrives information on index page
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> IndexInfoViewModel containg index data
        public IndexInfoViewModel getIndexViewModel(string username)
        {
            User[] users = GetUsers.getAllUsers();

            if (users == null)
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

            foreach (ReceivedMessage rm in receivedMessages)
            {
                if (!rm.read)
                    unreadMessages++;
            }

            return new IndexInfoViewModel(username, user.lastLogin, user.totalMonthLogin, unreadMessages);
        }

        /// <summary>
        /// Function that retrives message statistics
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> StatisticsViewModel containing statistics data
        public StatisticsViewModel getStatistics(string username)
        {
            User[] users = GetUsers.getAllUsers();

            if (users == null)
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

            return new StatisticsViewModel(user.removedMess, user.totalMess, user.readMess);
        }
    }
}