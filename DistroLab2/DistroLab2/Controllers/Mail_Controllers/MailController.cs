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
    public class MailController : Controller
    {
         //GET: Mail
        public ActionResult Inbox()
        {
            return View();
        }

        public ActionResult UserSearch()
        {
            return View();
        }

        public static InboxViewModel[] getAllUserMails(string username)
        {
            GetMailModel gm = new GetMailModel();
            return gm.getAllUserMails(username);
        }

        public static List<string> getAllMailSenders(string username)
        {
            GetMailModel gm = new GetMailModel();

            return gm.getAllMailSenders(username);
        }
    }
}