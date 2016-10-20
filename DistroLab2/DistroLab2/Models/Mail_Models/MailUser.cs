using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model that contains user data
    /// </summary>
    public class MailUser
    {
        private int id { get; set; }
        private string username { get; set; }
        private int removedMess { get; set; }
        private int totalMess { get; set; }
        private int readMess { get; set; }

        /// <summary>
        /// empty constructor
        /// </summary>
        public MailUser()
        {
            id = -1;
            username = null;
            removedMess = -1;
            totalMess = -1;
            readMess = -1;
        }

        /// <summary>
        /// constructor taking username input
        /// </summary>
        /// <param name="username"></param> string containing user username
        public MailUser(string username)
        {
            id = -1;
            this.username = username;
            removedMess = 0;
            totalMess = 0;
            readMess = 0;
        }

        /// <summary>
        /// Constructor taking multiple inputs
        /// </summary>
        /// <param name="id"></param> int containing user id
        /// <param name="username"></param> string containing user username
        /// <param name="removedMess"></param> int containing number of removed messages
        /// <param name="totalMess"></param> int containing total recieved messages
        /// <param name="readMess"></param> int containing number of read messages
        public MailUser(int id, string username, int removedMess, int totalMess, int readMess)
        {
            this.id = id;
            this.username = username;
            this.removedMess = removedMess;
            this.totalMess = totalMess;
            this.readMess = readMess;
        }

        /// <summary>
        /// Getter and setter for username
        /// </summary>
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