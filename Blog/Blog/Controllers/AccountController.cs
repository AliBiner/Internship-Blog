using System.Web.Mvc;
using Blog.Bussiness.Repositories.Login_Repository;
using Blog.Models.Dtos;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountPRepository _accountPRepository;

        public AccountController(IAccountPRepository accountPRepository)
        {
            _accountPRepository = accountPRepository;
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

            var userModel = _accountPRepository.LogIn(model);
            if (userModel == null)
            {
                ViewBag.Error = "Email veya Şifre Uyuşmuyor";

                return View();
            }

            _accountPRepository.SetSession(userModel);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return View();

            var result = _accountPRepository.Register(model);
            ViewBag.Error = result;
            return View();
        }

        public ActionResult SignOut()
        {
            _accountPRepository.LogOut();
            return RedirectToAction("Index","Home");
        }
    }
}