using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Blog.Layers.Bussiness;
using Blog.Models.Entities;

namespace Blog.Layers.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly BlogContext _blogContext;
        private readonly DbSet<Entry> _dbSet;

        public EntryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
            _dbSet = _blogContext.Set<Entry>();
        }

        public void Add(Entry entity)
        {
            _dbSet.Add(entity);
            _blogContext.SaveChanges();
        }

        public List<Entry> GetAll()
        {
            return _dbSet.ToList();
        }

        public Entry GetById(Guid Id)
        {
            
            return _dbSet.Include(x=>x.User).Include(x=>x.Comments).Include(x=>x.EntryLikes).FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(Entry entity)
        {
            _dbSet.Remove(entity);
            _blogContext.SaveChanges();
        }

        public void Update(Entry entity)
        {
            _blogContext.SaveChanges();
        }




















        //public string AddEntryByUserId(Models.PostTable.Entry entry, string userEmail)
        //{
        //    Models.PostTable.Entry model = new Models.PostTable.Entry();

        //    model.Description = entry.Description;
        //    model.CreateDate = DateTime.Now;
        //    model.Id = Guid.NewGuid();
        //    model.User = _blogContext.Users.Where(x=>x.Email == userEmail).FirstOrDefault();
        //    try
        //    {
        //        _blogContext.Posts.Add(model);
        //        _blogContext.SaveChanges();
        //        return "İşlem Başarılı";
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return "İşlem Başarısız!";
        //    }

        //}

        //public Models.PostTable.Entry GetEntryById(Guid id)
        //{
        //    var postModel = _blogContext.Posts.FirstOrDefault(x => x.Id == id);
        //    return postModel;
        //}

        //public string UploadImage(HttpPostedFileBase file)
        //{
        //    string uploadFolderPath = HttpContext.Current.Server.MapPath("~/Upload/UploadImage/PostImages/");
        //    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    string fullPath = Path.Combine(uploadFolderPath, fileName);
        //    file.SaveAs(fullPath);

        //    // Resmin URL'sini döndür.
        //    string imageUrl = "~/Upload/UploadImage/PostImages/" + fileName;
        //    return imageUrl;
        //}
    }
}