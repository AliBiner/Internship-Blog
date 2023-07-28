using System;
using Blog.Models.Context;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Bussiness
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _blogContext;

        public UserRepository()
        {
            _blogContext = new BlogContext();
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