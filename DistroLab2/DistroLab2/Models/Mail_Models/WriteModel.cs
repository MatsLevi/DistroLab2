using DistroLab2.Database;
using DistroLab2.ViewModels;
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

        public MessageViewModel registerMail(List<String> users, string title, string message, int userId)
        {
            Message msg = AddMail.RegisterMail(users, title, message, userId);

            if (msg == null)
                return null;

            return new MessageViewModel(msg.timestamp, msg.messId, true);
        }
    }
}