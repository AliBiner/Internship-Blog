using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.BaseDB;
using Blog.Models.PostTable;

namespace Blog.Models.Entities
{
    public class Comment: BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public Boolean Published { get; set; }

        public Post Post { get; set; }
        public Category Category { get; set; }

        public ICollection<Comment_Like> CommentLikes { get; set; }
    }
}