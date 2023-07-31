using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Layers.Models.Dtos.EntryDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.DtoMappers.EntryMapper
{
    public interface IEntryMapper
    {
        public EntryWithCommentsDto EntryToEntryByIdDto(Entry entry);
        public Entry EntryShareDtoTo(EntryShareDtoTo dto);

    }
}
