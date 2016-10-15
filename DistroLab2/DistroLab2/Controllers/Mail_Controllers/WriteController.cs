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
    public class WriteController : Controller
    {
        // GET: Write
        public ActionResult WriteMail()
        {
            return View();
        }

        public static MailUserViewModel[] getUsers()
        {
            GetMailModel gmm = new GetMailModel();
            return gmm.getAllUsers();
        }
    }
}