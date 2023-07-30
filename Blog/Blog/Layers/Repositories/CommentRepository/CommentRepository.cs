using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Blog.Layers.Bussiness;
using Blog.Models.Entities;

namespace Blog.Layers.Repositories.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext _blogContext;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(BlogContext blogContext, DbSet<Comment> dbSet)
        {
            _blogContext = blogContext;
            _dbSet = _blogContext.Set<Comment>();
        }


        public void Add(Comment comment)
        {
            _dbSet.Add(comment);
            _blogContext.SaveChanges();
        }
    }
}