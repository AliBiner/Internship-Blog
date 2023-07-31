
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
        public Entry EntryShareDtoTo(EntryShareDtoTo dto)
        {
            return new Entry()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Title = dto.Title,
                MetaTitle = dto.Summary,
                Description = dto.Description,
                UserId = dto.UserId,
                Published = true,
                CategoryId = Guid.Parse("98cabadb-7b7b-4089-b919-337693952c50")

            };
        }

        public EntryWithCommentsDto EntryToEntryByIdDto(Entry entry)
        {
            return new EntryWithCommentsDto()
            {
                Description = entry.Description,
                AuthorName = entry.User.Name + " " + entry.User.Surname,
                Comments = entry.Comments,
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