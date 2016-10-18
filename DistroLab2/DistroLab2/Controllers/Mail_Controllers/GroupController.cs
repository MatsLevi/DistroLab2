using DistroLab2.Models.Mail_Models;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistroLab2.Controllers.Mail_Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        public ActionResult EditGroup()
        {
            ModelState.Clear();
            return View("EditGroup");
        }

        public ActionResult ListGroups()
        {
            ModelState.Clear();
            return View("ListGroups");
        }

        [HttpPost]
        public ActionResult LeaveGroup(string GroupList)
        {
            System.Diagnostics.Debug.WriteLine("Entered LeaveGroup");
            System.Diagnostics.Debug.WriteLine("GroupList: " + GroupList);

            if (GroupList == null || GroupList.Equals(""))
            {
                System.Diagnostics.Debug.WriteLine("GroupList: empty");
                return View("EditGroup");

            }

            GroupModel gm = new GroupModel();
            gm.LeaveGroup(GroupList, User.Identity.Name);

            ModelState.Clear();
            return View("EditGroup");
        }

        [HttpPost]
        public ActionResult AddGroup(string GroupBox)
        {
            System.Diagnostics.Debug.WriteLine("Entered AddGroup");
            System.Diagnostics.Debug.WriteLine("GroupBox: " + GroupBox);

            GroupModel gm = new GroupModel();
            gm.AddGroup(GroupBox, User.Identity.Name);

            ModelState.Clear();
            return View("EditGroup");
        }

        public static GroupViewModel[] getGroups(string username)
        {
            GroupModel gm = new GroupModel();
            return gm.getUserGroups(username);
        }
    }
}