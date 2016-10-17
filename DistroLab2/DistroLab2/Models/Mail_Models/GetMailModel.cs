using DistroLab2.Database;
using DistroLab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistroLab2.Models.Mail_Models
{
    public class GetMailModel
    {
        public GetMailModel()
        {

        }

        public MailUserViewModel[] getAllUsers()
        {
            User[] dbUsers = GetUsers.getAllUsers();

            if(dbUsers == null)
            {
                return null;
            }

            MailUserViewModel[] usrs = new MailUserViewModel[dbUsers.Length];
            for(int i = 0; i < usrs.Length; i++)
            {
                usrs[i] = new MailUserViewModel(dbUsers[i].userId, dbUsers[i].name, dbUsers[i].removedMess, dbUsers[i].totalMess, dbUsers[i].readMess);
            }

            return usrs;
        }
    }
}