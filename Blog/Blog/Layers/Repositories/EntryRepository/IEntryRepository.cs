using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Blog.Models.User;
using Unity.Storage;

namespace Blog.Bussiness.Repositories.Entry
{
    public interface IEntryRepository
    {
        string AddEntryByUserId(Models.PostTable.Entry entry, string userEmail);
        Models.PostTable.Entry GetEntryById(Guid id);

        string UploadImage(HttpPostedFileBase file);

        public RegistrationSet.Entry GetById(Guid Id);
        public List<User> GetAll();
        public void Remove(User entity);
        public void Add(User entity);
        public void Update(User entity);

    }
}
