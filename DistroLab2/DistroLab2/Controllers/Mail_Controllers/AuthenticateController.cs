using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistroLab2.Models;
using DistroLab2.Models.Mail_Models;

namespace DistroLab2.Controllers.MailControllers
{
    /// <summary>
    /// The AuthenticateController acts as a controller for the the registration and login update
    /// process.
    /// </summary>
    public class AuthenticateController
    {
        /// <summary>
        /// Redirects to the registration process.
        /// </summary>
        /// <param name="user"> specifies the user to be registered.</param>
        public static void RegisterUser(ApplicationUser user)
        {
            AuthenticateModel am = new AuthenticateModel();
            am.Register(user);
        }

        /// <summary>
        /// Redirects to the update login information process.
        /// </summary>
        /// <param name="username"> specifies the user to be updated.</param>
        /// <returns> returns true if the user information was updated.</returns>
        public static bool UpdateLogin(string username)
        {
            UserModel um = new UserModel();
            um.updateLoginInformation(username);

            return false;
        }
    }
}