using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Bussiness.Repositories.Login_Repository;
using Blog.Models.Dtos;
using Blog.Repository;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;


        public AccountController(IAccountRepository accountRepository,IUserRepository _userRepository)
        {
            this._accountRepository = accountRepository;
            this._userRepository = _userRepository;

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

            var userModel = _accountRepository.LogIn(model);
            if (userModel == null)
            {
                ViewBag.Error = "Email veya Şifre Uyuşmuyor";

                return View();
            }

            _accountRepository.SetSession(userModel);

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

            var result = _accountRepository.Register(model);
            ViewBag.Error = result;
            return View();
        }
        [CustomActionFilter]
        public ActionResult SignOut()
        {
            _accountRepository.LogOut();
            return RedirectToAction("Index","Home");
        }
    }
}