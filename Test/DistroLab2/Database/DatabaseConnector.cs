using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    public class DatabaseConnector
    {
         
    }

    public class Group
    {
        [Key]
        public int groupId { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string name { get; set; }
        [Required]
        public string creator { get; set; }
    }

    public class GroupUsers
    {
        [Key]
        public int groupId { get; set; }
        [Key]
        public int userId { get; set; }
    }

    public class User
    {
        public int userId { get; set; }
    }

    public class Message
    {

    }

    public class ReceivedMessage
    {

    }
}