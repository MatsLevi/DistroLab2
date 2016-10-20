using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class MessageViewModel
    {
        private string timestamp;
        private int messId;
        private bool success;
        private string[] receivers;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="timestamp"></param> string containing mail timestamp
        /// <param name="messId"></param> int containing id of message
        /// <param name="success"></param> bool containing success information
        public MessageViewModel(string timestamp, int messId, bool success)
        {
            this.timestamp = timestamp;
            this.messId = messId;
            this.success = success;
        }

        /// <summary>
        /// Getter for mail timestamp
        /// </summary>
        public string Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        /// <summary>
        /// Getter for mail message id
        /// </summary>
        public int MessId
        {
            get
            {
                return messId;
            }
        }

        /// <summary>
        /// Getter for success
        /// </summary>
        public bool Success
        {
            get
            {
                return success;
            }
        }

        /// <summary>
        /// Getter and setter for mail recievers
        /// </summary>
        public string[] Receivers
        {
            get
            {
                return receivers;
            }
            set
            {
                receivers = value;
            }
        }
    }
}