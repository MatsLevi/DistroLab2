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
        public ActionResult Inbox()
        {
            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name));

            return View("Inbox", IVMW);
        }

        public ActionResult UserSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DisplayMails(string SenderList)
        {
            GetMailModel gm = new GetMailModel();
            InboxViewModel[] IVM = gm.getAllUserMailsFromSender(User.Identity.Name, SenderList);

            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(IVM);

            return View("Inbox", IVMW);
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