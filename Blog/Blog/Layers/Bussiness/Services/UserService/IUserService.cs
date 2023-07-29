using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blog.Layers.Models.Dtos;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Layers.Bussiness.Services
{
    public interface IUserService
    {
        public string UpdatePasswordByEmail(UpdatePasswordDto dto, string email);
        public string Update(UpdateUserInformationDto dto , string email);
        public UserInformationDto GetUserByEmail(string email);
        public string Login(LoginDto d);

        public void Logout();

        public string Signin(SigninDto d);


    }
}
