using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Entities;

namespace Blog.Layers.Repositories.CommentRepository
{
    public interface ICommentRepository
    {
        public void Add(Comment comment);
    }
}
