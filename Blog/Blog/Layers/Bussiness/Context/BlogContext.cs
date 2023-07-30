using System.Data.Entity;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness
{
    public class BlogContext: DbContext
    {
        public BlogContext(): base("BlogDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Comment_Like> CommentLikes { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryLike> EntryLikes { get; set; }
       
    }
}