
using System;
using System.Web.Mvc;
using Blog.Layers.Bussiness.DtoMappers.EntryMapper;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Models.Dtos.EntryDtos;
using Blog.Layers.Repositories;

namespace Blog.Layers.Bussiness.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IEntryMapper _entryMapper;

        public EntryService(IEntryRepository entryRepository, IEntryMapper entryMapper)
        {
            _entryRepository = entryRepository;
            _entryMapper = entryMapper;
        }


        public EntryByIdDto GetEntryById(string id)
        {
            var Id = Guid.Parse(id);
            var entryModel = _entryRepository.GetById(Id);
            var entryDto = _entryMapper.EntryToEntryByIdDto(entryModel);
            return entryDto;
        }


    }
}