using DistroLab2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class DeleteModel
    {
        public static bool deleteMail(int mailId, string username)
        {
            return DeleteMail.deleteMail(mailId, username);
        }
    }
}