using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class InboxViewModelWrapper
    {
        private InboxViewModel[] inboxVMs;
        private StatisticsViewModel svm;

        public InboxViewModelWrapper(InboxViewModel[] inboxVMs, StatisticsViewModel svm)
        {
            this.inboxVMs = inboxVMs;
            this.svm = svm;
        }

        public InboxViewModel[] InboxVMs
        {
            get
            {
                return inboxVMs;
            }
        }

        public StatisticsViewModel Svm
        {
            get
            {
                return svm;
            }
        }
    }
}