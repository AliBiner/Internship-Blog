
using Blog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Models.Dtos.EntryDtos;

namespace Blog.Layers.Bussiness.DtoMappers.EntryMapper
{
    public class EntryMapper : IEntryMapper
    {
        public EntryByIdDto EntryToEntryByIdDto(Entry entry)
        {
            return new EntryByIdDto()
            {
                Description = entry.Description,
                AuthorName = entry.User.Name + " " + entry.User.Surname,
                Comments = entry.Comments,
                EntryLikes = entry.EntryLikes,
                CreateDate = entry.CreateDate,
                Id = entry.Id
            };
        }

        //public Entry CommitByEntryIdDtoToEntry(CommentByEntryIdDto d)
        //{
        //    return new Comment()
        //    {
        //        Title = d.Title,
        //         = d.Message,
                
        //    }
        //}
    }
}