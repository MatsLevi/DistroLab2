using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class GroupModel
    {
        public GroupModel()
        {

        }

        public GroupViewModel[] getUserGroups(string username)
        {
            Group[] groups = GroupConnector.getUserGroups(username);

            if (groups != null && groups.Length != 0) {
                foreach (Group g in groups)
                {
                    System.Diagnostics.Debug.WriteLine("Group: " + g.name);
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("User groups: failed");
            }

            if(groups == null)
                return null;

            GroupViewModel[] groupVMs = new GroupViewModel[groups.Length];
            for (int i = 0; i < groups.Length; i++)
            {
                groupVMs[i] = new GroupViewModel(groups[i].groupId, groups[i].name);
            }

            return groupVMs;
        }

        public bool AddGroup(string groupName, string creator)
        {
            return GroupConnector.AddGroup(groupName, creator);
        }

        public bool LeaveGroup(string groupName, string username)
        {
            return GroupConnector.LeaveGroup(groupName, username);
        }
    }
}