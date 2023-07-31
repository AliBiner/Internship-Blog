using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.Entities;

namespace Blog.Models.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Entries = new List<Entry>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<Entry> Entries { get; set; }
    }
}