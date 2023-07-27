using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.BaseDB;
using Blog.Models.PostTable;

namespace Blog.Models.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}