using DistroLab2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model used during user registration
    /// </summary>
    public class AuthenticateModel
    {
        /// <summary>
        /// Model constructor
        /// </summary>
        public AuthenticateModel()
        {

        }

        /// <summary>
        /// Function used to register user in database
        /// </summary>
        /// <param name="user"></param> ApplicationUser containing neccsary information for registration
        /// <returns></returns> bool containing information wheter the registration succeeded or not
        public bool Register(ApplicationUser user)
        {
            MailUser mailUser = new MailUser(user.Email);

            return AddUser.registerUser(mailUser);
        }
    }
}