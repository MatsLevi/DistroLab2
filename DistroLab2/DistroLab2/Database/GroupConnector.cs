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
                    System.Diagnostics.Debug.WriteLine("DB Group:");
                    foreach (Group grp in db.Groups.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Group id: " + grp.groupId + " name: " + grp.name + " creator: " + grp.creator);
                    }

                    System.Diagnostics.Debug.WriteLine("\n\nDB GroupUser:");
                    foreach (GroupUser grpU in db.GroupUsers.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Group id: " + grpU.groupId + " User id: " + grpU.userId);
                    }

                    User user = (from User in db.Users where User.name == username select User).First();
                    System.Diagnostics.Debug.WriteLine("Successfully got user: " + user.name + " user id: " + user.userId);

                    GroupUser[] groupUsers = (from GroupUser in db.GroupUsers where GroupUser.userId == user.userId select GroupUser).ToArray();
                    System.Diagnostics.Debug.WriteLine("Successfully got groupUsers: " + groupUsers[0].groupId);
                    Group[] groups = new Group[groupUsers.Length];
                    System.Diagnostics.Debug.WriteLine("Successfully created group array: " + groups.Length);



                    for (int i = 0; i < groupUsers.Length; i++)
                    {
                        foreach(Group grp in db.Groups.ToArray())
                        {
                            if(grp.groupId == groupUsers[i].groupId)
                            {
                                groups[i] = grp;
                            }
                        }
                        
                        
                        
                        
                        
                        
                        //Group a = (from Group in db.Groups where Group.groupId == groupUsers[0].groupId select Group).First();
                        //System.Diagnostics.Debug.WriteLine("Got past: " + a.name);

                        //groups[i] = (from Group in db.Groups where Group.groupId == groupUsers[i].groupId select Group).First();
                        //System.Diagnostics.Debug.WriteLine("group user id: " + groupUsers[i].groupId);
                        //groups[i] = db.Groups.Where(u => u.groupId == groupUsers[i].groupId).First();
                        System.Diagnostics.Debug.WriteLine("Successfully added groups");
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

        public static bool AddGroup(string groupName, string groupCreator)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    Group group = new Group { name = groupName, creator = groupCreator };
                    db.Groups.Add(group);
                    db.SaveChanges();

                    // to get the generated id
                    group = (from Group in db.Groups where Group.name == groupName select Group).First();
                    User user = (from User in db.Users where User.name == groupCreator select User).First();

                    GroupUser groupUser = new GroupUser { groupId = group.groupId, userId = user.userId };
                    db.GroupUsers.Add(groupUser);
                    db.SaveChanges();

                    System.Diagnostics.Debug.WriteLine("DB Group:");
                    foreach (Group grp in db.Groups.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Group id: " + grp.groupId + " name: " + grp.name + " creator: " + grp.creator);
                    }

                    System.Diagnostics.Debug.WriteLine("\n\nDB GroupUser:");
                    foreach (GroupUser grpU in db.GroupUsers.ToArray())
                    {
                        System.Diagnostics.Debug.WriteLine("Group id: " + grpU.groupId + " User id: " + grpU.userId);
                    }

                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to add group!");
                    return false;
                }
            }
        }
    }
}