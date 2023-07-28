using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Blog.Models.User;

namespace Blog.Bussiness.Repositories.Post
{
    public interface IEntryRepository
    {
        string AddEntryByUserId(Models.PostTable.Entry entry, string userEmail);
        Models.PostTable.Entry GetEntryById(Guid id);

        string UploadImage(HttpPostedFileBase file);

    }
}
