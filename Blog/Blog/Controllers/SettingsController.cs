using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Blog.Bussiness;
using Blog.Models.Dtos;
using Blog.Repository;

namespace Blog.Controllers
{
    [CustomActionFilter]
    public class SettingsController : Controller
    {
        private readonly IUserRepository _userRepository;
        public SettingsController(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }
        // GET: Settings
        public ActionResult Index()
        {
            var email = Session["Email"].ToString();
            var model= _userRepository.GetByEmail(email);
            var changePassword = new UpdatePasswordDto();
            return View(model);
        }

       
        [HttpPost]
        public ActionResult UpdatePassword(string currentPassword,string newPassword)
        {
            var result = _userRepository.UpdatePassword(currentPassword,newPassword, Session["Email"].ToString());

            return RedirectToAction("Index", "Settings", result);
        }

        [HttpPost]
        public ActionResult UpdateUser(string name, string? middleName, string surname, string email, string phone )
        {
            var userDto = new UserDto();
            userDto.Name = name;
            userDto.MiddleName = middleName;
            userDto.Surname = surname;
            userDto.Email = email;
            userDto.Phone = phone;
            var sessionEmail = Session["Email"].ToString();

            var result = _userRepository.UpdateUser(userDto,sessionEmail);

            return RedirectToAction("Index", "Settings",result);
        }
    }
}