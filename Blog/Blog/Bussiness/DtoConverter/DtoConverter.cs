using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Bussiness.DtoConverter
{
    public class DtoConverter
    {
        public static User RegisterToUserConverter(RegisterDto model)
        {
            User user = new User();

            user.Id = model.Id;
            user.Name = model.Name;
            user.MiddleName = model.MiddleName;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.PasswordHash = model.PasswordHash;
            user.CreateDate = model.CreateDate;
            user.Role = "User";
            return user;
        }
    }
}