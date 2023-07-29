using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Layers.Bussiness.Services;
using Blog.Models.Dtos;
using Blog.Repository;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto model)
        {
            if (!ModelState.IsValid) return View();

            var result = _userService.Login(model);
            if (result!=null)
            {
                ViewBag.Error = result;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(SigninDto model)
        {
            if (!ModelState.IsValid) return View();

            var result = _userService.Signin(model);
            ViewBag.Error = result;
            return View();
        }

        [CustomActionFilter]
        public ActionResult SignOut()
        {
            _userService.Logout();
            return RedirectToAction("Index","Home");
        }
    }
}