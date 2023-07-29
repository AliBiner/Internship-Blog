using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Layers.Bussiness.DtoMappers;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Bussiness.DtoConverter
{
    public class UserMapper : IUserMapper
    {
        public User RegisterDtoToUser(RegisterDto model)
        {
            User user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                MiddleName = model.MiddleName,
                Surname = model.Surname,
                Email = model.Email,
                Phone = model.Phone,
                PasswordHash = model.PasswordHash,
                CreateDate = model.CreateDate,
                Role = "User"
            };

            
            return user;
        }

        public UserDto ToUserDto(User model)
        {
            UserDto ud = new UserDto()
            {
                Email = model.Email,
                Role = model.Role,
                Phone = model.Phone,
                CreateDate = model.CreateDate,
                Id = model.Id,
                FullName = model.Name + " " + model.MiddleName + " " + model.Surname,
                Name = model.Name,
                MiddleName = model.MiddleName,
                Surname = model.Surname
        };

            
            return ud;
        }
    }
}