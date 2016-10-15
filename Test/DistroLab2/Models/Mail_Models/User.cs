using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class User
    {
        private int id { get; set; }
        private string username { get; set; }
        private int removedMess { get; set; }
        private int totalMess { get; set; }
        private int readMess { get; set; }

        internal User()
        {
            id = -1;
            username = null;
            removedMess = -1;
            totalMess = -1;
            readMess = -1;
        }

        internal User(string username)
        {
            id = -1;
            this.username = username;
            removedMess = -1;
            totalMess = -1;
            readMess = -1;
        }

        internal User(int id, string username, int removedMess, int totalMess, int readMess)
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