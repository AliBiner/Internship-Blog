using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Blog.Models.Entities
{
    public class Comment_Like : BaseEntity
    {
        public Boolean Like { get; set; }
        public Boolean Dislike { get; set; }


        
        public Comment Comment { get; set; }
        public User User { get; set; }


    }
}