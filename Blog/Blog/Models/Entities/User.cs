using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.BaseDB;
using Blog.Models.Entities;
using Blog.Models.PostTable;

namespace Blog.Models.User
{
    public class User: BaseEntity
    {
       
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string ProfileDescription { get; set; }
        public byte[] Image { get; set; }
        public DateTime LostLogin { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment_Like> CommentLikes { get; set; }
        public ICollection<PostLike> PostLikes { get; set; }
        
    }
}