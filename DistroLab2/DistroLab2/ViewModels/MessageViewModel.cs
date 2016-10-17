using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class MessageViewModel
    {
        private string timestamp;
        private int messId;
        private bool success;
        private string[] receivers;

        public MessageViewModel(string timestamp, int messId, bool success)
        {
            this.timestamp = timestamp;
            this.messId = messId;
            this.success = success;
        }

        public string Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        public int MessId
        {
            get
            {
                return messId;
            }
        }

        public bool Success
        {
            get
            {
                return success;
            }
        }

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