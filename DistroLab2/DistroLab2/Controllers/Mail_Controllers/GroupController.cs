using DistroLab2.Models.Mail_Models;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistroLab2.Controllers.Mail_Controllers
{
    /// <summary>
    /// The GroupController acts as a controller for the group actions.
    /// </summary>
    [Authorize]
    public class GroupController : Controller
    {
        /// <summary>
        /// Clears the EditGroup view and returns it.
        /// </summary>
        /// <returns> the EditGroup view.</returns>
        public ActionResult EditGroup()
        {
            ModelState.Clear();
            return View("EditGroup");
        }

        /// <summary>
        /// Clears the ListGroups view and returns it.
        /// </summary>
        /// <returns> the ListGroups view.</returns>
        public ActionResult ListGroups()
        {
            ModelState.Clear();
            return View("ListGroups");
        }

        /// <summary>
        /// Makes a add user to group call and then returns a ListGroups view.
        /// </summary>
        /// <param name="GroupListName"> the group name.</param>
        /// <returns> a ListGroups view.</returns>
        [HttpPost]
        public ActionResult JoinGroup(string GroupListName)
        {
            if (GroupListName == null || GroupListName.Equals(""))
            {
                ModelState.Clear();
                return View("ListGroups");

            }

            GroupModel gm = new GroupModel();
            gm.JoinGroup(GroupListName, User.Identity.Name);

            ModelState.Clear();
            return View("ListGroups");
        }

        /// <summary>
        /// Makes a leave group call and then returns a EditGroup view.
        /// </summary>
        /// <param name="GroupList"> the group name.</param>
        /// <returns> a EditGroup view.</returns>
        [HttpPost]
        public ActionResult LeaveGroup(string GroupList)
        {
            if (GroupList == null || GroupList.Equals(""))
            {
                ModelState.Clear();
                return View("EditGroup");

            }

            GroupModel gm = new GroupModel();
            gm.LeaveGroup(GroupList, User.Identity.Name);

            ModelState.Clear();
            return View("EditGroup");
        }

        /// <summary>
        /// Makes a create group call and then returns a EditGroup view.
        /// </summary>
        /// <param name="GroupBox"> the group name.</param>
        /// <returns> a EditGroup view.</returns>
        [HttpPost]
        public ActionResult AddGroup(string GroupBox)
        {
            GroupModel gm = new GroupModel();
            gm.AddGroup(GroupBox, User.Identity.Name);

            ModelState.Clear();
            return View("EditGroup");
        }

        /// <summary>
        /// Gets all the groups for a user.
        /// </summary>
        /// <param name="username"> The users username.</param>
        /// <returns> all the groups the user belongs to.</returns>
        public static GroupViewModel[] getGroups(string username)
        {
            GroupModel gm = new GroupModel();
            return gm.getUserGroups(username);
        }

        /// <summary>
        /// Gets all the groups for a user.
        /// </summary>
        /// <param name="username"> The users username.</param>
        /// <returns> all the groups the user belongs to.</returns>
        public static GroupViewModel[] getAllGroups(string username)
        {
            GroupModel gm = new GroupModel();
            return gm.getAllGroups(username);
        }
    }
}