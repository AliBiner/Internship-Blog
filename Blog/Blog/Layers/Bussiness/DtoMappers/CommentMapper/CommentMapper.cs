using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Layers.Bussiness.DtoMappers.CommentMapper
{
    public class CommentMapper : ICommentMapper
    {
        public Comment CommentByEntryDtoTo(CommentByEntryIdDto dto,Entry entry, User user)
        {
            return new Comment()
            {
                Entry = entry,
                User = user,
                Title = dto.Title,
                Summary = dto.Message,
                CreateDate = DateTime.Now

            };
        }
    }
}