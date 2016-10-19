using DistroLab2.Models.Mail_Models;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistroLab2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserModel um = new UserModel();
            IndexInfoViewModel ivm = um.getIndexViewModel(User.Identity.Name);

            return View("Index", ivm);
        }
    }
}