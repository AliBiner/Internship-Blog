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
    public interface IPostRepository
    {
        string AddPostByUserId(Models.PostTable.Post post, string userEmail);
        Models.PostTable.Post GetPostById(Guid id);

        string UploadImage(HttpPostedFileBase file);

    }
}
