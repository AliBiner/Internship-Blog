using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Bussiness.Repositories.Login_Repository;
using Blog.Models.Dtos;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private IAccountRepository _accountRepository;

        public AccountController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            this._userRepository = userRepository;
            this._accountRepository = accountRepository;
            
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto model)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var userModel = _accountRepository.LogIn(model);
                if (userModel == null)
                {
                    ViewBag.Error = "Email veya Şifre Uyuşmuyor";
                    
                    return View();
                }
                else
                {
                    _accountRepository.SetSession(userModel);

                    return RedirectToAction("Index", "Home");
                }

            }
            
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterDto model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var result = _userRepository.Add(model);
                ViewBag.Error = result;
                return View();
            }
        }

        public ActionResult Logout()
        {
            _accountRepository.LogOut();
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}