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
            return View("EditGroup");
        }

        public ActionResult EditGroupMail()
        {
            return View("EditGroup");
        }

        public static GroupViewModel[] getGroups(string username)
        {
            GroupModel gm = new GroupModel();
            return gm.getUserGroups(username);
        }
    }
}