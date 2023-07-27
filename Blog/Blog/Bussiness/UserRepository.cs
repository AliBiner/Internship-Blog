using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Blog.Bussiness.DtoConverter;
using Blog.Key;
using Blog.Models.Context;
using Blog.Models.Dtos;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Bussiness
{
    public class UserRepository: IUserRepository
    {
        BlogContext blogContext = new BlogContext();
        public User LoginControl(LoginDto modelDto)
        {
            var model = blogContext.Users.Where(x => x.Email == modelDto.Email).FirstOrDefault();
            var passHashDecrypt = Methods.Decrypt(model.PasswordHash, Keys.AesKey());
            if (passHashDecrypt!=modelDto.Password)
                return null;

            return model;
        }

        public Boolean Add(RegisterDto modelDto)
        {
            if (modelDto==null)
            {
                return false;
            }
            else
            {

                modelDto.Id= Guid.NewGuid();
                modelDto.PasswordHash = Methods.Encrypt(modelDto.PasswordHash,Keys.AesKey());
                modelDto.CreateDate = DateTime.Now;
                var user = DtoConverter.DtoConverter.RegisterToUserConverter(modelDto);
                blogContext.Users.Add(user);
                blogContext.SaveChanges();
                return true;
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