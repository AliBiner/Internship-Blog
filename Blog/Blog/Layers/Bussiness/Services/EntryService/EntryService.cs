
using System;
using System.Collections.Generic;
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

        public string Add(EntryShareDtoTo dto)
        {
            var entry = _entryMapper.EntryShareDtoTo(dto);
            try
            {
                _entryRepository.Add(entry);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası";

            }
            

        }

        public EntryWithCommentsDto GetEntryById(Guid id)
        {
            var entryModel = _entryRepository.GetById(id);
            var entryDto = _entryMapper.EntryToEntryByIdDto(entryModel);
            return entryDto;
        }

        public List<TenEntriesDto> GetTenEntry()
        {
            var model =_entryRepository.GetTen();
            return model;
        }
    }
}