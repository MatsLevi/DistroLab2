using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class MailUserViewModel
    {
        private int id { get; set; }
        private string username { get; set; }
        private int removedMess { get; set; }
        private int totalMess { get; set; }
        private int readMess { get; set; }

        internal MailUserViewModel(int id, string username, int removedMess, int totalMess, int readMess)
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
        }

        public int ID
        {
            get
            {
                return id;
            }
        }
    }
}