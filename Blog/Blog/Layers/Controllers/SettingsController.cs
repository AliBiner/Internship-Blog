using System.Web.Mvc;
using Blog.Layers.Bussiness;
using Blog.Layers.Bussiness.Services.EntryService;
using Blog.Layers.Models.Dtos;
namespace Blog.Controllers
{
    [CustomActionFilter]
    public class SettingsController : Controller
    {
        private readonly IUserService _userService;

        public SettingsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Settings
        public ActionResult Index()
        {
            var email = Session["Email"].ToString();
            var model = _userService.GetUserByEmail(email);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult UpdatePassword()
        {
            return PartialView("UpdatePassword");
        }
        
        [HttpPost]
        public ActionResult UpdatePassword(UpdatePasswordDto dto)
        {
            var sessionEmail = Session["Email"].ToString();
            var result = _userService.UpdatePasswordByEmail(dto, sessionEmail);
            return RedirectToAction("Index","Settings");
        }

        [ChildActionOnly]
        public ActionResult UpdateUser()
        {
            var sessionEmail = Session["Email"].ToString();
            ViewData["Model"] = _userService.GetUserByEmail(sessionEmail);
            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateUser(UpdateUserInformationDto dto )
        {
            var sessionEmail = Session["Email"].ToString();

            var result = _userService.Update(dto, sessionEmail);
            return RedirectToAction("Index","Settings");
        }

        public ActionResult AccontManage()
        {
           
            return View();
        }

        //[HttpPost]
        //public ActionResult AccontManage()
        //{
        //    re
        //}
    }
}