using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class MailGroup
    {
        private int groupId;
        private string groupName;
        private string creatorName;

        public MailGroup(int groupId, string groupName, string creatorName)
        {
            this.groupId = groupId;
            this.groupName = groupName;
            this.creatorName = creatorName;
        }
    }
}