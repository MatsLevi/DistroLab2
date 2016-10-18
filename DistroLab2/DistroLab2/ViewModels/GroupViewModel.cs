using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    public class GroupViewModel
    {
        private int groupId;
        private string groupName;

        public GroupViewModel(int groupId, string groupName)
        {
            this.groupId = groupId;
            this.groupName = groupName;
        }
    }
}