using DistroLab2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    /// <summary>
    /// Model used for deleting messages
    /// </summary>
    public class DeleteModel
    {
        /// <summary>
        /// Function used for deleting mails
        /// </summary>
        /// <param name="mailId"></param> int containing mail id
        /// <param name="username"></param> string containing user username
        /// <returns></returns> bool containing information wheter the deletion succeeded or not
        public static bool deleteMail(int mailId, string username)
        {
            return DeleteMail.deleteMail(mailId, username);
        }
    }
}