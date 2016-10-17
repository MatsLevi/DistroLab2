using DistroLab2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class WriteModel
    {
        public WriteModel()
        {

        }

        public bool registerMail(List<String> users, string title, string message, int userId)
        {
            return AddMail.RegisterMail(users, title, message, userId);
        }
    }
}