using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    public class GroupConnector
    {
        public static Group[] getUserGroups(string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();

                    GroupUser[] groupUsers = (from GroupUser in db.GroupUsers where GroupUser.userId == user.userId select GroupUser).ToArray();
                    Group[] groups = new Group[groupUsers.Length];

                    for(int i = 0; i < groupUsers.Length; i++)
                    {
                        groups[i] = (from Group in db.Groups where Group.groupId == groupUsers[i].groupId select Group).First();
                    }
                    
                    return groups;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get user groups!");
                    return null;
                }
            }
        }
    }
}