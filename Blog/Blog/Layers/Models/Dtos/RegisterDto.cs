using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models.Dtos
{
    public class RegisterDto : BaseDto
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.")]
        public string Name { get; set; }


        public string? MiddleName { get; set; }


        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz.")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Lütfen Emailinizi Giriniz.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Lütfen Telefon Numaranızı Giriniz.")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz.")]
        public string PasswordHash { get; set; }
    }
}