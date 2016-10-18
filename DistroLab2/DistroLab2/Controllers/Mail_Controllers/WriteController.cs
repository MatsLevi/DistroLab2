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
    [Authorize]
    public class WriteController : Controller
    {
        // GET: Write
        public ActionResult WriteMail()
        {
            return View();
        }

        public ActionResult SendToGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterMail(List<String> UserListViewModel, String Title, String Message)
        {
            System.Diagnostics.Debug.WriteLine("Entered Controller");

            if (UserListViewModel == null || Title == null || Message == null)
            {
                System.Diagnostics.Debug.WriteLine("Nulling it up in the write Controller");
                return View("WriteMail");
            }
            else
            {
                foreach (string s in UserListViewModel)
                    System.Diagnostics.Debug.WriteLine("List item: " + s);

                System.Diagnostics.Debug.WriteLine("Title: " + Title);
                System.Diagnostics.Debug.WriteLine("Message: " + Message);
            }

            //System.Diagnostics.Debug.WriteLine("List item: " + UserListViewModel.ToArray()[0]);

            string currentUser = User.Identity.Name;
            System.Diagnostics.Debug.WriteLine("User name: " + currentUser);

            int senderId = 0;
            MailUserViewModel[] users = getUsers();
            foreach (MailUserViewModel m in users)
            {
                if (m.Username.Equals(currentUser))
                {
                    senderId = m.ID;
                }
            }


            System.Diagnostics.Debug.WriteLine("ID of current user: " + senderId);
            WriteModel mail = new WriteModel();

            MessageViewModel messageCheck = mail.registerMail(UserListViewModel, Title, Message, senderId);
            messageCheck.Receivers = UserListViewModel.ToArray();

            ModelState.Clear();
            return View("WriteMail", messageCheck);
        }

        public static MailUserViewModel[] getUsers()
        {
            GetMailModel gmm = new GetMailModel();
            return gmm.getAllUsers();
        }

        [HttpPost]
        public ActionResult RegisterGroupMail(string MailGroup, String Title, String Message)
        {
            System.Diagnostics.Debug.WriteLine("In writeController register group mail");

            if (MailGroup == null || Title == null || Message == null)
            {
                System.Diagnostics.Debug.WriteLine("Nulling it up in the write Controller");
                ModelState.Clear();
                return View("SendToGroup");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("List item: " + MailGroup);
                System.Diagnostics.Debug.WriteLine("Title: " + Title);
                System.Diagnostics.Debug.WriteLine("Message: " + Message);
            }

            string currentUser = User.Identity.Name;
            System.Diagnostics.Debug.WriteLine("User name: " + currentUser);

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