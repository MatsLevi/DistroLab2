using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.ViewModels
{
    /// <summary>
    /// ViewModel used to forward data to the view
    /// </summary>
    public class GroupViewModel
    {
        private int groupId;
        private string groupName;

        /// <summary>
        /// Constructor for the ViewModel
        /// </summary>
        /// <param name="groupId"></param> int containing id of group 
        /// <param name="groupName"></param> string containing name of the group
        public GroupViewModel(int groupId, string groupName)
        {
            this.groupId = groupId;
            this.groupName = groupName;
        }

        /// <summary>
        /// Getter for name of group
        /// </summary>
        public string GroupName
        {
            get
            {
                return groupName;
            }
        }
    }
}