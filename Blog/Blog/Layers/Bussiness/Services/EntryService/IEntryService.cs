using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Models.Dtos.EntryDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.Services.EntryService
{
    public interface IEntryService
    {
        public EntryWithCommentsDto GetEntryById(Guid id);
        public string Add(EntryShareDtoTo entry);

        public List<TenEntriesDto> GetTenEntry();
    }
}
