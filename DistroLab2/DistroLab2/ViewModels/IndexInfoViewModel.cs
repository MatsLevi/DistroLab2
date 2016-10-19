using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class IndexInfoViewModel
    {
        private string username;
        private string lastLogin;
        private int loginsThisMonth;
        private int unreadMails;

        public IndexInfoViewModel(string username, string lastLogin, int loginsThisMonth, int unreadMails)
        {
            this.username = username;
            this.lastLogin = lastLogin;
            this.loginsThisMonth = loginsThisMonth;
            this.unreadMails = unreadMails;
        }

        public string Username
        {
            get
            {
                return username;
            }
        }
        public string LastLogin
        {
            get
            {
                return lastLogin;
            }
        }
        public int LoginsThisMonth
        {
            get
            {
                return loginsThisMonth;
            }
        }
        public int UnreadMails
        {
            get
            {
                return unreadMails;
            }
        }
    }
}