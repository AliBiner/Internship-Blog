using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Blog.Models.Context;

namespace Blog.Bussiness.Repositories.Post
{
    public class EntryRepository : IEntryRepository
    {
        private readonly BlogContext _blogContext;

        public EntryRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public string AddEntryByUserId(Models.PostTable.Entry entry, string userEmail)
        {
            Models.PostTable.Entry model = new Models.PostTable.Entry();

            model.Description = entry.Description;
            model.CreateDate = DateTime.Now;
            model.Id = Guid.NewGuid();
            model.User = _blogContext.Users.Where(x=>x.Email == userEmail).FirstOrDefault();
            try
            {
                _blogContext.Posts.Add(model);
                _blogContext.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Başarısız!";
            }
            
        }

        public Models.PostTable.Entry GetEntryById(Guid id)
        {
            var postModel = _blogContext.Posts.FirstOrDefault(x => x.Id == id);
            return postModel;
        }

        public string UploadImage(HttpPostedFileBase file)
        {
            string uploadFolderPath = HttpContext.Current.Server.MapPath("~/Upload/UploadImage/PostImages/");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(uploadFolderPath, fileName);
            file.SaveAs(fullPath);

            // Resmin URL'sini döndür.
            string imageUrl = "~/Upload/UploadImage/PostImages/" + fileName;
            return imageUrl;
        }
    }
}