using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.DtoMappers.CommentMapper
{
    public interface ICommentMapper
    {
        public Comment CommentByEntryDtoTo(CommentByEntryIdDto dto);

    }
}
