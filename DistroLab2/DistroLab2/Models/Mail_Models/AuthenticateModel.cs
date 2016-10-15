using DistroLab2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class AuthenticateModel
    {
        public AuthenticateModel()
        {

        }

        public bool Register(ApplicationUser user)
        {
            MailUser mailUser = new MailUser(user.Email);
            System.Diagnostics.Debug.WriteLine("Registering: " + mailUser.Username);

            return AddUser.registerUser(mailUser);
        }
    }
}