using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI.WebControls;
using Blog.Bussiness.DtoConverter;
using Blog.Bussiness.Methods;
using Blog.Layers.Bussiness.DtoMappers;
using Blog.Models.Context;
using Blog.Models.Dtos;
using Blog.Models.User;
using Blog.Repository;

namespace Blog.Bussiness
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

        public List<User> GetAll()
        {
            return _dbSet.ToList();
        }

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
    }
}