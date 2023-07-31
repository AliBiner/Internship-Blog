
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;

using Blog.Layers.Bussiness;
using Blog.Layers.Models.Dtos.UserDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _blogContext;
        private readonly DbSet<User> _dbSet;
        public UserRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
            _dbSet = _blogContext.Set<User>();
        }
        public User GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email);
        }

        public User GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        //public List<AllUserForAccountManage> GetAll()
        //{
        //    var query
        //    return _dbSet.ToList();
        //}

        public void Remove(User entity)
        {
            _dbSet.Remove(entity);
            _blogContext.SaveChanges();
        }

        public void Add(User entity)
        {
            _blogContext.Users.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _blogContext.SaveChanges();

        }

        public bool ControlByEmailAndPhone(string email, string phone)
        {
           return _dbSet.Any(x => x.Email == email || x.Phone == phone);
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}