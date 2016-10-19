using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class StatisticsViewModel
    {
        private int removedMess;
        private int totalMess;
        private int readMess;

        public StatisticsViewModel(int removedMess, int totalMess, int readMess)
        {
            this.removedMess = removedMess;
            this.totalMess = totalMess;
            this.readMess = readMess;
        }

        public int RemovedMess
        {
            get
            {
                return removedMess;
            }
        }

        public int TotalMess
        {
            get
            {
                return totalMess;
            }
        }

        public int ReadMess
        {
            get
            {
                return readMess;
            }
        }
    }
}