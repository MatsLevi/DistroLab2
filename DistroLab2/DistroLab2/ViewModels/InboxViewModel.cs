using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class InboxViewModel
    {
        private string title;
        private string timestamp;

        public InboxViewModel(string title, string timestamp)
        {
            this.title = title;
            this.timestamp = timestamp;
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string TimeStamp
        {
            get
            {
                return timestamp;
            }
        }
    }
}