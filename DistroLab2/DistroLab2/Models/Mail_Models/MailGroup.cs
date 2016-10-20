using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model that contains group data
    /// </summary>
    public class MailGroup
    {
        private int groupId;
        private string groupName;
        private string creatorName;

        /// <summary>
        /// connstructor for class
        /// </summary>
        /// <param name="groupId"></param> int containing group id
        /// <param name="groupName"></param> string containing group name
        /// <param name="creatorName"></param> string containg username of creator
        public MailGroup(int groupId, string groupName, string creatorName)
        {
            this.groupId = groupId;
            this.groupName = groupName;
            this.creatorName = creatorName;
        }
    }
}