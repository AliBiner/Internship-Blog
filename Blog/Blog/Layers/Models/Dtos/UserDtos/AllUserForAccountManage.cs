using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Layers.Models.Dtos.UserDtos
{
    public class AllUserForAccountManage
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreateDate { get; set; }
    }
}