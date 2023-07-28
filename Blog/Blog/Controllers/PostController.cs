using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Bussiness.Repositories.Post;
using Blog.Models.PostTable;
using Blog.Repository;

namespace Blog.Controllers
{
    [CustomActionFilter]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public ActionResult Post()
        {
            var postStringId = "34ab2db2-f742-40b9-9f3c-3cbfc127ac27";
            Guid postId = Guid.Parse(postStringId);
            var model = _postRepository.GetPostById(postId);
            return View(model);
        }

        // GET: Post
        public ActionResult PostShare()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult PostShare(Post post)
        {
            var userEmail = Session["Email"].ToString();
            _postRepository.AddPostByUserId(post, userEmail);

            return View();
        }

        //[HttpPost]
        //public ActionResult UploadImage(HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        // Resmi istediğiniz bir klasöre kaydedin ve resmin URL'sini döndürün.
        //        // Örneğin:
        //        string fileName = Path.GetFileName(file.FileName);
        //        string path = Path.Combine(Server.MapPath("/Upload/UploadImage/PostImages"), fileName);
        //        file.SaveAs(path);
        //        string imageUrl = Url.Content("/Upload/UploadImage/PostImages" + fileName);

        //        return Json(new { location = imageUrl });
        //    }

        //    return Json(new { error = "Resim yüklenemedi." });
        //}
    }

}