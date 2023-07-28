using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;
using Blog.Models.BaseDB;
using Blog.Models.Entities;
using Blog.Models.PostTable;

namespace Blog.Models.User
{
    public class User: BaseEntity
    {
        public User()
        {
            Posts = new List<Post>();
            CommentLikes = new List<Comment_Like>();
            PostLikes = new List<PostLike>();
        }

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }

        [MaxLength(250,ErrorMessage = "Max. 250 Karakter Olmalıdır.")]
        public string? About { get; set; }

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

        public List<Post> Posts { get; set; }
        public List<Comment_Like> CommentLikes { get; set; }
        public List<PostLike> PostLikes { get; set; }

    }
}