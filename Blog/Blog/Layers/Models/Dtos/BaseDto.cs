using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models.Dtos
{
    public class BaseDto
    {
        
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}