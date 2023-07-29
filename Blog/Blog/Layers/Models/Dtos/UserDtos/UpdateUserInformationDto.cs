using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.Dtos;

namespace Blog.Layers.Models.Dtos
{
    public class UpdateUserInformationDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string? ProfileDescription { get; set; }
    }
}