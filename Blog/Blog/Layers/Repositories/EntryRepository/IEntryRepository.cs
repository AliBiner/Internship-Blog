using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Layers.Models.Dtos.EntryDtos;
using Blog.Models.Entities;


namespace Blog.Layers.Repositories
{
    public interface IEntryRepository
    {
        //string AddEntryByUserId(Models.PostTable.Entry entry, string userEmail);
        //Models.PostTable.Entry GetEntryById(Guid id);

        //string UploadImage(HttpPostedFileBase file);

        public Entry GetById(Guid Id);
        public List<Entry> GetAll();
        public List<TenEntriesDto> GetTen();
        public void Remove(Entry entity);
        public void Add(Entry entity);
        public void Update(Entry entity);

    }
}
