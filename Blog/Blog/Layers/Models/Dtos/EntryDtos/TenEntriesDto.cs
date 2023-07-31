using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Blog.Layers.Models.Dtos.EntryDtos
{
    public class TenEntriesDto
    {
        public string Title { get; set; }
        public Guid EntryId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string CategoryName { get; set; }
        public string Summary { get; set; }
        public DateTime CreateDate { get; set; }
    }
}