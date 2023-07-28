using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Blog.Models.Entities;
using Blog.Models.PostTable;

namespace Blog.Models.Context
{
    public class BlogContext: DbContext
    {
        public BlogContext(): base("BlogDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User.User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Comment_Like> CommentLikes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}