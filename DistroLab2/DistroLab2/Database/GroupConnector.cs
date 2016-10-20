using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    /// <summary>
    /// The GroupConnector acts as a connector to the DatabaseContext for the group calls.
    /// </summary>
    public class GroupConnector
    {
        /// <summary>
        /// Returns the groups the user belongs to.
        /// </summary>
        /// <param name="username"> the users username.</param>
        /// <returns>the groups the user belongs to.</returns>
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

                    GroupUser[] groupUsers = (from GroupUser in db.GroupUsers where GroupUser.userId == user.userId select GroupUser).ToArray();
                    Group[] groups = new Group[groupUsers.Length];

                    for (int i = 0; i < groupUsers.Length; i++)
                    {
                        foreach (Group grp in db.Groups.ToArray())
                        {
                            if (grp.groupId == groupUsers[i].groupId)
                            {
                                groups[i] = grp;
                            }
                        }
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

        /// <summary>
        /// Gets all the groups the user does not already belong to.
        /// </summary>
        /// <param name="username"> the users username.</param>
        /// <returns> all the groups the user does not already belong to.</returns>
        public static Group[] getAllGroups(string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();
                    GroupUser[] grpUsers = (from GroupUser in db.GroupUsers where GroupUser.userId == user.userId select GroupUser).ToArray();

                    List<Group> groups = new List<Group>();
                    bool add;

                    for (int i = 0; i < db.Groups.ToArray().Length; i++)
                    {
                        add = true;
                        foreach (GroupUser grpU in grpUsers)
                        {
                            if (db.Groups.ToArray()[i].groupId == grpU.groupId)
                                add = false;
                        }

                        if (add)
                            groups.Add(db.Groups.ToArray()[i]);

                        add = true;
                    }

                    return groups.ToArray();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to get all groups!");
                    return null;
                }
            }
        }

        /// <summary>
        /// Creates the specified group and adds the creator to it.
        /// </summary>
        /// <param name="groupName"> the group name.</param>
        /// <param name="groupCreator"> the group creator.</param>
        /// <returns> true if the group is successfully created and the user is added to it.</returns>
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

        /// <summary>
        /// Removes the specified user from the specified group.
        /// </summary>
        /// <param name="groupName"> the group name.</param>
        /// <param name="username"> the users username.</param>
        /// <returns> true if the user is successfully removed.</returns>
        public static bool LeaveGroup(string groupName, string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();
                    Group usersGroup = (from Group in db.Groups where Group.name == groupName select Group).First();

                    GroupUser groupUser = (from GroupUser in db.GroupUsers where GroupUser.groupId == usersGroup.groupId && GroupUser.userId == user.userId select GroupUser).First();

                    db.GroupUsers.Remove(groupUser);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to leave group!");
                    return false;
                }
            }
        }

        /// <summary>
        /// Adds the specified user to the specified group.
        /// </summary>
        /// <param name="groupName"> the group name.</param>
        /// <param name="username"> the users username.</param>
        /// <returns> true if the user is successfully added.</returns>
        public static bool JoinGroup(string groupName, string username)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    User user = (from User in db.Users where User.name == username select User).First();
                    Group selGroup = (from Group in db.Groups where Group.name == groupName select Group).First();

                    GroupUser groupUser = new GroupUser { groupId = selGroup.groupId, userId = user.userId };

                    db.GroupUsers.Add(groupUser);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to join group!");
                    return false;
                }
            }
        }
    }
}