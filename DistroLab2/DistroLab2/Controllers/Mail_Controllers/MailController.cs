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
    /// The MailController acts as a controller for the mail actions.
    /// </summary>
    [Authorize]
    public class MailController : Controller
    {
        /// <summary>
        /// Returns a Inbox view model containing all the user mails.
        /// </summary>
        /// <returns> a Inbox view.</returns>
        public ActionResult Inbox()
        {
            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name), getStatistics(User.Identity.Name));
            return View("Inbox", IVMW);
        }

        /// <summary>
        /// Returns a UserSearch view.
        /// </summary>
        /// <returns> a UserSearch view.</returns>
        public ActionResult UserSearch()
        {
            return View();
        }

        /// <summary>
        /// Returns a SpecificMail view.
        /// </summary>
        /// <returns> a SpecificMail view.</returns>
        public ActionResult SpecificMail()
        {
            return View("SpecificMail");
        }

        /// <summary>
        /// Deletes or displays a mail depending on the button parameter.
        /// </summary>
        /// <param name="MailList"> the selected mail.</param>
        /// <param name="button"> the information about which button was pressed.</param>
        /// <returns> a Inbox view or a SpecificMail view depending on the button click.</returns>
        [HttpPost]
        public ActionResult DisplaySpecificMail(string MailList, string button)
        {
            int mailId;

            try
            {
                string parsedMailId = (MailList.Split(new char[] { ':' }))[0];
                mailId = int.Parse(parsedMailId);
            }
            catch (Exception e)
            {
                InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name), getStatistics(User.Identity.Name));
                ModelState.Clear();
                return View("Inbox", IVMW);
            }

            if (button.Equals("View"))
                return ViewMail(mailId);
            return deleteMail(mailId);
        }

        /// <summary>
        /// Displays all the mails sent from the specified sender.
        /// </summary>
        /// <param name="SenderList"> the sender.</param>
        /// <returns> a Inbox view.</returns>
        [HttpPost]
        public ActionResult DisplayMails(string SenderList)
        {
            GetMailModel gm = new GetMailModel();
            InboxViewModel[] IVM = gm.getAllUserMailsFromSender(User.Identity.Name, SenderList);

            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(IVM, getStatistics(User.Identity.Name));

            return View("Inbox", IVMW);
        }

        /// <summary>
        /// Returns a SpecificMail view based on the specified mailId.
        /// </summary>
        /// <param name="mailId"> the mail id.</param>
        /// <returns> a SpecificMail view.</returns>
        public ActionResult ViewMail(int mailId)
        {
            GetMailModel gmm = new GetMailModel();
            SpecificMailViewModel smvm = gmm.getSpecificMail(mailId, User.Identity.Name);

            return View("SpecificMail", smvm);
        }

        /// <summary>
        /// Deletes the mail specified by the mailId from the inbox and returns a Inbox view.
        /// </summary>
        /// <param name="mailId"> the id needed to locate the message.</param>
        /// <returns> a Inbox view.</returns>
        public ActionResult deleteMail(int mailId)
        {
            DeleteModel.deleteMail(mailId, User.Identity.Name);

            InboxViewModelWrapper IVMW = new InboxViewModelWrapper(getAllUserMails(User.Identity.Name), getStatistics(User.Identity.Name));
            ModelState.Clear();
            return View("Inbox", IVMW);
        }

        /// <summary>
        /// Returns all the user mails.
        /// </summary>
        /// <param name="username"> the users username.</param>
        /// <returns> all the user mails.</returns>
        public static InboxViewModel[] getAllUserMails(string username)
        {
            GetMailModel gm = new GetMailModel();
            return gm.getAllUserMails(username);
        }

        /// <summary>
        /// Gets all the usernames of those who have sent mails to the specified user.
        /// </summary>
        /// <param name="username"> the specified users username.</param>
        /// <returns> all the usernames of those who have sent mails to the specified user.</returns>
        public static List<string> getAllMailSenders(string username)
        {
            GetMailModel gm = new GetMailModel();
            return gm.getAllMailSenders(username);
        }

        /// <summary>
        /// Gets statistics for the specified user.
        /// </summary>
        /// <param name="username"> the specified users username.</param>
        /// <returns> statistics for the specified user.</returns>
        public static StatisticsViewModel getStatistics(string username)
        {
            UserModel um = new UserModel();
            return um.getStatistics(username);
        }
    }
}