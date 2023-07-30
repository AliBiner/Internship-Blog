using System;
using System.Web.Mvc;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Models.Dtos.EntryDtos;

namespace Blog.Layers.Bussiness.Services.EntryService
{
    public interface IEntryService
    {
        public EntryByIdDto GetEntryById(string id);
    }
}
