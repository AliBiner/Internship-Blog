﻿
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Blog.Bussiness.Methods;
using Blog.Layers.Bussiness.DtoMappers;
using Blog.Layers.Models.Dtos;
using Blog.Layers.Models.Dtos.UserDtos;
using Blog.Layers.Repositories;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.Services.EntryService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public List<AllUserForAccountManage> GetAllUserForAccountManage()
        {
            throw new NotImplementedException();
        }

        //public List<AllUserForAccountManage> GetAllUserForAccountManage()
        //{
        //    var users = _userRepository.GetAll();
        //    var model = _userMapper.toAllUserForAccountManage(users);
        //    return 
        //}

        public UserInformationDto GetUserByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            var model = _userMapper.ForUserInformationPageDto(user);
            return model;
        }

        public string Login(LoginDto d)
        {
            var user = _userRepository.GetByEmail(d.Email);
            if (user==null)
            {
                return "Böyle Bir Kullanıcı Bulunmamaktır.";
            }
            var passDecrypt = Crypts.Decrypt(user.PasswordHash);
            if (passDecrypt != d.Password)
            {
                return "Hatalı Bir Şifre Giriniz.";
            }
            else
            {
                SetSession(user);
                return null;
            }
        }

        public void Logout()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }

        public string Signin(SigninDto d)
        {
            var control = _userRepository.ControlByEmailAndPhone(d.Email,d.Phone);
            if (control == true)
            {
                return "Bu Email veya Telefon Numarası Zaten Kullanılmaktadır.";
            }
            else
            {
                try
                {
                    var user = _userMapper.SigninDtoToUser(d);
                    _userRepository.Add(user);
                    return "İşlem Başarılı";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "İşlem Hatası";
                }

            }
        }

        public string Update(UpdateUserInformationDto dto, string email)
        {
            if (email== null)
            {
                return "Yeniden Giriş Yapmanız Gerekiyor.";
            }
            else
            {
                var user = _userRepository.GetByEmail(email);
                if (user == null)
                {
                    return "Böyle Bir Kullanıcı Bulunmamaktadır.";
                }
                else
                {
                    try
                    {
                        var dtoToUser = _userMapper.ForUpdateUserInformationPageDtoTo(dto, user);
                        _userRepository.Update(dtoToUser);
                        return "İşlem Başarılı";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return "İşlem Başarısız";
                    }
                    
                }
                
            }
           
        }

        public string UpdatePasswordByEmail(UpdatePasswordDto dto, string email)
        {
            if (email == null)
            {
                return "Yeniden Giriş Yapmanız Gerekiyor.";
            }
            else
            {
                var user = _userRepository.GetByEmail(email);
                if (user == null)
                {
                    return "Böyle Bir Kullanıcı Bulunmamaktadır.";
                }

                var passDecrypt = Crypts.Decrypt(user.PasswordHash);
                if (passDecrypt != dto.CurrentPassword)
                {
                    return "Mevcut Şifre Uyuşmuyor.";
                }
                else
                {
                    try
                    {
                        var passEncrypt = Crypts.Encrypt(dto.NewPassword);
                        user.PasswordHash = passEncrypt;
                        _userRepository.Update(user);
                        return "İşlem Başarılı";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return "İşlem Başarısız";
                    }
                    
                }
            }
            
        }

        private void SetSession(User entity)
        {
            FormsAuthentication.SetAuthCookie(entity.MiddleName, false);
            HttpContext.Current.Session["Name"] = entity.Name;
            HttpContext.Current.Session["Surname"] = entity.Surname;
            HttpContext.Current.Session["Email"] = entity.Email;
            HttpContext.Current.Session["Id"] = entity.Id;
            HttpContext.Current.Session["Role"] = entity.Role;
        }
    }
}