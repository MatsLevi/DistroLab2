using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class InboxViewModelWrapper
    {
        private InboxViewModel[] inboxVMs;
        private StatisticsViewModel svm;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="inboxVMs"></param> InboxViewModel array containing inboxVMs
        /// <param name="svm"></param> StatisticsViewModel containing statistics data
        public InboxViewModelWrapper(InboxViewModel[] inboxVMs, StatisticsViewModel svm)
        {
            this.inboxVMs = inboxVMs;
            this.svm = svm;
        }

        /// <summary>
        /// Getter for array of InboxViewModels
        /// </summary>
        public InboxViewModel[] InboxVMs
        {
            get
            {
                return inboxVMs;
            }
        }

        /// <summary>
        /// Getter for the StatisticsViewModel
        /// </summary>
        public StatisticsViewModel Svm
        {
            get
            {
                return svm;
            }
        }
    }
}