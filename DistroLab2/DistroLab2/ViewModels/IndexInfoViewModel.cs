using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class IndexInfoViewModel
    {
        private string username;
        private string lastLogin;
        private int loginsThisMonth;
        private int unreadMails;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <param name="lastLogin"></param> string containing time of last login
        /// <param name="loginsThisMonth"></param> int containing number of logins this month
        /// <param name="unreadMails"></param> int containing number of unread mails the user has
        public IndexInfoViewModel(string username, string lastLogin, int loginsThisMonth, int unreadMails)
        {
            this.username = username;
            this.lastLogin = lastLogin;
            this.loginsThisMonth = loginsThisMonth;
            this.unreadMails = unreadMails;
        }

        /// <summary>
        /// Getter for user username
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }
        }

        /// <summary>
        /// Getter for last login
        /// </summary>
        public string LastLogin
        {
            get
            {
                return lastLogin;
            }
        }

        /// <summary>
        /// Getter for number of logins this month
        /// </summary>
        public int LoginsThisMonth
        {
            get
            {
                return loginsThisMonth;
            }
        }

        /// <summary>
        /// Getter for numbers of unread mails
        /// </summary>
        public int UnreadMails
        {
            get
            {
                return unreadMails;
            }
        }
    }
}