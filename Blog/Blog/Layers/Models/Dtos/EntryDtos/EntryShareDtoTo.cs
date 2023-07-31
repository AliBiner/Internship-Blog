using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.Entities;

namespace Blog.Layers.Models.Dtos.EntryDtos
{
    public class EntryShareDtoTo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public Guid UserId { get; set; }
    }
}