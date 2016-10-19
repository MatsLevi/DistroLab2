﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistroLab2.Models;
using DistroLab2.Models.Mail_Models;

namespace DistroLab2.Controllers.MailControllers
{
    public class AuthenticateController
    {
        public static void RegisterUser(ApplicationUser user)
        {
            AuthenticateModel am = new AuthenticateModel();
            am.Register(user);
        }

        public static bool UpdateLogin(string username)
        {
            UserModel um = new UserModel();
            um.updateLoginInformation(username);

            return false;
        }
    }
}