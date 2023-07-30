using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Layers.Bussiness;
using Blog.Layers.Bussiness.Services.CommentService;
using Blog.Layers.Bussiness.Services.EntryService;

namespace Blog.Layers.Controllers
{
    [CustomActionFilter]
    public class DenemeController : Controller
    {
        private readonly ICommentService _commentService;


        public DenemeController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public ActionResult DenemeShare()
        {
            return View();
        }

        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult DenemaShare()
        //{
        //    //var userEmail = Session["Email"].ToString();
        //    //_entryService.GetEntryById();
        //    return 
        //}

    }
}