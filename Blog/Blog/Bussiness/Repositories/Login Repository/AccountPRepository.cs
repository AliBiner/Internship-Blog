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
    public class AccountPRepository : IAccountPRepository
    {
        private readonly BlogContext _blogContext;

        public AccountPRepository()
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
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
        public string Register(RegisterDto model)
        {
            if (model == null)
            {
                return "Model Boş";
            }
            else
            {
                var emailControl = _blogContext.Users.Any(x => x.Email == model.Email || x.Phone == model.Phone);
                if (emailControl == true)
                {
                    return "Bu Email veya Telefon Zaten Kullanılmaktadır.";
                }
                else
                {
                    model.Id = Guid.NewGuid();
                    model.PasswordHash = Crypts.Encrypt(model.PasswordHash);
                    model.CreateDate = DateTime.Now;
                    var user = DtoConverter.DtoConverter.RegisterToUserConverter(model);
                    _blogContext.Users.Add(user);
                    _blogContext.SaveChanges();
                    return "Kayıt İşlemi Başarılı.";
                }

            }
        }
        public void SetSession(User entity)
        {
            FormsAuthentication.SetAuthCookie(entity.MiddleName, false);
            HttpContext.Current.Session["Name"] = entity.Name;
            HttpContext.Current.Session["Surname"] = entity.Surname;
            HttpContext.Current.Session["Email"] = entity.Email;
            HttpContext.Current.Session["Id"] = entity.Id;
            HttpContext.Current.Session["Role"] = entity.Role;
        }
    }
}