using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Bussiness.Repositories.Login_Repository
{
    public interface IAccountRepository
    {
        string Register(RegisterDto model);
        User LogIn(LoginDto model);
        void LogOut();
        void SetSession(User entity);
    }
}
