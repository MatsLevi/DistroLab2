using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class MailUserViewModel
    {
        private int id { get; set; }
        private string username { get; set; }
        private int removedMess { get; set; }
        private int totalMess { get; set; }
        private int readMess { get; set; }

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="id"></param> int containing user id
        /// <param name="username"></param> string containing user username
        /// <param name="removedMess"></param> int containing numbers of messages removed by the user
        /// <param name="totalMess"></param> int containing number of total messages user recieved
        /// <param name="readMess"></param> int containing number of messages read by the user
        internal MailUserViewModel(int id, string username, int removedMess, int totalMess, int readMess)
        {
            this.id = id;
            this.username = username;
            this.removedMess = removedMess;
            this.totalMess = totalMess;
            this.readMess = readMess;
        }

        /// <summary>
        /// Getter for username
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }
        }

        /// <summary>
        /// Getter for id
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
        }
    }
}