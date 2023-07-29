using System;
using System.Linq;
using System.Web.UI.WebControls;
using Blog.Bussiness.Methods;
using Blog.Models.Context;
using Blog.Models.Dtos;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Bussiness
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _blogContext;

        public UserRepository()
        {
            _blogContext = new BlogContext();
        }

        public string UpdatePassword(string currentPassword, string newPassword, string email)
        {
            var user = _blogContext.Users.FirstOrDefault(x => x.Email == email);

            var passDecrypt = Crypts.Decrypt(user.PasswordHash);
            if (passDecrypt!= currentPassword)
            {
                return "Mevcut Şifre Uyuşmuyor";
            }
            else
            {
                user.PasswordHash = Crypts.Encrypt(newPassword);
                try
                {
                    _blogContext.SaveChanges();
                    return "İşlem Başarılı";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "İşlem Hatası!";
                }
            }
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public UserDto GetByEmail(string email)
        {
            var userModel = _blogContext.Users.FirstOrDefault(x => x.Email == email);
            var model = DtoConverter.UserMapper.ConverterUserToUserDto(userModel);
            return model;
        }

        public string UpdateUser(UserDto model,string sessionEmail)
        {
            var user = _blogContext.Users.FirstOrDefault(x => x.Email == sessionEmail);
            user.Email = model.Email;
            user.Name = model.Name;
            user.MiddleName = model.MiddleName;
            user.Surname = model.Surname;
            user.Phone = model.Phone;
            user.UpdateDate = DateTime.Now;
            try
            {
                _blogContext.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Hata!";
            }
        }
    }
}