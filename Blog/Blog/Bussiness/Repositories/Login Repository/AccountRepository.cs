using Blog.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blog.Bussiness.Methods;
using Blog.Models.Context;
using Blog.Models.User;

namespace Blog.Bussiness.Repositories.Login_Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BlogContext _blogContext;

        public AccountRepository()
        {
            _blogContext = new BlogContext();
        }

        public User LogIn(LoginDto model)
        {

            var userModel = _blogContext.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            var passHashDecrypt = Crypts.Decrypt(userModel.PasswordHash);
            if (passHashDecrypt != model.Password)
                return null;

            return userModel;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }

        public void SetCookies(User entity)
        {
            FormsAuthentication.SetAuthCookie(entity.MiddleName, false);
            
            HttpContext.Current.Session["Name"] = entity.Name;
            HttpContext.Current.Session["Surname"] = entity.Surname;
            HttpContext.Current.Session["Email"] = entity.Email;
            HttpContext.Current.Session["Id"] = entity.Id;
            HttpContext.Current.Session["Role"] = entity.Role;
        }

        public void SetSession(User entity)
        {
            throw new NotImplementedException();
        }
    }
}