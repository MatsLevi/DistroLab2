using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class MailUser
    {
        private int id { get; set; }
        private string username { get; set; }
        private int removedMess { get; set; }
        private int totalMess { get; set; }
        private int readMess { get; set; }

        internal MailUser()
        {
            id = -1;
            username = null;
            removedMess = -1;
            totalMess = -1;
            readMess = -1;
        }

        internal MailUser(string username)
        {
            id = -1;
            this.username = username;
            removedMess = 0;
            totalMess = 0;
            readMess = 0;
        }

        internal MailUser(int id, string username, int removedMess, int totalMess, int readMess)
        {
            this.id = id;
            this.username = username;
            this.removedMess = removedMess;
            this.totalMess = totalMess;
            this.readMess = readMess;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
    }
}