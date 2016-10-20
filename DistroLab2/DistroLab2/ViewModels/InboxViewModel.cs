using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class InboxViewModel
    {
        private string title;
        private string timestamp;
        private int id;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="title"></param> string containing mail title
        /// <param name="timestamp"></param> string containing mail timestamp
        /// <param name="id"></param> int containing mail id
        public InboxViewModel(string title, string timestamp, int id)
        {
            this.title = title;
            this.timestamp = timestamp;
            this.id = id;
        }

        /// <summary>
        /// Getter for mail title
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
        }

        /// <summary>
        /// Getter for mail timestamp
        /// </summary>
        public string TimeStamp
        {
            get
            {
                return timestamp;
            }
        }

        /// <summary>
        /// Getter for mail id
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
        }
    }
}