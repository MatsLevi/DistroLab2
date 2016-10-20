using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model containing most group functionallity
    /// </summary>
    public class GroupModel
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public GroupModel()
        {

        }

        /// <summary>
        /// Function that retrives groupes the user is a member of
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> GroupViewModel array containing group information
        public GroupViewModel[] getUserGroups(string username)
        {
            Group[] groups = GroupConnector.getUserGroups(username);

            if(groups == null)
                return null;

            GroupViewModel[] groupVMs = new GroupViewModel[groups.Length];
            for (int i = 0; i < groups.Length; i++)
            {
                groupVMs[i] = new GroupViewModel(groups[i].groupId, groups[i].name);
            }

            return groupVMs;
        }

        /// <summary>
        /// Function that retrives all groups from the database, excluding the ones the user has allredy joined
        /// </summary>
        /// <param name="username"></param> string containing user username
        /// <returns></returns> GroupViewModel array containing gour information
        public GroupViewModel[] getAllGroups(string username)
        {
            Group[] groups = GroupConnector.getAllGroups(username);

            if (groups == null)
                return null;

            GroupViewModel[] groupVMs = new GroupViewModel[groups.Length];
            for (int i = 0; i < groups.Length; i++)
            {
                groupVMs[i] = new GroupViewModel(groups[i].groupId, groups[i].name);
            }

            return groupVMs;
        }

        /// <summary>
        /// Function that creates and adds a group in the database
        /// </summary>
        /// <param name="groupName"></param> string containing the name of the group
        /// <param name="creator"></param> string containing name of the creator
        /// <returns></returns> bool containing information wheter the registration succeeded or not
        public bool AddGroup(string groupName, string creator)
        {
            return GroupConnector.AddGroup(groupName, creator);
        }

        /// <summary>
        /// Function that deregisters a user from a group
        /// </summary>
        /// <param name="groupName"></param> string containing name of group
        /// <param name="username"></param> string containing username of user
        /// <returns></returns> bool containing information wheter leaving succeeded or not
        public bool LeaveGroup(string groupName, string username)
        {
            return GroupConnector.LeaveGroup(groupName, username);
        }

        /// <summary>
        /// Function that allowes a user to join a choosen group
        /// </summary>
        /// <param name="groupName"></param> string containing group name
        /// <param name="username"></param> string containing user username
        /// <returns></returns>
        public bool JoinGroup(string groupName, string username)
        {
            return GroupConnector.JoinGroup(groupName, username);
        }
    }
}