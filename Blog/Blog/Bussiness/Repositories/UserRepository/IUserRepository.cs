using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Repository
{
    public interface IUserRepository
    {
        public void Update(User entity);
        public void Remove(User entity);
    }
}