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
        private int id;

        public InboxViewModel(string title, string timestamp, int id)
        {
            this.title = title;
            this.timestamp = timestamp;
            this.id = id;
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

        public int Id
        {
            get
            {
                return id;
            }
        }
    }
}