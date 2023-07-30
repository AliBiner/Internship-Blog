using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.Services.CommentService
{
    public interface ICommentService
    {
        public string PostCommentByEntryId(CommentByEntryIdDto dto);

    }
}
