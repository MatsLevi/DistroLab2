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
    }
}