
using System;
using System.Collections.Generic;

using Blog.Models.Entities;


namespace Blog.Layers.Repositories
{
    public interface IUserRepository
    {
        public User GetByEmail(string email);
        public List<User> GetAll();
        public void Remove(User entity);
        public void Add(User entity);
        public void Update(User entity);
        public User GetById(Guid id);

        public bool ControlByEmailAndPhone(string email, string phone);
        //public string UpdatePassword(string currentPassword,string newPassword, string email);
        //public string UpdateUser(UserInformationDto model,string sessionEmail);

    }
}