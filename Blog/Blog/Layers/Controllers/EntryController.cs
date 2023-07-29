using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Bussiness.Repositories.Entry;
using Blog.Models.PostTable;
using Blog.Repository;

namespace Blog.Controllers
{
    [CustomActionFilter]
    public class EntryController : Controller
    {
        private readonly IEntryRepository _entryRepository;

        public EntryController(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }


        // GET: Entry
        public ActionResult EntryShare()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EntryShare(Entry entry)
        {
            var userEmail = Session["Email"].ToString();
            _entryRepository.AddEntryByUserId(entry, userEmail);

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