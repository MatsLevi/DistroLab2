using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class SpecificMailViewModel
    {
        private string sender;
        private string message;
        private string title;

        public SpecificMailViewModel(string sender, string message, string title)
        {
            this.sender = sender;
            this.message = message;
            this.title = title;
        }

        public string Sender
        {
            get
            {
                return sender;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }
    }
}