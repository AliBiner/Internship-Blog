using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.BaseDB;
using Blog.Models.PostTable;

namespace Blog.Models.Entities
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            CommentLikes = new List<Comment_Like>();
        }
        public string Title { get; set; }
        public string Summary { get; set; }
        public Boolean Published { get; set; }

        
        public Entry Entry { get; set; }

        public List<Comment_Like> CommentLikes { get; set; }
    }
}