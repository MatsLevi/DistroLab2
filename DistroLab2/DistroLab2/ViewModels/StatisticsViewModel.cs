using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class StatisticsViewModel
    {
        private int removedMess;
        private int totalMess;
        private int readMess;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="removedMess"></param> int containing number of removed messages
        /// <param name="totalMess"></param> int containing number of total recieved messages
        /// <param name="readMess"></param> int containing number of read messages 
        public StatisticsViewModel(int removedMess, int totalMess, int readMess)
        {
            this.removedMess = removedMess;
            this.totalMess = totalMess;
            this.readMess = readMess;
        }

        /// <summary>
        /// Getter for number of removed messages
        /// </summary>
        public int RemovedMess
        {
            get
            {
                return removedMess;
            }
        }

        /// <summary>
        /// Getter for number of total messages
        /// </summary>
        public int TotalMess
        {
            get
            {
                return totalMess;
            }
        }

        /// <summary>
        /// Getter for number of read messages
        /// </summary>
        public int ReadMess
        {
            get
            {
                return readMess;
            }
        }
    }
}