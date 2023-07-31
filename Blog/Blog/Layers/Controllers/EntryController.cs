using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Layers.Bussiness;
using Blog.Layers.Bussiness.Services.CommentService;
using Blog.Layers.Bussiness.Services.EntryService;
using Blog.Layers.Models.Dtos.CommentDtos;
using Blog.Layers.Models.Dtos.EntryDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Controllers
{
    [CustomActionFilter]
    public class EntryController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly ICommentService _commentService;

        public EntryController(IEntryService entryService, ICommentService commentService)
        {
            _entryService = entryService;
            _commentService = commentService;
        }
        // GET: Entry
        public ActionResult EntryShare()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EntryShare(EntryShareDtoTo entry)
        {
            //var userEmail = Session["Email"].ToString();
            _entryService.Add(entry);
            return View();
        }

        public ActionResult EntryById(Guid id)
        {
            var entry = _entryService.GetEntryById(id);
            TempData["Id"] = id;

            return View(entry);
        }

        [ChildActionOnly]
        public ActionResult PostCommitByEntryId()
        {
            ViewBag.Id = TempData["Id"].ToString();
            return PartialView();
        }
        [HttpPost]
        public ActionResult PostCommitByEntryId(CommentByEntryIdDto dto)
        {
            var result = _commentService.PostCommentByEntryId(dto);

            return RedirectToAction("EntryById", "Entry",dto.EntryId);
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