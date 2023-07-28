using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Windows.Forms.PropertyGridInternal;
using Blog.Models.BaseDB;
using Blog.Models.Entities;

namespace Blog.Models.PostTable
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Comments = new List<Comment>();
            PostLikes = new List<PostLike>();
        }

        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Boolean Published { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }


        
        public User.User User { get; set; }
        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }
        public List<PostLike> PostLikes { get; set; }

    }
}