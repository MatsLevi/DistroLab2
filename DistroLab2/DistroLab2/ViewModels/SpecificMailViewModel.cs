using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class SpecificMailViewModel
    {
        private string sender;
        private string message;
        private string title;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="sender"></param> string containing sender username
        /// <param name="message"></param> string containing message
        /// <param name="title"></param> string containing message title
        public SpecificMailViewModel(string sender, string message, string title)
        {
            this.sender = sender;
            this.message = message;
            this.title = title;
        }

        /// <summary>
        /// Getter for sender username
        /// </summary>
        public string Sender
        {
            get
            {
                return sender;
            }
        }

        /// <summary>
        /// Getter for message
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
        }

        /// <summary>
        /// Getter for message title
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
        }
    }
}