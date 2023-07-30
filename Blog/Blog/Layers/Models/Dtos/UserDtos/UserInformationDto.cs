
using System.ComponentModel.DataAnnotations;


namespace Blog.Layers.Models.Dtos
{
    public class UserInformationDto: BaseDto
    {
        
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Name { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Surname { get; set; }

        public string? ProfileDescription { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MaxLength(15,ErrorMessage = "Max. 15 Hane Olmalıdır.")]
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}