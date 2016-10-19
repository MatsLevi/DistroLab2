using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class InboxViewModelWrapper
    {
        private InboxViewModel[] inboxVMs;

        public InboxViewModelWrapper(InboxViewModel[] inboxVMs)
        {
            this.inboxVMs = inboxVMs;
        }

        public InboxViewModel[] InboxVMs
        {
            get
            {
                return inboxVMs;
            }
        }
    }
}