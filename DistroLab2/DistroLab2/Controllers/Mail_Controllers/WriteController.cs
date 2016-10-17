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

        [HttpPost]
        public ActionResult WriteHello(List<String> UserListViewModel)
        {
            System.Diagnostics.Debug.WriteLine("Entered Controller");

            foreach(String s in UserListViewModel)
                System.Diagnostics.Debug.WriteLine("List item: " + s);

            //System.Diagnostics.Debug.WriteLine("List item: " + UserListViewModel.ToArray()[0]);

            return View("WriteMail");
        }

        public static MailUserViewModel[] getUsers()
        {
            GetMailModel gmm = new GetMailModel();
            return gmm.getAllUsers();
        }
    }
}