using DistroLab2.Models;
using DistroLab2.Models.Mail_Models;
using DistroLab2.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DistroLab2.Controllers.Mail_Controllers
{
    /// <summary>
    /// The WriteController acts as a controller for the write actions.
    /// </summary>
    [Authorize]
    public class WriteController : Controller
    {
        /// <summary>
        /// Returns a WriteMail view.
        /// </summary>
        /// <returns> a WriteMail view.</returns>
        public ActionResult WriteMail()
        {
            return View();
        }

        /// <summary>
        /// Returns a SendToGroup view.
        /// </summary>
        /// <returns> a SendToGroup view.</returns>
        public ActionResult SendToGroup()
        {
            return View();
        }

        /// <summary>
        /// Makes a register mail to db call and returns a cleared WriteMail view.
        /// </summary>
        /// <param name="UserListViewModel"> a list of the receivers.</param>
        /// <param name="Title"> the mail title.</param>
        /// <param name="Message"> the mail message.</param>
        /// <returns> a WriteMail view.</returns>
        [HttpPost]
        public ActionResult RegisterMail(List<String> UserListViewModel, String Title, String Message)
        {
            if (UserListViewModel == null || Title == null || Message == null)
            {
                return View("WriteMail");
            }
            
            string currentUser = User.Identity.Name;

            int senderId = 0;
            MailUserViewModel[] users = getUsers();
            foreach (MailUserViewModel m in users)
            {
                if (m.Username.Equals(currentUser))
                {
                    senderId = m.ID;
                }
            }
            
            WriteModel mail = new WriteModel();

            MessageViewModel messageCheck = mail.registerMail(UserListViewModel, Title, Message, senderId);
            messageCheck.Receivers = UserListViewModel.ToArray();

            ModelState.Clear();
            return View("WriteMail", messageCheck);
        }

        /// <summary>
        /// Gets all users except the the specified.
        /// </summary>
        /// <param name="username"> the specified users username.</param>
        /// <returns> all users except the the specified.</returns>
        public static MailUserViewModel[] getUsers(string username)
        {
            GetMailModel gmm = new GetMailModel();
            return gmm.getAllUsers(username);
        }

        /// <summary>
        /// Gets all registered users.
        /// </summary>
        /// <returns> all registered users.</returns>
        public static MailUserViewModel[] getUsers()
        {
            GetMailModel gmm = new GetMailModel();
            return gmm.getAllUsers();
        }

        /// <summary>
        /// Makes a register group mail to db call and returns a cleared SendToGroup view.
        /// </summary>
        /// <param name="MailGroup"> the group name.</param>
        /// <param name="Title"> the mail title.</param>
        /// <param name="Message"> the mail title.</param>
        /// <returns> a cleared SendToGroup view.</returns>
        [HttpPost]
        public ActionResult RegisterGroupMail(string MailGroup, String Title, String Message)
        {
            if (MailGroup == null || Title == null || Message == null)
            {
                ModelState.Clear();
                return View("SendToGroup");
            }

            string currentUser = User.Identity.Name;

            int senderId = 0;
            MailUserViewModel[] users = getUsers();
            foreach (MailUserViewModel m in users)
            {
                if (m.Username.Equals(currentUser))
                {
                    senderId = m.ID;
                }
            }

            WriteModel mail = new WriteModel();

            bool messageCheck = mail.registerGroupMail(MailGroup, Title, Message, senderId);

            ModelState.Clear();
            return View("SendToGroup");
        }
    }
}