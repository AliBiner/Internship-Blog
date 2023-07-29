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
        public User GetByEmail(string email);
        public List<User> GetAll();
        public void Remove(User entity);
        public void Add(User entity);
        public void Update(User entity);

        public bool ControlByEmailAndPhone(string email, string phone);
        //public string UpdatePassword(string currentPassword,string newPassword, string email);
        //public string UpdateUser(UserInformationDto model,string sessionEmail);

    }
}