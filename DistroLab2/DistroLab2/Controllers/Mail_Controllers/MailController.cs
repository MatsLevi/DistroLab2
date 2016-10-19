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
            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name), getStatistics(User.Identity.Name));

            return View("Inbox", IVMW);
        }

        public ActionResult UserSearch()
        {
            return View();
        }

        public ActionResult SpecificMail()
        {
            return View("SpecificMail");
        }

        [HttpPost]
        public ActionResult DisplaySpecificMail(string MailList, string button)
        {
            System.Diagnostics.Debug.WriteLine("Entered DisplaySpecificMail!");

            int mailId;

            try
            {
                string parsedMailId = (MailList.Split(new char[] { ':' }))[0];
                mailId = int.Parse(parsedMailId);
            }
            catch (Exception e)
            {
                InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name), getStatistics(User.Identity.Name));

                System.Diagnostics.Debug.WriteLine("Failed to parse id");
                ModelState.Clear();
                return View("Inbox", IVMW);
            }

            System.Diagnostics.Debug.WriteLine("MailList: " + mailId);

            if (button.Equals("View"))
                return ViewMail(mailId);
            return deleteMail(mailId);
        }

        [HttpPost]
        public ActionResult DisplayMails(string SenderList)
        {
            GetMailModel gm = new GetMailModel();
            InboxViewModel[] IVM = gm.getAllUserMailsFromSender(User.Identity.Name, SenderList);

            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(IVM, getStatistics(User.Identity.Name));

            return View("Inbox", IVMW);
        }

        public ActionResult ViewMail(int mailId)
        {
            GetMailModel gmm = new GetMailModel();
            SpecificMailViewModel smvm = gmm.getSpecificMail(mailId, User.Identity.Name);

            return View("SpecificMail", smvm);
        }

        public ActionResult deleteMail(int mailId)
        {
            DeleteModel.deleteMail(mailId, User.Identity.Name);

            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name), getStatistics(User.Identity.Name));
            ModelState.Clear();
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

        public static StatisticsViewModel getStatistics(string username)
        {
            UserModel um = new UserModel();
            return um.getStatistics(username);
        }
    }
}