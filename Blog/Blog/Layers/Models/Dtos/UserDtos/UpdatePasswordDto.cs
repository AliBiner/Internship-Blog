using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.Dtos
{
    public class UpdatePasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}