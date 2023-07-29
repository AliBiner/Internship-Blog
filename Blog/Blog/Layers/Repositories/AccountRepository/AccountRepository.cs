using Blog.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Blog.Bussiness.Methods;
using Blog.Layers.Bussiness.DtoMappers;
using Blog.Models.Context;
using Blog.Models.User;

namespace Blog.Bussiness.Repositories.Login_Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BlogContext _blogContext;
        private readonly IUserMapper _userMapper;

        public AccountRepository(BlogContext blogContext, IUserMapper userMapper)
        {
            _blogContext = blogContext;
            _userMapper = userMapper;
        }

        public User LogIn(LoginDto model)
        {
            var userModel = _blogContext.Users.FirstOrDefault(x => x.Email == model.Email);
            var passHashDecrypt = Crypts.Decrypt(userModel.PasswordHash);
            if (passHashDecrypt != model.Password)
                return null;

            return userModel;
        }
        [CustomActionFilter]
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
                    var user = _userMapper.RegisterDtoToUser(model);
                    _blogContext.Users.Add(user);
                    _blogContext.SaveChanges();
                    return "Kayıt İşlemi Başarılı.";
                }

            }
        }
        [CustomActionFilter]
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