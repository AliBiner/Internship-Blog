using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Blog.Bussiness.DtoConverter;
using Blog.Bussiness.Methods;
using Blog.Models.Context;
using Blog.Models.Dtos;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Bussiness
{
    public class UserRepository: IUserRepository
    {
        private readonly BlogContext _blogContext;

        public UserRepository()
        {
            _blogContext = new BlogContext();
        }
        
        public string Add(RegisterDto modelDto)
        {
            if (modelDto==null)
            {
                return "Model Boş";
            }
            else
            {
                var emailControl = _blogContext.Users.Any(x => x.Email == modelDto.Email || x.Phone==modelDto.Phone);
                if (emailControl==true)
                {
                    return "Bu Email veya Telefon Zaten Kullanılmaktadır.";
                }
                else
                {
                    modelDto.Id = Guid.NewGuid();
                    modelDto.PasswordHash = Crypts.Encrypt(modelDto.PasswordHash);
                    modelDto.CreateDate = DateTime.Now;
                    var user = DtoConverter.DtoConverter.RegisterToUserConverter(modelDto);
                    _blogContext.Users.Add(user);
                    _blogContext.SaveChanges();
                    return "Kayıt İşlemi Başarılı.";
                }
                
            }
            
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}