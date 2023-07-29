using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Repository
{
    public interface IUserRepository
    {
        public UserDto GetByEmail(string email);
        public string UpdatePassword(string currentPassword,string newPassword, string email);
        public string UpdateUser(UserDto model,string sessionEmail);
        public void Remove(User entity);
    }
}