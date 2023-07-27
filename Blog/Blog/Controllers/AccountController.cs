using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Models.Dtos;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
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
                var userModel = _userRepository.LoginControl(model);
                if (userModel == null)
                {
                    ViewBag.Error = "Email veya Şifre Uyuşmuyor";
                    
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userModel.MiddleName,false);
                    Session["Name"] = userModel.Name;
                    Session["Surname"] = userModel.Surname;
                    Session["Email"] = userModel.Email;
                    Session["Id"] = userModel.Id;
                    Session["Role"] = userModel.Role;

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
                var control = _userRepository.Add(model);
                if (control==false)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}