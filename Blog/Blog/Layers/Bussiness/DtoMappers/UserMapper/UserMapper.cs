using System;
using Blog.Bussiness.Methods;
using Blog.Layers.Models.Dtos;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.DtoMappers
{
    public class UserMapper : IUserMapper
    {
        public User SigninDtoToUser(SigninDto model)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                MiddleName = model.MiddleName,
                Surname = model.Surname,
                Email = model.Email,
                Phone = model.Phone,
                PasswordHash = Crypts.Encrypt(model.PasswordHash),
                CreateDate = DateTime.Now,
                Role = "User"
            };

            
            
        }

        public UserInformationDto ForUserInformationPageDto(User model)
        {
            return new UserInformationDto()
            {
                Email = model.Email,
                Role = model.Role,
                Phone = model.Phone,
                CreateDate = model.CreateDate,
                Id = model.Id,
                FullName = model.Name + " " + model.MiddleName + " " + model.Surname,
                Name = model.Name,
                MiddleName = model.MiddleName,
                Surname = model.Surname,
                ProfileDescription = model.ProfileDescription
            };

            
           
        }

        public User ForUpdateUserInformationPageDtoTo(UpdateUserInformationDto d,User u)
        {
            u.Email = d.Email;
            u.Name = d.Name;
            u.MiddleName = d.MiddleName;
            u.Surname = d.Surname;
            u.Phone = d.Phone;
            u.ProfileDescription = d.ProfileDescription;
            u.UpdateDate = DateTime.Now;
            return u;
        }
    }
}