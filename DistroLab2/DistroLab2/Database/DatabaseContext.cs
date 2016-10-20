using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DistroLab2.Database
{
    /// <summary>
    /// The DatabaseContexts consists DbSets for the different tables.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ReceivedMessage> ReceivedMessages { get; set; }
    }

    /// <summary>
    /// The Group class specifies the Group table in the database and can be 
    /// used to either retrieve, add or update a row in the table.
    /// </summary>
    public class Group
    {
        [Key]
        public int groupId { get; set; }
        [Required]
        [MaxLength(120)]
        [Index(IsUnique = true)]
        public string name { get; set; }
        [Required]
        public string creator { get; set; }
    }

    /// <summary>
    /// The GroupUser class specifies the GroupUser table in the database and can be 
    /// used to either retrieve, add or update a row in the table.
    /// </summary>
    public class GroupUser
    {
        [Key, Column(Order = 0)]
        public int groupId { get; set; }
        [Key, Column(Order = 1)]
        public int userId { get; set; }
    }

    /// <summary>
    /// The User class specifies the User table in the database and can be 
    /// used to either retrieve, add or update a row in the table.
    /// </summary>
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        [MaxLength(120)]
        [Index(IsUnique = true)]
        public string name { get; set; }
        [Required]
        public int removedMess { get; set; }
        [Required]
        public int totalMess { get; set; }
        [Required]
        public int readMess { get; set; }
        [Required]
        public string lastLogin { get; set; }
        [Required]
        public int totalMonthLogin { get; set; }
        [Required]
        public int currentMonth { get; set; }
    }

    /// <summary>
    /// The Message class specifies the Message table in the database and can be 
    /// used to either retrieve, add or update a row in the table.
    /// </summary>
    public class Message
    {
        [Key]
        public int messId { get; set; }
        [Required]
        public int senderId { get; set; }
        [Required]
        public string timestamp { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public string title { get; set; }
    }

    /// <summary>
    /// The ReceivedMessage class specifies the ReceivedMessage table in the database and can be 
    /// used to either retrieve, add or update a row in the table.
    /// </summary>
    public class ReceivedMessage
    {
        [Key, Column(Order = 0)]
        public int messId { get; set; }
        [Key, Column(Order = 1)]
        public int userId { get; set; }
        [Required]
        public bool read { get; set; }
    }
}