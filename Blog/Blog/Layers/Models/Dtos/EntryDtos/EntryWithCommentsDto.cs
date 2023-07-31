using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.Entities;

namespace Blog.Layers.Models.Dtos.EntryDtos
{
    public class EntryWithCommentsDto : BaseDto
    {

        public string Description { get; set; }
        public string AuthorName { get; set; }
        public List<Comment> Comments { get; set; }


    }
}