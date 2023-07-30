using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Blog.Models.Entities;

namespace Blog.Layers.Models.Dtos.CommentDtos
{
    public class CommentByEntryIdDto
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Entry Entry { get; set; }
        public User User { get; set; }
    }
}