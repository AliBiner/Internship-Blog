using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.PostTable;

namespace Blog.Models.Entities
{
    public class PostLike
    {
        public Boolean Like { get; set; }
        public Boolean Dislike { get; set; }

        public User.User User { get; set; }
        public Post Post { get; set; }
    }
}