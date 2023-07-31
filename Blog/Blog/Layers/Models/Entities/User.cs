using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Models.Entities
{
    public class User: BaseEntity
    {
        public User()
        {
            Entries = new List<Entry>();
            //CommentLikes = new List<Comment_Like>();
            //EntryLikes = new List<EntryLike>();
        }

        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        [Required]
        [Index( IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(15)]
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string? ProfileDescription { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? LostLogin { get; set; }

        public List<Entry> Entries { get; set; }
        //public List<Comment_Like> CommentLikes { get; set; }
        //public List<EntryLike> EntryLikes { get; set; }

    }
}